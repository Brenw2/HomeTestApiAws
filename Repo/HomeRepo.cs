using System.Xml.Linq;
using System.Linq;
namespace HomeApi.Repo
{
    using HomeApi.Model;
    using System.Collections.Generic;
    using HomeApi.Repo.Interface;
    public class HomeRepo : IHomeRepo{

        private List<Home> HomeTable {get; set;}

        public HomeRepo(){
            HomeTable = new List<Home>();
            GenerateTestData();
        }

        public void GenerateTestData(){
           var testData = new List<Home>{
             new Home{
                PropertyId = 11123,
                Address = "123 Wally St.",
                Bath = 1,
                Bed = 2,
                Type = "Ranch"
             },
             new Home{
                PropertyId = 2342234,
                Address = "1333 Mich St.",
                Bath = 5,
                Bed = 4,
                Type = "Colonial"
             },
              new Home{
                PropertyId = 56343,  
                Address = "1333 Eagle dr.",
                Bath = 5,
                Bed = 4,
                Type = "Cabin"
             },
              new Home{
                PropertyId = 895,
                Address = "5632 Johnson St.",
                Bath = 1,
                Bed = 3,
                Type = "Colonial"
             },
             new Home{
                 PropertyId = 159357,
                 Address = "432 West Ct.",
                 Bath = 2,
                 Bed = 2,
                 Type = "Victorian"
             }         
           };
           HomeTable.AddRange(testData);
        }

        public Home GetByPropertyId(long Id){
            return HomeTable.Where(x => x.PropertyId == Id).Single();
        }

        public void UpdateHome (Home home){
            var homeInTable = HomeTable.Where(x => x.PropertyId == home.PropertyId).SingleOrDefault();
            HomeTable.Remove(homeInTable);
            HomeTable.Add(home);
        }
        
        public void DeleteHome(long Id){
            var homeInTable = HomeTable.Where(x => x.PropertyId == Id).SingleOrDefault();
            HomeTable.Remove(homeInTable);
        }

        public void AddHome(Home home){
            HomeTable.Add(home);
        }

        public List<Home> GetAllHomes(){
            return HomeTable;
        }
    }
}