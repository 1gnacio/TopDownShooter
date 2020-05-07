using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using TopDownShooter.Source.GamePlay.World;

namespace TopDownShooter
{
    public class Projectile2d : Basic2d
    {
        public float speed;

        public Vector2 direction;

        public bool done;

        public McTimer timer;

        public Unit owner;

        public Projectile2d(string PATH, Vector2 POS, Vector2 DIMS, Unit OWNER, Vector2 TARGET) : base(PATH, POS, DIMS)
        {
            done = false;

            speed = 5.0f;

            owner = OWNER;

            direction = TARGET - owner.pos;

            direction.Normalize();

            timer = new McTimer(1200);

            rot = Globals.RotateTowards(pos, new Vector2(TARGET.X, TARGET.Y));
        }

        public virtual void Update(Vector2 OFFSET, List<Unit> UNITS)
        {
            pos += direction * speed;

            timer.UpdateTimer();

            if(timer.Test())
            {
                done = true;
            }

            if (HitSomething(UNITS))
            {
                done = true;
            }
        }

        public virtual bool HitSomething(List<Unit> UNITS)
        {
            bool hit = false;

            for (int i = 0; i<UNITS.Count; i++)
            {
                if(Globals.GetDistance(pos, UNITS[i].pos) < UNITS[i].hitDist)
                {
                    UNITS[i].GetHit();

                    hit = true;
                }
            }

            return hit;
        }

        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }
    }
}
