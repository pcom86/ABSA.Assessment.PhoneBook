using ABSA.Assessment.Domain.Dto;
using ABSA.Assessment.Domain.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ABSA.Assessment.Application.PhoneBook.Command
{
    public class CreatePhoneBookEntryHandler : IRequestHandler<CreatePhoneBookEntryCommand, int>
    {
        private readonly IPhoneBookRepository _phoneBookRepository;

        public CreatePhoneBookEntryHandler(IPhoneBookRepository phoneBookRepository)
        {
            _phoneBookRepository = phoneBookRepository;
        }
        public async Task<int> Handle(CreatePhoneBookEntryCommand request, CancellationToken cancellationToken)
        {
            return await _phoneBookRepository.CreatePhoneBookEntryAsync(request.CreatePhoneBookEntryCommandRequest.Entry, cancellationToken);
        }
    }
}
