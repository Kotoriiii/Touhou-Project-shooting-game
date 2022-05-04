using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;


namespace Touhou_Project
{
    public abstract class State
    {
        protected SpriteBatch spriteBatch;
        protected InputManager InputManager { get; set; }

        public State()
        {
            SetInputManager();
        }

        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);

        public abstract void LoadContent();

        public abstract void PostUpdate(GameTime gameTime);

        public abstract void Update(GameTime gameTime);

        public abstract void Draw(GameTime gameTime);
        public abstract void HandleInput(GameTime gameTime);
        protected abstract void SetInputManager();
    }
}
