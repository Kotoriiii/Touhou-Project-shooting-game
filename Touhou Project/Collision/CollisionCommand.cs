using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Touhou_Project.Collision
{
    public abstract class CollisionCommand
    {
        public async void KillPlayer()
        {
            GameUI._playerDead = true;
            await Task.Delay(TimeSpan.FromSeconds(2));
            
            if(GameUI.playerLives > 0)
            {
                // respawn player 
                StateManager.ChangeState(new GameUI());
            } else
            {
                resetGame();
            }
            
        }
        public async void GameWin()
        {
            if (GameUI._finalBossDead)
            {
                await Task.Delay(TimeSpan.FromSeconds(2));
                StateManager.ChangeState(new GameWin());
            }
        }

        public void resetGame()
        {
            StateManager.ChangeState(new GameOver());
        }

        public abstract void execute();
    }
}