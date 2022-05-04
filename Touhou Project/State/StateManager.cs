using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace Touhou_Project
{
    internal class StateManager
    {
        public static EventHandler ExitEvent;

        private static State currentState;
        private static State nextState;

        public static State CurrentState { 
            get => currentState; 
            set => currentState = value; 
        }

        public static void ChangeState(State state)
        {
            nextState = state;
        }

        public static void Update(GameTime gameTime)
        {
            SwitchToMainMenu();
            SwitchToNextState();
            CurrentState.Update(gameTime);
            CurrentState.PostUpdate(gameTime);
        }

        private static void SwitchToMainMenu()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                currentState = new MenuUI();
                nextState = null;
                currentState.LoadContent();
            }
        }

        private static void SwitchToNextState()
        {
            if (nextState != null)
            {
                currentState = nextState;
                nextState = null;
                currentState.LoadContent();
            }
        }

    }
}
