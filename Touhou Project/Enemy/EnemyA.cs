using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Touhou_Project.Movements;
using Touhou_Project.Sprites;

namespace Touhou_Project
{
    public class EnemyA : Enemy
    {
        private int _speed = 75;
        private Texture2D _texture;
        BulletMovementStrategy bulletStrategy = new BulletMovementStrategy();
        List<String> bulletMovement = new List<String>();
        BulletMovementFactory bulletFactory;
        Stack<MovementStrategy> movementStrategy = new Stack<MovementStrategy>();
        MovementBuilder builder = new MovementBuilder();
        public Bullet _bullet;
        public override int getType()
        {
            return 1;
        }
        public EnemyA(Texture2D texture, Vector2 newPos, Bullet bullet, int newhealth)
        {
            anim = new SpriteAnimation(texture, 8, 10);
            _bullet = bullet;
            this.Position = newPos;
            _texture = texture;
            Dead = false;
            this.Heath = newhealth;
            this.movementStrategy = builder.MovementGenerlizer(GameUI.enemyAmovement); //enemyA movement
            this.bulletMovement = bulletStrategy.bulletMovementBuilder(GameUI.enemyAbulletMovement);// enemyA bullets movement
            this.bulletFactory = new BulletMovementFactory(bulletMovement); // create bullet movement
            
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, new Vector2(Position.X - 48, Position.Y - 48), Color.White);
        }

        public override void Update(GameTime gameTime, Vector2 playerPos)
        {
            var time = gameTime.TotalGameTime.Milliseconds;
            bulletFactory.createBulletMovement(gameTime, anim.Position + new Vector2(15, 32), _bullet._texture);

            anim.Position = new Vector2(Position.X - 48, Position.Y - 66);
            anim.Update(gameTime);

            Position = movementStrategy.Peek().Update(Position, playerPos, gameTime);
            if (movementStrategy.Peek().Goal && movementStrategy.Count != 1)
                movementStrategy.Pop();
        }
        public override void Update(GameTime gameTime)
        {

        }
    }
}
