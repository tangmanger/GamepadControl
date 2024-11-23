using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GamepadControl.Structs
{
    public struct GamePadState
    {
        public uint dwPacketNumber;
        
        public GamePad Gamepad;
    }
}
