using MotoAPP.Models;
using MotoAPP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoAPP.Services
{
    public partial class SessaoUsuarioService
    {
        public static Usuario? Usuariologado { get; private set; }
        public static event Action? OnSessaoChanged; 

        public static void IniciarSessao(Usuario user) 
        {
            Usuariologado = user;
            
        }

        public static void EncerrarSessao() // Método de Logout unificado
        {
            Usuariologado = null;
        }
    }
}
