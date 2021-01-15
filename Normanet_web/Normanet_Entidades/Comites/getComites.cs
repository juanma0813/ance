using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Normanet_Entidades.Comites
{
    public class getComites
    {
        public string ID_Comite { get; set; }
        public string ID_CT { get; set; }
        public string ID_SC { get; set; }
        public string ID_Grupo { get; set; }
        public string Descripcion { get; set; }
        public string Objetivo { get; set; }
        public string Responsable { get; set; }
    }
    public class getComitesDescripcion
    {
        public string ID_Comite { get; set; }
        public string ID_CT { get; set; }
        public string ID_SC { get; set; }
        public string ID_Grupo { get; set; }
        public string Descripcion { get; set; }
        public string Objetivo { get; set; }
        public string Responsable { get; set; }
        public Boolean Inactivo { get; set; }

    }
    public class GetDeleteComitesDescripcion_Parameter
    {
        public string Bandera { get; set; }
        public string Comite { get; set; }
        public string CT { get; set; }
        public string SC { get; set; }
        public string GT { get; set; }
    }
    public class addComite_post_put_Parameter
    {
        public string Bandera { get; set; }
        public string Comite { get; set; }
        public string Descripcion { get; set; }
        public string Responsable { get; set; }
        public string Inactivo { get; set; }
        public string Objetivo { get; set; }
        public string CT { get; set; }
        public string SC { get; set; }
        public string GT { get; set; }
    }


}
