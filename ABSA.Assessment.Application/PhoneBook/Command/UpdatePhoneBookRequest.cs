using ABSA.Assessment.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABSA.Assessment.Application.PhoneBook.Command
{
   public class UpdatePhoneBookRequest
    {
        public string Name { get; set; }
        public int PhoneBookId { get; set; }
    }
}
