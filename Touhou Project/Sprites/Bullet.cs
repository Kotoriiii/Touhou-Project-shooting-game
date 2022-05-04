using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace Touhou_Project
{
    public class Bullet : Sprite
    {
        public int heath = 5; 
        public Texture2D _texture;
        private Vector2 _position;
        public new int radius = 15;
        private bool collided = false;
        public int radius_x;
        public int radius_y;
       
        public Bullet(Texture2D texture)
        {
            _texture = texture;
            _position = new Vector2(250, 850);
        }
        public override int getType()
        {
            return 0;
        }
        public Vector2 Position
        {
            get
            {
                return _position;
            }
            set
            {
                _position = value; 
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

        public bool Collided
        {
            get { return collided; }
            set { collided = value; }
        }


        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _position, null, Color.White, 0f, Vector2.Zero,
                0.5f, SpriteEffects.None, 0f);
        }
        public override void Update(GameTime gameTime, Vector2 playerPos)
        {

        }

        public override void Update(GameTime gameTime)
        {
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
            KeyboardState kState = Keyboard.GetState();
        }
    }
}
