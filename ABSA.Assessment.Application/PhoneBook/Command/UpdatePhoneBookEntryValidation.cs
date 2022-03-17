using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABSA.Assessment.Application.PhoneBook.Command
{
  public  class UpdatePhoneBookEntryValidation : AbstractValidator<UpdatePhoneBookEntryRequest>
    {
        public UpdatePhoneBookEntryValidation()
        {
            RuleFor(x => x.updateEntryDto.Name).NotEmpty();
            RuleFor(x => x.updateEntryDto.PhoneBookId).NotEmpty();
            RuleFor(x => x.updateEntryDto.EntryId).NotEmpty();
            RuleFor(x => x.updateEntryDto.PhoneNumber).NotEmpty();
        }
    }
}
