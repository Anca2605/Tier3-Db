using Db3;

class Program
{
    public async static Task Main(string[] args)
    {
        // await Populate();
        ServerSocket socketServer = new ServerSocket();
        socketServer.StartServer();
    }
    }
    