using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using IDAL;
using InterfaceImplement;
using System.Reflection;

namespace DAL
{
    public class DataAccess
    {   
        private static readonly string AssemblyName = "InterfaceImplement"; //要实例化对象的命名空间名
        private static readonly string db = ConfigurationManager.AppSettings["DB"];//读配置文件
        //private static readonly string db = "Imp_Sql";
        //private static readonly string db = "Imp_Oracle";

        public static IBlog CreateBlog()
        {
            //IUser result = null;
            //switch (db)
            //{
            //    case "SqlServer":
            //        result = new Imp_SqlUser();
            //        break;
            //    case "Oracle":
            //        result = new Imp_OracleUser();
            //        break;
            //}
            //return result;

            /*利用反射动态获取对象*/
            string className = AssemblyName + "." + db + "Blog";  //即InterfaceImplement命名空间的Imp_SqlUser对象
            return (IBlog)Assembly.Load(AssemblyName).CreateInstance(className);
        }

        public static IRemark CreateRemark()
        {
            //IProduct result = null;
            //switch (db)
            //{
            //    case "SqlServer":
            //        result = new Imp_SqlProduct();
            //        break;
            //    case "Oracle":
            //        result = new Imp_OracleProduct();
            //        break;
            //}
            //return result;

            string className = AssemblyName + "." + db + "Remark";  //即InterfaceImplement命名空间的Imp_SqlProduct对象
            return (IRemark)Assembly.Load(AssemblyName).CreateInstance(className);
        }

        public static IReply CreateReply()
        {
            //IProduct result = null;
            //switch (db)
            //{
            //    case "SqlServer":
            //        result = new Imp_SqlProduct();
            //        break;
            //    case "Oracle":
            //        result = new Imp_OracleProduct();
            //        break;
            //}
            //return result;

            string className = AssemblyName + "." + db + "Reply";  //即InterfaceImplement命名空间的Imp_SqlProduct对象
            return (IReply)Assembly.Load(AssemblyName).CreateInstance(className);
        }

        public static IMessage CreateMessage()
        {
            //IProduct result = null;
            //switch (db)
            //{
            //    case "SqlServer":
            //        result = new Imp_SqlProduct();
            //        break;
            //    case "Oracle":
            //        result = new Imp_OracleProduct();
            //        break;
            //}
            //return result;

            string className = AssemblyName + "." + db + "Message";  //即InterfaceImplement命名空间的Imp_SqlProduct对象
            return (IMessage)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static IUser_Student CreateStudent()
        {
            //IProduct result = null;
            //switch (db)
            //{
            //    case "SqlServer":
            //        result = new Imp_SqlProduct();
            //        break;
            //    case "Oracle":
            //        result = new Imp_OracleProduct();
            //        break;
            //}
            //return result;

            string className = AssemblyName + "." + db + "User_Student";  //即InterfaceImplement命名空间的Imp_SqlProduct对象
            return (IUser_Student)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static IUser_Teacher CreateTeacher()
        {
            //IProduct result = null;
            //switch (db)
            //{
            //    case "SqlServer":
            //        result = new Imp_SqlProduct();
            //        break;
            //    case "Oracle":
            //        result = new Imp_OracleProduct();
            //        break;
            //}
            //return result;

            string className = AssemblyName + "." + db + "User_Teacher";  //即InterfaceImplement命名空间的Imp_SqlProduct对象
            return (IUser_Teacher)Assembly.Load(AssemblyName).CreateInstance(className);
        }
        public static IUser_Manager CreateManager()
        {
            //IProduct result = null;
            //switch (db)
            //{
            //    case "SqlServer":
            //        result = new Imp_SqlProduct();
            //        break;
            //    case "Oracle":
            //        result = new Imp_OracleProduct();
            //        break;
            //}
            //return result;

            string className = AssemblyName + "." + db + "User_Manager";  //即InterfaceImplement命名空间的Imp_SqlProduct对象
            return (IUser_Manager)Assembly.Load(AssemblyName).CreateInstance(className);
        }
    }
}
