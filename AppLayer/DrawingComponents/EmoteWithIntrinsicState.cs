﻿using System;
using System.Drawing;
using System.Reflection;

namespace AppLayer.DrawingComponents
{
    /// <summary>
    /// This is class is part of two patterns: Flyweight and Decorator.  For the Flyweight Pattern it is a concrete flyweight
    /// that defines the intrinsic state (shared state).  For the Decorator pattern is a concrete components, i.e., something that can
    /// be decorated.
    /// 
    /// Note that this class is tagged as "internal", which means only components in the AppLayer can acces it.  This helps encapsulate the idea
    /// in the AppLayer and prevent misuse by components in other layers.
    /// 
    /// DECORATOR PATTERN AND FLYWEIGHT PATTERN
    /// </summary>
    internal class EmoteWithIntrinsicState : Emote
    {
        public static Color SelectionBackgroundColor { get; set; } = Color.DarkKhaki;
        public string EmoteType { get; set; }
        public Bitmap Image { get; private set; }
        public Bitmap ToolImage { get; private set; }
        public Bitmap ToolImageSelected { get; private set; }

        public override Element Clone()
        {
            return this;        // Don't really clone
        }

        public void LoadFromResource(string emoteType, Type referenceTypeForAssembly)
        {
            if (string.IsNullOrWhiteSpace(emoteType)) return;

            var assembly = Assembly.GetAssembly(referenceTypeForAssembly);

            if (assembly == null) return;

            using (var stream = assembly.GetManifestResourceStream(emoteType))
            {
                if (stream == null) return;
                Image = new Bitmap(stream);
                ToolImage = new Bitmap(Image, ToolSize);
                ToolImageSelected = new Bitmap(ToolSize.Width, ToolSize.Height);

                var g = Graphics.FromImage(ToolImageSelected);
                g.Clear(SelectionBackgroundColor);
                g.DrawImage(ToolImage, new Point() {X=0, Y = 0});
            }
        }

        public override bool IsSelected
        {
            get { return false; }
            set
            {
                throw new ApplicationException("Cannot select a emote with only intrinsic state - the intrinsic state is immutable");
            }
        }


        public override Point Location
        {
            get { return new Point(); }
            set
            {
                throw new ApplicationException("Cannot change a emote with only intrinsic state - the intrinsic state is immutable");
            }
        }

        public override Size Size
        {
            get { return new Size(); }
            set
            {
                throw new ApplicationException("Cannot change a emote with only intrinsic state - the intrinsic state is immutable");
            }
        }

        public override void Draw(Graphics graphics)
        {
            throw new ApplicationException("Cannot draw a emote with only intrinsic state");
        }
    }
}
