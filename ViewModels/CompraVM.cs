using MotoAPP.Models;
using MotoAPP.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MotoAPP.ViewModels
{
    public class CompraVM : BaseVM, IQueryAttributable
    {
        private readonly CompraService _compraService;

        // Propriedades para a tela (View)
        private Moto _motoParaComprar;
        private Usuario _usuarioLogado;
        private decimal _valorCompra;

        public Moto MotoParaComprar
        {
            get => _motoParaComprar;
            set { _motoParaComprar = value; OnPropertyChanged(); }
        }
        public Usuario UsuarioLogado
        {
            get => _usuarioLogado;
            set { _usuarioLogado = value; OnPropertyChanged(); }
        }
        public decimal ValorCompra
        {
            get => _valorCompra;
            set { _valorCompra = value; OnPropertyChanged(); }
        }

        // Comandos
        public ICommand SalvarCompraCommand { get; set; }
        public ICommand CommandVoltar { get; set; }

        // Construtor (Injetando o CompraService)
        public CompraVM(CompraService compraService)
        {
            _compraService = compraService;

            // Pega o usuário logado da sessão estática
            UsuarioLogado = SessaoUsuarioService.Usuariologado;

            // Inicializa os comandos
            SalvarCompraCommand = new Command(SalvarCompra);
            CommandVoltar = new Command(base.Voltar);
        }

        // Método chamado pelo botão "Confirmar Compra"
        private async void SalvarCompra()
        {
            if (MotoParaComprar == null || UsuarioLogado == null)
            {
                 ErroTela("Erro ao carregar dados. Tente novamente.");
                return;
            }
            if (ValorCompra <= 0)
            {
                 AvisoTela("Por favor, insira um valor de compra válido.");
                return;
            }

            try
            {
                // Chama o serviço que você criou
                _compraService.SalvarCompra(MotoParaComprar, UsuarioLogado, ValorCompra);

                 InfTela("Consórcio salvo com sucesso!");
                 base.Voltar(); // Volta para a tela anterior (lista de motos)
            }
            catch (Exception ex)
            {
                 ErroTela($"Erro ao salvar: {ex.Message}");
            }
        }

        // --- ESTE MÉTODO RECEBE O PARÂMETRO DA NAVEGAÇÃO ---
        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey("MotoParaComprar"))
            {
                MotoParaComprar = query["MotoParaComprar"] as Moto;
            }
        }
    }
}
