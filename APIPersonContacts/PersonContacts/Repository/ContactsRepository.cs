using Microsoft.EntityFrameworkCore;
using PersonContacts.Data;

namespace PersonContacts.Repository
{
    internal class ContactsRepository
    {
        internal async static Task<List<Contact>> GetContactsAsync()
        {
            using (var db = new AppDBContext())
            {
                return await db.Contacts.ToListAsync();
            }
        }

        internal async static Task<Contact> GetContactByIdAsync(int contactId)
        {
            using (var db = new AppDBContext())
            {
                return await db.Contacts.FirstOrDefaultAsync(contact => contact.ContactId == contactId);
            }
        }

        internal async static Task<bool> CreateContactAsync(Contact contactToCreate)
        {
            using (var db = new AppDBContext())
            {
                try
                {
                    await db.Contacts.AddAsync(contactToCreate);

                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }
        internal async static Task<bool> UpdateContactAsync(Contact contactToUpdate)
        {
            using (var db = new AppDBContext())
            {
                try
                {
                    db.Contacts.Update(contactToUpdate);

                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        internal async static Task<bool> DeletePostAsync(int contactId)
        {
            using (var db = new AppDBContext())
            {
                try
                {
                    Contact contactToDelete = await GetContactByIdAsync(contactId);

                    db.Remove(contactToDelete);

                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }
    }
}