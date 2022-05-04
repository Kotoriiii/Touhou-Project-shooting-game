using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Input;
namespace Touhou_Project
{
    public class Player: Sprite
    {
        public Bullet _bullet;
        private Texture2D _texture;
        private Vector2 _position;
        public new int radius = 35;
        private new int speed = 300;
        public static int health;
        public float dt;
        private int playerWidth = 50;
        private int playerHeight = 70;
        private bool _isShooting;
        private TimeSpan _lastShotAt;
        public static bool cheatmode;


        public SpriteAnimation anim;//store the current animation of the player
        public SpriteAnimation[] animations = new SpriteAnimation[8];

        public override int getType()
        {
            return 1;
        }
        public Player(Texture2D texture, Bullet bullet, int newhealth)
        {
            _texture = texture;
            _position = new Vector2(250, 900);
            _bullet = bullet;
            health = newhealth;
            cheatmode = false;
        }

        public Vector2 Position
        {
            get
            {
                return _position;
            }
        }

        public void setX(float newX)
        {
            _position.X = newX;
        }

        public void setY(float newY)
        {
            _position.Y = newY;
        }

        private void AddBullet()
        {
            var bullet = _bullet.Clone() as Bullet;
            bullet.setX(_position.X - 10);
            bullet.setY(_position.Y - 40);
            GameUI.playerBullet.Add(bullet);
        }

        public override void Update(GameTime gameTime)
        {
            _previousKey = _currentKey;
            _currentKey = Keyboard.GetState();
            List<Bullet> temp = new List<Bullet>();

            if(cheatmode)
            {
                health = 999;
            }

            // the variable dt contains the time between the previous frame and the current one
            // get the Delta time. this value is used to provide movement that is independent from the frame rate
            dt = (float)gameTime.ElapsedGameTime.TotalSeconds;

            // can't shoot more than every 0.2 seconds
            if (_lastShotAt != null && gameTime.TotalGameTime - _lastShotAt > TimeSpan.FromSeconds(0.2))
            {
                _isShooting = false;
            }

            for (int i = 0; i < GameUI.playerBullet.Count; i++)
            {
                var cur = GameUI.playerBullet[i];
                cur.setY(cur.Position.Y-(float)cur.speed);
                cur.lifeSpam += 20;
                if (cur.lifeSpam <= 10000)
                {
                    temp.Add(cur);
                }
            }
            GameUI.playerBullet = temp;


            anim.Position = new Vector2(_position.X - 35, _position.Y - 48);

        }
        public override void Update(GameTime gameTime, Vector2 playerPos)
        {

        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {

            //adjust the offset to the center of the player, the size of player is 70 px wide and 96 px tall
            spriteBatch.Draw(_texture, new Vector2(_position.X - 35, _position.Y - 48), Color.White);

        }

        public void MoveLeft()
        {
            if(_position.X > this.playerWidth)
            {
                _position.X -= speed * dt;
                anim = animations[2];
            }

        }

        public void MoveRight()
        {
            if(_position.X < (500 - this.playerWidth))
            {
                _position.X += speed * dt;
                anim = animations[3];
            }
        }

        public void MoveUp()
        {
            if(_position.Y > this.playerHeight)
            {
                _position.Y -= speed * dt;
                anim = animations[0];
            }
            
        }

        public void MoveDown()
        {
            if(_position.Y < (1000 - this.playerHeight))
            {
                _position.Y += speed * dt;
                anim = animations[1];
            }
        }
        public void SlowDown()
        {
            // switch noraml speed and slow speed
            // slow speed
            if (speed == 300)
            {
                speed = 150;
            }
            // normal speed
            else
            {
                speed = 300;
            }
            
        }
        public void CheatMode()
        {
            // cheat mode on
            cheatmode = true;
            
        }
        public void refillHealth()
        {
            //refill health to 50
            cheatmode = false;
            health = 50;
        }

        public void Shoot(GameTime gameTime)
        {
            if (!_isShooting)
            {
                AddBullet();
                _isShooting = true;
                _lastShotAt = gameTime.TotalGameTime;
                
                GameUI.soundControl.PlaySound("Shoot");
            }
        }
    }
}
