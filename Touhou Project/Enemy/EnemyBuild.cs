using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Touhou_Project.Enemys.Abstract_Factory;

namespace Touhou_Project
{
    public class EnemyBuild
    {
        public static double timer = 2D;
        public static double maxTime = 2D;
        static Random rand = new Random();
        public double totalTime = 0;
        public static int enemyA = 0;
        public static int enemyB = 0;

        public void Update(GameTime gameTime, Texture2D spriteSheet, List<Sprite> sprites, EnemyAFactory eAfactory, EnemyBFactory eBfactory, Bullet bullet, List<JSONModel.enemy> enemyStatus)
        {
            timer -= gameTime.ElapsedGameTime.TotalSeconds;
            //count total time in a real time
            totalTime += gameTime.ElapsedGameTime.TotalSeconds;

     
            if (timer <= 0)
            {
                int side = rand.Next(2);

                if(spriteSheet.ToString() == "Source/enemyA")
                {
                    if(gameTime.TotalGameTime.TotalSeconds > enemyStatus[0].start && gameTime.TotalGameTime.TotalSeconds < enemyStatus[0].end)
                    {
                        if(enemyA < enemyStatus[0].enemyAmount)
                        {
                            switch (side)
                            {
                                case 0://spawning the enemies from the left fo the frame
                                    sprites.Add(eAfactory.createEmemy(spriteSheet, new Vector2(-100, rand.Next(-100, 50)), bullet, 1));
                                    break;
                                case 1:////spawning the enemies from the right fo the frame
                                    sprites.Add(eAfactory.createEmemy(spriteSheet, new Vector2(700, rand.Next(-100, 50)), bullet, 1));
                                    break;
                            }
                            enemyA++;
                        }
                    }
                }
                else
                {
                    if (gameTime.TotalGameTime.TotalSeconds > enemyStatus[1].start && gameTime.TotalGameTime.TotalSeconds < enemyStatus[1].end)
                    {
                        if (enemyB < enemyStatus[1].enemyAmount)
                        {
                            switch (side)
                            {
                                case 0:////spawning the enemies from the upleft and upright to the frame
                                    sprites.Add(eBfactory.createEmemy(spriteSheet, new Vector2(-100, rand.Next(-100, 50)), bullet, 1));
                                    break;
                                case 1:////spawning the enemies from the up to the frame
                                    sprites.Add(eBfactory.createEmemy(spriteSheet, new Vector2(-100, rand.Next(-100, 50)), bullet, 1));
                                    break;

                            }
                            enemyB++;
                        }
                    }

                }

                timer = maxTime;

                if (maxTime > 0.5)
                {
                    maxTime -= 0.05D;
                }
            }         
        }
    }
}
