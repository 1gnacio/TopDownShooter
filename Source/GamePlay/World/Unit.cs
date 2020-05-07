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
    public class Unit : Basic2d
    {

        public bool dead;

        public float speed, hitDist;

        public Unit(string PATH, Vector2 POS, Vector2 DIMS) : base(PATH, POS, DIMS)
        {
            dead = false;

            speed = 2.0f;

            hitDist = 35.0f;
        }

        //Para no tener movimiento en diagonal, usar if/else
        public override void Update(Vector2 OFFSET)
        {


            base.Update(OFFSET);
        }

        public virtual void GetHit()
        {
            dead = true;
        }

        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }


    }
}
