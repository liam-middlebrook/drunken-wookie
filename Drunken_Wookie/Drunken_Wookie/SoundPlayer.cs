using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drunken_Wookie
{

 
    class SoundPlayer
    {
        public enum SoundType
        {
            Wookie,
            Laser,
            Uke
        };

        private Dictionary<SoundType, List<SoundEffect>> sounds = new Dictionary<SoundType, List<SoundEffect>>();

        public void LoadSounds(ContentManager Content) {
            List<SoundEffect> wookieSounds = new List<SoundEffect>();
            wookieSounds.Add(Content.Load<SoundEffect>("foo"));
            sounds.Add(SoundType.Wookie, wookieSounds);

            // etc.
        }

        public void playSound(SoundType soundType)
        {
            Random rand = new Random();
            sounds[soundType][rand.Next(0, sounds[soundType].Count)].Play();
        }

    }
}
