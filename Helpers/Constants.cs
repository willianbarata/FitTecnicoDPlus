using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitTecnicoDPlus.Helpers
{
    public static class Constants
    {
        public static string DatabasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "FitTecnicoDPlus.db");
        public const SQLiteOpenFlags Flags = SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.SharedCache;
    }
}
