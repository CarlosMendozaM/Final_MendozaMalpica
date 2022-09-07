using System;
using System.Collections.Generic;
using System.Text;
using EFinal.Dominio;
using EFinal.Data;

namespace EFinal.Logic
{
    public static class TipoDocumentoBL
    {
        public static List<TipoDocumento> Listar()
        {
            var tipoDocumentoData = new TipoDocumentoData();
            return tipoDocumentoData.Listar();
        }
    }
}
