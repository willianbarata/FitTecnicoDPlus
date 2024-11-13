using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitTecnicoDPlus.Model
{
    [SQLite.Table("CLIENTE")]
    public class Cliente : INotifyPropertyChanged
    {
        private int _id;
        private string _name;
        public string _lastName { get; set; }
        public int? _age { get; set; }
        public string _adress { get; set; }

        public Cliente()
        {
            _age = null;
        }

        [PrimaryKey, AutoIncrement]
        public int Id 
        {
            get { return _id; } 
            set { _id = value; OnPropertyChanged(nameof(Id)); } 
        }
        [SQLite.Column("Name"), MaxLength(20), NotNull]
        public string Name
        { 
            get { return _name; }
            set { _name = value; OnPropertyChanged(nameof(Name)); }
        }
        [SQLite.Column("LastName"), MaxLength(40), NotNull]
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; OnPropertyChanged(nameof(LastName)); }
        }
        [SQLite.Column("Age")]
        public int? Age
        {
            get { return _age; }
            set { _age = value; OnPropertyChanged(nameof(Age)); }
        }
        [SQLite.Column("Adress"), MaxLength(100)]
        public string Adress
        {
            get { return _adress; }
            set { _adress = value; OnPropertyChanged(nameof(Adress)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
