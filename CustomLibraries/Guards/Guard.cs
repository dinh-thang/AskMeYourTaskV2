using System.Collections.Generic;
using System;

namespace CustomLibraries.Guards
{
    public static class Guard
    {
        public static void AgainstNull(object? arg, string argName)
        {
            ArgumentNullException.ThrowIfNull(arg, argName);
        }
    }
}
