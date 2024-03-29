﻿using System.Drawing;
using System.Runtime.Serialization;

namespace AppLayer.DrawingComponents
{
    /// <summary>
    /// This class plays a role in two different patterns: a Flyweight and a Decorator.  For the Flyweight, this
    /// class represent a "whole" emote that combines both intrinsic state part and the extrinsic state part.
    /// Objects of this class only need to exist for short period time, like a drawing session.
    /// 
    /// For the decorator pattern, this class is a Decorator.  It add the extrinsic state to EmoteWithIntrinsic State objects
    /// DECORATOR PATTERN AND FLYWEIGHT PATTERN
    /// </summary>
    [DataContract]
    public class EmoteWithAllState : Emote
    {
        public Pen OutlinePen { get; set; } = new Pen(Color.DarkGray);
        internal EmoteWithIntrinsicState IntrinsicState { get; }

        [DataMember]
        public EmoteExtrinsicState ExtrinsicState { get; set; }

        internal EmoteWithAllState(EmoteWithIntrinsicState sharedPart, EmoteExtrinsicState nonsharedPart)
        {
            IntrinsicState = sharedPart;                // From a decorator perspective, this is the decorated object
            ExtrinsicState = nonsharedPart;            // From a decorator perspective, this is the added feature or
                                                        // capability that this object (a decorator) is adding
        }

        public override bool IsSelected {
            get { return ExtrinsicState?.IsSelected ?? false;  }
            set { if (ExtrinsicState!=null) ExtrinsicState.IsSelected = value;  }
        }

        public override Point Location
        {
            get { return ExtrinsicState?.Location ?? new Point(0,0) ; }
            set { if (ExtrinsicState != null) ExtrinsicState.Location = value; }
        }


        public override Size Size
        {
            get { return ExtrinsicState?.Size ?? new Size(0,0); }
            set { if (ExtrinsicState != null) ExtrinsicState.Size = value; }
        }

        public override Element Clone()
        {
            return new EmoteWithAllState(IntrinsicState, ExtrinsicState = ExtrinsicState.Clone());
        }

        public override void Draw(Graphics graphics)
        {
            if (graphics == null || IntrinsicState?.Image == null) return;

            graphics.DrawImage(IntrinsicState.Image,
                new Rectangle(ExtrinsicState.Location.X, ExtrinsicState.Location.Y, ExtrinsicState.Size.Width,
                    ExtrinsicState.Size.Height),
                0, 0, IntrinsicState.Image.Width, IntrinsicState.Image.Height,
                GraphicsUnit.Pixel);

            if (!ExtrinsicState.IsSelected) return;
            var g = new GraphicsWithSelection() {MyGraphics = graphics};
            g.DrawSelectionBox(ExtrinsicState.Location, ExtrinsicState.Size);
        }

        public override bool ContainsPoint(Point point)
        {
            return point.X >= Location.X && point.Y >= Location.Y &&
                   point.X <= Location.X + Size.Width &&
                   point.Y <= Location.Y + Size.Height;
        }

    }

}
