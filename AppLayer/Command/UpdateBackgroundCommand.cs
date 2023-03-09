using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLayer.Command
{
    public class UpdateBackgroundCommand : Command
    {
        private int _color;
        private int _oldColor; 
        internal UpdateBackgroundCommand() { }
        internal UpdateBackgroundCommand(params object[] commandParameters)
        {
            if (commandParameters.Length > 0)
            {               
                _color = Convert.ToInt32(commandParameters[0]);
            }
        }
        public override bool Execute()
        {
            if (_color == 0 || TargetDrawing == null) return false;

            _oldColor = TargetDrawing.GetCurrentColor();
            var color = Color.FromArgb(_color);
            TargetDrawing.ChangeBackground(_color);
            return true;
        }

        internal override void Redo()
        {
            TargetDrawing.ChangeBackground(_color);
        }

        internal override void Undo()
        {
            TargetDrawing.ChangeBackground(_oldColor);
        }
    }
}
