﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyecto_1.Models.ViewModel
{
    public class ListaClientesViewModel
    {
        public int id_cliente { get; set; }

        public string nombre { get; set; }

        public string direccion { get; set; }

        public int telefono { get; set; }

        public char estado { get; set; }

        public string CUIT { get; set; }

        public string IVA { get; set; }
    }
}