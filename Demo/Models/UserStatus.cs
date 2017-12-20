/******************************************************************
** auth: Frank
** date: 12/20/2017 9:42:15 PM
** desc:
******************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo.Models
{
    public enum UserStatus
    {
        AuthenticatedAdmin,
        AuthenticatedUser,
        NonAuthenticatedUser
    }
}
