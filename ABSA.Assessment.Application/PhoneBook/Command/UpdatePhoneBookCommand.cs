using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABSA.Assessment.Application.PhoneBook.Command
{
  public  class UpdatePhoneBookCommand : IRequest<bool>
    {
        public UpdatePhoneBookRequest UpdatePhoneBookRequest { get; set; }
    }
}
