﻿using SistemaVendas.Domain.Entities;
using SistemaVendas.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVendas.Application.ViewModels
{
    public class ProductViewModel
    {
        public int id_produto { get; set; }

        public string Nome { get; set; } = null!;

        public string Descricao { get; set; } = null!;

        public int Quantidade { get; set; }

        public decimal? Valor { get; set; }

        public DateTime? DataCadastro { get; set; }

        public virtual ICollection<SaleViewModel> Sales { get; set; } = new List<SaleViewModel>();
    }
}
