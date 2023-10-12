namespace Task.BLL.Interfaces;

public interface IRabbitMqService
{
    void SendMessage(string queueName, string message);
}