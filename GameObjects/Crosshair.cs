using System;
using System.Collections.Generic;
using System.Text;

namespace ImpHunter2021.GameObjects
{
    class Crosshair : SpriteGameObject
    {
        private bool _shoots;
        public Crosshair(string _assetName = "spr_crosshair") : base(_assetName)
        {
            origin = Center;
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            position = inputHelper.MousePosition;
            Shoots = inputHelper.MouseLeftButtonPressed();
        }

        bool Shoots
        {
            get { return _shoots; }
            set { _shoots = value; }
        }
    }
}
