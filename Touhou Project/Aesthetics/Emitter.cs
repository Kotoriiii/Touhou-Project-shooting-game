using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Touhou_Project.Aesthetics
{
    public abstract class Emitter: Component
    {
        public float speed = 0.005f;
        public float velocity = 1;
        public int numOfParticles = 1000;
        public Particle particle;
        public List<Particle> particles;

        private float spanwnTimer;
        private float rotateTimer;

        public Emitter(Particle particle)
        {
            this.particle = particle;
            this.particles = new List<Particle>();
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (var particle in this.particles)
            {
                particle.Draw(gameTime, spriteBatch);
            }
        }

        public override void Update(GameTime gameTime)
        {
            this.spanwnTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            this.rotateTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            this.AddParticle();

            if (this.rotateTimer > this.velocity)
            {
                this.rotateTimer = 0;
                this.GenerateVelocity();
            }

            foreach (var particle in this.particles)
            {
                particle.Update(gameTime);
            }
            this.RemovedParticles();
        }

        protected abstract void GenerateVelocity();

        private void RemovedParticles()
        {
            for (int i = 0; i < this.particles.Count; i++)
            {
                if (this.particles[i].IsRemoved)
                {
                    this.particles.RemoveAt(i);
                    i--;
                }
            }
        }

        protected abstract Particle GenerateParticle();

        private void AddParticle()
        {
            if (this.spanwnTimer > this.speed)
            {
                this.spanwnTimer = 0;

                if (this.particles.Count < this.numOfParticles)
                {
                    this.particles.Add(this.GenerateParticle());
                }
            }
        }
    }
}
