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
    public class GamePlay
    {

        int playState;



        World world;

        public GamePlay()
        {
            playState = 0;

            ResetWorld(null);
        }

        public virtual void Update()
        {
            if (playState == 0)
            {
                world.Update();
            }
        }

        public virtual void ResetWorld(object INFO)
        {
            world = new World(ResetWorld);
        }

        public virtual void Draw()
        {
            if(playState == 0)
            {
                world.Draw(Vector2.Zero);
            }
        }
    }
}
