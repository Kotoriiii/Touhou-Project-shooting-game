using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Touhou_Project
{
    public class GameplayInputMapper : BaseInputMapper
    {
        public override IEnumerable<BaseInputCommand> GetKeyboardState(KeyboardState state)
        {
            var commands = new List<GameplayInputCommand>();

            if (state.IsKeyDown(KeyboardInput.Exit))
            {
                commands.Add(new GameplayInputCommand.GameExit());
            }

            if (state.IsKeyDown(KeyboardInput.Left))
            {
                commands.Add(new GameplayInputCommand.PlayerMoveLeft());
            }

            if (state.IsKeyDown(KeyboardInput.Right))
            {
                commands.Add(new GameplayInputCommand.PlayerMoveRight());
            }

            if (state.IsKeyDown(KeyboardInput.Up))
            {
                commands.Add(new GameplayInputCommand.PlayerMoveUp());
            }

            if (state.IsKeyDown(KeyboardInput.Down))
            {
                commands.Add(new GameplayInputCommand.PlayerMoveDown());
            }

            if (state.IsKeyDown(KeyboardInput.Shoot))
            {
                commands.Add(new GameplayInputCommand.PlayerShoots());
            }

            if (state.IsKeyDown(KeyboardInput.SlowMode))
            {
                commands.Add(new GameplayInputCommand.PlayerSlowMode());
            }

            if (state.IsKeyDown(KeyboardInput.CheatMode))
            {
                commands.Add(new GameplayInputCommand.PlayerCheatMode());
            }

            if (state.IsKeyDown(KeyboardInput.RefillHealth))
            {
                commands.Add(new GameplayInputCommand.PlayerRefillHealth());
            }
            
            if(state.IsKeyDown(KeyboardInput.ClearAllBullets))
            {
                commands.Add(new GameplayInputCommand.ClearAllBullets());
            }

            return commands;
        }

        public override IEnumerable<BaseInputCommand> GetMouseState(MouseState state)
        {
            var commands = new List<GameplayInputCommand>();
            if (state.LeftButton == ButtonState.Pressed)
            {
                commands.Add(new GameplayInputCommand.PlayerMoveLeft());
            }

            if (state.RightButton == ButtonState.Pressed)
            {
                commands.Add(new GameplayInputCommand.PlayerMoveRight());
            }

            if (state.MiddleButton == ButtonState.Pressed)
            {
                commands.Add(new GameplayInputCommand.PlayerShoots());
            }
            return commands;
        }

        //public override IEnumerable<BaseInputCommand> GetGamePadState(GamePad state)
        //{
           
        //}
            
    }
}
