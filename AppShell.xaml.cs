using MotoAPP.Views;
namespace MotoAPP
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(CadMotoView), typeof(CadMotoView));
            Routing.RegisterRoute(nameof(VisMotoView), typeof(VisMotoView));
            Routing.RegisterRoute(nameof(PrincipalView), typeof(PrincipalView));
            Routing.RegisterRoute(nameof(PgPrincipalCliente), typeof(PgPrincipalCliente));

        }
    }
}
