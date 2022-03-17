using ABSA.Assessment.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABSA.Assessment.Application.PhoneBook.Query
{
   public class SearchPhoneBookQuery : IRequest<IEnumerable<Domain.Entities.PhoneBook>>
    {
        public SearchPhoneBookRequest GetPhoneBookEntryRequest { get; set; }

    }
}
