// <copyright file="KeyBinding.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EverLite.Modules.Input
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.Xna.Framework.Input;

    class KeyBinding //: Binding
    {
        Keys key;

        public KeyBinding(Keys key)
        {
            this.key = key;
        }

        public bool IsPressed()
        {
            return Keyboard.GetState().IsKeyDown(key);
        }
    }
}
