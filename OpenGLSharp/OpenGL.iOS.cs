using System;
using System.Runtime.InteropServices;
using ObjCRuntime;

namespace OpenGL
{
	public partial class GL
	{
		static partial void LoadPlatformEntryPoints()
		{
			BoundApi = RenderApi.ES;
		}

		internal static class EntryPointHelper {
			
			static IntPtr GL = IntPtr.Zero;

			static EntryPointHelper () 
			{
				try {
					GL = Dlfcn.dlopen("/System/Library/Frameworks/OpenGLES.framework/OpenGLES", 0);
				} catch (Exception ex) {
					System.Diagnostics.Debug.WriteLine (ex.ToString());
				}
			}

			public static IntPtr GetAddress(String function)
			{
				if (GL == IntPtr.Zero)
					return IntPtr.Zero;

				return Dlfcn.dlsym (GL, function);
			}
		}
	}
}

