using Model.EF;
using Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class RoomDao
    {
        DBContext db = null;
        public RoomDao()
        {
            db = new DBContext();
        }

        public List<Room> GetListRoom()
        {
            return db.Rooms.Where(x => x.Visible == true).ToList();
        }

        public object GetAllRoom()
        {
            return db.Rooms.Where(x => x.Visible == true).ToList();
        }

        public object GetDetailRoom(int roomID)
        {
            return db.Rooms.Select(x => new
            {
                RoomID = x.RoomID,
                Avatar = x.Avatar,
                RoomName = x.RoomName,
                Description = x.Description,
                Seat = x.Seat,
                PhoneCall = x.PhoneCall,
                VideoCall = x.VideoCall,
                Visible = x.Visible,
                Position = x.Position,
                AreaID = x.AreaID,
                UpdateBy = x.UpdateBy,
                UpdateTime = x.UpdateTime,
                CreateBy = x.CreateBy,
                CreateTime = x.CreateTime,
                NumberPeople = x.NumberPeople,
                AreaName = db.Areas.FirstOrDefault(z => z.AreaID == x.AreaID).AreaName
            }).FirstOrDefault(x => x.RoomID == roomID);
        }

        public object GetAreaByRoom(int? areaID)
        {
            return db.Areas.Where(x => x.AreaID == areaID).Select(x => x.AreaName).ToList();
        }

        public object AddRoom(int roomID, string roomName, int areaID, int seat, bool? phoneCall, bool? videoCall, bool? visible, string desc, string avatar, string createBy)
        {
            var checkRoomName = db.Rooms.Where(x => x.RoomName == roomName).FirstOrDefault();
            if (checkRoomName != null)
            {
                return new
                {
                    status = 2
                };
            }
            Room room = new Room();
            room.RoomName = roomName;
            room.AreaID = areaID;
            room.Seat = seat;
            room.VideoCall = videoCall;
            room.PhoneCall = phoneCall;
            room.Visible = visible;
            room.Description = desc;
            room.Avatar = avatar;
            room.UpdateBy = createBy;
            db.Rooms.Add(room);
            try
            {
                db.SaveChanges();
                return new
                {
                    status = 1,
                };
            }
            catch (Exception)
            {
                return new
                {
                    status = 0,
                };
            }

        }

        public object UpdateRoomDetail(int roomID, string roomName, int areaID, int seat, bool? phoneCall, bool? videoCall, bool? visible, string desc, string avatar, string createBy)
        {
            var room = db.Rooms.Where(x => x.RoomID == roomID).FirstOrDefault();

            room.RoomName = roomName;
            room.AreaID = areaID;
            room.Seat = seat;
            room.VideoCall = videoCall;
            room.PhoneCall = phoneCall;
            room.Visible = visible;
            room.Description = desc;
            room.Avatar = avatar;
            room.UpdateBy = createBy;

            try
            {
                db.SaveChanges();
                return new
                {
                    status = 1,
                };
            }
            catch (Exception)
            {
                return new
                {
                    status = 0,
                };
            }

        }

        public object DeleteRoom(int roomID)
        {
            var itemRoom = db.Rooms.Where(x => x.RoomID == roomID).FirstOrDefault();
            db.Rooms.Remove(itemRoom);
            try
            {
                db.SaveChanges();
                return new
                {
                    status = 1
                };
            }
            catch (Exception)
            {
                return new
                {
                    status = 0
                };
            }
        }

        //Search Room
        public object ListRoom(string roomName, int? areaID)
        {
            IEnumerable<ListRoomModel> data;

            //DateTime d = DateTime.Now;
            //string date = d.Year + "/" + d.Month + "/" + d.Day;
            //string hours = d.Hour + ":" + d.Minute + ":" + d.Minute;
            //DateTime d1 = Convert.ToDateTime(date);

            DateTime d1 = DateTime.Now;
            DateTime d2 = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " 23:59");

            if (roomName != string.Empty)
            {
                if (areaID != 0)
                {

                    data = from a in db.Rooms
                           join b in db.Areas on a.AreaID equals b.AreaID
                           where a.Visible == true
                           && b.Visible == true
                           && a.RoomName.Contains(roomName)
                           select new ListRoomModel
                           {
                               roomID = a.RoomID,
                               roomName = a.RoomName,
                               roomAvatar = a.Avatar,
                               phoneCall = a.PhoneCall,
                               videoCall = a.VideoCall,
                               seat = a.Seat,
                               desc = a.Description,
                               listLineRoom = db.LineRooms
                               .Where(x => x.RoomID == a.RoomID
                               && x.TimeEnd >= d1 && x.TimeEnd <= d2).ToList()

                               //&& DbFunctions.TruncateTime(x.TimeStart) == d1
                               //&&  DbFunctions.TruncateTime(x.TimeEnd) == d1).ToList()
                           };


                }
                else
                {
                    data = from a in db.Rooms
                           join b in db.Areas on a.AreaID equals b.AreaID
                           where a.Visible == true
                           && b.Visible == true
                           && a.RoomName.Contains(roomName)
                           select new ListRoomModel
                           {
                               roomID = a.RoomID,
                               roomName = a.RoomName,
                               roomAvatar = a.Avatar,
                               phoneCall = a.PhoneCall,
                               videoCall = a.VideoCall,
                               seat = a.Seat,
                               desc = a.Description,
                               listLineRoom = db.LineRooms
                               .Where(x => x.RoomID == a.RoomID
                               && x.TimeEnd >= d1 && x.TimeEnd <= d2).ToList()

                               //&& DbFunctions.TruncateTime(x.TimeStart) == d1
                               //&&  DbFunctions.TruncateTime(x.TimeEnd) == d1).ToList()
                           };
                }
            }
            else if (areaID != 0)
            {
                data = from a in db.Rooms
                       join b in db.Areas on a.AreaID equals b.AreaID
                       where a.Visible == true
                       && b.Visible == true
                   && a.AreaID == areaID
                       select new ListRoomModel
                       {
                           roomID = a.RoomID,
                           roomName = a.RoomName,
                           roomAvatar = a.Avatar,
                           phoneCall = a.PhoneCall,
                           videoCall = a.VideoCall,
                           seat = a.Seat,
                           desc = a.Description,
                           listLineRoom = db.LineRooms
                           .Where(x => x.RoomID == a.RoomID
                            && x.TimeEnd >= d1 && x.TimeEnd <= d2).ToList()

                           //&& DbFunctions.TruncateTime(x.TimeStart) == d1
                           //&& DbFunctions.TruncateTime(x.TimeEnd) == d1).ToList()
                       };
            }
            else
            {
                data = from a in db.Rooms
                       join b in db.Areas on a.AreaID equals b.AreaID
                       where a.Visible == true
                       && b.Visible == true
                       select new ListRoomModel
                       {
                           roomID = a.RoomID,
                           roomName = a.RoomName,
                           roomAvatar = a.Avatar,
                           phoneCall = a.PhoneCall,
                           videoCall = a.VideoCall,
                           seat = a.Seat,
                           desc = a.Description,
                           listLineRoom = db.LineRooms
                           .Where(x => x.RoomID == a.RoomID
                            && x.TimeEnd >= d1 && x.TimeEnd <= d2).ToList()
                           //&& DbFunctions.TruncateTime(x.TimeStart) == d1
                           //&& DbFunctions.TruncateTime(x.TimeEnd) ==d1).ToList()
                       };
            }

            var result = data.ToList();

            return result;
        }

        public object ListAllRoom(string roomName, int? areaID)
        {
            IEnumerable<ListRoomModel> data;
            if (roomName != string.Empty)
            {
                if (areaID != 0)
                {

                    data = from a in db.Rooms
                           where a.RoomName.Contains(roomName)
                           && a.AreaID == areaID
                           select new ListRoomModel
                           {
                               roomID = a.RoomID,
                               roomName = a.RoomName,
                               roomAvatar = a.Avatar,
                               phoneCall = a.PhoneCall,
                               videoCall = a.VideoCall,
                               seat = a.Seat,
                               desc = a.Description,
                               visible = a.Visible
                           };


                }
                else
                {
                    data = from a in db.Rooms
                           where a.RoomName.Contains(roomName)
                           select new ListRoomModel
                           {
                               roomID = a.RoomID,
                               roomName = a.RoomName,
                               roomAvatar = a.Avatar,
                               phoneCall = a.PhoneCall,
                               videoCall = a.VideoCall,
                               seat = a.Seat,
                               desc = a.Description,
                               visible = a.Visible
                           };
                }
            }
            else if (areaID != 0)
            {
                data = from a in db.Rooms
                       where a.AreaID == areaID
                       select new ListRoomModel
                       {
                           roomID = a.RoomID,
                           roomName = a.RoomName,
                           roomAvatar = a.Avatar,
                           phoneCall = a.PhoneCall,
                           videoCall = a.VideoCall,
                           seat = a.Seat,
                           desc = a.Description,
                           visible = a.Visible
                       };
            }
            else
            {
                data = from a in db.Rooms
                       select new ListRoomModel
                       {
                           roomID = a.RoomID,
                           roomName = a.RoomName,
                           roomAvatar = a.Avatar,
                           videoCall = a.VideoCall,
                           phoneCall = a.PhoneCall,
                           seat = a.Seat,
                           desc = a.Description,
                           visible = a.Visible
                       };
            }

            var result = data.ToList();

            return result;
        }

    }
}
