#region References
using System;
#endregion

namespace Server
{
    public static class ShardSettings
	{
		[CallPriority(Int32.MinValue)]
		public static void Configure()
		{
			Core.OnExpansionChanged += Invalidate;
			
			Invalidate();
		}

		public static void Invalidate()
		{
			if (Core.AOS)
			{
				Mobile.VisibleDamageType = VisibleDamageType.Related;

				Mobile.AOSStatusHandler = AOS.GetStatus;
			}
			else
			{
				Mobile.VisibleDamageType = VisibleDamageType.None;

				Mobile.AOSStatusHandler = null;
			}
		}
    }
}
