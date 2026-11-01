using Microsoft.Extensions.DependencyInjection;

namespace MauiAppLogin1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Inicializa provisoriamente com a tela de Login para o app arrancar de forma síncrona e segura
            MainPage = new Login();
        }

        protected override async void OnStart()
        {
            base.OnStart();

            try
            {
                // Verifica de forma segura se já existe um usuário logado armazenado
                string usuario_logado = await SecureStorage.Default.GetAsync("usuario_logado");

                if (!string.IsNullOrEmpty(usuario_logado))
                {
                    // Se já estiver logado, redireciona para a área protegida
                    MainPage = new Protegida();
                }
            }
            catch (Exception)
            {
                // Caso ocorra qualquer falha no SecureStorage, mantém na tela de Login por segurança
                MainPage = new Login();
            }
        }

        protected override Window CreateWindow(IActivationState activationState)
        {
            var window = base.CreateWindow(activationState);
            window.Width = 400;
            window.Height = 600;
            return window;
        }
    }
}