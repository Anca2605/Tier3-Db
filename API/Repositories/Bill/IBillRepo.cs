using Db3.Client;

namespace Tier3_Db.Repositories.Bill;

public interface IBillRepo
{
    Task<ServerClient> GetBill(int Id);
}