using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeetingBooking.Controllers
{
  public class BookingRoomController : Controller
  {
    // GET: BookingRoom
    public ActionResult Index()
    {
      return View();
    }

    /// <summary>
    /// Booking Meeting
    /// </summary>
    /// <param name="userID"></param>
    /// <param name="facutlyID"></param>
    /// <param name="roomID"></param>
    /// <param name="timeStart"></param>
    /// <param name="timeEnd"></param>
    /// <param name="title"></param>
    /// <param name="content"></param>
    /// <param name="note"></param>
    /// <param name="numberPerson"></param>
    /// <returns></returns>
    [HttpPost]
    public JsonResult Book(string userID, int facutlyID, int roomID, string timeStart, string timeEnd, string title, string content, string note,int numberPerson)
    {
      return Json(new BookingRoomDao().Book(userID, facutlyID, roomID, timeStart, timeEnd, title, content, note, numberPerson), JsonRequestBehavior.AllowGet);
    }

    [HttpPost]
    public JsonResult Update(int lineRoomID, string userID, int facutlyID, int roomID, string timeStart, string timeEnd, string title, string content, string note, int numberPerson)
    {
      return Json(new BookingRoomDao().Update(lineRoomID, userID, facutlyID, roomID, timeStart, timeEnd, title, content, note, numberPerson), JsonRequestBehavior.AllowGet);
    }
  }
}
