using System;
using System.Collections.Generic;
using System.Text;

namespace EverLite.Modules.Input
{
    interface IButtonController
    {
        void Shoot();

        void MoveUp();

        void MoveDown();

        void MoveRight();

        void MoveLeft();

    }
}
