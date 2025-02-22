using Microsoft.EntityFrameworkCore;
using StarSecurityServices.Data;
using StarSecurityServices.Models;

namespace StarSecurityServices.BussinessLayer
{
    public class ContactRepository : IContactRepository
    {
        private readonly AuthContext _context;

        public ContactRepository(AuthContext context)
        {
            _context = context;
        }

        public async Task<List<Contact>> GetAllAsync()
        {
            return await _context.Contacts.ToListAsync();
        }

        public async Task<Contact> GetByIdAsync(int id)
        {
            return await _context.Contacts.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task AddAsync(Contact contact)
        {
            _context.Add(contact);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Contact contact)
        {
            _context.Update(contact);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact != null)
            {
                _context.Contacts.Remove(contact);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Contacts.AnyAsync(c => c.Id == id);
        }
    }

}
