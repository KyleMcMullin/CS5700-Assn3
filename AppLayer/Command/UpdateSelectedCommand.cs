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
            return _movedElements != null && _movedElements.Count > 0;
        }

        internal override void Redo()
        {
            if (_movedElements == null || _movedElements.Count == 0) return;
            _movedElements = TargetDrawing?.MoveElementsBack(_movedElements);
        }

        internal override void Undo()
        {
            if (_movedElements == null || _movedElements.Count == 0) return;
            _movedElements = TargetDrawing?.MoveElementsBack(_movedElements);
        }
    }
}
