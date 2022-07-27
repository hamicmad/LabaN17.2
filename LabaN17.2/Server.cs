using Client;
using System.Net;
using System.Net.Sockets;



 const int port = 8080;
 TcpListener listener = null;

try
{
    listener = new TcpListener(IPAddress.Parse("127.0.0.1"), port);
    listener.Start();
    Console.WriteLine("Ожидание...");

    while (true)
    {
        var client = listener.AcceptTcpClient();
        var clientObject = new ClientObject(client);

        var clientThread = new Thread(new ThreadStart(clientObject.Process));
        clientThread.Start();
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
finally
{
    if (listener != null)
        listener.Stop();
}

Console.ReadLine();