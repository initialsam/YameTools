using System;
using System.Collections.Generic;
using System.Text;

namespace YameTools.Extensions
{
	public static class DoubleExtension
	{
		/// <summary>
		/// 無條件進位
		/// </summary>
		/// <param name="double"></param>
		/// <returns></returns>
		public static double RoundUp(this double @double)
		{
			return Math.Ceiling(@double);
		}

		/// <summary>
		/// 四捨五入
		/// </summary>
		/// <param name="decimal"></param>
		/// <param name="小數點幾位"></param>
		/// <returns></returns>
		public static double ToFixed(this double @double, int 小數點幾位 = 0)
		{
			return Math.Round(@double, 小數點幾位, MidpointRounding.AwayFromZero);
		}

		/// <summary>
		/// 0.75 變成 75%
		/// </summary>
		/// <param name="decimal"></param>
		/// <returns></returns>
		public static string ToPercentageDisplay(this double @double)
		{
			if (@double == 0) return "0%";

			return $"{@double * 100:#.####}%";
		}
	}
}
