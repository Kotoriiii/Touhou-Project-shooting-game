using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Touhou_Project
{
    public abstract class Enemy : Sprite
    {
        private bool dead;
        private int heath = 0;
        private Vector2 _position;
        public Vector2 Position
        {
            get { return _position; }
            set { _position = value; }
        }

        public float PositionX
        {
            get { return _position.X; }
            set { _position.X = value; }
        }

        public float PositionY
        {
            get { return _position.Y; }
            set { _position.Y = value; }
        }

        public bool Dead
        {
            get { return dead; }
            set { dead = value; }
        }
        public int Heath {
            get { return heath; }
            set { heath = value; }
        }


        public override abstract void Update(GameTime gameTime, Vector2 playerPos);
        public override abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);
    }
}
