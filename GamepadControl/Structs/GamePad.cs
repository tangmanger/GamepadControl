using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GamepadControl.Structs
{
    [StructLayout(LayoutKind.Explicit,Size =12)]
    public struct GamePad
    {
        [FieldOffset(0)]
        public uint wButtons;
        [FieldOffset(2)]
        public byte bLeftTrigger;
        [FieldOffset(3)]
        public byte bRightTrigger;
        [FieldOffset(4)]
        public short sThumbLX;
        [FieldOffset(6)]
        public short sThumbLY;
        [FieldOffset(8)]
        public short sThumbRX;
        [FieldOffset(10)]
        public short sThumbRY;
    }
 
}
