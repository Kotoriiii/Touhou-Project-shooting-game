using System;
using System.Collections.Generic;
using System.Text;

namespace Touhou_Project
{
    public class GameplayInputCommand : BaseInputCommand
    {
        public class GameExit : GameplayInputCommand { }
        public class PlayerMoveLeft : GameplayInputCommand { }
        public class PlayerMoveRight : GameplayInputCommand { }
        public class PlayerMoveUp : GameplayInputCommand { }
        public class PlayerMoveDown : GameplayInputCommand { }
        public class PlayerShoots : GameplayInputCommand { }
        public class PlayerSlowMode : GameplayInputCommand { }
        public class PlayerCheatMode : GameplayInputCommand { }
        public class PlayerRefillHealth : GameplayInputCommand { }
        public class ClearAllBullets: GameplayInputCommand { }
    }
}
