namespace ScheduleWpfApp.DTOs
{
    public class SessionDto
    {
        public int Id { get; set; }
        public string FilmName { get; set; }    
        public string Cinema { get; set; }  
        public int HallNumber { get; set; } 
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
        public int Duration { get; set; }
        public decimal Price { get; set; }
    }
}
