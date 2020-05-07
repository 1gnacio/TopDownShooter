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
    public class Fireball : Projectile2d
    {

        public Fireball(Vector2 POS, Unit OWNER, Vector2 TARGET) : base("2d\\Projectiles\\Fireball", POS, new Vector2(20, 20), OWNER, TARGET)
        {

        }

        public override void Update(Vector2 OFFSET, List<Unit> UNITS)
        {
            base.Update(OFFSET, UNITS);
        }


        public override void Draw(Vector2 OFFSET)
        {
            base.Draw(OFFSET);
        }
    }
}
