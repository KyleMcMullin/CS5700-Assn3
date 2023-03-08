using AppLayer.DrawingComponents;
using System;
using System.Drawing;

namespace AppLayer.Command
{
    public class AddEmoteCommand : Command
    {
        private const int NormalWidth = 80;
        private const int NormalHeight = 80;

        private readonly string _emoteType;
        private Point _location;
        private readonly float _scale;
        private Element _emoteAdded;
        internal AddEmoteCommand() { }

        /// <summary>
        /// Constructor
        /// 
        /// </summary>
        /// <param name="commandParameters">An array of parameters, where
        ///     [1]: string     emote type -- a fully qualified resource name
        ///     [2]: Point      center location for the emote, defaut = top left corner
        ///     [3]: float      scale factor</param>
        internal AddEmoteCommand(params object[] commandParameters)
        {
            if (commandParameters.Length>0)
                _emoteType = commandParameters[0] as string;

            if (commandParameters.Length > 1)
                _location = (Point) commandParameters[1];
            else
                _location = new Point(0, 0);

            if (commandParameters.Length > 2)
                _scale = (float) commandParameters[2];
            else
                _scale = 1.0F;
        }

        public override bool Execute()
        {
            if (string.IsNullOrWhiteSpace(_emoteType) || TargetDrawing==null) return false;

            var emoteSize = new Size()
            {
                Width = Convert.ToInt16(Math.Round(NormalWidth * _scale, 0)),
                Height = Convert.ToInt16(Math.Round(NormalHeight * _scale, 0))
            };
            var emoteLocation = new Point(_location.X - emoteSize.Width / 2, _location.Y - emoteSize.Height / 2);

            var extrinsicState = new EmoteExtrinsicState()
            {
                EmoteType = _emoteType,
                Location = emoteLocation,
                Size = emoteSize
            };
            _emoteAdded = EmoteFactory.Instance.GetEmote(extrinsicState);
            TargetDrawing.Add(_emoteAdded);

            return true;
        }

        internal override void Undo()
        {
            TargetDrawing.DeleteElement(_emoteAdded);
        }

        internal override void Redo()
        {
            TargetDrawing.Add(_emoteAdded);
        }
    }
}
