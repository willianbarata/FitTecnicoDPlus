using FitTecnicoDPlus.Model;
using FitTecnicoDPlus.MVVM.View;
using FitTecnicoDPlus.Repository;
using FitTecnicoDPlus.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FitTecnicoDPlus.MVVM.ViewModel
{
    public class ListarClienteViewModel : INotifyPropertyChanged
    {
        public ICommand NovoClienteCommand { get; set; }
        public Cliente Cliente { get; set; }
        public ObservableCollection<Cliente> Clientes { get; set; }
        public ICommand SelecionarClienteCommand { get; }

        public ListarClienteViewModel()
        {
            NovoClienteCommand = new Command(NovoCliente);
            SelecionarClienteCommand = new Command(SelecionarCliente);
            Clientes = new ObservableCollection<Cliente>();
        }
        private void NovoCliente()
        {
            Shell.Current.GoToAsync(nameof(CadastrarCliente));

        }
        private void SelecionarCliente()
        {
            if(Cliente != null)
            {
                var navigationParameter = new Dictionary<string, object> { { "Cliente", Cliente } };

                Shell.Current.GoToAsync(nameof(EditarCliente), navigationParameter);
            }

        }

        public void RecarregarClientes() 
        { 
            if(Clientes != null)
            {
                Cliente = null;
                Clientes.Clear();
                var listaClientes = App._clienteRepo.GetAll();
                foreach (var clientes in listaClientes)
                {
                    Clientes.Add(clientes);
                }
                
            }
           
            
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
