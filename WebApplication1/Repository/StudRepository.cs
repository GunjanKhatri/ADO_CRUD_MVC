using ADOCRUD_MVC.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication1.Repository
{
    public class StudRepository
    {
        SqlConnection con;

        public StudRepository()
        {
            string constr = ConfigurationManager.ConnectionStrings["getconn"].ToString();
            con = new SqlConnection(constr);
        }

        public List<StudentModel> GetAllStudents()
        {
            List<StudentModel> StudList = new List<StudentModel>();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from student";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();

            foreach(DataRow dr in dt.Rows)
            {
                StudList.Add(
                    new StudentModel
                    {
                        EmailId = Convert.ToString(dr["EmailId"]),
                        Name = Convert.ToString(dr["Name"]),
                        City = Convert.ToString(dr["City"]),
                        Address = Convert.ToString(dr["Address"]),
                        StudId = Convert.ToInt32(dr["StudId"])

                    }
                    );
            }
            return StudList;
        }
    }
}