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
  ClientRepo clientRepo = new ClientRepo();
  Client moderator = new Client()
  {
      Username = "moderator",
      Password = "123456",
      Name = "sefu"
  };
  await clientRepo.CreateClientAccount(moderator);
  
  //clients

  Client client1 = new Client()
  {
      Email = "client1@yahoo.com",
      Name = "Sandu Malai",
      Password = "via12345",
      Username = "stapanullumii"
  };
  Client client2 = new Client()
  {
      Email = "client2@yahoo.com",
      Name = "Florin Alexandru",
      Password = "florinel25",
      Username = "floriVia"
  };
  Client client3 = new Client()
  {
      Email = "client3@yahoo.com",
      Name = "Stefan Marius",
      Password = "honda1995",
      Username = "mariusstefanel21"
  };
  Client client4 = new Client()
  {
      Email = "client4@yahoo.com",
      Name = "Adrian Gabriel",
      Password = "adi123",
      Username = "adivaitis"
  };
  Client client5 = new Client()
  {
      Email = "client5@yahoo.com",
      Name = "Mircea Mihai",
      Password = "telecomanda",
      Username = "wilsonthevolleyball"
  };
  await clientRepo.CreateClientAccount(client1);
  await clientRepo.CreateClientAccount(client2);
  await clientRepo.CreateClientAccount(client3);
  await clientRepo.CreateClientAccount(client4);
  await clientRepo.CreateClientAccount(client5);

  //burials

  BurialRepo burialRepo = new BurialRepo();

  Burial burial1 = new Burial()
  {
      Client = client1,
      ClientId = client1.Id,
      Comments =
          "I want to have a religious burial where all my friend and family will attend and also i want to have national music played",
      Date = new DateTime(17 / 05 / 2023),
      PreferenceForBurial = preferenceList,
      FullNameOfTheDeadMan = "Marius Alexandru Mihai",
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
  await burialRepo.CreateBurial(burial1);
  await burialRepo.CreateBurial(burial2);
  
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

    

