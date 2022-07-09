using System;
using System.Collections.Generic;
using System.Text;

namespace YameTools.Extensions
{
	public static class DecimalExtension
	{
		/// <summary>
		/// 無條件進位
		/// </summary>
		/// <param name="decimal"></param>
		/// <returns></returns>
		public static decimal RoundUp(this decimal @decimal)
		{
			return Math.Ceiling(@decimal);
		}

		/// <summary>
		/// 四捨五入
		/// </summary>
		/// <param name="decimal"></param>
		/// <param name="小數點幾位"></param>
		/// <returns></returns>
		public static decimal ToFixed(this decimal @decimal, int 小數點幾位 = 0)
		{
			return Math.Round(@decimal, 小數點幾位, MidpointRounding.AwayFromZero);
		}

		/// <summary>
		/// 0.75 變成 75%
		/// </summary>
		/// <param name="decimal"></param>
		/// <returns></returns>
		public static string ToPercentageDisplay(this decimal @decimal)
		{
			if (@decimal == 0) return "0%";

			return $"{@decimal * 100:#.####}%";
		}
	}
}
