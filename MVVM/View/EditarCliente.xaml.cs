using FitTecnicoDPlus.MVVM.ViewModel;

namespace FitTecnicoDPlus.MVVM.View;

public partial class EditarCliente : ContentPage
{
	public EditarCliente()
	{
		InitializeComponent();
	}

    private async void Delete_Clicked(object sender, EventArgs e)
    {
        bool excluir = await DisplayAlert("Exclus�o?", "Deseja realmente EXCLUIR o cliente?", "Sim", "N�o");

        if (excluir) 
        {
            if (BindingContext is EditarClienteViewModel viewModel)
            {
                viewModel.DeleteCommand.Execute(viewModel);
            }
        }
        
    }
}