using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        //public string GetData(int value)
        //{
        //    return string.Format("You entered: {0}", value);
        //}

        public BeneficiarioX GetBeneficiario(string ssn1, string ssn2, string ssn3)
        {
            if (ssn1.Length != 3 || ssn2.Length != 2 || ssn3.Length != 4)
            {
                throw new ArgumentNullException("Invalid SSN");
            }
           
            DBConnectionDataContext DB = new DBConnectionDataContext();
            var BEs = from e in DB.Beneficiarios where e.SSN1 == ssn1 && e.SSN2 == ssn2 && e.SSN3 == ssn3 select e;
            
            if (BEs.ToList().Count > 0)
            {
                var BE = BEs.First();
                var SEs = from s in DB.Serv_Benefs where s.id_key == BE.id_Key select s;
                BeneficiarioX B = new BeneficiarioX();
                B.nombre = BE.Nombre;
                B.segundoNombre = BE.SegundoNombre;
                B.apellidoPaterno = BE.ApellidoPaterno;
                B.apellidoMaterno = BE.ApellidoMaterno;
                B.municipioRecidencia = BE.MunicipioResidencia;
                B.sexo = BE.Sexo[0];
                B.fechaDeNacimiento = BE.FechaDeNac;
                foreach(Serv_Benef Se in SEs)
                {
                    ServiciosA SA = new ServiciosA();
                    SA.servicio = Se.Servicio.Servicio1;
                    SA.codigoDeServicio = Se.Servicio.CodServ;
                    SA.fechaDeServicio = Se.FechaServ;
                    SA.servicioActivo = Se.Activo;
                    SA.beneficioActivo = Se.Servicio.Activo;
                    B.servicios.Add(SA);
                }
                return B;
            }
            return null;
        }
    }
}
