using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
namespace Touhou_Project.Sprites
{
    public class BulletMovementFactory
    {
        public static int range_x = -20;
        public GameTime gameTime;
        List<String> bulletMovement = new List<String>();
        private int elapsedTime = 0;

        public BulletMovementFactory() { }
      
        public BulletMovementFactory(List<String> bulletMovement)
        {
            this.bulletMovement = bulletMovement;
        }

        public void createBulletMovement(GameTime gameTime, Vector2 Pos, Texture2D texture)
        {
            //bullet movement is a combination of different types of movements
            if(bulletMovement.Count > 1)
            {
                createBulletMultipleMovements(gameTime, Pos, texture);
            } else
            { //bullet movement contains only one type of movement
                for (int i = 0; i < bulletMovement.Count; i++)
                {
                    if (this.bulletMovement[i] == "regular")
                    {
                        addRegularBulletFactory(gameTime, Pos, texture);
                    }
                    else if (this.bulletMovement[i] == "sweep")
                    {
                        addSweepBulletFactory(gameTime, Pos, texture, 20);
                    }
                    else if (this.bulletMovement[i] == "spiral")
                    {
                        addSpiralBulletFactory(gameTime, Pos, texture, 10);
                    }
                    else if (this.bulletMovement[i] == "ultimate")
                    {
                        for (int j = 10; j <= 490; j += 90)
                        {
                            addUltimateFactory(gameTime, new Vector2(j, 1000), texture);
                        }
                    }
                    else
                    {
                        addRegularBulletFactory(gameTime, Pos, texture);
                    }
                }
            }
        }

        public void createBulletMultipleMovements(GameTime gameTime, Vector2 Pos, Texture2D texture)
        {
            for (int i = 0; i < bulletMovement.Count; i++)
            {
                if (i == 0 && elapsedTime <= 10000)
                {
                    if (this.bulletMovement[i] == "regular")
                    {
                        addRegularBulletFactory(gameTime, Pos, texture);
                        elapsedTime += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
                    }
                    else if (this.bulletMovement[i] == "sweep")
                    {
                        addSweepBulletFactory(gameTime, Pos, texture, 20);
                        elapsedTime += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
                    }
                    else if (this.bulletMovement[i] == "spiral")
                    {
                        addSpiralBulletFactory(gameTime, Pos, texture, 10);
                        elapsedTime += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
                    }
                    else if (this.bulletMovement[i] == "ultimate")
                    {
                        for (int j = 10; j <= 490; j += 90)
                        {
                            addUltimateFactory(gameTime, new Vector2(j, 1000), texture);
                        }
                        elapsedTime += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
                    }
                    else
                    {
                        addRegularBulletFactory(gameTime, Pos, texture);
                        elapsedTime += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
                    }
                }

                //10s time delay to change to another type of movement
                if (i > 0 && elapsedTime > 10000)
                {
                    if (this.bulletMovement[i] == "regular")
                    {
                        addRegularBulletFactory(gameTime, Pos, texture);
                        elapsedTime += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
                    }
                    else if (this.bulletMovement[i] == "sweep")
                    {
                        addSweepBulletFactory(gameTime, Pos, texture, 20);
                        elapsedTime += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
                    }
                    else if (this.bulletMovement[i] == "spiral")
                    {
                        addSpiralBulletFactory(gameTime, Pos, texture, 10);
                        elapsedTime += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
                    }
                    else if (this.bulletMovement[i] == "ultimate")
                    {
                        for (int j = 10; j <= 490; j += 90)
                        {
                            addUltimateFactory(gameTime, new Vector2(j, 1000), texture);
                        }
                        elapsedTime += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
                    }
                    else
                    {
                        addRegularBulletFactory(gameTime, Pos, texture);
                        elapsedTime += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
                    }
                }
            }
        }
        
        public void addSercetFeatureBulletFactory(GameTime gameTime, Vector2 Pos, Texture2D texture)
        {
            SecretFeatureBullet bullet = new SecretFeatureBullet(Pos, texture);
        }

        public void addRegularBulletFactory(GameTime gameTime, Vector2 Pos, Texture2D texture)
        {
            var time = gameTime.TotalGameTime.Milliseconds;
            if (time % 1000 == 0)
                GameUI.enemyBullet.Add(new RegularBullet(Pos, texture));
        }

        public void addSweepBulletFactory(GameTime gameTime, Vector2 Pos, Texture2D texture, int range)
        {
            if (range_x == 20)
                range_x = -20;
            var time = gameTime.TotalGameTime.Milliseconds;
            if (time % 10== 0)
                GameUI.enemyBullet.Add(new SweepBullet(Pos, texture, range_x));
            range_x += 1;
        }

        public void addSpiralBulletFactory(GameTime gameTime, Vector2 Pos, Texture2D texture, int range)
        {
            if (range_x == 20)
                range_x = -20;
            var time = gameTime.TotalGameTime.Milliseconds;
            if (time % 10 == 0)
                GameUI.enemyBullet.Add(new SpiralBullet(Pos, texture, range_x));
            range_x += 1;
        }

        public void addUltimateFactory(GameTime gameTime, Vector2 Pos, Texture2D texture)
        {
            var time = gameTime.TotalGameTime.Milliseconds;

            GameUI.playerBullet.Add(new UltimateBullet(Pos, texture));
            //GameUI.playerBullet.Add(new UltimateBullet(Pos, texture));
            
        }
        public void addBombsFactory(GameTime gameTime, Vector2 Pos, Texture2D texture)
        {
            float X = 0, Y = 1000;
            var time = gameTime.TotalGameTime.Milliseconds;
            for (float x = 0; x < 500.0; x++)
            {
                if (x % 10 == 0)
                {
                    Vector2 pos = new Vector2(x + X, Y);
                    GameUI.playerBullet.Add(new UltimateBullet(pos, texture));
                }
            }
        }
    }
}
