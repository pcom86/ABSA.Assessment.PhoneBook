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
    public class CreatePhoneBookHandler : IRequestHandler<CreatePhoneBookCommand, int>
    {
        private readonly IPhoneBookRepository _phoneBookRepository;

        public CreatePhoneBookHandler(IPhoneBookRepository phoneBookRepository)
        {
            _phoneBookRepository = phoneBookRepository;
        }
        public async Task<int> Handle(CreatePhoneBookCommand request, CancellationToken cancellationToken)
        {
            return await _phoneBookRepository.CreatePhoneBookAsync(new AddPhoneBookDto
            {
                Name = request.CreatePhoneBookCommandRequest.Name  
            }, cancellationToken);
        }
    }
}
