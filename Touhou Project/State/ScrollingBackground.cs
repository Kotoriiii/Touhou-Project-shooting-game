using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Touhou_Project;

namespace Touhou_Project
{
    class ScrollingBackground
    {
        public Texture2D texture;
        public Rectangle rectangle;

        public ScrollingBackground(Texture2D newTexture, Rectangle newRectangle)
        {
            texture = newTexture;
            rectangle = newRectangle;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.White);
        }

        public void Update()
        {
            KeyboardState kState = Keyboard.GetState();
            // switch noraml speed and slow speed
            if (kState.IsKeyDown(Keys.V))
            {
                rectangle.Y += 1;
            }
            else
            {
                rectangle.Y += 3;
            }

        }

    }


}
