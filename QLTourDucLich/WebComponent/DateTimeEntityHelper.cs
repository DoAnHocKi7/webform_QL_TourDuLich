﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebComponent
{
    public class DateTimeEntityHelper
    {
        public static Boolean Compare(DateTime date1, DateTime date2)
        {
            return date1.Year == date2.Year && date1.Month == date2.Month && date1.Day == date2.Day;
        }
    }
}
