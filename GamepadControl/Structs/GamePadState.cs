using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GamepadControl.Structs
{
    [StructLayout(LayoutKind.Sequential,Size =16)]
    public struct GamePadState
    {
        [MarshalAs(UnmanagedType.U4)]
        public uint dwPacketNumber;
        
        public GamePad Gamepad;
    }
}
