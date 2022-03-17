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
    public class SearchEntryHandler : IRequestHandler<SearchEntryQuery, IEnumerable<Domain.Entities.Entry>>
    {
        private readonly IPhoneBookRepository _phoneBookRepository;

        public SearchEntryHandler(IPhoneBookRepository phoneBookRepository)
        {
            _phoneBookRepository = phoneBookRepository;
        }
        public async Task<IEnumerable<Domain.Entities.Entry>> Handle(SearchEntryQuery request, CancellationToken cancellationToken)
        {
            return await _phoneBookRepository.SearchEntryAsync(request.SearchEntryRequest.SearchText, cancellationToken);
        }
    }
}
