using ImpHunter2021.GameObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImpHunter2021.GameStates
{
    class PlayingState : GameObjectList
    {
        Crosshair ch;
        GameObjectList imps;
        int impAmount = 3;
        public PlayingState()
        {
            Add(new SpriteGameObject("spr_background"));
            Add(ch = new Crosshair());
            imps = new GameObjectList();
            for (int i = 0; i < impAmount; i++)
            {
                imps.Add(new Imps());
            }
            Add(imps);
        }
    }
}
