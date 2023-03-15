using System.Drawing;
using System.Runtime.Serialization;

namespace AppLayer.DrawingComponents
{
    // DECORATOR
    [DataContract]
    public class EmoteExtrinsicState
    {
        [DataMember]
        public string EmoteType { get; set; }

        [DataMember]
        public Point Location { get; set; }

        [DataMember]
        public Size Size { get; set; }

        [DataMember]
        public bool IsSelected { get; set; }

        public EmoteExtrinsicState Clone()
        {
            return new EmoteExtrinsicState()
            {
                EmoteType = EmoteType,
                Location = Location,
                Size = Size,
                IsSelected = IsSelected
            };
        }
    }
}
