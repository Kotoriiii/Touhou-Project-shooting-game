using System;
using Microsoft.Xna.Framework;

namespace Touhou_Project.Aesthetics
{
    public class SnowEmitter : Emitter
    {
        public static Random rand = new Random();

        public SnowEmitter(Particle particle)
          : base(particle)
        {
        }

        protected override void GenerateVelocity()
        {
            var xRotation = (float)rand.Next(-2, 2);
            foreach (var particle in this.particles)
            {
                particle.Velocity.X = (xRotation * particle.Scale) / 50;
            }
        }

        protected override Particle GenerateParticle()
        {
            var sprite = this.particle.Clone() as Particle;
            var positionX = rand.Next(0, 1000);
            var speedY = rand.Next(10, 100) / 100f;

            sprite.Position = new Vector2(positionX, -sprite.Rectangle.Height);
            sprite.Velocity = new Vector2(0, speedY);
            sprite.Rotation = MathHelper.ToRadians(rand.Next(0, 360));
            sprite.Opacity = (float)rand.NextDouble();
            sprite.Scale = (float)rand.NextDouble() + rand.Next(0, 3);
            return sprite;
        }
    }
}
