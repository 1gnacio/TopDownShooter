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
    public class UI
    {

        public SpriteFont font;

        public QuantityDisplayBar healthBar;

        public UI()
        {
            font = Globals.content.Load<SpriteFont>("Fonts\\HeyComic");

            healthBar = new QuantityDisplayBar(new Vector2(104, 16), 2, Color.Red);
        }

        public void Update(World WORLD)
        {
            healthBar.Update(WORLD.hero.health, WORLD.hero.healthMax);
        }

        public void Draw(World WORLD)
        {
            string tempStr = "Num Killed: " + WORLD.numKilled;
            Vector2 strDims = font.MeasureString(tempStr);
            Globals.spriteBatch.DrawString(font, tempStr, new Vector2(Globals.screenWidth / 2 - strDims.X / 2, Globals.screenHeight - 40), Color.Black);

            healthBar.Draw(new Vector2(20, Globals.screenHeight - 40));
        }
    }
}
