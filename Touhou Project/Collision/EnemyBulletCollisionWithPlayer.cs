using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Touhou_Project.Collision
{
    public class EnemyBulletCollisionWithPlayer : CollisionCommand
    {
        private Player player;
        private List<Bullet> enemybullet;

        public EnemyBulletCollisionWithPlayer(Player player, List<Bullet> enemybullet)
        {
            this.player = player;
            this.enemybullet = enemybullet;

        }
        public override void execute()
        {
            foreach (Bullet proj in this.enemybullet)
            {
                if (Vector2.Distance(this.player.Position, proj.Position) < 30)
                {
                    proj.Collided = true;
                    Player.health -= 2;
                   
                    if(GameUI._finalBossDead)
                    {
                        GameWin();
                    }

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
