using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IES300.API.Domain.Entities
{
    public abstract class EntityBase
    {
        protected EntityBase() { }

        protected EntityBase(int id)
        {
            this.Id = id;
        }

        public int Id { get; set; }

        public bool Ativado { get; set; }
    }
}
