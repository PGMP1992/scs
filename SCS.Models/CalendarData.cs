// Created to Load the Cert Slots into calendar - PM
namespace SCS.Models
{
    public class CalendarData
    {
        public int id { get; set; }
        public string title { get; set; }
        public DateOnly start { get; set; }
        public DateOnly end { get; set; }
    }
}
