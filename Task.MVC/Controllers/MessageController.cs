using Microsoft.AspNetCore.Mvc;
using Task.BLL.Interfaces;

namespace Task.Controllers;

public class MessageController : Controller
{
    private readonly IRabbitMqService _rabbitMqService;

    public MessageController(IRabbitMqService rabbitMqService)
    {
        _rabbitMqService = rabbitMqService;
    }

    public IActionResult Index()
    {
        const string queueName = "test-queue";
        const string message = "Hello, RabbitMQ!";
        _rabbitMqService.SendMessage(queueName, message);

        return View();
    }
}