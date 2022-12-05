using Db3;

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
      Location = "Horsens, Denmark"
  };
  Burial burial2 = new Burial()
  {
      Client = client2,
      ClientId = client2.Id,
      Comments =
          "After the religious ceremony, i want to be compressed to a vinyl",
      Date = new DateTime(01 / 01 / 2031),
      PreferenceForBurial = preferenceList2,
      FullNameOfTheDeadMan = "David Cosmin Prodan",
      Location = "Bucharest, Romania"
  };
  await billRepo.CreateBill(bill1);
  await billRepo.CreateBill(bill2);
  await billRepo.CreateBill(bill3);
  
  //preferences

  PreferenceRepo preferenceRepo = new PreferenceRepo();

  Preference preference1 = new Preference()
  {
      Description = "national songs",
      BurialId = burial1.Id
  };
  Preference preference2 = new Preference()
  {
      Description = "fireworks"
  };
  Preference preference3 = new Preference()
  {
      Description = "military singing"
  };
  Preference preference4 = new Preference()
  {
      Description = "specific food"
  };

  await preferenceRepo.CreatePreference(preference1);
  await preferenceRepo.CreatePreference(preference2);
  await preferenceRepo.CreatePreference(preference3);
  await preferenceRepo.CreatePreference(preference4);

  IList<Preference> preferenceList = new Collection<Preference>();
  preferenceList.Add(preference1);
  preferenceList.Add(preference2);
  preferenceList.Add(preference3);
  preferenceList.Add(preference4);
  
  
  Preference preference5 = new Preference()
  {
      Description = "cars rev matching"
  };
  
  Preference preference6 = new Preference()
  {
      Description = "specific food"
  };
  
  Preference preference7 = new Preference()
  {
      Description = "national flag on the coffin"
  };
  
  Preference preference8 = new Preference()
  {
      Description = "all classmates from highschool should be present"
  };
  
  await preferenceRepo.CreatePreference(preference5);
  await preferenceRepo.CreatePreference(preference6);
  await preferenceRepo.CreatePreference(preference7);
  await preferenceRepo.CreatePreference(preference8);

  IList<Preference> preferenceList2 = new Collection<Preference>();
  preferenceList.Add(preference5);
  preferenceList.Add(preference6);
  preferenceList.Add(preference7);
  preferenceList.Add(preference8);
  

}
*/
    }
    