using Microsoft.AspNetCore.SignalR;
using Project_MLD.Service.Interface;

public class AccountHub : Hub
{
    private readonly IAccountRepository _accountRepository;
    public AccountHub(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }
    public async Task SendGetAllAccountEvent()
    {
        var account = await _accountRepository.GetAllAccounts();
        await Clients.All.SendAsync("GetAllAccount", account);
    }
}

