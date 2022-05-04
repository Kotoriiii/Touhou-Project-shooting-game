using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Touhou_Project.Collision
{
    public class PlayerCollisionWithEnemy : CollisionCommand
    {
        private Player player;
        private List<Sprite> sprites;

        public PlayerCollisionWithEnemy(Player player, List<Sprite> sprites)
        {
            this.player = player;
            this.sprites = sprites;
        }

        public override void execute()
        {
            foreach (var e in this.sprites)
            {
                int sum = 30;
                if (e.GetType() == typeof(EnemyA))
                {
                    if (Vector2.Distance(this.player.Position, ((EnemyA)e).Position) < sum)
                    {
                        ((EnemyA)e).Dead = true;
                        Player.health -= ((EnemyA)e).Heath;
                        if (Player.health <= 0)
                        {
                            GameUI.playerLives--;
                            KillPlayer();
                        }
                    }
                }
                if (e.GetType() == typeof(EnemyB))
                {
                    if (Vector2.Distance(this.player.Position, ((EnemyB)e).Position) < sum)
                    {
                        ((EnemyB)e).Dead = true;
                        Player.health -= ((EnemyB)e).Heath;
                        if (Player.health <= 0)
                        {
                            GameUI.playerLives--;
                            KillPlayer();
                        }
                    }
                }

                if (e.GetType() == typeof(Mid_boss))
                {
                    if (Vector2.Distance(this.player.Position, ((Mid_boss)e).Position) < 100)
                    {
                        if (Player.health > 0)
                        {
                            ((Mid_boss)e).Heath -= Player.health;
                            Player.health -= ((Mid_boss)e).Heath;
                        }
                        if (Player.health <= 0)
                        {
                            GameUI.playerLives--;
                            KillPlayer();
                        }
                            
                    }
                }
                if (e.GetType() == typeof(Final_boss))
                {
                    if (Vector2.Distance(this.player.Position, ((Final_boss)e).Position) < 100)
                    {
                        if (Player.health > 0)
                        {
                            ((Final_boss)e).Heath -= Player.health;
                            Player.health -= ((Final_boss)e).Heath;
                            if (((Final_boss)e).Heath <= 0)
                            {
                                GameUI._finalBossDead = true;
                            }
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
}
