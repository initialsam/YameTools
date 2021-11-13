using System;
using System.Collections.Generic;
using System.Text;

namespace YameTools.Format
{
    public class DateTimeFormatSetting
    {
        public virtual string DateFormatWithoutYear => "MM/dd";
        public virtual string DateFormat => "yyyy/MM/dd";
        public virtual string DateFormatWithoutSlash => "yyyyMMdd";
        public virtual string DateFormatForSmarteraspDb => "M_d_yyyy";
        public virtual string DateTimeFormat => "yyyy/MM/dd HH:mm";
        public virtual string DateTimeFileName => "yyyy_MM_dd_HH_mm_ss";
        public virtual string TimeFormat => "HH:mm";
    }


}
