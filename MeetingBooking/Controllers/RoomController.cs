using Model.DAO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MeetingBooking.Controllers
{
  public class RoomController : Controller
  {
    // GET: Room
    public ActionResult Index()
    {
      return View();
    }

    /// <summary>
    /// GetAllRoom
    /// </summary>
    /// <returns></returns>
    public JsonResult GetAllRoom()
    {
      return Json(new RoomDao().GetAllRoom(), JsonRequestBehavior.AllowGet);
    }

    /// <summary>
    /// Get List Room
    /// </summary>
    /// <returns></returns>
    public JsonResult GetListRoom()
    {
      return Json(new RoomDao().GetListRoom(), JsonRequestBehavior.AllowGet);
    }

    /// <summary>
    /// Get Detail Room
    /// </summary>
    /// <param name="roomID"></param>
    /// <returns></returns>
    [HttpPost]
    public JsonResult GetDetailRoom(int roomID)
    {
      return Json(new RoomDao().GetDetailRoom(roomID), JsonRequestBehavior.AllowGet);
    }

    /// <summary>
    /// Lấy ra area tương ứng của từng room
    /// </summary>
    /// <param name="areaID"></param>
    /// <returns></returns>
    [HttpPost]
    public JsonResult GetAreaByRoom(int areaID)
    {
      return Json(new RoomDao().GetAreaByRoom(areaID), JsonRequestBehavior.AllowGet);
    }

    /// <summary>
    /// Upload Images
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public JsonResult Uploadmage()
    {

      string fileName = string.Empty;
      string urlFile = string.Empty;
      string nopic = "/Content/Images/nopic.png";
      if (Request.Files.Count > 0)
      {
        try
        {
          //  Get all files from Request object
          HttpFileCollectionBase files = Request.Files;
          for (int i = 0; i < files.Count; i++)
          {
            //string path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/";
            //string filename = Path.GetFileName(Request.Files[i].FileName);

            HttpPostedFileBase file = files[i];
            string extension = Path.GetExtension(file.FileName);//Lấy ra đuôi của file
            // Checking for Internet Explorer
            if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
            {
              string[] testfiles = file.FileName.Split(new char[] { '\\' });
              fileName = testfiles[testfiles.Length - 1];
            }
            else
            {
              fileName = (DateTime.Now.ToString().Replace(":", string.Empty).Replace("/", string.Empty) + extension).Replace(" ", string.Empty); ;
            }
            urlFile = "/Uploads/Images/" + fileName;
            // Get the complete folder path and store the file inside it.
            fileName = Path.Combine(Server.MapPath("/Uploads/Images/"), fileName);
            file.SaveAs(fileName);
          }
          // Returns message that successfully uploaded
          return Json(urlFile, JsonRequestBehavior.AllowGet);
        }
        catch (Exception ex)
        {
          return Json(nopic, JsonRequestBehavior.AllowGet);
        }
      }
      else
      {
        return Json(nopic, JsonRequestBehavior.AllowGet);
      }
    }

    /// <summary>
    /// AddRoom
    /// </summary>
    /// <param name="roomID"></param>
    /// <param name="roomName"></param>
    /// <param name="areaID"></param>
    /// <param name="seat"></param>
    /// <param name="phoneCall"></param>
    /// <param name="videoCall"></param>
    /// <param name="visible"></param>
    /// <param name="desc"></param>
    /// <param name="avatar"></param>
    /// <param name="createBy"></param>
    /// <returns></returns>
    [HttpPost]
    public JsonResult AddRoom(int roomID, string roomName, int areaID, int seat, bool? phoneCall, bool? videoCall, bool? visible, string desc, string avatar, string createBy)
    {
      return Json(new RoomDao().AddRoom(roomID, roomName, areaID, seat, phoneCall, videoCall, visible, desc, avatar, createBy), JsonRequestBehavior.AllowGet);
    }

    /// <summary>
    /// Update Room
    /// </summary>
    /// <param name="roomID"></param>
    /// <param name="roomName"></param>
    /// <param name="areaID"></param>
    /// <param name="seat"></param>
    /// <param name="phoneCall"></param>
    /// <param name="videoCall"></param>
    /// <param name="visible"></param>
    /// <param name="desc"></param>
    /// <param name="avatar"></param>
    /// <param name="createBy"></param>
    /// <returns></returns>
    [HttpPost]
    public JsonResult UpdateRoomDetail(int roomID, string roomName, int areaID, int seat, bool? phoneCall, bool? videoCall, bool? visible, string desc, string avatar, string createBy)
    {
      return Json(new RoomDao().UpdateRoomDetail(roomID, roomName, areaID, seat, phoneCall, videoCall, visible, desc, avatar, createBy), JsonRequestBehavior.AllowGet);
    }

    /// <summary>
    /// Delete Room
    /// </summary>
    /// <param name="roomID"></param>
    /// <returns></returns>
    [HttpPost]
    public JsonResult DeleteRoom(int roomID)
    {
      return Json(new RoomDao().DeleteRoom(roomID), JsonRequestBehavior.AllowGet);
    }

    /// <summary>
    /// Search Room
    /// </summary>
    /// <param name="roomName"></param>
    /// <param name="areaID"></param>
    /// <returns></returns>
    [HttpPost]
    public JsonResult Search(string roomName, int? areaID)
    {
      var model = new RoomDao().ListRoom(roomName, areaID);
      return Json(model, JsonRequestBehavior.AllowGet);
    }

    /// <summary>
    /// Search All Room
    /// </summary>
    /// <param name="roomName"></param>
    /// <param name="areaID"></param>
    /// <returns></returns>
    [HttpPost]
    public JsonResult SearchAll(string roomName, int? areaID)
    {
      var model = new RoomDao().ListAllRoom(roomName, areaID);
      return Json(model, JsonRequestBehavior.AllowGet);
    }
  }
}
