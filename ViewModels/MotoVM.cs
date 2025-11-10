using MotoAPP.Models;
using MotoAPP.Services;
using MotoAPP.Views;
using System.Security.Cryptography.X509Certificates;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Threading.Tasks;

namespace MotoAPP.ViewModels
{
    public class MotoVM : BaseVM
    {
        public string NomeUsuarioLogado
        {
            get
            {
                // Busca o nome do usuário na sessão estática
                return SessaoUsuarioService.Usuariologado?.Username ?? "Convidado";
            }
        }
        private readonly CompraService _compraService;

        private readonly MotoService _motoservice;

        // VARIAVEIS
        private string? _descricao;
        private string? _marca;
        private string? _modelo;
        private string? _ano;
        private ObservableCollection<Moto>? _motos;
        private Moto? _motoSelecionada;
        private bool _isEditMode;
        // COMANDOS

        public ICommand CommandVoltar { get; set; }
        public ICommand CommandCadastrar { get; set; }
        public ICommand CommandMotoView { get; set; }
        public ICommand CommandVisualizar { get; set; }
        public ICommand CommandVisMotoView { get; set; }
        public ICommand CommandEditar  {get; set; }
        public ICommand CommandAlterar { get; set; }
        public ICommand CommandExcluir { get; set; }

        public ICommand CommandComprar { get; set; }

        // PROPRIEDADES
        public bool IsEditMode
        {
            get { return _isEditMode; }
            set
            {
                _isEditMode = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsNotEditMode)); // Notifica a propriedade inversa
            }
        }
        public bool IsNotEditMode => !IsEditMode;
        public string? Descricao
        {
            get { return _descricao; }
            set
            {
                _descricao = value;
                OnPropertyChanged();
            }

        }
        public string? Marca
        {
            get { return _marca; }
            set
            {
                _marca = value;
                OnPropertyChanged();
            }

        }
        
        public string? Modelo
        {
            get { return _modelo; }
            set
            {
                _modelo = value;
                OnPropertyChanged();
            }

        }
        public string? Ano
        {
            get { return _ano; }
            set
            {
                _ano = value;
                OnPropertyChanged();
            }

        }
        public ObservableCollection<Moto>? Motos
        {
            get { return _motos; }
            set
            {
                _motos = value;
                OnPropertyChanged();
            }
        }

        // METODOS
        void CadastrarMoto()
        {
            if (string.IsNullOrWhiteSpace(Descricao) ||
                string.IsNullOrWhiteSpace(Marca) ||
                string.IsNullOrEmpty(Modelo) ||
                string.IsNullOrEmpty(Ano))
            {
                AvisoTela("Por favor, preencha todos os campos");
                return;
            }

            Moto moto = new Moto
            {
                Descricao = Descricao,
                Marca = Marca,
                Modelo = Modelo,
                Ano = Ano
            };

            _motoservice.Insert(moto);

            InfTela("Moto Cadastrada com sucesso!😎");
            Shell.Current.GoToAsync(nameof(VisMotoView));
        }

        void VisMoto()
        {
            // 1. Chama o método GetAll do Service
            List<Moto> listaDoDB = _motoservice.GetAll();

            // 2. Converte a lista para ObservableCollection
            Motos = new ObservableCollection<Moto>(listaDoDB);
        }

        async void MotoCadView()
        {
            Descricao = string.Empty;
            Marca = string.Empty;
            Modelo = string.Empty;
            Ano = string.Empty;
            MotoSelecionada = null; // Garante que não estamos editando

            // 2. Define o modo como "Criação" (NÃO é edição)
            IsEditMode = false;

            // 3. Navega para a tela de cadastro
            await Shell.Current.GoToAsync(nameof(CadMotoView));
        }

        void MotoVisView()
        {
            Shell.Current.GoToAsync(nameof(VisMotoView));
        }
        public Moto? MotoSelecionada
        {
            get { return _motoSelecionada; }
            set
            {
                _motoSelecionada = value;
                OnPropertyChanged();
            }
        }
        async void PreencherParaEditar()
        {
            // 1. Verifica a propriedade pública
            if (MotoSelecionada == null)
            {
                AvisoTela("Selecione uma moto para editar.");
                return;
            }

            Descricao = MotoSelecionada.Descricao;
            Marca = MotoSelecionada.Marca;
            Modelo = MotoSelecionada.Modelo;
            Ano = MotoSelecionada.Ano;

            // 3. Define o modo e navega
            IsEditMode = true;
            await Shell.Current.GoToAsync(nameof(CadMotoView));
        }
        async void ExcluirMoto()
        {
            var motoParaExcluir = MotoSelecionada;
            // 1. Verifica a propriedade pública
            if (motoParaExcluir == null)
            {
                AvisoTela("Selecione uma moto para Excluir.");
                return;
            }

            bool confirmou = await Application.Current.MainPage.DisplayAlert("Confirmar Exclusão",
                $"Tem certeza que deseja excluir a moto: {motoParaExcluir.Descricao}?",
                "Sim, Excluir",
                "Não");

            if(!confirmou)
            {
                return;
            }
            else
            {
                try
                {
                    _motoservice.Delete(motoParaExcluir);
                    Motos.Remove(motoParaExcluir);

                    MotoSelecionada = null;
                    InfTela("Moto excluída com sucesso.");
                }
                catch(Exception ex)
                {
                    ErroTela($"Erro ao excluir: {ex.Message}");
                }
            }

        }

        void AlterarMoto()
        {
           
            // 1. Verifica se uma moto foi selecionada ANTES de navegar para esta tela
            if (MotoSelecionada == null)
            {
                AvisoTela("Erro: Nenhuma moto estava selecionada para alteração.");
                return;
            }

            // 2. Atualiza o objeto 'MotoSelecionada' com os dados dos campos (Entrys)
            MotoSelecionada.Descricao = Descricao;
            MotoSelecionada.Marca = Marca;
            MotoSelecionada.Modelo = Modelo;
            MotoSelecionada.Ano = Ano;

            // 3. Chama o serviço de atualização no banco de dados
            _motoservice.Update(MotoSelecionada);

            InfTela("Moto alterada com sucesso!");

            // 4. Limpa os campos e volta para a lista
            Descricao = string.Empty;
            Marca = string.Empty;
            Modelo = string.Empty;
            Ano = string.Empty;

            Shell.Current.GoToAsync(nameof(VisMotoView));
        }
        async void ComprarMoto()
        {
            if (MotoSelecionada != null && SessaoUsuarioService.Usuariologado != null)
            {
                decimal valorDoConsorcio = 10000.00m; // Pega o valor de algum lugar

                // A ViewModel apenas DELEGA a tarefa para o serviço
                _compraService.SalvarCompra(MotoSelecionada, SessaoUsuarioService.Usuariologado, valorDoConsorcio);

                InfTela("Compra realizada com sucesso!");
            }
        }
        // CONSTRUTOR

        public MotoVM(MotoService motoService)
        {
            _motoservice = motoService;
            CommandEditar = new Command(PreencherParaEditar);
            CommandCadastrar = new Command(CadastrarMoto);
            CommandVoltar = new Command (base.Voltar);
            CommandMotoView = new Command(MotoCadView);
            CommandVisualizar = new Command(VisMoto);
            CommandVisMotoView = new Command(MotoVisView);
            CommandAlterar = new Command(AlterarMoto);
            CommandExcluir = new Command(ExcluirMoto);
            CommandComprar = new Command(ComprarMoto);

            SessaoUsuarioService.OnSessaoChanged +=
                () => OnPropertyChanged(nameof(NomeUsuarioLogado));

        }
    }
}
