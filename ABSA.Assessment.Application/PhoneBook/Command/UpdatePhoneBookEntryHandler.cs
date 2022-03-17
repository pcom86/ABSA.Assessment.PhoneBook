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
    public class UpdatePhoneBookEntryHandler : IRequestHandler<UpdatePhoneBookEntryCommand, bool>
    {
        private readonly IPhoneBookRepository _phoneBookRepository;

        public UpdatePhoneBookEntryHandler(IPhoneBookRepository phoneBookRepository)
        {
            _phoneBookRepository = phoneBookRepository;
        }
        public async Task<bool> Handle(UpdatePhoneBookEntryCommand request, CancellationToken cancellationToken)
        {
            return await _phoneBookRepository.UpdatePhoneBookEntryAsync(new UpdateEntryDto
            {
                Name = request.UpdatePhoneBookEntryRequest.updateEntryDto.Name,
                PhoneNumber = request.UpdatePhoneBookEntryRequest.updateEntryDto.PhoneNumber,
                EntryId = request.UpdatePhoneBookEntryRequest.updateEntryDto.EntryId,
                PhoneBookId = request.UpdatePhoneBookEntryRequest.updateEntryDto.PhoneBookId,
            }, cancellationToken);
        }
    }
}
