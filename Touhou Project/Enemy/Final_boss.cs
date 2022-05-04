using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Touhou_Project.Movements;
using Touhou_Project.Sprites;
namespace Touhou_Project
{
    public class Final_boss : Enemy
    {
        private Texture2D _texture;
        public float dx;
        public float dy;
        public int range_x = -20;
        public int range_x2 = 20;
        public Bullet _bullet;
        Random random = new Random();
        BulletMovementFactory bulletFactory;
        BulletMovementStrategy bulletStrategy = new BulletMovementStrategy();
        List<String> bulletMovement = new List<String>();
        Stack<MovementStrategy> movementStrategy = new Stack<MovementStrategy>();
        MovementBuilder builder = new MovementBuilder();

        public override int getType()
        {
            return 1; 
        }

        public Final_boss(Texture2D texture, Vector2 newPos, Bullet bullet, int newhealth)
        {
            _texture = texture;
            _bullet = bullet;
            anim = new SpriteAnimation(texture, 9, 3);
            Position = newPos;
            dx = random.Next(1, 5);
            dy = random.Next(1, 5);
            if (random.Next(0, 1) == 0)
            {
                dx *= -1;
            }
            if (random.Next(0, 1) == 0)
            {
                dy *= -1;
            }
            Dead = false;
            this.Heath = newhealth;
            this.movementStrategy = builder.MovementGenerlizer(GameUI.finalBossMovement); // FinalBoss movement
            this.bulletMovement = bulletStrategy.bulletMovementBuilder(GameUI.finalBossBulletmovement);// FinalBoss bullets movement
            this.bulletFactory = new BulletMovementFactory(bulletMovement); // create bullet movement
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, new Vector2(Position.X, Position.Y), Color.White);
        }

        public override void Update(GameTime gameTime, Vector2 playerPos)
        {
            bulletFactory.createBulletMovement(gameTime, anim.Position + new Vector2(40, 40), _bullet._texture);
            var time = gameTime.TotalGameTime.Milliseconds;
            Position = movementStrategy.Peek().Update(Position, playerPos, gameTime);
            if (movementStrategy.Peek().Goal && movementStrategy.Count != 1)
                movementStrategy.Pop();
            anim.Position = Position;
            anim.Update(gameTime);
        }

        public override void Update(GameTime gameTime)
        {

        }
    }
}
