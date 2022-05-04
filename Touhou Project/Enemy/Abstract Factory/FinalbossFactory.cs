using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Touhou_Project.Enemys.Abstract_Factory
{
    class FinalbossFactory : AbstractEmemyFactory
    {
        public override Enemy createEmemy(Texture2D texture, Vector2 newPos, Bullet bullet, int health)
        {
            return new Final_boss(texture, newPos, bullet, health);
        }
    }
}
