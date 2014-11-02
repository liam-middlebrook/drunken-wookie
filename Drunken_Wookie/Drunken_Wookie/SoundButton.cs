using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Drunken_Wookie
{
    class SoundButton
    {
        private Texture2D texture;
        private Vector2 position;
        private PadNames activationPad;

        public Texture2D Texture
        {
            get { return texture; }
            set { texture = value; }
        }

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public SoundButton(PadNames _activationPad)
        {
            activationPad = _activationPad;
        }

        public void Update(DrumPad drumPad)
        {
            if(drumPad.IsJustReleased(activationPad))
            {
                // Play my sound
            }
        }
        
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
