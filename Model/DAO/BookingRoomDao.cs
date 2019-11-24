using Model.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class BookingRoomDao
    {
        DBContext db = null;
        public BookingRoomDao()
        {
            db = new DBContext();
        }

        public object Book(string userID, int facutlyID, int roomID, string timeStart, string timeEnd, string title, string content, string note,int numberPerson)
        {

            string[] timeStartSplit = timeStart.Split(' ');
            string[] dateStart      = timeStartSplit[0].Split('/');
            string hourStart        = timeStartSplit[1];
            string[] timeEndSplit   = timeEnd.Split(' ');
            string[] dateEnd        = timeEndSplit[0].Split('/');
            string hourEnd          = timeEndSplit[1];
            //Array.Reverse(dateStart);
            //Array.Reverse(dateEnd);
            string timeStartCast= String.Concat(dateStart[2]+'/', dateStart[1] + '/', dateStart[0]," " +hourStart);
            string timeEndCast= String.Concat(dateEnd[2]+'/', dateEnd[1] + '/', dateEnd[0], " " + hourEnd);

            DateTime start = Convert.ToDateTime(timeStartCast);
            DateTime end   = Convert.ToDateTime(timeEndCast);

            //var checkCoinCide = db.LineRooms.Where(x => x.RoomID == roomID
            //&& (start >= x.TimeStart && start <= x.TimeEnd)
            //|| (end >= x.TimeStart && end <= x.TimeEnd)
            //|| (start >= x.TimeStart && end <= x.TimeEnd)
            //).ToList();

            var checkCoinCide = db.LineRooms.Where(q => q.RoomID == roomID
             && ((DbFunctions.DiffMinutes(start, q.TimeStart) >= 0 && DbFunctions.DiffMinutes(end, q.TimeStart) <= 0) ||
                (DbFunctions.DiffMinutes(start, q.TimeEnd) >= 0 && DbFunctions.DiffMinutes(end, q.TimeEnd) <= 0))
             ).ToList();

            if (checkCoinCide.Count() != 0)
            {
                return new
                {
                    isBooking = false,
                    message = "Lịch họp bạn đặt đã trùng với một cuộc họp khác",
                };
            }

            LineRoom lineRoom     = new LineRoom();
            lineRoom.LineRoomName = title;
            lineRoom.Content      = content;
            lineRoom.Description  = note;
            lineRoom.Status       = 1;

            lineRoom.TimeStart    = start;
            lineRoom.TimeEnd      = end;
            lineRoom.NumberPerson = numberPerson;
            lineRoom.CreateBy     = userID;
            lineRoom.CreateTime   = DateTime.Now;
            lineRoom.RoomID       = roomID;
            db.LineRooms.Add(lineRoom);
            try
            {
                db.SaveChanges();
                return new
                {
                    isBooking = true,
                    message = "Bạn đã đặt phòng họp thành công",
                    result = new LineRoomDao().GetLineRoomByRoomID(roomID)
                };
            }
            catch
            {
                return new
                {
                    isBooking = false,
                    message = "Lỗi hệ thống! Vui lòng thử lại",
                };
            }


        }

        public object Update(int? lineRoomID,string userID, int facutlyID, int roomID, string timeStart, string timeEnd, string title, string content, string note, int numberPerson)
        {
            var itemLineRoom = db.LineRooms.Find(lineRoomID);

            string[] timeStartSplit = timeStart.Split(' ');
            string[] dateStart      = timeStartSplit[0].Split('/');
            string hourStart        = timeStartSplit[1];
            string[] timeEndSplit   = timeEnd.Split(' ');
            string[] dateEnd        = timeEndSplit[0].Split('/');
            string hourEnd          = timeEndSplit[1];
            //Array.Reverse(dateStart);
            //Array.Reverse(dateEnd);
            string timeStartCast    = String.Concat(dateStart[2] + '/', dateStart[1] + '/', dateStart[0], " " + hourStart);
            string timeEndCast      = String.Concat(dateEnd[2] + '/', dateEnd[1] + '/', dateEnd[0], " " + hourEnd);

            DateTime start = Convert.ToDateTime(timeStartCast);
            DateTime end   = Convert.ToDateTime(timeEndCast);

            itemLineRoom.LineRoomName = title;
            itemLineRoom.Content      = content;
            itemLineRoom.Description  = note;
            itemLineRoom.Status       = 1;
            itemLineRoom.TimeStart    = start;
            itemLineRoom.TimeEnd      = end;
            itemLineRoom.NumberPerson = numberPerson;
            itemLineRoom.UpdateBy     = userID;
            itemLineRoom.UpdateTime   = DateTime.Now;
            itemLineRoom.RoomID       = roomID;

            try
            {
                db.SaveChanges();
                return new
                {
                    isBooking = true,
                    message = "Đã cập nhật dữ liệu thành công !",
                    result = new LineRoomDao().GetLineRoomByRoomID(roomID)
                };
            }
            catch
            {
                return new
                {
                    isBooking = false,
                    message = "Lỗi hệ thống! Vui lòng thử lại",
                };
            }


        }
    }
}
