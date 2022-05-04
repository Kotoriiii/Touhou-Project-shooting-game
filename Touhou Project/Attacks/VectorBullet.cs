using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Touhou_Project.Movements;

namespace Touhou_Project.Sprites
{
    public class VectorBullet : Bullet
    {
        VectorMovement movementStrategy;
        public VectorBullet(Vector2 Pos, Texture2D texture, Vector2 Goal) : base(texture)
        {
            movementStrategy = new VectorMovement(Goal);
            this.Position = Pos;
            this.speed = 5;
        }
        public override void Update(GameTime gameTime)
        {
            this.Position = movementStrategy.BulletUpdate(this.Position, gameTime);
            lifeSpam += 10;
            if (lifeSpam >= 10000)
                this.Collided = true;
        }
    }
}
