using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GamepadControl.Structs
{
    [StructLayout(LayoutKind.Sequential,Pack =2,Size =12)]
    public struct GamePad
    {
        public uint wButtons;
        public byte bLeftTrigger;
        public byte bRightTrigger;
        public short sThumbLX;
        public short sThumbLY;
        public short sThumbRX;
        public short sThumbRY;
    }
 
}
