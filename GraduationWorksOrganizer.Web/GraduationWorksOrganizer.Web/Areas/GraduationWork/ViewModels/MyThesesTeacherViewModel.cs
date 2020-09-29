using AutoMapper;
using GraduationWorksOrganizer.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraduationWorksOrganizer.Web.Areas.GraduationWork.ViewModels
{
    public class MyThesesTeacherViewModel
    {
        public PreviewThesisViewModel ThesesViewModel { get; set; }

        public UserEntryViewModel UserEntry { get; set; }
    }
}
