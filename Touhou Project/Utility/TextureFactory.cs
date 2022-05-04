using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Touhou_Project
{
    internal class TextureFactory
    {
        public static ContentManager Content { get; set; }

        public static Texture2D GetTexture(string textureName)
        {
            var texture = Content.Load<Texture2D>(textureName);

            return texture;
        }

        public static SpriteFont GetSpriteFont(string spriteFontName)
        {
            var spriteFont = Content.Load<SpriteFont>(spriteFontName);

            return spriteFont;
        }
    }
}
