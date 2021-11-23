using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Resources;
using System.Text;

namespace YameTools.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this String Input) => String.IsNullOrEmpty(Input);
        public static bool IsNullOrWhiteSpace(this String Input) => String.IsNullOrWhiteSpace(Input);
        
        public static bool HasValue(this String Input) => String.IsNullOrEmpty(Input) == false;
    }
}
