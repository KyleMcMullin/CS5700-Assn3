using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLayer.Command
{
    public class ExportCommand : Command
    {
        private readonly string _filename;
        private Bitmap _bitmap;
        internal ExportCommand(params object[] commandParameters)
        {
            if (commandParameters.Length > 0)
                _filename = commandParameters[0] as string;
            if (commandParameters.Length > 1)
                _bitmap = commandParameters[1] as Bitmap;
        }

        public override bool Execute()
        {
            //StreamWriter writer = new StreamWriter(_filename);
            TargetDrawing?.Export(_filename, _bitmap);
            //TargetDrawing?.SaveToStream(writer.BaseStream);
            //writer.Close();

            return true;
        }

        internal override void Undo()
        {
            // Do nothing -- we don't want to delete the saved file.
        }

        internal override void Redo()
        {
            Execute();
        }
    }
}
