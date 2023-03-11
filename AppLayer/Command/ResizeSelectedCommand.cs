using AppLayer.DrawingComponents;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLayer.Command
{
    public class ResizeSelectedCommand : Command
    {
        private const int NormalWidth = 80;
        private const int NormalHeight = 80;
        
        private List<Tuple<Size, Element>> _resizedElements;
        private Size _newSize;

        internal ResizeSelectedCommand() { }

        internal ResizeSelectedCommand(params object[] commandParameters)
        {
            float _scale = 1.0F;
            if (commandParameters.Length >0)
            {
                _scale = (float)commandParameters[0];
            }

            _newSize = new Size()
            {
                Width = Convert.ToInt16(Math.Round(NormalWidth * _scale, 0)),
                Height = Convert.ToInt16(Math.Round(NormalHeight * _scale, 0))
            };
        }

        public override bool Execute()
        {
            _resizedElements = TargetDrawing?.ResizeAllSelected(_newSize);
            return _resizedElements != null && _resizedElements.Count > 0;
        }

        internal override void Undo()
        {
            if (_resizedElements == null || _resizedElements.Count == 0) return;
            _resizedElements = TargetDrawing?.ResizeElementsBack(_resizedElements);

            //foreach (var element in _resizedElements)
            //    TargetDrawing?.Add(element);
        }

        internal override void Redo()
        {
            if (_resizedElements == null || _resizedElements.Count == 0) return;
            _resizedElements = TargetDrawing?.ResizeElementsBack(_resizedElements);
        }
    }
}
