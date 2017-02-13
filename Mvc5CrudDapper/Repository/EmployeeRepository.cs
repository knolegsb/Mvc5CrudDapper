using Dapper;
using Mvc5CrudDapper.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Mvc5CrudDapper.Repository
{
    public class EmployeeRepository
    {
        public SqlConnection con;

        private void connection()
        {
            string connStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            con = new SqlConnection(connStr);
        }

        public void AddEmployee(Employee obj)
        {
            try
            {
                connection();
                con.Open();
                con.Execute("AddNewEmployeeDetails", obj, commandType: CommandType.StoredProcedure);
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Employee> GetAllEmployees()
        {
            try
            {
                connection();
                con.Open();
                IList<Employee> employeeList = SqlMapper.Query<Employee>(con, "GetEmployees").ToList();
                con.Close();
                return employeeList.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateEmployee(Employee obj)
        {
            try
            {
                connection();
                con.Open();
                con.Execute("UpdateEmployeeDetails", obj, commandType: CommandType.StoredProcedure);
                con.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteEmployee(int id)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Id", id);
                connection();
                con.Open();
                con.Execute("DeleteEmployeeById", param, commandType: CommandType.StoredProcedure);
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}