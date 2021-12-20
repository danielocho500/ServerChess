/******************************************************************/
/* Archivo: IRegisterService.cs                                   */
/* Programador: Daniel Diaz Rossell                             */
/* Fecha: 18/oct/2021                                             */
/* Fecha modificación: 22/oct/2021                                */
/* Descripción: Interfaz donde se definen metodos del server para */
/*              para el servicio de login                         */
/******************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.register
{
    [ServiceContract(CallbackContract = typeof(IRegisterClient))]
    interface IRegisterService
    {
        [OperationContract(IsOneWay = true)]
        void GenerateCodeRegister(string username, string password, string email);
        [OperationContract(IsOneWay = true)]
        void VerificateCode(string codeuser);
    }
}
