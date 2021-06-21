using ImpHunter2021.GameObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImpHunter2021.GameStates
{
    class PlayingState : GameObjectList
    {
        Crosshair ch;
        public PlayingState()
        {
            Add(new SpriteGameObject("spr_background"));
            Add(ch = new Crosshair());
        }
    }
}
