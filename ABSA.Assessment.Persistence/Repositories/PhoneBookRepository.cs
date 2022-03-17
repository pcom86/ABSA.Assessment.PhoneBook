using ABSA.Assessment.DataLayer.Entities;
using ABSA.Assessment.Domain.Dto;
using ABSA.Assessment.Domain.Entities;
using ABSA.Assessment.Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ABSA.Assessment.Persistence.Repositories
{
    public class PhoneBookRepository : IPhoneBookRepository
    {
        private readonly ABSAContext _context;
        public PhoneBookRepository(ABSAContext context)
        {
            _context = context;

        }
        public async Task<int> CreatePhoneBookAsync(AddPhoneBookDto phoneBookDto, CancellationToken cancellationToken)
        {

            var phoneBook = new PhoneBook
            {
                Name = phoneBookDto.Name
            };
            _context.PhoneBooks.Add(phoneBook);

            await _context.SaveChangesAsync();
            return phoneBook.PhoneBookId;

        }

        public async Task<int> CreatePhoneBookEntryAsync(AddEntryDto addEntryDto, CancellationToken cancellationToken)
        {
            var entry = new Entry { Name = addEntryDto.Name, PhoneNumber = addEntryDto.PhoneNumber, PhoneBookId = addEntryDto.PhoneBookId };
            _context.Entries.Add(entry);
            await _context.SaveChangesAsync();
            return entry.EntryId;
        }

        public async Task<bool> DeletePhoneBookAsync(int phoneBookId, CancellationToken cancellationToken)
        {
            var phonebook = await _context.PhoneBooks.Where(x => x.PhoneBookId == phoneBookId).FirstOrDefaultAsync();
            _context.PhoneBooks.Remove(phonebook);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeletePhoneBookEntryAsync(int entryId, CancellationToken cancellationToken)
        {
            var entry = await _context.Entries.Where(x => x.EntryId == entryId).FirstOrDefaultAsync();
            _context.Entries.Remove(entry);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<PhoneBook>> SearchPhoneBookAsync(string searchText, CancellationToken cancellationToken)
        {
            return await _context.PhoneBooks.Include(e => e.Entries)
                        .Where(item =>  item.Name.Contains(searchText))
                        .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<Entry>> SearchEntryAsync(string searchText, CancellationToken cancellationToken)
        {
            return await _context.Entries
                        .Where(item => item.Name.Contains(searchText) || item.PhoneNumber.Contains(searchText))
                        .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<PhoneBook>> GetPhoneBookListAsync(CancellationToken cancellationToken)
        {
            return await _context.PhoneBooks.Include(x => x.Entries)
                        .ToListAsync(cancellationToken);
        }
        public async Task<PhoneBook> GetPhoneBookAsync(int phoneBookId, CancellationToken cancellationToken)
        {
            return await _context.PhoneBooks.Where(x => x.PhoneBookId == phoneBookId).Include(x => x.Entries)
                        .SingleOrDefaultAsync(cancellationToken);
        }

        public async Task<Entry> GetPhoneBookEntryAsync(int entryId, CancellationToken cancellationToken)
        {
            return await _context.Entries.Where(x => x.EntryId == entryId)
                        .SingleOrDefaultAsync(cancellationToken);
        }

        public async Task<bool> UpdatePhoneBookAsync(UpdatePhoneBookDto addPhoneBookDto, CancellationToken cancellationToken)
        {
            var phoneBook = new PhoneBook
            {
                Name = addPhoneBookDto.Name,
                PhoneBookId = addPhoneBookDto.PhoneBookId
            };
            _context.PhoneBooks.Update(phoneBook);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdatePhoneBookEntryAsync(UpdateEntryDto updateEntryDto, CancellationToken cancellationToken)
        {
            var phoneBookEntry = new Entry
            {
                Name = updateEntryDto.Name,
                PhoneBookId = updateEntryDto.PhoneBookId,
                EntryId = updateEntryDto.EntryId,
                PhoneNumber = updateEntryDto.PhoneNumber
            };
            _context.Entries.Update(phoneBookEntry);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
