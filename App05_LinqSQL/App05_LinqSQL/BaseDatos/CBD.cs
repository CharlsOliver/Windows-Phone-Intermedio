using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App05_LinqSQL.BaseDatos
{
    class CBD
    {
    }

    [Table(Name = "tCliente")]

    public class tCliente {
        [Column(DbType = "INT NOT NULL IDENTITY ", //Tipo de dato
                IsPrimaryKey = true,
                IsDbGenerated = true)] //Generar en la misma columna
        public int idCliente { get; set; }

        [Column(DbType = "NVARCHAR(100) NOT NULL")]
        public string nombre { get; set; }

        [Column(DbType = "NVARCHAR(20) NOT NULL")]
        public string telefono { get; set; }

        [Column(DbType = "NVARCHAR(50) NOT NULL")]
        public string correo { get; set; }
    }

}
