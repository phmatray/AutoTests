using TicketBookingApp.Models;

namespace TicketBookingApp.Services;

public class EventService
{
    private readonly List<Event> _events =
    [
        new()
        {
            Id = 1,
            Title = "Rock Concert",
            Description = "An amazing rock concert",
            Date = DateTime.Now.AddDays(10),
            Price = 49.99m
        },
        new()
        {
            Id = 2,
            Title = "Art Exhibition",
            Description = "Modern art exhibition",
            Date = DateTime.Now.AddDays(20),
            Price = 29.99m
        },
        new()
        {
            Id = 3,
            Title = "Stand-up Comedy",
            Description = "Laugh out loud with the best comedians",
            Date = DateTime.Now.AddDays(5),
            Price = 39.99m
        }
    ];

    public IEnumerable<Event> GetEvents()
        => _events;

    public Event? GetEventById(int id)
        => _events.FirstOrDefault(e => e.Id == id);
}