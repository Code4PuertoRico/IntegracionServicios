using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        BeneficiarioX GetBeneficiario(string ssn1, string ssn2, string ssn3);
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class BeneficiarioX
    {
        bool Activo = true;
        string SSN1 = "000";
        string SSN2 = "00";
        string SSN3 = "0000";

        string Nombre = "";
        string SegundoNombre = "";
        string ApellidoPaterno = "";
        string ApellidoMaterno = "";
        char? Sexo;
        DateTime? FechaDeNacimiento;

        int MunicipioRecidencia = 0;

        List<ServiciosA> Servicios = new List<ServiciosA>();

        [DataMember]
        public bool activo
        {
            get { return Activo; }
            set { Activo = value; }
        }

        //[DataMember]
        //public string ssn
        //{
        //    get { return string.Format("{0}-{1}-{2}", SSN1, SSN2, SSN3); }
        //    //set { stringValue = value; }
        //}
        [DataMember]
        public string nombre
        {
            get { return Nombre; }
            set { Nombre = value; }
        }
        [DataMember]
        public string apellidoPaterno
        {
            get { return ApellidoPaterno; }
            set { ApellidoPaterno = value; }
        }

        [DataMember]
        public string apellidoMaterno
        {
            get { return ApellidoMaterno; }
            set { ApellidoMaterno = value; }
        }

        [DataMember]
        public int municipioRecidencia
        {
            get { return MunicipioRecidencia; }
            set { MunicipioRecidencia = value; }
        }

        [DataMember]
        public string segundoNombre
        {
            get { return SegundoNombre; }
            set { SegundoNombre = value; }
        }

        [DataMember]
        public char? sexo
        {
            get { return Sexo; }
            set { Sexo = value; }
        }

        [DataMember]
        public DateTime? fechaDeNacimiento
        {
            get { return FechaDeNacimiento; }
            set { FechaDeNacimiento = value; }
        }

        [DataMember]
        public List<ServiciosA> servicios
        {
            get { return Servicios; }
            set { Servicios = value; }
        }
    }

    [DataContract]
    public class ServiciosA
    {
        string Servicio;
        string CodigoDeServicio;
        bool? ServicioActivo;
        DateTime? FechaDeServicio;
        bool? BeneficioActivo;

        [DataMember]
        public string servicio
        {
            get { return Servicio; }
            set { Servicio = value; }
        }

        [DataMember]
        public string codigoDeServicio
        {
            get { return CodigoDeServicio; }
            set { CodigoDeServicio = value; }
        }

        [DataMember]
        public bool? servicioActivo
        {
            get { return ServicioActivo; }
            set { ServicioActivo = value; }
        }

        [DataMember]
        public bool? beneficioActivo
        {
            get { return BeneficioActivo; }
            set { BeneficioActivo = value; }
        }

        [DataMember]
        public DateTime? fechaDeServicio
        {
            get { return FechaDeServicio; }
            set { FechaDeServicio = value; }
        }
    }

}
