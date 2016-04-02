using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SummitPDB.BusinessEntities
{
    public class BEManagementUser : BEUser
    {
        public string codUser {get;set;}
        public string firstName { get; set; }
        public string lastName {get;set;}
        public string lastName2 {get;set;}
        public string fullName {get;set;}
        public DateTime	dateModify {get;set;}
        public string codLocal { get; set; }
        public string nomLocal { get; set; }
        public string codRol { get; set; }
    }
}
