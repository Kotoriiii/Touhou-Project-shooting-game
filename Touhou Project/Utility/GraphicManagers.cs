using System;
using System.Collections.Generic;
using System.Text;

namespace Touhou_Project
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal class GraphicManagers
    {
        public static GraphicsDeviceManager GraphicsDeviceManager { get; set; }

        public static GraphicsDevice GraphicsDevice { get => GraphicsDeviceManager.GraphicsDevice; }
    }
}

