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
    public class DeletePhoneBookEntryHandler : IRequestHandler<DeletePhoneBookEntryCommand, bool>
    {
        private readonly IPhoneBookRepository _phoneBookRepository;

        public DeletePhoneBookEntryHandler(IPhoneBookRepository phoneBookRepository)
        {
            _phoneBookRepository = phoneBookRepository;
        }
        public async Task<bool> Handle(DeletePhoneBookEntryCommand request, CancellationToken cancellationToken)
        {
            return await _phoneBookRepository.DeletePhoneBookEntryAsync( request.DeletePhoneBookEntryRequest.EntryId, cancellationToken);
        }
    }
}
