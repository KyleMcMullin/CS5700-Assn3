using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;

namespace AppLayer.DrawingComponents
{
    // NOTE: This class at least one  problem that is hurting coupling and cohesion

    public class Drawing
    {
        private static readonly DataContractJsonSerializer JsonSerializer =
                new DataContractJsonSerializer(typeof(List<Object>), new[] { typeof(Element), typeof(Emote), typeof(EmoteWithAllState), typeof(EmoteExtrinsicState), typeof(LabeledBox), typeof(Line), typeof(Background) });

        private readonly List<Element> _elements = new List<Element>();
        private readonly object _myLock = new object();

        private int _color { get; set; } = -1;
        public bool IsDirty { get; set; } = true;

        public List<Element> GetCloneOfElements()
        {
            var cloneList = new List<Element>();
            lock (_myLock)
            {
                cloneList.AddRange(_elements.Select(element => element.Clone()));
            }

            return cloneList;           
        }

        public void Clear()
        {
            lock (_myLock)
            {
                _elements.Clear();
                _color = -1;
                IsDirty = true;
            }
        }

        public void ChangeBackground(int color)
        {
            lock (_myLock)
            {
                _color = color;
                IsDirty = true;
            }    
        }
        
        public void LoadFromStream(Stream stream)
        {
            var loadedElements = JsonSerializer.ReadObject(stream) as List<Object>;
            var background = loadedElements[0] as Background;
            if (background != null)
            {
                _color = background.Color; // could change this to a background object
            }

            loadedElements = loadedElements.GetRange(1, loadedElements.Count - 1);

            if (loadedElements == null || loadedElements.Count == 0) return;

            lock (_myLock)
            {
                // Since only the extrinsic state is saved, recreate the full emote objects
                foreach (var element in loadedElements)
                {
                    var tmpElement = element as Element;
                    if (tmpElement == null) continue;
                    var tmpEmote = element as EmoteWithAllState;
                    if (tmpEmote != null)
                    {
                        Emote fullEmote = EmoteFactory.Instance.GetEmote(tmpEmote.ExtrinsicState);
                        _elements.Add(fullEmote);
                    }
                    else 
                    {
                        _elements.Add(tmpElement);
                    }
                }
                IsDirty = true;
            }
        }

        public void SaveToStream(Stream stream)
        {
            lock (_myLock)
            {
                var objects = new List<Object>() { new Background(_color) };
                objects.AddRange(_elements);
                JsonSerializer.WriteObject(stream, objects);
            }
        }

        public void Export(string fileName, Bitmap bitmap)
        {
            try
            {
                Graphics graphics = Graphics.FromImage(bitmap);
                var write = Draw(graphics, true);
                if (write)
                {
                    bitmap.Save(fileName);
                }
            }
            catch (Exception)
            {

            }
        }

        public void Add(Element element)
        {
            if (element == null) return;

            lock (_myLock)
            {
                _elements.Add(element);
                IsDirty = true;
            }
        }

        public List<Element> DeleteAllSelected()
        {
            List<Element> elementsToDelete;
            lock (_myLock)
            {
                elementsToDelete = _elements.FindAll(t => t.IsSelected);
                _elements.RemoveAll(t => t.IsSelected);
                IsDirty = true;
            }

            return elementsToDelete;
        }

        public List<Tuple<Size, Element>> ResizeAllSelected(Size size)
        {
            List<Tuple<Size, Element>> elementsToResize = new List<Tuple<Size, Element>>();
            
            lock (_myLock)
            {
                var tempElements = _elements.FindAll(t => t.IsSelected);
                foreach (var t in _elements.Where(t => t.IsSelected))
                {
                    if (t.GetType() == typeof(EmoteWithAllState))
                    {
                        var emote = (EmoteWithAllState)t;
                        elementsToResize.Add(new Tuple<Size, Element>(emote.Size, emote));
                        emote.Size = size;
                    }
                }
                IsDirty = true;
                DeselectAll();
            }
            return elementsToResize;
        }

        public List<Tuple<Size, Element>> ResizeElementsBack(List<Tuple<Size, Element>> elements)
        {
            List<Tuple<Size, Element>> elementsToResize = new List<Tuple<Size, Element>>();
            lock (_myLock)
            {
                elements.ForEach(t =>
                {
                    if (t.Item2.GetType() == typeof(EmoteWithAllState))
                    {
                        var emote = (EmoteWithAllState)t.Item2;
                        elementsToResize.Add(new Tuple<Size, Element>(emote.Size, emote));
                        emote.Size = t.Item1;
                    }
                });
                IsDirty = true;
            }
            return elementsToResize;
        }

        public int GetCurrentColor()
        {
            return _color;
        }

        public void DeleteElement(Element element)
        {
            lock (_myLock)
            {
                _elements.Remove(element);
                IsDirty = true;
            }
        }

        public List<Tuple<Point, Element>> MoveAllSelected(Point location)
        {
            List<Tuple<Point, Element>> elementsToMove;
            lock (_myLock)
            {
                //_elements[_elements.IndexOf(element)] = element
                elementsToMove = new List<Tuple<Point, Element>>();
                foreach (var t in _elements.Where(t => t.IsSelected))
                {
                    if (t.GetType() == typeof(EmoteWithAllState))
                    {
                        var emote = (EmoteWithAllState)t;
                        elementsToMove.Add(new Tuple<Point, Element>(emote.Location, emote));
                        emote.Location = location;
                    }
                }
                IsDirty = true;
                DeselectAll();
            }
            return elementsToMove;
        }

        public List<Tuple<Point, Element>> MoveElementsBack(List<Tuple<Point, Element>> elementsToMove)
        {
            List<Tuple<Point, Element>> itemsToMove = new List<Tuple<Point, Element>>();
            lock (_myLock)
            {
                elementsToMove.ForEach(t =>
                {
                    if (t.Item2.GetType() == typeof(EmoteWithAllState))
                    {
                        var emote = (EmoteWithAllState)t.Item2;
                        itemsToMove.Add(new Tuple<Point, Element>(emote.Location, emote));
                        emote.Location = t.Item1;
                    }
                });
                IsDirty = true;
            }
            return itemsToMove;
        }

        public void Draw(Graphics graphics)
        {
            lock (_myLock)
            {
                if (_color != -1)
                {
                    graphics.Clear(Color.FromArgb(_color));
                }
                _elements.ForEach(t => t.Draw(graphics));
            }
        }
        
        public Element FindElementAtPosition(Point point)
        {
            Element result;
            lock (_myLock)
            {
                result = _elements.FindLast(t => t.ContainsPoint(point));
            }
            return result;
        }

        public List<Element> DeselectAll()
        {
            var selectedElements = new List<Element>();
            lock (_myLock)
            {
                foreach (var t in _elements.Where(t => t.IsSelected))
                {
                    selectedElements.Add(t);
                    t.IsSelected = false;
                }
                IsDirty = true;
            }
            return selectedElements;
        }

        public bool Draw(Graphics graphics, bool redrawEvenIfNotDirty = false)
        {
            lock (_myLock)
            {
                if (!IsDirty && !redrawEvenIfNotDirty) return false;
                
                graphics.Clear(Color.FromArgb(_color));
                foreach (var t in _elements)
                    t.Draw(graphics);
                IsDirty = false;
            }
            return true;
        }

    }
}
