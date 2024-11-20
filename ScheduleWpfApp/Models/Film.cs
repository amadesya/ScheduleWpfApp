using System;
using System.Collections.Generic;

namespace ScheduleWpfApp.Models;

public partial class Film
{
    public int IdFilm { get; set; }

    public string FilmName { get; set; } = null!;

    public short FilmDuration { get; set; }

    public short YearPublication { get; set; }

    public string? FilmDescription { get; set; }

    public string? Poster { get; set; }

    public string? AgeRating { get; set; }

    public DateOnly? RentalBeggining { get; set; }

    public DateOnly? RentalEnd { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();
}
