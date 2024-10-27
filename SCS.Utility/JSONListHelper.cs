namespace SCS.Utility
{
    public static class JSONListHelper
    {
        public static string GetEventListJSONString(List<CalendarData> events)
        {
            var eventList = new List<CalendarData>();
            foreach (var model in events)
            {
                var myEvents = new CalendarData()
                {
                    id = model.id,
                    title = model.title,
                    start = model.start,
                    end = model.end,
                };
                eventList.Add(myEvents);
            }
            return System.Text.Json.JsonSerializer.Serialize(eventList);
        }
    }

    public class CalendarData
    {
        public int id { get; set; }
        public string title { get; set; } = "";
        public DateOnly start { get; set; }
        public DateOnly end { get; set; }
    }
}

