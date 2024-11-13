using FitTecnicoDPlus.MVVM.View;
using FitTecnicoDPlus.View;

namespace FitTecnicoDPlus;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(ListarCliente), typeof(ListarCliente));
        Routing.RegisterRoute(nameof(CadastrarCliente), typeof(CadastrarCliente));
        Routing.RegisterRoute(nameof(EditarCliente), typeof(EditarCliente));
    }
}