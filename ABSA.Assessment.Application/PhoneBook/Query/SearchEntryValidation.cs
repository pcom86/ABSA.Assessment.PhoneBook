using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABSA.Assessment.Application.PhoneBook.Query
{
  public  class SearchEntryValidation : AbstractValidator<SearchEntryRequest>
    {
        public SearchEntryValidation()
        {
            RuleFor(x => x.SearchText).Empty();
        }

    }
}
