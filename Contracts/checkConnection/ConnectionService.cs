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
        public void check()
        {

            var connection = OperationContext.Current.GetCallbackChannel<IConnectionClient>();
            bool status = CheckConnection.isConnected();
            connection.isConnected(status);
        }
    }
}
