using Client;
using System.Net.Sockets;



const int port = 8080;
const string address = "127.0.0.1";

Console.WriteLine("Введите имя:");
string userName = Console.ReadLine();
TcpClient client = null;

try
{
    client = new TcpClient(address, port);
    NetworkStream stream = client.GetStream();
    Data clientData = new Data(userName);

    while (true)
    {

        Console.WriteLine("Введите число 1-3");
        var message = int.Parse(Console.ReadLine());

        clientData.Number = (Data.value)message;
        clientData.Serial(stream);

        clientData = (Data)clientData.DeSerial(stream);    

        Console.WriteLine($"Вы: {clientData.User} - Бот: {clientData.ServerNumber}.Итог: {clientData.ServerAnswer}. " +
        $"Очки:{clientData.Points} : {clientData.PointsServer}");
    }
    
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
finally
{
    client.Close();
}

Console.ReadLine();