using System;
using System.Collections.Generic;
using System.Text;

namespace ImpHunter2021.GameStates
{
    class PlayingState : GameObjectList
    {
        public PlayingState()
        {
            Add(new SpriteGameObject("spr_background"));
        }
    }
}
