using System;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using static CSimple.SDK.Util;

namespace CSimple.SDK
{
   public static class Memory
    {
        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll")]
        private static extern bool ReadProcessMemory(int hProcess, int lpBaseAddress, byte[] buffer, int size, ref int lpNumberOfBytesRead);

        [DllImport("kernel32.dll")]
        private static extern bool WriteProcessMemory(int hProcess, int lpBaseAddress, byte[] buffer, int size, out int lpNumberOfBytesWritten);

        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(int vKey);

        public static Process g_pProcess;
        public static IntPtr g_pProcessHandle;
        public static IntPtr g_pClient;
        public static IntPtr g_pEngine;
        public static int m_iBytesRead = 0;
        public static int m_iBytesWrite = 0;

        public static T ReadMemory<T>(int Adress) where T : struct
        {
            int ByteSize = Marshal.SizeOf(typeof(T)); 
            byte[] buffer = new byte[ByteSize]; 
            ReadProcessMemory((int)g_pProcessHandle, Adress, buffer, buffer.Length, ref m_iBytesRead);

            return  ByteArrayToStructure<T>(buffer);
        }

        public static void WriteMemory<T>(int Adress, object Value)
        {
            byte[] buffer = StructureToByteArray(Value);  

            WriteProcessMemory((int)g_pProcessHandle, Adress, buffer, buffer.Length, out m_iBytesWrite);
        }
    }
}
