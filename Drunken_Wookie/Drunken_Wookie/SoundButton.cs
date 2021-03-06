﻿using System;
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
        private SoundPlayer.SoundType soundType;

        private bool isActivated;

        public SoundButton(PadNames _activationPad, SoundPlayer.SoundType _soundType, Texture2D _texture, Vector2 _position)
        {
            activationPad = _activationPad;
            soundType = _soundType;
            texture = _texture;
            position = _position;
        }

        public void Update(DrumPad drumPad, SoundPlayer soundPlayer)
        {
            if(drumPad.IsJustReleased(activationPad))
            {
                soundPlayer.playSound(soundType);
            }

            isActivated = drumPad.IsPressed(activationPad);
        }
        
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, isActivated ? Color.Red : Color.White);
        }
    }
}
