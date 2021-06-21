using ImpHunter2021.GameObjects;
using Microsoft.Xna.Framework;
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
        GameObjectList guards;
        int guardAmount = 3;
        SpriteGameObject walls;
        public PlayingState()
        {
            Add(new SpriteGameObject("spr_background"));

            Add(walls = new SpriteGameObject("spr_towers"));

            Add(ch = new Crosshair());

            imps = new GameObjectList();
            for (int i = 0; i < impAmount; i++)
            {
                imps.Add(new Imps());
            }
            Add(imps);

            guards = new GameObjectList();
            for (int i = 0; i < guardAmount; i++)
            {
                guards.Add(new Guard(new Vector2(170 + 150 * i, 490)));
            }
            Add(guards);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            for (int i = guards.Children.Count - 1; i >= 0; i--)
            {
                Guard g = (guards.Children[i] as Guard);
                if (g.CollidesWith(walls))
                {
                    g.Bounce();
                }

                for (int x = guards.Children.Count - 1; x >= 0; x--)
                {
                    Guard og = (guards.Children[x] as Guard);
                    if (g.CollidesWith(og))
                    {
                        g.Bounce();
                    }
                }
            }
        }
    }
}
