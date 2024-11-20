using System;
using System.Collections.Generic;

namespace ScheduleWpfApp.Models;

public partial class CinemaHall
{
    public byte IdCinemaHall { get; set; }

    public string Cinema { get; set; } = null!;

    public byte HallNumber { get; set; }

    public byte RowsAmount { get; set; }

    public byte RowPlaceAmount { get; set; }

    public bool IsVip { get; set; }

    public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();
}
