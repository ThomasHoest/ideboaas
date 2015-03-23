using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdeboaasWeb.Controllers
{
  public class BookingController : Controller
  {
    public ActionResult Index()
    {
      CalenderContents cc = new CalenderContents();
      cc.Bookings = new Booking[]
      {
        new Booking()
        {
          title = "Test",color = "blue",start = DateTime.Now.ToString("yyyy-M-d"), end =  DateTime.Now.AddDays(7).ToString("yyyy-M-d")
        }
      };
      return View(cc);
    }
  }

  public class CalenderContents
  {
    public Booking  [] Bookings{ get; set; }
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