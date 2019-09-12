using System.Collections.Generic;
using HomeApi.Model;

namespace HomeApi.Repo.Interface
{
    public interface IHomeRepo
    {
         void GenerateTestData();

         Home GetByPropertyId(long Id);

         List<Home> GetAllHomes();

         void UpdateHome (Home home);

         void DeleteHome(long Id);
         

         void AddHome(Home home);

    }
}