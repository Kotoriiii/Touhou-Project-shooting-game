using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Touhou_Project.Sprites;


namespace Touhou_Project.Movements
{
    public class VectorMovement : MovementStrategy
    {
        Vector2 destination;
        int _speed = 75;
        public VectorMovement()
        {
            destination = new Vector2(240, 200);
        }
        public VectorMovement(Vector2 des)
        {
            destination = des;
        }
        public Vector2 BulletUpdate(Vector2 current, GameTime gameTime)
        {
            if (Vector2.Distance(current, destination) <= 5)
            {
                this.Goal = true;
                return destination;
            }
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;

            Vector2 moveDir = destination - current;
            moveDir.Normalize();

            current += moveDir * _speed * dt;
            return current;
        }
        public override Vector2 Update(Vector2 current, Vector2 playerPos, GameTime gameTime)
        {
            if (Vector2.Distance(current, destination) <= 5)
            {
                this.Goal = true; 
                return destination;
            }
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;

            Vector2 moveDir = destination - current;
            moveDir.Normalize();

            current += moveDir * _speed * dt;
            return current;
        }
    }
}
