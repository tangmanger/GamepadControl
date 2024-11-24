using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamepadControl.Enums
{
    [Flags]
    public enum GamePadButton : ushort
    {
        None = 0,
        Up = 1,
        Down = 2,
        Left = 4,
        Right = 8,
        LeftShoulder= 256,
        RightShoulder= 512,
        Guide = 1024,
        A = 4096,
        B = 8192,
        Y = 32768,
        X = 16384
    }

}
