using System;
using System.Collections.Generic;
using System.Text;

namespace ImpHunter2021.GameObjects
{
    class Score : TextGameObject
    {
        int points, point = 1;
        public Score(string _assetName = "GameFont") : base(_assetName)
        {
            Reset();
        }

        public void AddScore()
        {
            points += point;
            Text = points.ToString();
        }

        public override void Reset()
        {
            base.Reset();
            points = 0;
            Text = points.ToString();
        }
    }
}
