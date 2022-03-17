using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABSA.Assessment.Application.PhoneBook.Command
{
  public  class UpdatePhoneBookValidation : AbstractValidator<UpdatePhoneBookRequest>
    {
        public UpdatePhoneBookValidation()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.PhoneBookId).NotEmpty();
        }
    }
}
