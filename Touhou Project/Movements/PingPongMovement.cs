using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Touhou_Project.Sprites;
namespace Touhou_Project.Movements
{
    public class PingPongMovement : MovementStrategy
    {
        Vector2 destination;
        int _speed = 75;
        int dx = 2, dy = 2;
        int count = 0;
        public PingPongMovement()
        {
            destination = new Vector2(240, 200);
        }
        public override Vector2 Update(Vector2 current, Vector2 playerPos, GameTime gameTime)
        {
            if (current.X + dx <= -100 || current.X + dx >= 500)
            {
                dx = -dx;
            }
            if (current.Y + dy <= 0 || current.Y + dy >= 400)
            {
                dy = -dy;
            }
            if (count == 300)
                this.Goal = true;
            count++; 
            current.X += dx;
            current.Y += dy;
            return current;
        }
    }
}
