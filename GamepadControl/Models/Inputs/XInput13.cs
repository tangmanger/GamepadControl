using GamepadControl.Enums;
using GamepadControl.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GamepadControl.Models.Inputs
{
    public class XInput13 : BaseXInputModel
    {

        const string dllName = "xinput1_3.dll";
        public override string DllName => dllName;
        UserIndex userIndex;
        GetStateEx getStateEx;

        public XInput13(UserIndex userIndex) : base(userIndex)
        {


            var intp = GetProcAddress(DllPtr, 100);
            getStateEx = (GetStateEx)Marshal.GetDelegateForFunctionPointer(intp, typeof(GetStateEx));
        }

        //[DllImport(dllName, CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetKeystroke")]
        //public static extern int XInputGetKeystroke(int dwUserIndex, int dwReserved, out Keystroke keystrokeRef);

        //[DllImport(dllName, CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetBatteryInformation")]
        //public static extern int XInputGetBatteryInformation(int dwUserIndex, BatteryDeviceType devType, out BatteryInformation batteryInformationRef);



        //[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
        //private static extern unsafe int XInputSetState_(int arg0, void* arg1);

        [DllImport(dllName, CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
        public static extern int GetState(UserIndex dwUserIndex, out GamePadState gamePadState);

        public override int XInputGetState(out GamePadState gamePadState)
        {
            return getStateEx(UserIndex, out gamePadState);
        }

        public override int XInputGetState(UserIndex userIndex, out GamePadState gamePadState)
        {
            return getStateEx(userIndex, out gamePadState);
        }

    
        //[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputEnable")]
        //public static extern void XInputEnable(RawBool arg0);

        //[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
        //public static extern int XInputGetCapabilities(int dwUserIndex, DeviceQueryType dwFlags, out Capabilities capabilitiesRef);
        //public override int XInputGetState(int dwUserIndex, out GamePadState gamePadState)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
