using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Touhou_Project.Sprites;

namespace Touhou_Project.Movements
{
    public class StayMovement : MovementStrategy
    {
        Vector2 destination;
        int _speed = 75;
        int count = 0;
        int time = 0;
        SecretFeatureBullet bulletBuilder;
        public StayMovement()
        {
            
        }
        public override Vector2 Update(Vector2 current, Vector2 playerPos, GameTime gameTime)
        {

            if (bulletBuilder == null)
                bulletBuilder = new SecretFeatureBullet(current, GameUI.secretFeatureBullet_texture);
            else
            {
                if (count == 120)
                {
                    count = 0;
                    time++;
                }
                if (time == 10)
                {
                    this.Goal = true;
                }
                else if (count < 2)
                {
                    bulletBuilder.Update();
                }
                count++;
            }
            return current;
        }
    }
}
