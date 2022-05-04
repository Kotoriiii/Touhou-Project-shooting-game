using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Touhou_Project
{
    public abstract class Sprite : ICloneable
    {
        public SpriteAnimation anim;
        public double lifeSpam = 5f;
        public double speed = 15;
        protected KeyboardState _currentKey;
        protected KeyboardState _previousKey;
        public int radius = 15;
        private bool collided = false;
        public abstract int getType();
        public abstract void Update(GameTime gameTime);
        public abstract void Update(GameTime gameTime, Vector2 playerPos);
        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
