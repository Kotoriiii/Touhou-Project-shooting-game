using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Touhou_Project.Sprites;

namespace Touhou_Project.Movements
{
    public abstract class MovementStrategy
    {
        bool goal = false;
        public abstract Vector2 Update(Vector2 current, Vector2 playerPos, GameTime gameTime);
        public bool Goal
        {
            get { return goal; }
            set { goal = value; }
        }
    }
}
