using System;
using System.Collections.Generic;
using System.Text;

namespace GraduationWorksOrganizer.Core.Additional
{
    public interface ISMTPConfiguration
    {
        bool IsHTML { get; set; }

        string SMTPHost { get; set; }

        int SMTPPort { get; set; }

        bool UseSSl { get; set; }

        string UserEmail { get; set; }

        string UserEmailPassword { get; set; }

        string MessageTemplate { get; set; }
    }
}
