namespace TicketBookingApp.Models;

public class Event
{
    public required int Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required DateTime Date { get; set; }
    public required decimal Price { get; set; }
}