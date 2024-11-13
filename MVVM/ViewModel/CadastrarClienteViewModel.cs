using FitTecnicoDPlus.Model;
using FitTecnicoDPlus.Repository;
using FitTecnicoDPlus.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FitTecnicoDPlus.ViewModel
{
    public class CadastrarClienteViewModel : INotifyPropertyChanged
    {
        private string _errorMessage;
        public CadastrarClienteViewModel()
        {
            SaveCommand = new Command(Save);
            GoBackCommand = new Command(GoBack);
            Cliente = new Cliente();
        }
        public ICommand SaveCommand { get; set; }
        public ICommand GoBackCommand { get; set; }
        public Cliente Cliente { get; set; }

        private void Save()
        {
            if (ValidarEntradas())
            {
                App._clienteRepo.Add(Cliente);

                Shell.Current.GoToAsync("..");
            }
                
        }
        private void GoBack()
        {
            Shell.Current.GoToAsync("//ListarCliente");
        }

        private bool ValidarEntradas() 
        { 
            if (string.IsNullOrWhiteSpace(Cliente.Name) 
                || string.IsNullOrWhiteSpace(Cliente.LastName) 
                || !Cliente.Age.HasValue 
                || string.IsNullOrWhiteSpace(Cliente.Adress)) 
            { 
                ErrorMessage = "Todos os campos são obrigatórios."; 
                return false; 
            } 
            return true; 
        }

        public string ErrorMessage 
        { 
            get 
            { 
                return _errorMessage; 
            } 
            set 
            { 
                _errorMessage = value; 
                OnPropertyChanged(nameof(ErrorMessage)); 
            } 
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName) 
        { 
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); 
        }
    }
}
