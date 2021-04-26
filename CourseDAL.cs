using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using Model;
using Common;
namespace DAL
{
    public  class CourseDAL
    {
        public void AddCourse(Course course)
        {

           
                string sql = "insert into course(course_name,course_type,course_introduce,course_picpath,course_id) values(@course_name,@course_type,@course_introduce,@course_picpath,@course_id)";
                SqlParameter[] pars = new SqlParameter[] { 
                    new SqlParameter("@course_name", SqlDbType.NVarChar) { Value = course.Name }, 
                    new SqlParameter("@course_type", SqlDbType.NVarChar) { Value = course.CourseType }, 
                    new SqlParameter("@course_introduce", SqlDbType.NVarChar) { Value = course.Introduce }, 
                    new SqlParameter("@course_picpath", SqlDbType.NVarChar) { Value = course.Coursepic },
                    new SqlParameter("@course_id", SqlDbType.NVarChar) { Value = course.Id } };

                SqlServerHelper.Insert(sql, pars);

          

        }
        public void AddFile(FileModle fileModle)
        {

            string sql = "insert into course_file(fName,fpath,uploadtime,course_id,file_size) values(@fName,@fpath,@uploadtime,@course_id,@file_size)";
            SqlParameter[] pars = new SqlParameter[] {
                new SqlParameter("@fName", SqlDbType.NVarChar) { Value = fileModle.Name },
                new SqlParameter("@fpath", SqlDbType.NVarChar) { Value = fileModle.Path },
                new SqlParameter("@uploadtime", SqlDbType.DateTime) { Value = fileModle.Time },
                new SqlParameter("@course_id", SqlDbType.NVarChar) { Value = fileModle.CourseID },
                new SqlParameter("@file_size", SqlDbType.NVarChar) { Value = fileModle.Size } };

            SqlServerHelper.Insert(sql, pars);






        }

        public List<FileModle> GetFilesById(string id)
        {
            List<FileModle> list = new List<FileModle>();
            string sql = "select * from course_file where course_id=@course_id";
            SqlParameter[] pars = new SqlParameter[] { new SqlParameter("@course_id", SqlDbType.NVarChar) { Value = id } };
            SqlDataReader dr = SqlServerHelper.GetReader(sql,pars);
            while (dr.Read())
            {
                FileModle fileModle = new FileModle();
                DateTime dateString = Convert.ToDateTime(dr["uploadtime"].ToString());
                

                fileModle.Time = dateString;
                fileModle.Name = dr["fName"].ToString();
                fileModle.Size = dr["file_size"].ToString();
                fileModle.Path = dr["fpath"].ToString();
                fileModle.Id = dr["fId"].ToString();
                list.Add(fileModle);


            }
            return list;






        }
        public List<Course> GetCourses()
        {
            List<Course> list = new List<Course>();
            string sql = "select * from course";
            SqlDataReader dr = SqlServerHelper.GetReader(sql);
            while (dr.Read())
            {
                Course course = new Course();
                course.Name = dr["course_name"].ToString();
                course.Id = dr["course_id"].ToString();
                course.Introduce = dr["course_introduce"].ToString();
                course.CourseType = dr["course_type"].ToString();
                
                list.Add(course);


            }
            return list;






        }

        public void  DeleteCourseById( string id)
        {
            string sql = "delete  from course where course_id=@course_id";
            SqlParameter[] pars = new SqlParameter[] { new SqlParameter("@course_id", SqlDbType.NVarChar) { Value = id } };
            SqlServerHelper.Insert(sql, pars);

        }
        public Course GetCourseById(string id)
        {
            Course course = new Course();
            string sql = "select *  from course where course_id=@course_id";
            SqlParameter[] pars = new SqlParameter[] { new SqlParameter("@course_id", SqlDbType.NVarChar) { Value = id } };
           SqlDataReader sqlDataReader= SqlServerHelper.GetReader(sql, pars);
            while (sqlDataReader.Read())
            {

                course.Name = sqlDataReader["course_name"].ToString();
                course.CourseType = sqlDataReader["course_type"].ToString();
                course.Introduce = sqlDataReader["course_introduce"].ToString();
                course.Coursepic = sqlDataReader["course_picpath"].ToString();
            }
            return course;
        }
        public void EditCourse(Course course)
        {
            string sql = "update course set course_name=@course_name,course_type=@course_type,course_introduce=@course_introduce  where course_id=@course_id";
            SqlParameter[] pars = new SqlParameter[] { 
                new SqlParameter("@course_id", SqlDbType.NVarChar) { Value = course.Id },
                new SqlParameter("@course_name", SqlDbType.NVarChar) { Value = course.Name },
                new SqlParameter("@course_type", SqlDbType.NVarChar) { Value = course.CourseType }, 
                new SqlParameter("@course_introduce", SqlDbType.NVarChar) { Value = course.Introduce }};
                SqlServerHelper.Insert(sql, pars);
        }
    }
}