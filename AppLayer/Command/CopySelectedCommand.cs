using AppLayer.DrawingComponents;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AppLayer.Command
{
    public class CopySelectedCommand : Command
    {
        private List<Element> _addedElements;
        public CopySelectedCommand()
        {
        }
        public override bool Execute()
        {
            if (TargetDrawing == null) return false;
            _addedElements = new List<Element>();
            var tempList = TargetDrawing.DeselectAll();
            foreach (var element in tempList)
            {
                var emote = element as EmoteWithAllState;
                if (emote == null) continue;
                var emoteSize = new Size(emote.Size.Width, emote.Size.Height);
                var emoteLocation = new Point(emote.Location.X + 5, emote.Location.Y - 5);
                var extrinsicState = new EmoteExtrinsicState()
                {
                    EmoteType = emote.ExtrinsicState.EmoteType,
                    Location = emoteLocation,
                    Size = emoteSize
                };
                var _emoteAdded = EmoteFactory.Instance.GetEmote(extrinsicState);
                _addedElements.Add(_emoteAdded);
                TargetDrawing.Copy(_emoteAdded);
            }
            return true;
        }

        internal override void Redo()
        {
            if (_addedElements == null || _addedElements.Count == 0) return;
            foreach (var element in _addedElements)
            {
                TargetDrawing?.Add(element);
            }
        }

        internal override void Undo()
        {
            if (_addedElements == null || _addedElements.Count == 0) return;
            foreach (var element in _addedElements)
            {
                TargetDrawing?.DeleteElement(element);
            }
        }
    }
}
