using System;
using System.Collections.Generic;

namespace ScheduleWpfApp.Models;

public partial class Session
{
    public int IdSession { get; set; }

    public int IdFilm { get; set; }

    public byte IdCinemaHall { get; set; }

    public decimal Price { get; set; }

    public DateTime Datetime { get; set; }

    public bool Is3D { get; set; }

    public virtual CinemaHall Halls { get; set; } = null!;

    public virtual Film Films { get; set; } = null!;
}
