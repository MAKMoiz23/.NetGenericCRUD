using TestApp.IServices;
using TestApp.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using TestApp.Data.IDataModel;
using System.Text.Json;

namespace TestApp.Data.DataModel
{
    public class EmpData : IEmpData
    {
        private readonly IGenericCrudServices _services;
        public EmpData(IGenericCrudServices services)
        {
            _services = services;
        }

        public Task<IEnumerable<Emp>> GetAll() =>
            _services.LoadData<Emp, dynamic>("[Test].[dbo].[GetAllEmp]", new { });

        public async Task<Emp?> GetById(int Id)
        {
            var result = await _services.LoadData<Emp, dynamic>(
                "[Test].[dbo].[GetEmpById]",
                new { ParamTable1 = Id });
            return result.FirstOrDefault();
        }

        public Task SaveData(Emp Emp)
        {
            return _services.SaveData("[Test].[dbo].[SaveEmp]",
                new { ParamTable1 = JsonSerializer.Serialize(Emp) });
        }

        public Task UpdateData(Emp Emp)
        {
            return _services.SaveData("[Test].[dbo].[UpdateEmp]", new { ParamTable1 = JsonSerializer.Serialize(Emp) });
        }

        public Task DeleteData(int Id) =>
            _services.SaveData("[Test].[dbo].[DeleteEmp]", new { ParamTable1 = Id });

    }
}
