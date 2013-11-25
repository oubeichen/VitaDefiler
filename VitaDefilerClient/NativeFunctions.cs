using System;
using System.Security;
using System.Security.Permissions;
using System.Runtime.InteropServices;

[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification=true)]
namespace VitaDefilerClient
{
	public class NativeFunctions
	{
		[SecurityCritical]
		public static IntPtr AllocData(int length)
		{
			return Marshal.AllocHGlobal(length);
		}

		[SecurityCritical]
		public static void FreeData(IntPtr ptr)
		{
			Marshal.FreeHGlobal(ptr);
		}

		[SecurityCritical]
		public static void Read(IntPtr src, byte[] dest, int offset)
		{
			Marshal.Copy(src, dest, offset, dest.Length);
		}

		[SecurityCritical]
		public static void Write(IntPtr dest, byte[] src, int offset)
		{
			Marshal.Copy(src, offset, dest, src.Length-offset);
		}

		[SecurityCritical]
		public unsafe static int Execute(IntPtr addr, int arg0, int arg1, int arg2, int arg3)
		{
			/*
			ldarg 4
			ldarg.3
			ldarg.2
			ldarg.1
			ldarg.0
			calli int32 (native int, native int, native int, native int)
			ret
			*/
			return 0;
		}
	}
}