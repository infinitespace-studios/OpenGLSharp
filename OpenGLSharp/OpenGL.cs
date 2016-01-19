using System;
using System.Runtime.InteropServices;
#if __IOS__
using ObjCRuntime;
#endif

namespace OpenGL
{
	public partial class GL
	{
		public enum RenderApi
		{
			ES = 12448,
			GL = 12450,
		}

		public static RenderApi BoundApi = RenderApi.GL;

		public enum EnableCap : int
		{
			PointSmooth = ((int)0x0B10),
			LineSmooth = ((int)0x0B20),
			CullFace = ((int)0x0B44),
			Lighting = ((int)0x0B50),
			ColorMaterial = ((int)0x0B57),
			Fog = ((int)0x0B60),
			DepthTest = ((int)0x0B71),
			StencilTest = ((int)0x0B90),
			Normalize = ((int)0x0BA1),
			AlphaTest = ((int)0x0BC0),
			Dither = ((int)0x0BD0),
			Blend = ((int)0x0BE2),
			ColorLogicOp = ((int)0x0BF2),
			ScissorTest = ((int)0x0C11),
			Texture2D = ((int)0x0DE1),
			PolygonOffsetFill = ((int)0x8037),
			RescaleNormal = ((int)0x803A),
			VertexArray = ((int)0x8074),
			NormalArray = ((int)0x8075),
			ColorArray = ((int)0x8076),
			TextureCoordArray = ((int)0x8078),
			Multisample = ((int)0x809D),
			SampleAlphaToCoverage = ((int)0x809E),
			SampleAlphaToOne = ((int)0x809F),
			SampleCoverage = ((int)0x80A0),
		}

		[Flags]
		public enum ClearBufferMask : int
		{
			DepthBufferBit = ((int)0x00000100),
			StencilBufferBit = ((int)0x00000400),
			ColorBufferBit = ((int)0x00004000),
		}

		[System.Security.SuppressUnmanagedCodeSecurity()]
		[MonoNativeFunctionWrapper]
		public delegate int EnableDelegate (EnableCap cap);
		public static EnableDelegate Enable;

		[System.Security.SuppressUnmanagedCodeSecurity()]
		[MonoNativeFunctionWrapper]
		internal delegate void ClearColorDelegate(Single red, Single green, Single blue, Single alpha);
		internal static ClearColorDelegate ClearColor;

		[System.Security.SuppressUnmanagedCodeSecurity()]
		[MonoNativeFunctionWrapper]
		internal delegate void ClearDelegate(ClearBufferMask mask);
		internal static ClearDelegate Clear;


		public static void LoadEntryPoints()
		{
			LoadPlatformEntryPoints ();
			Enable = (EnableDelegate)Marshal.GetDelegateForFunctionPointer (EntryPointHelper.GetAddress ("glEnable"), typeof(EnableDelegate));
			ClearColor = (ClearColorDelegate)Marshal.GetDelegateForFunctionPointer (EntryPointHelper.GetAddress ("glClearColor"), typeof(ClearColorDelegate));
			Clear = (ClearDelegate)Marshal.GetDelegateForFunctionPointer (EntryPointHelper.GetAddress ("glClear"), typeof(ClearDelegate));
		}

		static partial void LoadPlatformEntryPoints();
	}
}

