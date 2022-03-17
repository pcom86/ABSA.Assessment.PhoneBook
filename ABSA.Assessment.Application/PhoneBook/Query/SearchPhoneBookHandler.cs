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
    public class SearchPhoneBookHandler : IRequestHandler<SearchPhoneBookQuery, IEnumerable<Domain.Entities.PhoneBook>>
    {
        private readonly IPhoneBookRepository _phoneBookRepository;

        public SearchPhoneBookHandler(IPhoneBookRepository phoneBookRepository)
        {
            _phoneBookRepository = phoneBookRepository;
        }
        public async Task<IEnumerable<Domain.Entities.PhoneBook>> Handle(SearchPhoneBookQuery request, CancellationToken cancellationToken)
        {
            return await _phoneBookRepository.SearchPhoneBookAsync(request.GetPhoneBookEntryRequest.SearchText, cancellationToken);
        }
    }
}
