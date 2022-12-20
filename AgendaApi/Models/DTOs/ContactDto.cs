namespace AgendaApi.Models.DTOs;

public class ContactDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public long? CellPhoneNumber { get; set; }
    public long? TelephoneNumber { get; set; }
    public string? Description { get; set; }
    public int? ContactsBookId { get; set; }
}