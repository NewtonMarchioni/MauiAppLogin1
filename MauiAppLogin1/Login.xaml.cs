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
        string usuario = txt_usuario.Text;
        string senha = txt_senha.Text;

        if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(senha))
        {
            await DisplayAlert("Atenção", "Preencha todos os campos!", "OK");
            return;
        }

        // Validação de exemplo e troca para a MainPage
        if (usuario == "admin" && senha == "123")
        {
            Application.Current.MainPage = new NavigationPage(new MainPage());
        }
        else
        {
            await DisplayAlert("Erro", "Usuário ou senha incorretos.", "OK");
            txt_senha.Text = string.Empty;
            txt_usuario.Focus();
        }
    }
}