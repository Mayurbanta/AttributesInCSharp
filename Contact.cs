using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace ProjAttributes
{
    [DebuggerDisplay("Display Name = {Name} and Age in Years = {Age}")]
    public class Contact
    {   
        [Display("First Name: ", ConsoleColor.Red)]
        public string Name { get; set; }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public int Age { get; set; }
    }
}
