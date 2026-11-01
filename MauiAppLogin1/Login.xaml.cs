namespace MauiAppLogin1; // Certifique-se de que o '1' está aqui

public partial class Login : ContentPage
{
    public Login()
    {
        InitializeComponent();
    }

    // Método que o botão está procurando no XAML
    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            List<DadosUsuario> lista_usuarios = new List<DadosUsuario>()
            {
                new DadosUsuario()
                {
                    Usuario = "jose",
                    Senha = "123",
                },
                new DadosUsuario()
                {
                    Usuario = "maria",
                    Senha = "321"
                }
            };

            DadosUsuario dados_digitados = new DadosUsuario()
            {
                Usuario = txt_usuario.Text,
                Senha = txt_senha.Text
            };

            // LINQ
            if (lista_usuarios.Any(i => (i.Usuario == dados_digitados.Usuario && i.Senha == dados_digitados.Senha)))
            {
                await SecureStorage.Default.SetAsync("usuario_logado", dados_digitados.Usuario);

                App.Current.MainPage = new Protegida();

            }
            else 
            {
                throw new Exception("Usuário ou senha incorretos!");
            }            

        }
        catch (Exception ex)
        {
            await DisplayAlertAsync("Ops!", ex.Message, "Fechar");
        }
    }
}