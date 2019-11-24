using Model.DAO;
using Model.EF;
using Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeetingBooking.Controllers
{
  public class ChartController : Controller
  {
    // GET: Chart
    public ActionResult Index()
    {
      return View();
    }

    /// <summary>
    /// GetDataChart
    /// </summary>
    /// <param name="Month"></param>
    /// <param name="Year"></param>
    /// <param name="roomID"></param>
    /// <returns></returns>
    [HttpPost]
    public JsonResult GetDataChart(int Month, int Year, int roomID)
    {
      DBContext db = new DBContext();

      Calendar calendar = CultureInfo.CurrentCulture.Calendar;

      IEnumerable<int> daysInMonth = Enumerable.Range(1, calendar.GetDaysInMonth(Year, Month));
      List<Tuple<DateTime, DateTime>> weeks = daysInMonth.Select(day => new DateTime(Year, Month, day))
                .GroupBy(d => calendar.GetWeekOfYear(d, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Sunday))
                .Select(g => new Tuple<DateTime, DateTime>(g.First(), g.Last()))
                .ToList();
      List<DataWeekModel> dataWeekModels = new List<DataWeekModel>();

      foreach (var item in weeks)
      {
        List<LineRoom> dataLineRoom = new List<LineRoom>();

        DataWeekModel itemWeekModel = new DataWeekModel();
        DateTime d1 = item.Item1;
        DateTime d2 = item.Item2;
        //Nếu có chọn phòng cụ thể
        if (roomID != 0)
        {
          dataLineRoom = db.LineRooms
         .Where(x => x.RoomID == roomID
       && DbFunctions.TruncateTime(x.TimeStart) >= d1
       && DbFunctions.TruncateTime(x.TimeStart) <= d2).ToList();
        }
        //Ngược lại lấy tất cả dữ liệu các phòng
        else
        {
           dataLineRoom = db.LineRooms
        .Where(x => DbFunctions.TruncateTime(x.TimeStart) >= d1
      && DbFunctions.TruncateTime(x.TimeStart) <= d2).ToList();
        }

        itemWeekModel.name = d1.ToString("dd/MM") + " to " + d2.ToString("dd/MM");
        itemWeekModel.y = dataLineRoom.Count();
        dataWeekModels.Add(itemWeekModel);
      }

      return Json(dataWeekModels, JsonRequestBehavior.AllowGet);
    }

  }
}
