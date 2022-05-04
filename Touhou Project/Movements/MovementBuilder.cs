using System;
using System.Collections.Generic;
using System.Text;

namespace Touhou_Project.Movements
{
    public class MovementBuilder
    {
        public MovementBuilder()
        {

        }
        public Stack<MovementStrategy> MovementGenerlizer(string strategy)
        {
            Stack<MovementStrategy> cur = new Stack<MovementStrategy>();
            //Movement1
            if (strategy == "PingPongThenVector")
                cur = Movement1();
            //Movement2
            if (strategy == "FOX")
                cur = Movement2();
            //Movement3
            if (strategy == "PingPong")
                cur = Movement3();
            //Movement4
            if (strategy == "PingPongThenStay")
                cur = Movement4();
            return cur; 
        }
        Stack<MovementStrategy> Movement1()
        {
            Stack<MovementStrategy> movementStrategy = new Stack<MovementStrategy>();
            movementStrategy.Push(new PingPongMovement());
            movementStrategy.Push(new VectorMovement());
            return movementStrategy;
        }
        Stack<MovementStrategy> Movement2()
        {
            Stack<MovementStrategy> movementStrategy = new Stack<MovementStrategy>();
            movementStrategy.Push(new FOX3Movement());
            return movementStrategy;
        }
        Stack<MovementStrategy> Movement3()
        {
            Stack<MovementStrategy> movementStrategy = new Stack<MovementStrategy>();
         
            movementStrategy.Push(new PingPongMovement());
            return movementStrategy;
        }
        Stack<MovementStrategy> Movement4()
        {
            Stack<MovementStrategy> movementStrategy = new Stack<MovementStrategy>();
            movementStrategy.Push(new PingPongMovement());
            movementStrategy.Push(new StayMovement());
            movementStrategy.Push(new PingPongMovement());
            movementStrategy.Push(new StayMovement());
            movementStrategy.Push(new PingPongMovement());
            return movementStrategy;
        }
    }
}
