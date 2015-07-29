using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace IdeboaasWeb.Controllers
{
    public class BookingController : Controller
    {
        public ActionResult Index()
        {
            return View(ReadBookings());
        }

        //
        // POST: /Account/Book
        [HttpPost]
        public void Book(Booking booking)
        {
            if (booking != null)
            {
                CalenderContents cc = ReadBookings();
                var bookings = new List<Booking>(cc.Bookings);
                bookings.Add(booking);
                cc.Bookings = bookings.ToArray();
                SaveBookings(cc);
            }
        }

        private CalenderContents ReadBookings()
        {
            string path = HttpContext.Server.MapPath("~/App_Data/bookings.json");
            string json;
            using (StreamReader sr = new StreamReader(new FileStream(path, FileMode.Open)))
            {
                json = sr.ReadToEnd();
            }

            CalenderContents cc = new CalenderContents();

            if (!string.IsNullOrEmpty(json))
            {
                cc.Bookings = JsonConvert.DeserializeObject<Booking[]>(json);
            }
            return cc;
        }

        private void SaveBookings(CalenderContents cc)
        {
            string path = HttpContext.Server.MapPath("~/App_Data/bookings.json");
            string json;
            using (StreamWriter sw = new StreamWriter(new FileStream(path, FileMode.Open)))
            {
                sw.WriteLine(JsonConvert.SerializeObject(cc.Bookings));
            }
        }
    }

    public class CalenderContents
    {
        public Booking[] Bookings { get; set; }
    }

    public class Booking
    {
        public string title { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public string color { get; set; }
        public string owner { get; set; }
    }
}