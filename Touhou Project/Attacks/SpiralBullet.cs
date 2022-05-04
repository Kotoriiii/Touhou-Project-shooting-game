using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Touhou_Project.Sprites
{
    public class SpiralBullet : Bullet
    {
        public float spin;
        public float rotation;
        public float x;
        public float y;
        public float angle;
        Vector2[] velocity;
        public int count = 0;
        int shootnum = 2;

        public SpiralBullet(Vector2 Pos, Texture2D texture, int range) : base(texture)
        {
            Pos.X += 20;
            Pos.Y += 100;
            this.Position = Pos;
            this.radius_x = range;
            this.speed = 5;
        }

        public override void Update(GameTime gametime)
        {
            rotation += 500 * (float)gametime.ElapsedGameTime.TotalSeconds;
            rotation = updateAngle(rotation);

            setXY();

            setX(this.Position.X + velocity[count].X);
            setY(this.Position.Y + velocity[count].Y + (float)speed);

            if (count == shootnum - 1)
            {
                count = 0;
            }
            count += 1;

            lifeSpam += 10;
            if (lifeSpam >= 10000)
                this.Collided = true;
        }

        private static float updateAngle(float angle)
        {
            while (angle >= 360)
            {
                angle -= 360;
            }

            while (angle <= 360)
            {
                angle += 360;
            }

            return angle;
        }

        void setXY()
        {
            float[] angles = new float[shootnum];
            velocity = new Vector2[shootnum];

            for (int i = 0; i < shootnum; i++)
            {
                angles[i] = rotation + (i * 45);
                angles[i] = updateAngle(angles[i]);

                velocity[i].X = (float)Math.Sin(MathHelper.ToRadians(angles[i])) * 8;
                velocity[i].Y = (float)Math.Cos(MathHelper.ToRadians(angles[i])) * 8;
            }

        }

    }
}
