using System;
using System.Collections.Generic;

namespace AppLayer.DrawingComponents
{
    // SINGLETON PATTERN AND FACTORY PATTERN
    public class EmoteFactory
    {
        private static EmoteFactory _instance;
        private static readonly object MyLock = new object();

        private EmoteFactory() { }

        public static EmoteFactory Instance
        {
            get
            {
                lock (MyLock)
                {
                    if (_instance == null)
                        _instance = new EmoteFactory();
                }
                return _instance;
            }
        }

        public string ResourceNamePattern { get; set; }
        public Type ReferenceType { get; set; }

        private readonly Dictionary<string, EmoteWithIntrinsicState> _sharedEmotes = new Dictionary<string, EmoteWithIntrinsicState>();

        public EmoteWithAllState GetEmote(EmoteExtrinsicState extrinsicState)
        {
            EmoteWithIntrinsicState emoteWithIntrinsicState;
            if (_sharedEmotes.ContainsKey(extrinsicState.EmoteType))
                emoteWithIntrinsicState = _sharedEmotes[extrinsicState.EmoteType];
            else
            {
                emoteWithIntrinsicState = new EmoteWithIntrinsicState();
                var resourceName = string.Format(ResourceNamePattern, extrinsicState.EmoteType);
                emoteWithIntrinsicState.LoadFromResource(resourceName, ReferenceType);
                _sharedEmotes.Add(extrinsicState.EmoteType, emoteWithIntrinsicState);
            }

            return new EmoteWithAllState(emoteWithIntrinsicState, extrinsicState);
        }
    }
}
