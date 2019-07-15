﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NestedObjectsSample
{
    class Student
    {
        public string FulllName { get; set; }

        public string EmailAddress { get; set; }

        public string HomeAddress { get; set; }

        /// <summary>
        /// The students Home phone number
        /// </summary>
        public string Phone { get; set; }
    }
}
