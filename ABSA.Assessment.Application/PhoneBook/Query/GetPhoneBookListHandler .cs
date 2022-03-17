using ABSA.Assessment.Domain.Entities;
using ABSA.Assessment.Domain.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ABSA.Assessment.Application.PhoneBook.Query
{
    public class GetPhoneBookListHandler : IRequestHandler<GetPhoneBookListQuery, IEnumerable<Domain.Entities.PhoneBook>>
    {
        private readonly IPhoneBookRepository _phoneBookRepository;

        public GetPhoneBookListHandler(IPhoneBookRepository phoneBookRepository)
        {
            _phoneBookRepository = phoneBookRepository;
        }
        public async Task<IEnumerable<Domain.Entities.PhoneBook>> Handle(GetPhoneBookListQuery request, CancellationToken cancellationToken)
        {
            return await _phoneBookRepository.GetPhoneBookListAsync(cancellationToken);
        }
    }
}
