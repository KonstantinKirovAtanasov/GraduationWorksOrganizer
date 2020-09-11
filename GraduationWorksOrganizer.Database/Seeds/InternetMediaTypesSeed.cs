using GraduationWorksOrganizer.Database.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;

namespace GraduationWorksOrganizer.Database.Seeds
{
    /// <summary>
    /// Seed за Internet Media Types
    /// </summary>
    internal static class InternetMediaTypesSeed
    {
        /// <summary>
        /// Метод който сийдва данните
        /// </summary>
        /// <param name="typeBuilder"></param>
        internal static void SeedData(this EntityTypeBuilder<MimeType> typeBuilder)
        {
            List<MimeType> mimeTypes = new List<MimeType>();
            Assembly assembly = Assembly.GetExecutingAssembly();
            string seedFileName = assembly.GetManifestResourceNames().Where(s => s.Contains("MimeTypes")).First();
            Stream fs = assembly.GetManifestResourceStream(seedFileName);
            using (StreamReader sr = new StreamReader(fs))
            {
                while (!sr.EndOfStream)
                {
                    string[] values = sr.ReadLine()?.Split(',');

                    if (values != null && values.Length != 0)
                    {
                        mimeTypes.Add(new MimeType()
                        {
                            Id = Convert.ToInt32(values[0]),
                            Name = values[1],
                            MIMEType = values[2],
                            FileExtention = values[3],
                        });
                    }
                }

                typeBuilder.HasData(mimeTypes);
            }
        }
    }
}