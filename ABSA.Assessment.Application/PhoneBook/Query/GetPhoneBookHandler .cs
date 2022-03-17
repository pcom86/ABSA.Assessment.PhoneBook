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
    public class GetPhoneBookHandler : IRequestHandler<GetPhoneBookQuery, Domain.Entities.PhoneBook>
    {
        private readonly IPhoneBookRepository _phoneBookRepository;

        public GetPhoneBookHandler(IPhoneBookRepository phoneBookRepository)
        {
            _phoneBookRepository = phoneBookRepository;
        }
        public async Task<Domain.Entities.PhoneBook> Handle(GetPhoneBookQuery request, CancellationToken cancellationToken)
        {
            return await _phoneBookRepository.GetPhoneBookAsync(request.GetPhoneBookRequest.PhoneBookId, cancellationToken);
        }
    }
}
