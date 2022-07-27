using System.Runtime.Serialization.Formatters.Binary;

namespace Client
{
    [Serializable]
    public class Data
    {
       public enum value
        {
            Камень = 1,
            Ножницы,
            Бумага
        }
        public string User { get; set; }
        public value Number { get; set; }
        public int Points { get; set; }

        public value? ServerNumber { get; set; }
        public int PointsServer { get; set; }
        public string ServerAnswer { get; set; }

        public Data() 
        {
            ServerNumber = null;
        }
        public Data(string user)
        {
            User = user;
            Points = 0;
        }

        public void Serial (Stream stream)
        {
            var fm = new BinaryFormatter();
            fm.Serialize(stream, this);
        }

        public object DeSerial(Stream stream)
        {
            var fm = new BinaryFormatter();
            return fm.Deserialize(stream);
        }
    }
}
