using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SummitPDB.BusinessEntities
{
    public class BEUser
    {
        private string userName;
        private string userPassword;
        private string userCod;
        private string respuesta;
        private string userNameAccount;
        public string UserPasswordRep { get; set; }
        public string codRol { get; set; }

        public string UserNameAccount
        {
            set { userNameAccount = value; }
            get { return userNameAccount; }
        }
        public string UserName
        {
            set { userName = value; }
            get { return userName; }
        }
        public string UserPassword
        {
            set { userPassword = value; }
            get { return userPassword; }
        }

        public string UserCod
        {
            set { userCod = value; }
            get { return userCod; }
        }

        public string Respuesta
        {
            set { respuesta = value; }
            get { return respuesta; }
        }

        public string codLocal { get; set; }
    }
}
