using System;
using System.Collections.Generic;
using System.Text;

namespace ImpHunter2021.GameStates
{
    class GameOverState : GameObjectList
    {
        public GameOverState()
        {
            Add(new SpriteGameObject("spr_gameover"));
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            if (inputHelper.AnyKeyPressed)
            {
                GameEnvironment.GameStateManager.SwitchTo("playingState");
            }
        }
    }
}
