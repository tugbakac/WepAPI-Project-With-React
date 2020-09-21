using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class EmployeeController : ApiController
    {
        public HttpResponseMessage Get()
        {
            DataTable dt = new DataTable();

            string query = @"select EmployeeID,EmployeeName,Department,MailID,CONVERT(varchar(10),DateOfJoining,120) as DOJ from Employees ";

            var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString);

            var command = new SqlCommand(query, con);

            using (var da = new SqlDataAdapter(command))
            {
                command.CommandType = CommandType.Text;
                da.Fill(dt);
            }

            return Request.CreateResponse(HttpStatusCode.OK, dt);
        }

        public string Post(Employees emp)
        {
            try
            {
                DataTable dt = new DataTable();

                string query = @"insert into dbo.Employees (EmployeeName, Department, MailID, DateOfJoining) values (
                    '" + emp.EmployeeName + @"',
                    '" + emp.Department + @"',
                    '" + emp.MailID + @"',
                    '" + emp.DateOfJoining + @"' )";

                var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString);
                var command = new SqlCommand(query, con);

                using(var da=new SqlDataAdapter(command))
                {
                    command.CommandType = CommandType.Text;
                    da.Fill(dt);
                }
                return "Added Succesfully";
            }
            catch (Exception ex)
            {
                return "Failed to Add";
            }
        }

        public string Put(Employees emp)
        {
            try
            {
                DataTable dt = new DataTable();

                string query = @"update dbo.Employees set EmployeeName='"+emp.EmployeeName+@"', 
                  Department='"+emp.Department+@"',
                  MailID='"+emp.MailID+@"',
                  DateOfJoining='"+emp.DateOfJoining+@"'
                    where EmployeeID='"+emp.EmployeeID+@"'";

                var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString);

                var command = new SqlCommand(query, con);

                using (var da = new SqlDataAdapter(command))
                {
                    command.CommandType = CommandType.Text;
                    da.Fill(dt);
                }
                return "Updated successfully";
            }
            catch (Exception)
            {
                return "Failed to Update";
            }
        }

        public string Delete(Employees emp)
        {
            try
            {
                DataTable dt = new DataTable();

                string query = @"delete dbo.Employees 
                where EmployeeID='"+emp.EmployeeID+@"'";

                var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeAppDB"].ConnectionString);

                var command = new SqlCommand(query, con);

                using(var da=new SqlDataAdapter(command))
                {
                    command.CommandType = CommandType.Text;
                    da.Fill(dt);
                }

                return "Deleted Successfully";
            }
            catch (Exception)
            {
                return "Failed to Delete";
            }
        }
    }
}
