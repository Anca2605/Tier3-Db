using Db3;
using Tier3_Db.Network.Connection;


class Program
{
    
    
    public async static Task Main(string[] args)
    {
        
        ServerSocket socketServer = new ServerSocket();
        socketServer.StartServer();
    }
    
    }
    