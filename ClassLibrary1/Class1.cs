using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; // DirectoryInfo FileInfo 사용
using System.Runtime.Serialization.Formatters.Binary;

namespace ClassLibrary1
{
    public class Class1
    {
    }

    public enum PacketType
    {
        초기화 = 0,
        탐색기,
        상세화
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
    public class Initialize : Packet // 초기화 데이터 요청
    {
        public string buffer = null; // 서버 log창에 출력할 메시지
    }

    [Serializable]
    public class Browser : Packet // 원격 탐색기 요청 (= 파일탐색 요청)
    {
        public string message = null; // 서버 log창에 출력할 메시지
        public DirectoryInfo[] di;
        public string fullpath = null; // 노드의 전체 경로
        public int num = 0; // 1 : beforeExpand, 2 : beforeSelect
        public FileInfo[] fi;
    }

    [Serializable]
    public class Detail : Packet // 상세정보 및 다운로드
    {
        public string message = null; // 서버 log창에 출력할 메시지
    }
}