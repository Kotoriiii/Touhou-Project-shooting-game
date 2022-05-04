using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Touhou_Project.Sprites
{
    public class BulletMovementStrategy
    {
        private List<String> bulletMoveLinear = new List<String>();
        private List<String> bulletMoveRadical = new List<String>();
        private List<String> bulletMoveCircular = new List<String>(); // need new type of bullet attack pattern
        private List<String> bulletMoveSpiral = new List<String>();
        private List<String> bulletMoveLinearThenMoveRadical = new List<String>();
        private List<String> bulletMoveRadicalThenMoveSpiral = new List<String>();
        // more combination of movements ...

        public BulletMovementStrategy()
        {

        }

        public List<String> bulletMovementBuilder(string movement)
        {
            if(movement == "Linear")
            {
                getBulletMoveLinear();
                return this.bulletMoveLinear;
            }
            else if (movement =="Radical")
            {
                getBulletMoveRadical();
                return this.bulletMoveRadical;
            }
            else if (movement == "Circular")
            {
                getBulletMoveCircular();
                return this.bulletMoveCircular;
            }
            else if (movement == "Spiral")
            {
                getBulletMoveSpiral();
                return this.bulletMoveSpiral;
            } 
            else if (movement == "LinearThenRadical")
            {
                getBulletMoveLinearThenMoveRadical();
                return this.bulletMoveLinearThenMoveRadical;
            }
            else if (movement == "RadicalThenSpiral")
            {
                getBulletMoveRadicalThenMoveSpiral();
                return this.bulletMoveRadicalThenMoveSpiral;
            }
            else
            {
                return this.bulletMoveLinear;
            }
        }

        public List<String> getBulletMoveLinear()
        {
            bulletMoveLinear.Add("regular");
            return bulletMoveLinear;
        }

        public List<String> getBulletMoveRadical()
        {
            bulletMoveRadical.Add("sweep");
            return bulletMoveRadical;
        }

        public List<String> getBulletMoveCircular()
        {
            bulletMoveCircular.Add("circular");
            return bulletMoveCircular;
        }


        public List<String> getBulletMoveSpiral()
        {
            bulletMoveSpiral.Add("spiral");
            return bulletMoveSpiral;
        }

        public List<String> getBulletMoveLinearThenMoveRadical()
        {
            bulletMoveLinearThenMoveRadical.Add("regular");
            bulletMoveLinearThenMoveRadical.Add("sweep");
            return bulletMoveLinearThenMoveRadical;
        }

        public List<String> getBulletMoveRadicalThenMoveSpiral()
        {
            bulletMoveRadicalThenMoveSpiral.Add("sweep");
            bulletMoveRadicalThenMoveSpiral.Add("spiral");
            return bulletMoveRadicalThenMoveSpiral;
        }
    }
}
