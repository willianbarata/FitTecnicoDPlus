using FitTecnicoDPlus.Model;
using FitTecnicoDPlus.MVVM.ViewModel;
using System.Collections.ObjectModel;

namespace FitTecnicoDPlus.View;

public partial class ListarCliente : ContentPage
{
    public ListarCliente()
	{
		InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is ListarClienteViewModel viewModel) 
        { 
            viewModel.RecarregarClientes(); 
        }
    }

}