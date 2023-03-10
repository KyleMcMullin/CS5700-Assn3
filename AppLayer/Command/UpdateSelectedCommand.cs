using AppLayer.DrawingComponents;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLayer.Command
{
    
    public class UpdateSelectedCommand : Command
    {
        private Point _location;
        private Point _oldLocation;
        //private List<Element> _movedElements;
        private List<Tuple<Point, Element>> _movedElements;

        internal UpdateSelectedCommand(params object[] commandParameters)
        {
            if (commandParameters.Length > 0)
            {
                _location = (Point) commandParameters[0];
            }
            else
            {
                _location = new Point(0, 0);
            }
        }
        public override bool Execute()
        {
            if (TargetDrawing == null) return false;
            _movedElements = TargetDrawing?.MoveAllSelected(_location);
            //_oldLocation = TargetDrawing.SelectedLocation;
            //TargetDrawing.SelectedLocation = _location;
            return true;
        }

        internal override void Redo()
        {
            if (_movedElements == null || _movedElements.Count == 0) return;
            _movedElements = TargetDrawing?.MoveElementsBack(_movedElements);
            //foreach (var tup in _movedElements)
            //{
            //    if (tup.Item2.GetType() == typeof(Emote))
            //    {
            //        var emote = (Emote)tup.Item2;
            //        emote.Location = tup.Item1;                    
            //    }
            //}
            //TargetDrawing.SelectedLocation = _location;
        }

        internal override void Undo()
        {
            if (_movedElements == null || _movedElements.Count == 0) return;
            _movedElements = TargetDrawing?.MoveElementsBack(_movedElements);
            //foreach (var tup in _movedElements)
            //{
            //    if (tup.Item2.GetType() == typeof(Emote))
            //    {
            //        var emote = (Emote)tup.Item2;
            //        emote.Location = tup.Item1;
            //    }
            //}
            //TargetDrawing.SelectedLocation = _oldLocation;
        }
    }
}
