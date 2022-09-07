using System;
using System.Collections.Generic;
using System.Text;
using EFinal.Dominio;
using EFinal.Data;

namespace EFinal.Logic
{
    public static class TipoClienteBL
    {
        public static List<TipoCliente> Listar()
        {
            var tipoClienteData = new TipoClienteData();
            return tipoClienteData.Listar();
        }
    }
}
