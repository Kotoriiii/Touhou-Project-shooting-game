using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Touhou_Project.Movements;
using Touhou_Project.Sprites;

/// <summary>
/// This class has the information of Enemy B.
/// </summary>
namespace Touhou_Project
{
    public class EnemyB : Enemy
    {
        Stack<MovementStrategy> movementStrategy = new Stack<MovementStrategy>();
        BulletMovementStrategy bulletStrategy = new BulletMovementStrategy();
        List<String> bulletMovement = new List<String>();
        BulletMovementFactory bulletFactory;
        MovementBuilder builder = new MovementBuilder();
        private Texture2D _texture;
        public Bullet _bullet;
        
        public override int getType()
        {
            return 1;
        }
        public EnemyB(Texture2D texture, Vector2 newPos, Bullet bullet, int newhealth)
        {
            anim = new SpriteAnimation(texture, 8, 10);
            _bullet = bullet;
            this.Position = newPos;
            _texture = texture;
            Dead = false;
            this.Heath = newhealth;
            // movementStrategy接口
            this.movementStrategy = builder.MovementGenerlizer(GameUI.enemyBmovement); // enemyB movement
            this.bulletMovement = bulletStrategy.bulletMovementBuilder(GameUI.enemyBbulletMovement);// enemyB bullets movement
            this.bulletFactory = new BulletMovementFactory(bulletMovement);//create bullet movement
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, new Vector2(Position.X - 48, Position.Y - 48), Color.White);
        }

        public override void Update(GameTime gameTime, Vector2 playerPos)
        {
            bulletFactory.createBulletMovement(gameTime, anim.Position + new Vector2(15, 32), _bullet._texture);

            //bulletFactory.addRegularFactory(gameTime, anim.Position + new Vector2(15, 32), _bullet._texture);
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
