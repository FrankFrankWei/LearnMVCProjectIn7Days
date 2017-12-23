/******************************************************************
** auth: Frank
** date: 12/23/2017 12:30:33 PM
** desc:
******************************************************************/

using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BusinessSettings
    {
        public BusinessSettings()
        { }

        public static void SetBusiness()
        {
            DatabaseSettings.SetDatabase();
        }
    }
}
