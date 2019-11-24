using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class AreaDao
    {
        DBContext db = null;

        public AreaDao()
        {
            db = new DBContext();
        }

        /// <summary>
        ///GetAllArea
        /// </summary>
        /// <returns></returns>
        public List<Area> GetAllArea()
        {
            return db.Areas.ToList();
        }

        /// <summary>
        /// GetListArea
        /// </summary>
        /// <returns></returns>
        public List<Area> GetListArea()
        {
            return db.Areas.Where(x=>x.Visible==true).ToList();
        }

        /// <summary>
        /// GetDetailArea
        /// </summary>
        /// <param name="AreaID"></param>
        /// <returns></returns>
        public object GetDetailArea(int AreaID)
        {
            return db.Areas.Select(x => new
            {
                AreaID = x.AreaID,
                AreaName = x.AreaName,
                Avatar = x.Avatar,
                Description = x.Description,
                Visible = x.Visible,
            }).FirstOrDefault(x=>x.AreaID == AreaID);
        }

        /// <summary>
        /// AddArea
        /// </summary>
        /// <param name="areaName"></param>
        /// <param name="avatar"></param>
        /// <param name="desc"></param>
        /// <param name="visible"></param>
        /// <param name="createBy"></param>
        /// <returns></returns>
        public object AddArea(string areaName, string avatar, string desc, bool? visible, string createBy)
        {
            var checkAreaName = db.Areas.Where(x => x.AreaName == areaName).FirstOrDefault();
            if (checkAreaName != null)
            {
                return new
                {
                    status = 2
                };
            }
            Area area = new Area();
            area.AreaName = areaName;
            area.Avatar = avatar;
            area.Description = desc;
            area.Visible = visible;
            area.CreateBy = createBy;
            area.CreateTime = DateTime.Now;

            db.Areas.Add(area);
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

        /// <summary>
        /// UpdateArea
        /// </summary>
        /// <param name="areaID"></param>
        /// <param name="areaName"></param>
        /// <param name="avatar"></param>
        /// <param name="desc"></param>
        /// <param name="visible"></param>
        /// <param name="createBy"></param>
        /// <returns></returns>
        public object UpdateArea(int areaID, string areaName, string avatar, string desc, bool? visible, string createBy)
        {
            var itemArea         = db.Areas.Where(x => x.AreaID == areaID).FirstOrDefault();
            itemArea.AreaName    = areaName;
            itemArea.Avatar      = avatar;
            itemArea.Description = desc;
            itemArea.Visible     = visible;
            itemArea.UpdateBy    = createBy;
            itemArea.UpdateTime  = DateTime.Now;
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

        /// <summary>
        /// DeleteArea
        /// </summary>
        /// <param name="AreaID"></param>
        /// <returns></returns>
        public object DeleteArea(int AreaID)
        {
            var itemArea = db.Areas.Where(x=>x.AreaID == AreaID).FirstOrDefault();
            db.Areas.Remove(itemArea);
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
    }
}
