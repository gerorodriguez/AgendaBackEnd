using System.ComponentModel.DataAnnotations;

namespace AgendaApi.Entities;

public class ContactsBook
{
    public int Id { get; set; }
    
    public string Name { get; set; } = String.Empty;
    
    public int Code { get; set; }
    
    public ICollection<User> Users { get; set; }
    
    public ICollection<Contact> Contacts { get; set; }

}