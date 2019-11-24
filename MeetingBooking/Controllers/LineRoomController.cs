using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeetingBooking.Controllers
{
  public class LineRoomController : Controller
  {
    // GET: LineRoom
    public ActionResult Index()
    {
      return View();
    }

    /// <summary>
    /// GetLineRoomByRoomID
    /// </summary>
    /// <param name="roomID"></param>
    /// <returns></returns>
    [HttpPost]
    public JsonResult GetLineRoomByRoomID(int roomID)
    {
      return Json(new LineRoomDao().GetLineRoomByRoomID(roomID), JsonRequestBehavior.AllowGet);
    }

    /// <summary>
    /// GetDetailLineRoomByID
    /// </summary>
    /// <param name="lineRoomID"></param>
    /// <returns></returns>
    [HttpPost]
    public JsonResult GetDetailLineRoomByID(int lineRoomID)
    {
      return Json(new LineRoomDao().GetDetailLineRoomByID(lineRoomID), JsonRequestBehavior.AllowGet);
    }

    [HttpPost]
    public JsonResult EditLineRoomByID(int lineRoomID)
    {
      return Json(new LineRoomDao().EditLineRoomByID(lineRoomID), JsonRequestBehavior.AllowGet);
    }

    /// <summary>
    /// DeleteLineRoomByID
    /// </summary>
    /// <param name="lineRoomID"></param>
    /// <param name="roomID"></param>
    /// <returns></returns>
    [HttpPost]
    public JsonResult DeleteLineRoomByID(int lineRoomID, int roomID)
    {
      return Json(new LineRoomDao().DeleteLineRoomByID(lineRoomID, roomID), JsonRequestBehavior.AllowGet);
    }
  }
}
