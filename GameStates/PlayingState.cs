using ImpHunter2021.GameObjects;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        int[] guardPositionXYOffset = { 170, 490, 150 };
        SpriteGameObject walls;
        Score score;
        int escaped, maxEscaped = 3;
        public PlayingState()
        {
            Reset();
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

            foreach (Imps imp in imps.Children)
            {
                if (imp.LeaveTop())
                {
                    foreach (Guard g in guards.Children)
                    {
                        if (g.Position.Y == guardPositionXYOffset[1])
                        {
                            imp.Reset();
                            g.Fall();
                            escaped++;
                            return;
                        }
                    }
                }
            }

            if (escaped >= maxEscaped)
            {
                GameEnvironment.GameStateManager.SwitchTo("gameOverState");
                Reset();
            }
        }

        public override void Reset()
        {
            base.Reset();
            Add(new SpriteGameObject("spr_background"));

            guards = new GameObjectList();
            for (int i = 0; i < guardAmount; i++)
            {
                guards.Add(new Guard(new Vector2(guardPositionXYOffset[0] + guardPositionXYOffset[2] * i, guardPositionXYOffset[1])));
            }
            Add(guards);

            imps = new GameObjectList();
            for (int i = 0; i < impAmount; i++)
            {
                imps.Add(new Imps());
            }
            Add(imps);

            Add(walls = new SpriteGameObject("spr_towers"));

            Add(score = new Score());

            Add(ch = new Crosshair());

            escaped = 0;
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            if (inputHelper.MouseLeftButtonPressed())
            {
                foreach (Imps imp in imps.Children)
                {
                    if (ch.CollidesWith(imp) && !imp.CollidesWith(walls))
                    {
                        imp.Die();
                        score.AddScore();
                    }
                }
            }
        }
    }
}
