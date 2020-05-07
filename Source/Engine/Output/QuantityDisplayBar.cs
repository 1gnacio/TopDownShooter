using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using TopDownShooter.Source.GamePlay.World;
using Microsoft.Xna.Framework.Graphics;

namespace TopDownShooter
{
    public class QuantityDisplayBar
    {
        public int border;

        public Basic2d bar, barBkg;

        public Color color;

        public QuantityDisplayBar(Vector2 DIMS, int BORDER, Color COLOR)
        {
            border = BORDER;

            color = COLOR;

            bar = new Basic2d("2d\\Misc\\Solid", new Vector2(0, 0), new Vector2(DIMS.X - border * 2, DIMS.Y - border * 2));

            barBkg = new Basic2d("2d\\Misc\\Shade", new Vector2(0, 0), new Vector2(DIMS.X, DIMS.Y));
        }

        public virtual void Update(float CURRENT, float MAX)
        {
            bar.dims = new Vector2(CURRENT / MAX * (barBkg.dims.X - border * 2), bar.dims.Y);
        }

        public virtual void Draw(Vector2 OFFSET)
        {
            barBkg.Draw(OFFSET, new Vector2(0, 0), Color.Black);

            bar.Draw(OFFSET + new Vector2(border, border), new Vector2(0, 0), color);
        }
    }
}
