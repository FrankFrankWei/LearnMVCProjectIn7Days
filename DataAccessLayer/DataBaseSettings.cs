/******************************************************************
** auth: Frank
** date: 12/23/2017 12:09:01 PM
** desc:
******************************************************************/

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DatabaseSettings
    {
        public DatabaseSettings()
        { }

        public static void SetDatabase()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<SalesERPDAL>());
        }
    }
}
