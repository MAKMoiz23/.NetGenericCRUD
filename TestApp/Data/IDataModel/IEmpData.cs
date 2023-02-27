using TestApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestApp.Data.IDataModel
{
    public interface IEmpData
    {
        Task DeleteData(int Id);
        Task<IEnumerable<Emp>> GetAll();
        Task<Emp?> GetById(int Id);
        Task SaveData(Emp Emp);
        Task UpdateData(Emp Emp);
    }
}