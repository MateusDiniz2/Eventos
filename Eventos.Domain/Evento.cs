﻿using System;
using System.Collections.Generic;

namespace Eventos.Domain
{
    public class Evento
    {
        public int Id { get; set; }
        public string Local { get; set; }
        public string Tema { get; set; }
        public int QtdPessoas { get; set; }
        public string ImagemURL { get; set; }
        public string Telefone { get; set; }
        public DateTime? DataEvento { get; set; }
        public IEnumerable<Lote> Lote { get; set; }
        public IEnumerable<RedeSocial> RedeSociais { get; set; }
        public IEnumerable<PalestranteEvento> PalestranteEventos { get; set; }

    }
}
 