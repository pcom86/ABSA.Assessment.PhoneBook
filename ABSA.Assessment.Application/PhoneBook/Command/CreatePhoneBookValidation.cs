using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABSA.Assessment.Application.PhoneBook.Command
{
  public  class CreatePhoneBookValidation : AbstractValidator<CreatePhoneBookRequest>
    {
        public CreatePhoneBookValidation()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
