/******************************************************************
** auth: Frank
** date: 12/22/2017 11:16:02 AM
** desc:
******************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo.ViewModels
{
    public class FileUploadViewModel : BaseViewModel
    {
        public HttpPostedFileBase FileUpload { set; get; }
    }
}
