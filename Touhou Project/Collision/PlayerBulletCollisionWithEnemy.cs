using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Touhou_Project.Collision
{
    public class PlayerBulletCollisionWithEnemy : CollisionCommand
    {
        private List<Sprite> sprites;
        private List<Bullet> bullet;


        public PlayerBulletCollisionWithEnemy(List<Sprite> sprites, List<Bullet> bullet)
        {
            this.sprites = sprites;
            this.bullet = bullet;
        }

        public override void execute()
        {
            foreach (Bullet proj in this.bullet)
            {
                foreach (var b in this.sprites)
                {
                    int sum = proj.radius + b.radius;
                    if (b.GetType() == typeof(Final_boss))
                    {
                        if (Vector2.Distance(proj.Position, ((Final_boss)b).Position) < 100)
                        {
                            proj.Collided = true;
                            ((Final_boss)b).Heath -= proj.heath;
                            //((Final_boss)b).Dead = true;
                            if (((Final_boss)b).Heath <= 0)
                            {
                                GameUI._finalBossDead = true;
                            }
                            if (Player.health <= 0)
                            {
                                GameUI.playerLives--;
                                KillPlayer();
                            }
                        }
                    }
                    else if (b.GetType() == typeof(Mid_boss))
                    {
                        if (Vector2.Distance(proj.Position, ((Mid_boss)b).Position) < 100)
                        {
                            proj.Collided = true;
                            ((Mid_boss)b).Heath -= proj.heath;
                            //((Mid_boss)b).Dead = true;
                            if (Player.health <= 0)
                            {
                                GameUI.playerLives--;
                                KillPlayer();
                            }
                        }
                    }
                    if (b.GetType() == typeof(EnemyA))
                    {
                        var temp = Vector2.Distance(proj.Position, ((EnemyA)b).Position);

                        if (Vector2.Distance(proj.Position, ((EnemyA)b).Position) < sum)
                        {
                            proj.Collided = true;
                            ((EnemyA)b).Dead = true;
                            if (Player.health <= 0)
                            {
                                GameUI.playerLives--;
                                KillPlayer();
                            }
                        }
                    }
                    else if (b.GetType() == typeof(EnemyB))
                    {
                        var temp = Vector2.Distance(proj.Position, ((EnemyB)b).Position);
                        if (Vector2.Distance(proj.Position, ((EnemyB)b).Position) < sum)
                        {
                            proj.Collided = true;
                            ((EnemyB)b).Dead = true;
                            if (Player.health <= 0)
                            {
                                GameUI.playerLives--;
                                KillPlayer();
                            }
                        }
                    }
                }
            }
        }
    }
}
