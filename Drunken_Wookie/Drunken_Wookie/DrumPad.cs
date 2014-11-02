using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Drunken_Wookie
{
    public enum PadNames
    {
        Bass = Buttons.LeftShoulder,
    }

    class DrumPad
    {
        private GamePadState padState;
        private GamePadState prevPadState;

        private PlayerIndex playerIndex;

        public GamePadState PadState
        {
            get { return padState; }
            set { padState = value; }
        }
        public GamePadState PrevPadState
        {
            get { return prevPadState; }
            set { prevPadState = value; }
        }

        public DrumPad(PlayerIndex _playerIndex)
        {
            playerIndex = _playerIndex;
        }

        public void Update()
        {
            prevPadState = padState;
            padState = GamePad.GetState(playerIndex);
        }

        #region Drumpad Specifics

        public bool IsPressed(PadNames padName)
        {
            return padState.IsButtonDown((Buttons)padName);
        }

        public bool IsJustReleased(PadNames padName)
        {
            return padState.IsButtonDown((Buttons)padName) && prevPadState.IsButtonUp((Buttons)padName);
        }
        public bool IsReleased(PadNames padName)
        {
            return padState.IsButtonUp((Buttons)padName);
        }
        #endregion

    }
}
