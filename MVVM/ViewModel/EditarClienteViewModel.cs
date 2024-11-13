using FitTecnicoDPlus.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace FitTecnicoDPlus.MVVM.ViewModel
{
    [QueryProperty(nameof(Cliente), "Cliente")]
    public class EditarClienteViewModel : INotifyPropertyChanged
    {
        private Cliente _cliente;
        private string _errorMessage;

        public EditarClienteViewModel()
        {
            EditCommand = new Command(Edit);
            DeleteCommand = new Command(Delete);
            GoBackCommand = new Command(GoBack);
        }

        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand GoBackCommand { get; }
        public Cliente Cliente
        {
            get => _cliente;
            set
            {
                _cliente = value;
                OnPropertyChanged(nameof(Cliente));
            }
        }

        private void Edit()
        {
            if (ValidarEntradas())
            {
                App._clienteRepo.Update(Cliente);

                Shell.Current.GoToAsync("//ListarCliente");
            }
                
        }
        private void Delete()
        {
            App._clienteRepo.Delete(Cliente);
            Shell.Current.GoToAsync("//ListarCliente");
        }

        private void GoBack()
        {
            Shell.Current.GoToAsync("//ListarCliente");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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

        public void Initialize(object parameter)
        {
            if (parameter is Cliente cliente)
            {
                Cliente = cliente;
            }
        }
    }

}
