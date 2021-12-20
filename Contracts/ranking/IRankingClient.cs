using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.ranking
{
    [ServiceContract]
    interface IRankingClient
    {
        [OperationContract(IsOneWay = true)]
        void ShowRanking(Tuple<string,int> rank);
    }
}

