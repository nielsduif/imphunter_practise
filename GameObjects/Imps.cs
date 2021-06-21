using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImpHunter2021.GameObjects
{
    class Imps : RotatingSpriteGameObject
    {
        static int[] randomX = { 250, 550 };
        static int[] speedXY = { 0, -200 };
        static int[] randomHorShiv = { -11, 12 };
        static int dieSpeed = 400;
        public Imps(string _assetName = "spr_imp") : base(_assetName)
        {
            origin = Center;
            Reset();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Velocity += new Vector2(GameEnvironment.Random.Next(randomHorShiv[0], randomHorShiv[1]), 0);
            AngularDirection = velocity;
        }

        public override void Reset()
        {
            base.Reset();
            Position = new Vector2(GameEnvironment.Random.Next(randomX[0], randomX[1]), GameEnvironment.Screen.Y + Center.Y);
            Velocity = new Vector2(speedXY[0], speedXY[1]);
        }

        public void Die()
        {
            Velocity = new Vector2(0, dieSpeed);
        }
    }
}
