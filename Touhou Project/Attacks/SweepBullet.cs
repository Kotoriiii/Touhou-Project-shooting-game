using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
namespace Touhou_Project.Sprites
{
    public class SweepBullet: Bullet
    {

        public SweepBullet(Vector2 Pos, Texture2D texture, int range) : base(texture)
        {
            Pos.X += 20;
            Pos.Y += 100;
            this.Position = Pos;
            this.radius_x = range; 
            this.speed = 8;
        }
        public override void Update(GameTime gameTime)
        {
            setX(this.Position.X + this.radius_x);
            setY(this.Position.Y + (float)(speed));
            lifeSpam += 10;
            if (lifeSpam >= 10000)
                this.Collided = true;
        }

    }
}
