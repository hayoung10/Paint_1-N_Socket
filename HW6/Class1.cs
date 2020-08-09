using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace HW6
{
    public class Class1
    {
    }

    public enum PacketType
    {
        그림판 = 0,
        채팅,
        연결
    }

    public enum PacketSendERROR
    {
        정상 = 0,
        에러
    }

    [Serializable]
    public class Packet
    {
        public int Length;
        public int Type;

        public Packet()
        {
            this.Length = 0;
            this.Type = 0;
        }

        public static byte[] Serialize(Object o)
        {
            MemoryStream ms = new MemoryStream(1024 * 4);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ms, o);
            return ms.ToArray();
        }

        public static Object Desserialize(byte[] bt)
        {
            MemoryStream ms = new MemoryStream(1024 * 4);
            foreach (byte b in bt)
                ms.WriteByte(b);

            ms.Position = 0;
            BinaryFormatter bf = new BinaryFormatter();
            Object obj = bf.Deserialize(ms);
            ms.Close();
            return obj;
        }
    }

    [Serializable]
    public class Paint : Packet // 그림판
    {
        public int receive = 0; // 0:초기값, 1:Client->Server, 2:Server->Client
    }

    [Serializable]
    public class Chat : Packet // 채팅
    {
        public string name = null; // 닉네임
        public string say = null; // 메시지
    }

    [Serializable]
    public class Connect : Packet // 연결
    {
        public string username = null; // 닉네임
        public string path = null; // 서버에 저장된 그림 정보 path
        public bool connect = false; // true : 연결, false : 연결X
    }
}
