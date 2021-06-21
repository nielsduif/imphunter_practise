using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImpHunter2021.GameObjects
{
    class Guard : SpriteGameObject
    {
        Vector2 startPos;
        int speedHor = 50, speedVer = 0;
        public Guard(Vector2 _startPos, string _assetName = "spr_guard") : base(_assetName)
        {
            startPos = _startPos;
            Reset();
        }

        public override void Reset()
        {
            base.Reset();
            position = startPos;
            velocity = new Vector2(speedHor, speedVer);
        }

        public void Bounce()
        {
            velocity.X *= -1;
        }
    }
}
