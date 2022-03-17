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
    public class UpdatePhoneBookHandler : IRequestHandler<UpdatePhoneBookCommand, bool>
    {
        private readonly IPhoneBookRepository _phoneBookRepository;

        public UpdatePhoneBookHandler(IPhoneBookRepository phoneBookRepository)
        {
            _phoneBookRepository = phoneBookRepository;
        }
        public async Task<bool> Handle(UpdatePhoneBookCommand request, CancellationToken cancellationToken)
        {
            return await _phoneBookRepository.UpdatePhoneBookAsync(new UpdatePhoneBookDto
            {
                Name = request.UpdatePhoneBookRequest.Name  ,
                PhoneBookId = request.UpdatePhoneBookRequest.PhoneBookId
            }, cancellationToken);
        }
    }
}
