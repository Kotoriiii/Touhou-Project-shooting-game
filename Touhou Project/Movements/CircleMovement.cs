using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Touhou_Project.Sprites;
namespace Touhou_Project.Movements
{
    public class CircleMovement: MovementStrategy
    {
        Vector2 center = new Vector2(140, 200);
        double degree = 0.0;
        double r = 100.0; 
        public CircleMovement()
        {

        }
        public CircleMovement(float x, float y)
        {
            Vector2 center = new Vector2(x, y);
        }
        public CircleMovement(float x, float y, double new_r)
        {
            Vector2 center = new Vector2(x, y);
            r = new_r;
        }
        public override Vector2 Update(Vector2 current, Vector2 playerPos, GameTime gameTime)
        {
            if (degree == 360)
                degree = 0;
            Vector2 res = new Vector2((float)(center.X + r * Math.Cos((float)radiusConvertor(degree))), (float)(center.Y + r * Math.Sin((float)radiusConvertor(degree))));
            degree++;
            return res; 
        }
        double radiusConvertor(double n)
        {
            return (n * (Math.PI) / 180.0);
        }

    }
}
