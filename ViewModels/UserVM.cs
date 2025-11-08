using MotoAPP.Services;
using MotoAPP.Models;
using MotoAPP.Views;
using System.Windows.Input;

namespace MotoAPP.ViewModels
{
    public class UserVM : BaseVM
    {
        // Instanciar a classe de serviço
        UserService userService = new UserService();

        // VARIAVEIS
       // private int _userid;
        private string _username;
        private string _email;
        private string _telefone;
        private string _senha;
        private bool _tipousuario;
        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged();
            }

        }
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged();
            }

        }
        public string Telefone
        {
            get { return _telefone; }
            set
            {
                _telefone = value;
                OnPropertyChanged();
            }

        }
        public string Senha
        {
            get { return _senha; }
            set
            {
                _senha = value;
                OnPropertyChanged();
            }

        }

        public bool TipoUsuario
        {
            get { return _tipousuario; }
            set
            {
                _tipousuario = value;
                OnPropertyChanged();
            }

        }

        // COMANDOS

        public ICommand CommandCadastrar { get; set; }
        public ICommand CommandVoltar { get; set; }
        public ICommand CommandCadView { get; set; }
        public ICommand CommandAcessar { get; set; }

        // MÉTODOS
        void CadastrarUser()
        {
            if (string.IsNullOrWhiteSpace(Username) ||
                string.IsNullOrWhiteSpace(Senha) ||
                string.IsNullOrEmpty(Email) ||
                string.IsNullOrEmpty(Telefone))
            {
                AvisoTela("Por favor, preencha todos os campos");
                return;
            }

            Usuario user = new Usuario();

            user.Username = Username;
            user.Email = Email;
            user.Telefone = Telefone;
            user.Senha = Senha;
            user.TipoUsuario = TipoUsuario;

            userService.Insert(user);

            InfTela("Usuário Cadastrado com sucesso");
            AbrirView(new LoginView());
        }

        void Voltar()
        {
            Voltar();
        }
        void CadView()
        {
            AbrirView(new CadastroView());
        }

        async Task Acessar()
        {
            // Validação: Verifica se os campos estão vazios
            if (string.IsNullOrWhiteSpace(Username)
                || string.IsNullOrWhiteSpace(Senha))
            {
                AvisoTela("Por favor, preencha o usuário e a senha.");
                return;
            }

            // Validação: Verifica no banco de dados
            Usuario usuarioValidado = userService.
                ValidarLogin(Username, Senha);

            if (usuarioValidado != null)
            {
                // Login bem-sucedido
                InfTela($"Bem-vindo, {usuarioValidado.Username}!");

                SessaoUsuarioService.IniciarSessao(usuarioValidado);

                if (usuarioValidado.TipoUsuario == true) 
                {
                    await Shell.Current.GoToAsync(nameof(PrincipalView));
                }
                else 
                {
                    await Shell.Current.GoToAsync(nameof(PgPrincipalCliente));
                }
            }
            else
            {
                // Login falhou
                ErroTela("Usuário ou senha inválidos");
            }
        }

        // Vincular Comandos aos métodos
        public UserVM()
        {
            CommandCadastrar = new Command(CadastrarUser);
            CommandVoltar = new Command(Voltar);
            CommandCadView = new Command(CadView);
            CommandAcessar = new Command(async () => await Acessar());
        }
    }
}
