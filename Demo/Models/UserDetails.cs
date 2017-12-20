/******************************************************************
** auth: Frank
** date: 12/20/2017 11:52:40 AM
** desc:
******************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Demo.Models
{
    public class UserDetails
    {
        [StringLength(7, MinimumLength=2, ErrorMessage="username length should be between 2 and 7")]
        public string UserName { set; get; }
        public string Password { set; get; }
    }
}
