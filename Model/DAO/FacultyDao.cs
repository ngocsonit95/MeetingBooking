using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class FacultyDao
    {
        DBContext db = null;

        public FacultyDao()
        {
            db = new DBContext();
        }

        public List<Faculty> GetAllFaculty()
        {
            return db.Faculties.ToList();

        }

        public List<Faculty> GetListFaculty()
        {
            return db.Faculties.Where(x => x.Visible == true).ToList();
        }

        public object GetDetailFaculty(int FacultyID)
        {
            return db.Faculties.Select(x => new
            {
                FacultyID       = x.FacultyID,
                FacultyName     = x.FacultyName,
                Avatar          = x.Avatar,
                Description     = x.Description,
                Visible         = x.Visible,
            }).FirstOrDefault(x => x.FacultyID == FacultyID);
        }

        public object AddFaculty(string facultyName, string avatar, string desc, bool? visible, string createBy)
        {
            var checkFacultyName = db.Faculties.Where(x => x.FacultyName == facultyName).FirstOrDefault();
            if (checkFacultyName != null)
            {
                return new
                {
                    status = 2
                };
            }
            Faculty faculty = new Faculty();
            faculty.FacultyName = facultyName;
            faculty.Avatar = avatar;
            faculty.Description = desc;
            faculty.Visible = visible;
            faculty.CreateBy = createBy;
            faculty.CreateTime = DateTime.Now;

            db.Faculties.Add(faculty);
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

        public object UpdateFaculty(int facultyID, string facultyName, string avatar, string desc, bool? visible, string createBy)
        {
            var itemFaculty = db.Faculties.Where(x => x.FacultyID == facultyID).FirstOrDefault();
            itemFaculty.FacultyName = facultyName;
            itemFaculty.Avatar = avatar;
            itemFaculty.Description = desc;
            itemFaculty.Visible = visible;
            itemFaculty.UpdateBy = createBy;
            itemFaculty.UpdateTime = DateTime.Now;

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

        public object DeleteFaculty(int FacultyID)
        {
            var itemFaculty = db.Faculties.Where(x => x.FacultyID == FacultyID).FirstOrDefault();
            db.Faculties.Remove(itemFaculty);
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
