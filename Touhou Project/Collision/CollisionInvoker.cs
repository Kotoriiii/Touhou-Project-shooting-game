using System;
using System.Collections.Generic;
using System.Text;

namespace Touhou_Project.Collision
{
    public class CollisionInvoker
    {
        private CollisionCommand command;

        public CollisionInvoker()
        {
        }

        public void setCommand(CollisionCommand command)
        {
            this.command = command;
        }


        public void CollisionDetect()
        {
            this.command.execute();
        }
    }
}
