namespace HomeApi.Model
{
    using System;
    public class Home
    {
        public Home(){
            Id = Guid.NewGuid();
        }

        public Guid Id {get;} 

        public long PropertyId {get; set;}
        public string Address {get; set;}

        public int Bed {get; set;}

        public int Bath {get; set;}

        public string Type {get; set;}   
    }
}