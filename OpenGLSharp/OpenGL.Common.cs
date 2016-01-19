using System;

namespace OpenGL
{
	public partial class GL
	{
		// Required to allow platforms other than iOS use the same code.
		// just don't include this on iOS
		[AttributeUsage (AttributeTargets.Delegate)]
		public sealed class MonoNativeFunctionWrapper : Attribute {
		}
	}
}

