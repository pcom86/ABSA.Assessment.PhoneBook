﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABSA.Assessment.Domain.Dto
{
    public class AddEntryDto
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public int PhoneBookId { get; set; }
    }
}
