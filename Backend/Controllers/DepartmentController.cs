using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class DepartmentController : ApiController
    {
        public HttpResponseMessage Get()
        {
            DataTable dt = new DataTable();

            string query = @"select DepartmentID,DepartmentName from Departments";

            var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString);

            var command = new SqlCommand(query, con);

            using (var da = new SqlDataAdapter(command))
            {
                command.CommandType = CommandType.Text;
                da.Fill(dt);
            }

            //içeride hata olur olmaz fırlatır safe connection
            return Request.CreateResponse(HttpStatusCode.OK, dt);
        }

        public string Post(Departments dep)
        {
            try
            {
                DataTable table = new DataTable();

                string query = @"insert into dbo.Departments values ('"+dep.DepartmentName+@"')";

                var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString);
                var command = new SqlCommand(query, con);

                using (var da = new SqlDataAdapter(command))
                {
                    command.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Added Succesfully";
            }
            catch (Exception ex)
            {
                return "Failed to Add";
            }
        }

        public string Put(Departments dep)
        {
            try
            {
                DataTable dt = new DataTable();

                string query=@"update dbo.Departments set DepartmentName='"+dep.DepartmentName+
                    @"'where DepartmentID="+dep.DepartmentID+@"";

                var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString);

                var command = new SqlCommand(query, con);

                using(var da=new SqlDataAdapter(command))
                {
                    command.CommandType = CommandType.Text;
                    da.Fill(dt);
                }
                return "Updated Successfully";
            }
            catch (Exception)
            {

                return "Failed to Update";
            }
        }

        public string Delete(Departments dep)
        {
            try
            {
                DataTable dt = new DataTable();

                string query = @"delete dbo.Departments where DepartmentID='" + dep.DepartmentID+@"'";

                var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString);

                var command = new SqlCommand(query, con);

                using(var da=new SqlDataAdapter(command))
                {
                    command.CommandType = CommandType.Text;
                    da.Fill(dt);
                }

                return "Deleted Succesfully";
            }
            catch (Exception)
            {
                return "Failed to Delete";
            }
        }
    }
}
