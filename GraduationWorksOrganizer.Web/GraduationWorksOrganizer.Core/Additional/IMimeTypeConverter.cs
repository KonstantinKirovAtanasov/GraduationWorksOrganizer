using System;
using System.Collections.Generic;
using System.Text;

namespace GraduationWorksOrganizer.Core.Additional
{
    public interface IMimeTypeConverter
    {
        string GetMimeTypeByPartialPath(string partialPath);
    }
}
