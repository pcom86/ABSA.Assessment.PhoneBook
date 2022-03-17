using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABSA.Assessment.Application.PhoneBook.Command
{
    public class CreatePhoneBookEntryValidation : AbstractValidator<CreatePhoneBookEntryRequest>
    {
        public CreatePhoneBookEntryValidation()
        {
            RuleFor(x => x.Entry.Name).Empty();
            RuleFor(x => x.Entry.PhoneNumber).Empty();
        }

    }

}
