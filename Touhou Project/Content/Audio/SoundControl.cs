using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

namespace Touhou_Project
{
    public class SoundControl
    {

        public SoundItem bgm;
        public List<SoundItem> soundItem = new List<SoundItem>();

        public SoundControl(string musicPath)
        {

            if(musicPath != "")
            {
                ChangeMusic(musicPath);
            }
        }

        public void ChangeMusic(string musicPath)
        {
            bgm = new SoundItem("BGM",musicPath, 0.25f); // BGM音量在这改
            bgm.CreateInstance();

            bgm.instance.Volume = bgm.volume;
            bgm.instance.IsLooped = true;
            bgm.instance.Play();
        }

        public void AddSound(string soundName, string musicPath, float vol)
        {
            soundItem.Add(new SoundItem(soundName, musicPath, vol));
        }

        public void PlaySound(string soundName)
        {
            for(int i=0;i<soundItem.Count;i++)
            {
                if(soundItem[i].name== soundName)
                {
                    soundItem[i].CreateInstance();  //如果没有这个的话，每次子弹发射的音效都需要等待上一个音效结束后才能生效。
                    RunSound(soundItem[i].sound, soundItem[i].instance);
                }
            }
        }

        public void RunSound(SoundEffect SOUND, SoundEffectInstance INSTANCE)
        {
            INSTANCE.Volume = 1f;
            INSTANCE.Play();
        }
    }
}
