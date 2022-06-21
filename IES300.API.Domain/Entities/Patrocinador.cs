using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IES300.API.Domain.Entities
{
    public class Patrocinador : EntityBase
    {
        public Patrocinador() { }

        public Patrocinador(int id, string nome, string website, string email, string celular, string urlLogo) : base(id)
        {
            this.Nome = nome;
            this.Website = website;
            this.Email = email;
            this.Celular = celular;
            this.UrlLogo = urlLogo;
        }

        public string Nome { get; set; }

        public string Website { get; set; }

        public string Email { get; set; }

        public string Celular { get; set; }

        public string UrlLogo { get; set; }



        public virtual ICollection<Tema> Temas { get; set; }
    }
}
