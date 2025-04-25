using AFT_Portal.DataAccess.Company.DBConnection;
using AFT_Portal.Model.Company;
using System.Data;

namespace AFT_Portal.DataAccess.Company
{
    public class CompanyDataAccess
    {
        public async Task<CompanyModel> GetCompanyDataAsync()
        {
            var dbConnection = new AzureDbConnection();
            string query = "SELECT * FROM Companies"; // Replace with your actual query
            DataTable dataTable = await dbConnection.ExecuteQueryToDataTableAsync(query);

            // Map DataTable to CompanyModel
            if (dataTable.Rows.Count > 0)
            {
                var row = dataTable.Rows[0];
                return new CompanyModel
                {
                    // Replace these with actual column names and properties
                    Id = Convert.ToInt32(row["Id"]),
                    Name = row["Name"].ToString(),
                    Address = row["Address"].ToString()
                };
            }

            return null; // Or handle the case where no data is found
        }
    }
}
