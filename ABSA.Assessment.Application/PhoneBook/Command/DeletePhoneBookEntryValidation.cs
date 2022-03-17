using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABSA.Assessment.Application.PhoneBook.Command
{
  public  class DeletePhoneBookEntryValidation : AbstractValidator<DeletePhoneBookEntryRequest>
    {
        public DeletePhoneBookEntryValidation()
        {
            RuleFor(x => x.EntryId).NotEmpty();
        }
    }
}
