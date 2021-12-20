/******************************************************************/ 
/* Archivo: ConnectionService.cs                                  */ 
/* Programador: Raul Peredo Estudillo                             */ 
/* Fecha: 23/oct/2021                                             */ 
/* Fecha modificación: 23/oct/2021                                */ 
/* Descripción: Servicio para verificar si hay conexión con el    */ 
/*              server                                            */ 
/******************************************************************/ 
using Logica.helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.checkConnection
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.Single)]
    class ConnectionService : IConnectionService
    {
        public void Check()
        {

            var connection = OperationContext.Current.GetCallbackChannel<IConnectionClient>();
            bool status = CheckConnection.IsConnected();
            try
            {
                connection.IsConnected(status);
            }
            catch (CommunicationObjectAbortedException)
            {
            }
            
        }
    }
}
