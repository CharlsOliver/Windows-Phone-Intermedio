using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App05_LinqSQL.BaseDatos
{
   public class cContextData:DataContext
    {
        public cContextData(string cnBD) : base(cnBD) { }

        public Table<tCliente> tClientes {
            get { return this.GetTable<tCliente>();  }
        }
    }
}
