using FitTecnicoDPlus.Repository;
using FitTecnicoDPlus.View;

namespace FitTecnicoDPlus
{
    public partial class App : Application
    {
        public static ClienteRepository _clienteRepo { get; set; }
        public App(ClienteRepository clienteRepository)
        {
            InitializeComponent();
            _clienteRepo = clienteRepository;

            MainPage = new AppShell();
        }
    }
}
