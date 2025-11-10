using MotoAPP.Models;
using MotoAPP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoAPP.Services
{
    public static class SessaoUsuarioService 
    {
        public static Usuario? Usuariologado { get; private set; }

        // (Opcional, mas bom) Evento para notificar a UI se o usuário mudar
        public static event Action? OnSessaoChanged;

        public static void IniciarSessao(Usuario user)
        {
            Usuariologado = user;
            OnSessaoChanged?.Invoke(); // Dispara o evento
        }

        public static void EncerrarSessao()
        {
            Usuariologado = null;
            OnSessaoChanged?.Invoke(); // Dispara o evento
        }
    }
}
