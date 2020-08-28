using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace GraduationWorksOrganizer.Common
{
    /// <summary>
    /// Клас с константи
    /// </summary>
    public class Constants
    {
        /// <summary>
        /// Клас с имена на роли
        /// </summary>
        public static class RoleNames
        {
            /// <summary> Роля за учител</summary>
            public const string TeacherRole = "Teacher";

            /// <summary> Роля за студент </summary>
            public const string StudentRole = "Student";

            /// <summary> Роля за админ </summary>
            public const string AdminRole = "Admin";

            /// <summary> Роля за промотиран учител </summary>
            public const string PromotedTeacherRole = "PromotedTeacher";
        }

        public static class ClaimNames
        {

        }

        /// <summary>
        /// Клас с имена на полисита
        /// </summary>
        public static class PolicyNames
        {
            /// <summary>
            /// Полиси дали може да вижда тезите
            /// </summary>
            public const string ViewTheses = "ViewTheses";
        }
    }
}
