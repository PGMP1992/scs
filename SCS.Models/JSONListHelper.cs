using SCS.Models;

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

        //public static string GetResourceListJSONString(List<Models.Location> locations)
        //{
        //    var resourcelist = new List<Resource>();

        //    foreach (var loc in locations)
        //    {
        //        var resource = new Resource()
        //        {
        //            id = loc.Id,
        //            title = loc.Name
        //        };
        //        resourcelist.Add(resource);
        //    }
        //    return System.Text.Json.JsonSerializer.Serialize(resourcelist);
        //}
    }

    public class Event
    {
        //public int id { get; set; }
        //public string title { get; set; }
        //public DateTime start { get; set; }
        //public DateTime end { get; set; }
        //public int resourceId { get; set; }
        //public string description { get; set; }
        public int idd { get; set; }
        public string title { get; set; }    
        public DateOnly start { get; set; }
        public DateOnly end {  get; set; } 
    }

    //public class Resource
    //{
    //    public int id { get; set; }
    //    public string title { get; set; }
    //}
}

