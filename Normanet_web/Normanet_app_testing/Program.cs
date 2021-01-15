using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using comunicaciones = Normanet_Comunicaciones.Comites.Comites;

namespace Normanet_app_testing
{
    class Program
    {
        static void Main(string[] args)
        {

            //List<Normanet_Entidades.Comites.getComites> getComites = comunicaciones.getComites_Get("CT 14", "SC 14 A");


            Normanet_Entidades.Comites.GetDeleteComitesDescripcion_Parameter getDelete = new Normanet_Entidades.Comites.GetDeleteComitesDescripcion_Parameter();
            getDelete.Bandera = "4";
            getDelete.Comite = "CONANCE 2";
            getDelete.CT = "CT 14";
            getDelete.GT = "GT 14 TEST";
            getDelete.SC = "SC 14 A";
            List<Normanet_Entidades.Comites.getComitesDescripcion> getComitesDescripcion = comunicaciones.getComitesDescripcion_Get(getDelete);
            Console.WriteLine();
        }
    }
}
