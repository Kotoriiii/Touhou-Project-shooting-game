using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Touhou_Project.Aesthetics
{
    public class Particle : Component, ICloneable
    {
        public Vector2 Position;
        public Vector2 Velocity;

        protected Texture2D texture;

        public Particle(Texture2D texture)
        {
            this.texture = texture;
            this.Opacity = 1f;
            this.Origin = new Vector2(this.texture.Width / 2, this.texture.Height / 2);
        }

        public float Opacity { get; set; }
        public float Rotation { get; set; }
        public float Scale { get; set; }
        public bool IsRemoved { get; set; }
        public Vector2 Origin { get; set; }

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)(this.Position.X - this.Origin.X), 
                    (int)(this.Position.Y - this.Origin.Y), (int)(this.texture.Width * this.Scale), 
                    (int)(this.texture.Height * this.Scale));
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, this.Position, null, 
                Color.Coral * this.Opacity, this.Rotation, this.Origin, this.Scale, 
                SpriteEffects.None, 0);
        }

        public override void Update(GameTime gameTime)
        {
            this.Position += this.Velocity;

            if (this.Rectangle.Top > 1000)
            {
                this.IsRemoved = true;
            }
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

    }
}
