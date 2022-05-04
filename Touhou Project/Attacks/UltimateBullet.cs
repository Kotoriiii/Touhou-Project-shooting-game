using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace Touhou_Project.Sprites
{
    public class UltimateBullet : Bullet
    {
        private List<Bullet> bullets;
        public UltimateBullet(Vector2 Pos, Texture2D texture) : base(texture)
        {
            this.Position = Pos;
            this.speed = 5;
        }
        public void update()
        {
            //setY(this.Position.Y + (float)(speed));
            //lifeSpam += 10;
            //if (lifeSpam >= 10000)
            //    this.Collided = true;



            setY(this.Position.Y - 10);

            lifeSpam += 10;
            if (lifeSpam >= 10000)
                this.Collided = true;
        }
    }
}
