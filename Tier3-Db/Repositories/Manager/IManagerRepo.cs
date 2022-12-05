﻿namespace Db3.Repositories.Manager;

public interface IManagerRepo
{
    Task<Models.Manager.Manager> GetManager(string username, string password);
    Task DeleteManager(int managerId);
    Task<Models.Manager.Manager> GetManagerByUsername(string username);
    Task<Models.Manager.Manager> GetManagerById(int managerId);
    Task DeleteClient(int clientId);
    Task<Models.Client.Client> GetClient(int clientId);
}