using AFT_Portal.DataAccess.Company;
using AFT_Portal.Model.Company;

namespace AFT_Portal.BusinessAccess.Company
{
    public class CompanyBusinessAccess
    {
        public async Task<CompanyModel> GetCompanyDataAsync()
        {
            var companyDataAccess = new CompanyDataAccess();
            return await companyDataAccess.GetCompanyDataAsync(); 
        }
    }
}
