using System.Windows.Input;

namespace MotoAPP.ViewModels
{
    public class BaseVM : BaseNotifyVM
    {

        // # # # COMANDOS # # # \\
        public ICommand CommandVoltar { get; set; }

        // # # # MÉTODOS # # # \\
        public async void Voltar()
        {
            await App.Current.MainPage.Navigation.PopAsync();
        }

        public async void AbrirView(ContentPage view)
        {
            await App.Current.MainPage.Navigation.PushAsync(view);
        }


        // ### AVISOS TELA ###
        public async void InfTela(string conteudo)
        {
            await App.Current.MainPage.DisplayAlert("Informação",
                conteudo, "OK");
        }

        public async void AvisoTela(string conteudo)
        {
            await App.Current.MainPage.DisplayAlert("Atenção",
                conteudo, "OK");
        }

        public async void ErroTela(string conteudo)
        {
            await App.Current.MainPage.DisplayAlert("Atenção",
                conteudo, "OK");
        }
    }
}
