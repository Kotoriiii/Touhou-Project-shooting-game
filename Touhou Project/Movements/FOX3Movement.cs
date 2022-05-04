using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Touhou_Project.Sprites;

namespace Touhou_Project.Movements
{
    class FOX3Movement : MovementStrategy
    {
        Vector2 destination;
        int _speed = 75;
        public FOX3Movement()
        {

        }
        public override Vector2 Update(Vector2 current, Vector2 playerPos, GameTime gameTime)
        {
            destination = GameUI._player.Position;
            if (Vector2.Distance(current, destination) <= 5)
            {
                return destination;
            }
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;

            Vector2 moveDir = GameUI._player.Position - current;
            moveDir.Normalize();

            current += moveDir * _speed * dt;
            return current;
        }
    }
}
