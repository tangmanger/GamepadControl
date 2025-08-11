using GamepadControl.Enums;
using GamepadControl.Interfaces;
using GamepadControl.Models.Inputs;
using GamepadControl.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GamepadControl.Models
{
    public abstract class BaseXInputModel : IXInput
    {
        // 定义一个与非托管函数签名匹配的委托
        [UnmanagedFunctionPointer(CallingConvention.StdCall)] // 或者 CallingConvention.StdCall，取决于DLL的导出方式
        public delegate int GetStateEx(UserIndex param1, out GamePadState param2);
        [DllImport("kernel32", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern IntPtr LoadLibrary(string lpFileName);
        // 导入 GetProcAddress 函数
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr GetProcAddress(IntPtr hModule, int lpProcName);

        // 导入 FreeLibrary 函数
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool FreeLibrary(IntPtr hModule);
        public abstract string DllName { get; }
        UserIndex _userIndex;
        public UserIndex UserIndex => _userIndex;
        public string Msg { get; set; }
        public bool IsInit { get; set; }
    
        public BaseXInputModel(UserIndex userIndex)
        {
            _userIndex = userIndex;
            if (!Load())
            {
                Msg = $"加载{DllName}失败！";
            }
            else
            {
                IsInit = true;
            }
        }
        public IntPtr DllPtr { get; set; }
        public bool Load()
        {
            DllPtr = LoadLibrary(DllName);
            if (DllPtr != IntPtr.Zero)
                return true;
            return false;
        }
        public abstract int XInputGetState(out GamePadState gamePadState);
        public abstract int XInputGetState(UserIndex userIndex, out GamePadState gamePadState);
        public bool IsConnected
        {
            get
            {
                GamePadState stateRef;
                return XInputGetState(out stateRef) == 0;
            }
        }
    }
}
