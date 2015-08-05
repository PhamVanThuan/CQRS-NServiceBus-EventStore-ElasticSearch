using System.Collections.Generic;
using ElasticSearchReadModel.Documents;

namespace ElasticSearchReadModel.Repositories
{
    public interface IClientInformationRepository
    {
        IEnumerable<ClientInformation> GetClientsBy(string name, bool? onlyPossiblyStolen);
    }
}
