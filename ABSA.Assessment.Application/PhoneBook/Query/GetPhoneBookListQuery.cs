using ABSA.Assessment.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABSA.Assessment.Application.PhoneBook.Query
{
   public class GetPhoneBookListQuery : IRequest<IEnumerable<Domain.Entities.PhoneBook>>
    {

    }
}
