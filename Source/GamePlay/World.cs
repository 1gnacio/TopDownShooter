﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopDownShooter.Source.GamePlay.World;

namespace TopDownShooter
{
    public class World

    {
        public UI ui;

        public int numKilled;

        public Vector2 offset;

        public Hero hero;

        public List<Projectile2d> projectiles = new List<Projectile2d>();

        public List<Mob> mobs = new List<Mob>();

        public List<SpawnPoint> spawnPoints = new List<SpawnPoint>();

        PassObject resetWorld;

        public World(PassObject RESETWORLD)
        {
            resetWorld = RESETWORLD;

            numKilled = 0;

            hero = new Hero("2d\\Hero", new Vector2(300, 300), new Vector2(40, 40));

            GameGlobals.PassProjectile = AddProjectile;

            GameGlobals.PassMob = AddMob;

            GameGlobals.CheckScroll = CheckScroll;

            offset = new Vector2(0, 0);

            spawnPoints.Add(new SpawnPoint("2d\\Misc\\Circle", new Vector2(50, 50), new Vector2(35, 35)));

            spawnPoints.Add(new SpawnPoint("2d\\Misc\\Circle", new Vector2(Globals.screenWidth / 2, 50), new Vector2(35, 35)));

            spawnPoints[spawnPoints.Count - 1].spawnTimer.AddToTimer(500);

            spawnPoints.Add(new SpawnPoint("2d\\Misc\\Circle", new Vector2(Globals.screenWidth - 50, 50), new Vector2(35, 35)));

            spawnPoints[spawnPoints.Count - 1].spawnTimer.AddToTimer(1000);

            ui = new UI();

        }

        public virtual void Update()
        {

            if(!hero.dead)
            {
                hero.Update(offset);

                for (int i = 0; i < spawnPoints.Count; i++)
                {
                    spawnPoints[i].Update(offset);
                }

                for (int i = 0; i < projectiles.Count; i++)
                {
                    projectiles[i].Update(offset, mobs.ToList<Unit>());

                    if (projectiles[i].done)
                    {
                        projectiles.RemoveAt(i);
                        i--;
                    }
                }

                for (int i = 0; i < mobs.Count; i++)
                {
                    mobs[i].Update(offset, hero);

                    if (mobs[i].dead)
                    {
                        numKilled++;
                        mobs.RemoveAt(i);
                        i--;
                    }
                }
            } else
            {
                if (Globals.keyboard.GetPress("Enter"))
                {
                    resetWorld(null);
                }
            }
            

            ui.Update(this);
        }

        public virtual void AddMob(object INFO)
        {
            mobs.Add((Mob) INFO);
        }

        public virtual void AddProjectile(object INFO)
        {
            projectiles.Add((Projectile2d)INFO);
        }

        public virtual void CheckScroll(object INFO)
        {
            Vector2 tempPos = (Vector2)INFO;
            
            if(tempPos.X < -offset.X + (Globals.screenWidth * .4f))
            {
                offset = new Vector2(offset.X + hero.speed * 2, offset.Y);
            }

            if (tempPos.X > -offset.X + (Globals.screenWidth * .6f))
            {
                offset = new Vector2(offset.X - hero.speed * 2, offset.Y);
            }

            if (tempPos.Y < -offset.Y + (Globals.screenHeight * .4f))
            {
                offset = new Vector2(offset.X, offset.Y + hero.speed * 2);
            }

            if (tempPos.Y > -offset.Y + (Globals.screenHeight * .6f))
            {
                offset = new Vector2(offset.X, offset.Y - hero.speed * 2);
            }
        }

        public virtual void Draw(Vector2 OFFSET)
        {
            hero.Draw(offset);

            for (int i = 0; i < projectiles.Count; i++)
            {
                projectiles[i].Draw(offset);
            }

            for (int i = 0; i < spawnPoints.Count; i++)
            {
                spawnPoints[i].Draw(offset);
            }

            for (int i = 0; i < mobs.Count; i++)
            {
                mobs[i].Draw(offset);
            }

            ui.Draw(this);


            

        }

    }
}
