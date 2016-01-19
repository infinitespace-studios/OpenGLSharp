using System;
using System.Runtime.InteropServices;
using System.Security;

namespace OpenGL
{
	public partial class GL
	{
		static partial void LoadPlatformEntryPoints()
		{
			BoundApi = RenderApi.GL;
		}
	}

	internal class EntryPointHelper {
		[SuppressUnmanagedCodeSecurity]
		[DllImport("SDL2.dylib", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GL_GetProcAddress", ExactSpelling = true)]
		public static extern IntPtr GetProcAddress(IntPtr proc);
		public static IntPtr GetAddress(string proc)
		{
			IntPtr p = Marshal.StringToHGlobalAnsi(proc);
			try
			{
				var addr = GetProcAddress(p);
				if (addr == IntPtr.Zero)
					throw new EntryPointNotFoundException (proc);
				return addr;
			}
			finally
			{
				Marshal.FreeHGlobal(p);
			}
		}
	}
}

