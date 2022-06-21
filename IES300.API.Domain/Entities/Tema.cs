using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IES300.API.Domain.Entities
{
    public class Tema : EntityBase
    {
        public Tema() { }

        public Tema(int id, string nome, string urlTabuleiro, int idPatrocinador) : base(id)
        {
            this.Nome = nome;
            this.UrlTabuleiro = urlTabuleiro;
            this.IdPatrocinador = idPatrocinador;
        }

        public string Nome { get; set; }

        public string UrlTabuleiro { get; set; }

        public int IdPatrocinador { get; set; }


        public virtual Patrocinador Patrocinador { get; set; }

        public virtual ICollection<Ficha> Fichas { get; set; }
    }
}
