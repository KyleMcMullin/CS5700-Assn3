using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AppLayer.DrawingComponents
{
    [DataContract]
    public class Background
    {
        [DataMember]
        public int Color { get; set; } = -1;
        
        public Background()
        { }
        public Background(int color)
        {
            Color = color;
        }
    }
}
