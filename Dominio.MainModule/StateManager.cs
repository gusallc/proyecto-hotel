using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio.Objetos;
namespace Dominio.MainModule
{
    public class StateManager
    {
        public List<State> ListaState = new List<State>() {
        new State{ nombre="INACTIVO",valor="0"},
        new State{ nombre="ACTIVO",valor="1"},
        new State{ nombre="RESERVADO",valor="2"}
        };
    }
}
