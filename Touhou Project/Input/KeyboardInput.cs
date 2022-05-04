using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Touhou_Project
{
    public class KeyboardInput
    {
        private static Keys exit = Keys.Escape;
        private static Keys left = Keys.A;
        private static Keys right = Keys.D;
        private static Keys up = Keys.W;
        private static Keys down = Keys.S;
        private static Keys shoot = Keys.Space;
        private static Keys slowMode = Keys.V;
        private static Keys cheatMode = Keys.C;
        private static Keys refillHealth = Keys.X;
        private static Keys clearAllBullets = Keys.T;


        public static Keys Exit 
        {
            get { return exit; } //get method
            set { exit = value; } // set method
        }

        public static Keys Left 
        {
            get { return left; } //get method
            set { left = value; } // set method
        }

        public static Keys Right 
        {
            get { return right; } //get method
            set { right = value; } // set method
        }

        public static Keys Up 
        {
            get { return up; } //get method
            set { up = value; } // set method
        }

        public static Keys Down 
        {
            get { return down; } //get method
            set { down = value; } // set method
        }


        public static Keys Shoot 
        {
            get { return shoot; } //get method
            set { shoot = value; } // set method
        }

        public static Keys SlowMode
        {
            get { return slowMode; } //get method
            set { slowMode = value; } // set method
        }

        public static Keys CheatMode 
        {
            get { return cheatMode; } //get method
            set { cheatMode = value; } // set method
        }

        public static Keys RefillHealth
        {
            get { return refillHealth; } //get method
            set { refillHealth = value; } // set method
        }

        public static Keys ClearAllBullets
        {
            get { return clearAllBullets; }
            set { clearAllBullets = value; }
        }

        public static void SetKeyboardKey(string keyName, Keys newKey)
        {
            switch (keyName)
            {
                case "Exit":
                    Exit = newKey;
                    break;
                case "Left":
                    Left = newKey;
                    break;
                case "Right":
                    Right = newKey;
                    break;
                case "Up":
                    Up = newKey;
                    break;
                case "Down":
                    Down = newKey;
                    break;
                case "Shoot":
                    Shoot = newKey;
                    break;
                case "Slow":
                    SlowMode = newKey;
                    break;
                case "Cheat":
                    CheatMode = newKey;
                    break;
                case "RefillHealth":
                    RefillHealth = newKey;
                    break;
                case "Clear":
                    ClearAllBullets = newKey;
                    break;
                default:
                    return;
            }
        }

        public static bool IsBinded(Keys key)
        {
            if (Exit == key || Left == key || Right == key || Up == key || Down == key || 
                Shoot == key || SlowMode == key || CheatMode == key ||RefillHealth == key || SlowMode == key || ClearAllBullets == key)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
