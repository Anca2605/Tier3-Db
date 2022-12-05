using Db3;
using Tier3_Db.Network.Connection;

class Program
{
    public async static Task Main(string[] args)
    {
        // await Populate();
        ServerSocket socketServer = new ServerSocket();
        socketServer.StartServer();
    }
    /*  static async Task Populate()
{
  ManagerRepo managerRepo = new ManagerRepo();
  Manager manager = new Manager()
  {
      Username = "Manager",
      Password = "000000",
      Name = "Boss"
  };
  await managerRepo.CreateManagerAccount(manager);
  
  //clients

  Client client1 = new Client()
  {
      Email = "khamzat@gmail.com",
      Name = "Khamzat Chimaev",
      Password = "password886",
      Username = "gourmetChechen",
      Phonenumber = "11112222",
      Id = "1"
  };
  Client client2 = new Client()
  {
      Email = "karolsoban@gmail.com",
      Name = "Karolina Sobanska",
      Password = "vegeislife",
      Username = "karolinasobanska",
      Phonenumber = "33334444",
      Id = "2"
  };
  Client client3 = new Client()
  {
      Email = "sobanmaupa@gmail.com",
      Name = "Jakob Sobanski",
      Password = "veganforlife",
      Username = "Soban227",
      Phonenumber = "55556666",
      Id = "3"
  };

  await clientRepo.CreateClientAccount(client1);
  await clientRepo.CreateClientAccount(client2);
  await clientRepo.CreateClientAccount(client3);

  //bill

  BillRepo billRepo = new BillRepo();

  Bill bill1 = new Bill()
  {
      Client = client1,
      ClientId = client1.Id,
      Date = new DateTime(11 / 03 / 2022),
      Phonenumber = 11112222,
      Name = "Khamzat Chimaev",
      BillId = bill1.Id,
      TotalAmount = 
  };
  
  await billRepo.CreateBill(bill1);
}
*/
    }
    