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
            Starwars,
            Laser,
            Music,
            R2D2
        };

        private Dictionary<SoundType, List<SoundEffect>> sounds = new Dictionary<SoundType, List<SoundEffect>>();

        public void LoadSounds(ContentManager Content) {
            List<SoundEffect> wookieSounds = new List<SoundEffect>();
            wookieSounds.Add(Content.Load<SoundEffect>("chewbacca_02"));
            wookieSounds.Add(Content.Load<SoundEffect>("chewbacca_03"));
            wookieSounds.Add(Content.Load<SoundEffect>("chewbacca_04"));
            wookieSounds.Add(Content.Load<SoundEffect>("chewbacca_05"));
            sounds.Add(SoundType.Wookie, wookieSounds);

            List<SoundEffect> starwarsSounds = new List<SoundEffect>();
            starwarsSounds.Add(Content.Load<SoundEffect>("forcestrong"));
            starwarsSounds.Add(Content.Load<SoundEffect>("leia_what"));
            starwarsSounds.Add(Content.Load<SoundEffect>("luke_badfeel"));
            starwarsSounds.Add(Content.Load<SoundEffect>("swvader02"));
            starwarsSounds.Add(Content.Load<SoundEffect>("WilHelmScream"));
            sounds.Add(SoundType.Starwars, starwarsSounds);

            List<SoundEffect> laserSounds = new List<SoundEffect>();
            laserSounds.Add(Content.Load<SoundEffect>("laser_02"));
            laserSounds.Add(Content.Load<SoundEffect>("laser_03"));
            laserSounds.Add(Content.Load<SoundEffect>("laser_04"));
            laserSounds.Add(Content.Load<SoundEffect>("laser_05"));
            laserSounds.Add(Content.Load<SoundEffect>("laser_06"));
            laserSounds.Add(Content.Load<SoundEffect>("laser_07"));
            laserSounds.Add(Content.Load<SoundEffect>("laser_08"));
            laserSounds.Add(Content.Load<SoundEffect>("laser_09"));
            laserSounds.Add(Content.Load<SoundEffect>("laser_10"));
            laserSounds.Add(Content.Load<SoundEffect>("laser_11"));
            sounds.Add(SoundType.Laser, laserSounds);

            List<SoundEffect> r2d2Sounds = new List<SoundEffect>();
            r2d2Sounds.Add(Content.Load<SoundEffect>("R2D2a"));
            r2d2Sounds.Add(Content.Load<SoundEffect>("R2D2b"));
            r2d2Sounds.Add(Content.Load<SoundEffect>("R2D2c"));
            r2d2Sounds.Add(Content.Load<SoundEffect>("R2D2d"));
            r2d2Sounds.Add(Content.Load<SoundEffect>("R2D2e"));
            r2d2Sounds.Add(Content.Load<SoundEffect>("R2D2f"));
            sounds.Add(SoundType.R2D2, r2d2Sounds);

            List<SoundEffect> musicSounds = new List<SoundEffect>();
            musicSounds.Add(Content.Load<SoundEffect>("tracktojamto"));
            musicSounds.Add(Content.Load<SoundEffect>("cantina"));
            sounds.Add(SoundType.Music, musicSounds);
            // etc.
        }

        public void playSound(SoundType soundType)
        {
            Random rand = new Random();
            sounds[soundType][rand.Next(0, sounds[soundType].Count)].Play();
        }

    }
}
