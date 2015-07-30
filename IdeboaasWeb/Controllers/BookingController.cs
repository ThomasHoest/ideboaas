using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
        // POST: /Booking/Book
        [HttpPost]
        public bool Password(string password)
        {
            return password == "magic";
        }

        //
        // POST: /Booking/Book
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

        // DELETE: /Booking/Book
        [HttpPost]
        public void Delete(string id)
        {
            if (id != null)
            {
                CalenderContents cc = ReadBookings();
                var bookings = new List<Booking>(cc.Bookings);

                var booking = bookings.FirstOrDefault(b => b.id == id);
                if (booking != null)
                {
                    bookings.Remove(booking);
                    cc.Bookings = bookings.ToArray();
                    SaveBookings(cc);    
                }
            }
        }

        private CalenderContents ReadBookings()
        {
            string path = HttpContext.Server.MapPath("~/App_Data/bookings.json");
            string json;
            using (StreamReader sr = new StreamReader(new FileStream(path, FileMode.OpenOrCreate)))
            {
                json = sr.ReadToEnd();
            }

            CalenderContents cc = new CalenderContents
            {
                Bookings = !string.IsNullOrEmpty(json) ? JsonConvert.DeserializeObject<Booking[]>(json) : new Booking[] {}
            };

            return cc;
        }

        private void SaveBookings(CalenderContents cc)
        {
            string path = HttpContext.Server.MapPath("~/App_Data/bookings.json");
            string json;
            using (FileStream fs =new FileStream(path, FileMode.Open))
            {
                byte[] data = UTF8Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(cc.Bookings));
                fs.Position = 0;
                fs.Write(data,0,data.Length);
                fs.SetLength(data.Length);
            }
        }
    }

    public class CalenderContents
    {
        public Booking[] Bookings { get; set; }
    }

    public class Booking
    {
        public string id { get; set; }
        public string title { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public string color { get; set; }
        public string owner { get; set; }
    }
}