using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Common;

namespace DAL
{
    public class FileDAL
    {
        public void DeleteFileById(string id)
        {
            string sql = "delete  from course_file where fId=@fId";
            SqlParameter[] pars = new SqlParameter[] { new SqlParameter("@fId", SqlDbType.Int) { Value = Convert.ToInt32(id) } };
            SqlServerHelper.Insert(sql, pars);

        }



    }
}