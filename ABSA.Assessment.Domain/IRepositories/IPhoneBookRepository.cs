using ABSA.Assessment.Domain.Dto;
using ABSA.Assessment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ABSA.Assessment.Domain.IRepositories
{
   public interface IPhoneBookRepository
    {
        Task<int> CreatePhoneBookAsync(AddPhoneBookDto  phoneBookDto, CancellationToken cancellationToken);
        Task<int> CreatePhoneBookEntryAsync(AddEntryDto addEntryDto, CancellationToken cancellationToken);
        Task<IEnumerable<PhoneBook>> SearchPhoneBookAsync(string searchText, CancellationToken cancellationToken);
         Task<IEnumerable<Entry>> SearchEntryAsync(string searchText, CancellationToken cancellationToken); 
        Task<bool> UpdatePhoneBookAsync(UpdatePhoneBookDto updatePhoneBook, CancellationToken cancellationToken);
        Task<bool> UpdatePhoneBookEntryAsync(UpdateEntryDto updateEntryDto, CancellationToken cancellationToken);
        Task<bool> DeletePhoneBookAsync(int phoneBookId, CancellationToken cancellationToken);
        Task<bool> DeletePhoneBookEntryAsync(int entryId, CancellationToken cancellationToken);
        Task<IEnumerable<PhoneBook>> GetPhoneBookListAsync(CancellationToken cancellationToken);
        Task<PhoneBook> GetPhoneBookAsync(int phoneBookId, CancellationToken cancellationToken);
        Task<Entry> GetPhoneBookEntryAsync(int entryId, CancellationToken cancellationToken);

    }
}
