using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
namespace Touhou_Project
{
    internal class UtlilityManager
    {
        public static void Initialize(ContentManager content, GraphicsDeviceManager graphicsDeviceManager)
        {
            TextureFactory.Content = content;
            GraphicManagers.GraphicsDeviceManager = graphicsDeviceManager;
        }
    }
}
