﻿using matrix.Models.Entidades;

namespace matrix.Models.Views
{
    public class ServicoViewModel
    {
        public string Descricao { get; set; }
        public string TipoServico { get; set; }
        public string? NomeEquipe { get; set; }
        public int EquipeId { get; set; }
    }
}
