/******************************************************************
** auth: Frank
** date: 12/23/2017 3:33:24 PM
** desc:
******************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ViewModel.SPA
{
    public class FileUploadViewModel
    {
        public FileUploadViewModel()
        { }

        public HttpPostedFileBase fileUpload { set; get; }

    }
}
