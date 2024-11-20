using ScheduleWpfApp.Data;
using ScheduleWpfApp.Models;
using Microsoft.EntityFrameworkCore;
using ScheduleWpfApp.DTOs;

namespace ScheduleWpfApp.Services
{
    public class SessionService
    {
        private readonly CinemaContext _context = new();

        //public IQueryable<Session> GetAll()
        //    => _context.Sessions
        //    .Include(c => c.IdFilm)
        //    .Include(c => c.IdCinemaHall)
        //    .AsQueryable();

        public async Task<List<Session>> GetAll()
            => await _context.Sessions.ToListAsync();

        public async Task<List<DateTime>> GetDateBySession()
            => await _context.Sessions.Select( s => s.Datetime).Distinct().ToListAsync();

        public async Task<List<string>> GetCinemaHallsAsync()
            => await _context.CinemaHalls.Select(h => h.Cinema).Distinct().ToListAsync();

        //public async Task<List<SessionDto>> GetAllByCinema(DateTime date, string cinema)
        //    => await _context.Sessions
        //    .Include(c => c.Films)
        //    .Include(c => c.Halls)
        //    .Where(s => s.Datetime.Date == date.Date)
        //    .Where(s => s.Halls.Cinema == cinema)
        //    .Select(s => new SessionDto()
        //    {
        //        Id = s.IdSession,
        //        FilmName = s.Films.FilmName,
        //        HallNumber = s.Halls.HallNumber,
        //        Start = s.Datetime.TimeOfDay,
        //        Price = s.Price
        //    })
        //    .OrderBy(s => s.FilmName)
        //    .ThenBy(s => s.Start)
        //    .ToListAsync();
    }
}
