using Lesson24.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson24.Extentions
{
    internal static class FileHelper<T>
    {
        private static readonly string[] _paths = new string[]
        {
            @"C:\Users\Mate_Okroshiashvili\Desktop\Hotels\Hotels.txt",
            @"C:\Users\Mate_Okroshiashvili\Desktop\Hotels\Rooms.txt",
            @"C:\Users\Mate_Okroshiashvili\Desktop\Hotels\Users.txt",
        };

        public static void WriteInFile(
            FILE_TYPES fileType, T entity, bool append = true)
        {
            using (StreamWriter writer = new StreamWriter(
                _paths[Convert.ToInt32(fileType)], append: append))
            {
                writer.WriteLine(entity);
            }
        }

        public static void WriteInFile(
            FILE_TYPES fileType, List<T> values, bool append = true)
        {
            using (StreamWriter writer = new StreamWriter(
                _paths[Convert.ToInt32(fileType)], append: append))
            {
                foreach (T entity in values) 
                {
                    writer.WriteLine(entity);
                }
            }
        }
    }
}
