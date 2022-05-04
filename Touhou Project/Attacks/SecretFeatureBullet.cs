using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Touhou_Project.Movements;

namespace Touhou_Project.Sprites
{
    public class SecretFeatureBullet:  Bullet
    {
        double r = 10000.0;
        double bias = 0;
        Vector2 center;
        Texture2D texture;
        double radiusConvertor(double n)
        {
            return (n * (Math.PI) / 180.0);
        }
        bool judge(double degree)
        {
            if ((0 + bias) % 360 < degree && degree < (40 + bias) % 360)
                return false;
            if ((90 + bias) % 360 < degree && degree < (130 + bias) % 360)
                return false;
            if ((180 + bias) % 360 < degree && degree < (220 + bias) % 360)
                return false;
            if ((270 + bias) % 360 < degree && degree < (310 + bias) % 360)
                return false;
            return true;
        }
        public SecretFeatureBullet(Vector2 Pos, Texture2D texture) : base(texture)
        {
            this.Position = Pos;
            this.texture = texture;
            center = this.Position;
            for (double degree = 0.0; degree <= 360; degree++)
            { 
                Vector2 res = new Vector2((float)(center.X + r * Math.Cos((float)radiusConvertor(degree))), (float)(center.Y + r * Math.Sin((float)radiusConvertor(degree))));
                if (judge(degree))
                {
                    GameUI.enemyBullet.Add(new VectorBullet(Pos, texture, res));
                }
            
            }
            bias+=10;
            if (bias == 360)
                bias = 0;
        
        }
        public void Update()
        {
            for (double degree = 0.0; degree <= 360; degree++)
            {
                Vector2 res = new Vector2((float)(center.X + r * Math.Cos((float)radiusConvertor(degree))), (float)(center.Y + r * Math.Sin((float)radiusConvertor(degree))));
                if (judge(degree))
                {
                    GameUI.enemyBullet.Add(new VectorBullet(this.Position, this.texture, res));
                }

            }
            bias += 10;
            if (bias == 360)
                bias = 0;
        }
        
    }
}
