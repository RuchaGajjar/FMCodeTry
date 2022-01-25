using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace FMCodeFirstTryWin
{
    /// <summary>
    /// Business Layer Class with all fucntionality
    /// </summary>
    public class Driver
    {
        //Const query and commands
        const string connectionString = @"Integrated Security = SSPI; Initial Catalog = Rucha_Test; Data Source = RTD-MAIN\SQLEXPRESS";
        const string sqlSelect = "Select FName+' '+LName [Customer Name], DOB [Date of Birth], (Case When IsNull(Photopath,'') = '' Then 'No' Else 'Yes' End) [ID Provided] From [dbo].[Customer_Details]";
        const string sqlInsert = "Insert into [dbo].[Customer_Details] Values (@FirstName,@LastName,@DateOfBirth,@BirthCountry,@LicenseNumber,@LicenseDate,@LicenseFilePath)";

        /// <summary>
        /// Empty contructor - actually no need
        /// </summary>
        public Driver() { }

        /// <summary>
        /// New Constructor
        /// </summary>
        /// <param name="FName">First name of driver</param>
        /// <param name="LName">last name driver</param>
        public Driver(string FName, string LName)
        { }
                
        /// <summary>
        /// Get all driver details - select query
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllDrivers()
        {
            DataTable dt = null;

            try
            {
                using (SqlConnection sqlCn = new SqlConnection(connectionString))
                {
                    using (SqlCommand sqlCmd = new SqlCommand(sqlSelect, sqlCn))
                    {
                        using (SqlDataAdapter sqlAdp = new SqlDataAdapter(sqlCmd))
                        {
                            DataSet ds = new DataSet();
                            sqlAdp.Fill(ds);
                            dt = ds.Tables.Count > 0 ? (ds.Tables[0]) : null;
                        }
                    }
                }
            }
            catch (Exception ex) { throw ex; }

            return dt;
        }

        /// <summary>
        /// Insert driver details into sql
        /// </summary>
        /// <param name="pFName"></param>
        /// <param name="pLName"></param>
        /// <param name="pDOB"></param>
        /// <param name="pDOBCountry"></param>
        /// <param name="pLicNo"></param>
        /// <param name="pLicDt"></param>
        /// <param name="pFile"></param>
        /// <returns></returns>
        public bool CreateNewDriver(string pFName,string pLName, DateTime pDOB, string pDOBCountry, string pLicNo, DateTime pLicDt, string pFile)
        {
            int inserted = 0;

            try
            {
                using (SqlConnection sqlCn = new SqlConnection(connectionString))
                {
                    if (sqlCn.State != ConnectionState.Open)
                        sqlCn.Open();

                    using (SqlCommand sqlCmd = new SqlCommand(sqlInsert, sqlCn))
                    {
                        //Add Parameters
                        sqlCmd.Parameters.AddWithValue("@FirstName", pFName);
                        sqlCmd.Parameters.AddWithValue("@LastName", pLName);
                        sqlCmd.Parameters.AddWithValue("@DateOfBirth", pDOB);
                        sqlCmd.Parameters.AddWithValue("@BirthCountry", pDOBCountry);
                        sqlCmd.Parameters.AddWithValue("@LicenseNumber", pLicNo);
                        sqlCmd.Parameters.AddWithValue("@LicenseDate", pLicDt);
                        sqlCmd.Parameters.AddWithValue("@LicenseFilePath", pFile);

                        inserted = sqlCmd.ExecuteNonQuery();
                    }
                    sqlCn.Close();
                }
            }
            catch (Exception ex) { throw ex; }
            finally {
            }

            //If record inserted the return true otherwise false
            return inserted > 0? true:false;
        }
    }
}
