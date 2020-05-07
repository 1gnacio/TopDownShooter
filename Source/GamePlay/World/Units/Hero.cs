using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopDownShooter.Source.GamePlay.World
{
    public class Hero : Unit
    {

        public Hero(string PATH, Vector2 POS, Vector2 DIMS) : base(PATH, POS, DIMS)
        {
            speed = 2.0f;
        }

        //Para no tener movimiento en diagonal, usar if/else
        public override void Update(Vector2 OFFSET)
        {

            if (Globals.keyboard.GetPress("A") && pos.X > 0)
            {
                pos = new Vector2(pos.X - speed, pos.Y);
            }

            if (Globals.keyboard.GetPress("D") && pos.X < Globals.screenWidth)
            {
                pos = new Vector2(pos.X + speed, pos.Y);
            }

            if (Globals.keyboard.GetPress("W") && pos.Y > 0)
            {
                pos = new Vector2(pos.X, pos.Y - speed);
            }

            if (Globals.keyboard.GetPress("S") && pos.Y < Globals.screenHeight)
            {
                pos = new Vector2(pos.X, pos.Y + speed);
            }


            rot = Globals.RotateTowards(pos, new Vector2(Globals.mouse.newMousePos.X, Globals.mouse.newMousePos.Y));

            if (Globals.mouse.LeftClick())
            {
                GameGlobals.PassProjectile(new Fireball(new Vector2(pos.X, pos.Y), this, new Vector2(Globals.mouse.newMousePos.X, Globals.mouse.newMousePos.Y)));
            }

            base.Update(OFFSET);
        }

        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }


    }
}
