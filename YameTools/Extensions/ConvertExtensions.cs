using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YameTools.Extensions;

public static class ConvertExtensions
{
    public static T ConvertValue<T>(this object value,T defaultValue = default)
    {
        var type = typeof(T);
		try
		{
			var nullableType = Nullable.GetUnderlyingType(type);
			if (nullableType is not null)
			{
                return (T)Convert.ChangeType(value, nullableType);
			}

            return (T)Convert.ChangeType(value, type);
        }
		catch
		{
			return defaultValue;
        }
    }
}
