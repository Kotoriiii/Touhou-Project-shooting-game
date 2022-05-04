using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
namespace Touhou_Project
{
    public class SoundItem
    {
        public string name;
        public float volume;
        public SoundEffect sound;
        public SoundEffectInstance instance;

        public SoundItem(string soundName, string musicPath, float vol)
        {
            name = soundName;
            volume = vol;
            sound = TextureFactory.Content.Load<SoundEffect>(musicPath);
            CreateInstance();
        }

        public void CreateInstance()
        {
            instance = sound.CreateInstance();
        }
    }
}
