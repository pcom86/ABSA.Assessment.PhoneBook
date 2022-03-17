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
    public class GetPhoneBookEntryByIdHandler : IRequestHandler<GetPhoneBookEntryByIdQuery, Domain.Entities.Entry>
    {
        private readonly IPhoneBookRepository _phoneBookRepository;

        public GetPhoneBookEntryByIdHandler(IPhoneBookRepository phoneBookRepository)
        {
            _phoneBookRepository = phoneBookRepository;
        }
        public async Task<Domain.Entities.Entry> Handle(GetPhoneBookEntryByIdQuery request, CancellationToken cancellationToken)
        {
            return await _phoneBookRepository.GetPhoneBookEntryAsync(request.GetPhoneEntryByIdRequest.entryId, cancellationToken);
        }
    }
}
