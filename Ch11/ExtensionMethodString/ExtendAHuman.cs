﻿using System;
using System.Collections.Generic;
using System.Text;

// it's a good idea to put extension methods in their own namespace
namespace AmazingExtensions
{
    public static class ExtendAHuman
    {
        public static bool IsDistressCall(this string s)
        {
            if (s.Contains("Help!"))
                return true;
            else
                return false;
        }
    }
}
