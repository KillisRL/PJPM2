using MotoAPP.Models;
using MotoAPP.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;
namespace MotoAPP.ViewModels
{
    public class GerenciarComprasVM : BaseVM
    {
        private readonly CompraService _compraService;

        private ObservableCollection<MotoCompra> _minhasCompras;
        public ObservableCollection<MotoCompra> MinhasCompras
        {
            get => _minhasCompras;
            set { _minhasCompras = value; OnPropertyChanged(); }
        }

        public ICommand CarregarMinhasComprasCommand { get; set; }
        public ICommand CommandVoltar { get; set; }

        public GerenciarComprasVM(CompraService compraService)
        {
            _compraService = compraService;
            MinhasCompras = new ObservableCollection<MotoCompra>();

            // Comandos
            CarregarMinhasComprasCommand = new Command(CarregarMinhasCompras);
            CommandVoltar = new Command(base.Voltar); // Do seu BaseVM
        }

        public void CarregarMinhasCompras()
        {
            // 1. Pega o usuário logado da Sessão
            var usuarioLogado = SessaoUsuarioService.Usuariologado;
            if (usuarioLogado == null)
            {
                AvisoTela("Usuário não encontrado.");
                return;
            }

            // 2. Limpa a lista antiga
            MinhasCompras.Clear();

            // 3. Chama o serviço para buscar APENAS as compras deste usuário
            var compras = _compraService.GetComprasTotal();

            // 4. Adiciona na lista da tela
            foreach (var compra in compras)
            {
                MinhasCompras.Add(compra);
            }
        }
    }
}