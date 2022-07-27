using System;
using System.Net.Sockets;


namespace Client
{
    public class ClientObject
    {
        public TcpClient client;
        public ClientObject(TcpClient tcpClient)
        {
            client = tcpClient;
        }

        public void Process()
        {
            NetworkStream stream = null;
            try
            {
                stream = client.GetStream();
                var dt = new Data();

                while (true)
                {
                    
                    dt = (Data)dt.DeSerial(stream);
                    
                      dt.ServerNumber = (Data.value)new Random().Next(1,4);
                    

                    if (dt.Number == (Data.value)1 && dt.ServerNumber == (Data.value)1) 
                    { 
                        dt.ServerAnswer = "Draw";
                        dt.Points += 1;
                        dt.PointsServer += 1;
                    }

                    if (dt.Number == (Data.value)1 && dt.ServerNumber == (Data.value)2) { dt.ServerAnswer = "Win"; dt.Points += 3; }

                    if (dt.Number == (Data.value)1 && dt.ServerNumber == (Data.value)3) { dt.ServerAnswer = "Lose"; dt.PointsServer += 3; }

                    if (dt.Number == (Data.value)2 && dt.ServerNumber == (Data.value)1) { dt.ServerAnswer = "Lose"; dt.PointsServer += 3; }

                    if (dt.Number == (Data.value)2 && dt.ServerNumber == (Data.value)2)
                    {
                        dt.ServerAnswer = "Draw";
                        dt.Points += 1;
                        dt.PointsServer += 1;
                    }
                    if (dt.Number == (Data.value)2 && dt.ServerNumber == (Data.value)3) { dt.ServerAnswer = "Win"; dt.Points += 3; }

                    if (dt.Number == (Data.value)3 && dt.ServerNumber == (Data.value)1) { dt.ServerAnswer = "Win"; dt.Points += 3; }

                    if (dt.Number == (Data.value)3 && dt.ServerNumber == (Data.value)2) { dt.ServerAnswer = "Lose"; dt.PointsServer += 3; }

                    if (dt.Number == (Data.value)3 && dt.ServerNumber == (Data.value)3)
                    {
                        dt.ServerAnswer = "Draw";
                        dt.Points += 1;
                        dt.PointsServer += 1;
                    }
                    dt.Serial(stream);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if(stream != null) stream.Close();
                if(client != null) client.Close();
            }
        }
    }
}
