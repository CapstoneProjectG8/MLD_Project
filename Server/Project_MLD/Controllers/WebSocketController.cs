using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_MLD.Service.Interface;
using Project_MLD.Service.Repository;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Text;

namespace Project_MLD.Controllers
{
    [Route("api/[controler]")]
    [ApiController]
    public class WebSocketController : ControllerBase
    {
        private static readonly List<WebSocket> _sockets = new List<WebSocket>();
        private readonly IUserRepository _userRepo;
        private readonly IAccountRepository _accountRepo;

        //chỉ để test
        private readonly ILogger<WebSocketController> _logger;

        public WebSocketController(IUserRepository userRepo, IAccountRepository accountRepo, ILogger<WebSocketController> logger)
        {
            _userRepo = userRepo;
            _accountRepo = accountRepo;
            _logger = logger;
        }

        [Route("/ws")]
        [HttpGet]
        public async Task Get()
        {
            if (HttpContext.WebSockets.IsWebSocketRequest)
            {
                using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
                _logger.LogInformation("WebSocket connection established.");
                _sockets.Add(webSocket);
                await Echo(webSocket);
                _sockets.Remove(webSocket);
            }
            else
            {
                HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            }
        }

        [Route("/GetAllUser")]
        [HttpGet]   
        public async Task GetAllUser()
        {
            if (HttpContext.WebSockets.IsWebSocketRequest)
            {
                using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();

                var users = await _userRepo.GetAllUsers();

                var userJson = System.Text.Json.JsonSerializer.Serialize(users);

                var buffer = System.Text.Encoding.UTF8.GetBytes(userJson);

                await webSocket.SendAsync(
                    new ArraySegment<byte>(buffer),
                    WebSocketMessageType.Text, true,
                    CancellationToken.None);

                await Echo(webSocket);
            }
            else
            {
                HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            }
        }

        [Route("/GetAllAccount")]
        [HttpGet]
        public async Task GetAllAccount()
        {
            if (HttpContext.WebSockets.IsWebSocketRequest)
            {
                using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();

                var users = await _accountRepo.GetAllAccounts();

                var userJson = System.Text.Json.JsonSerializer.Serialize(users);

                var buffer = System.Text.Encoding.UTF8.GetBytes(userJson);

                await webSocket.SendAsync(
                    new ArraySegment<byte>(buffer),
                    WebSocketMessageType.Text, true,
                    CancellationToken.None);

                await Echo(webSocket);
            }
            else
            {
                HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            }
        }

        public static async Task NotifyAllClients(string message)
        {
            var buffer = Encoding.UTF8.GetBytes(message);
            var tasks = _sockets.Select(async socket =>
            {
                if (socket.State == WebSocketState.Open)
                {
                    await socket.SendAsync(
                        new ArraySegment<byte>(buffer, 0, buffer.Length),
                        WebSocketMessageType.Text, true, CancellationToken.None);
                }
            });
            await Task.WhenAll(tasks);
        }

        private static async Task Echo(WebSocket webSocket)
        {
            var buffer = new byte[1024 * 4];
            var receiveResult = await webSocket.ReceiveAsync(
                new ArraySegment<byte>(buffer), CancellationToken.None);

            while (!receiveResult.CloseStatus.HasValue)
            {
                await webSocket.SendAsync(
                    new ArraySegment<byte>(buffer, 0, receiveResult.Count),
                    receiveResult.MessageType,
                    receiveResult.EndOfMessage,
                    CancellationToken.None);

                receiveResult = await webSocket.ReceiveAsync(
                    new ArraySegment<byte>(buffer), CancellationToken.None);
            }

            await webSocket.CloseAsync(
                receiveResult.CloseStatus.Value,
                receiveResult.CloseStatusDescription,
                CancellationToken.None);
        }
    }
}
