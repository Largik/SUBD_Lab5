using System.Runtime.Serialization;

namespace JournalDB
{
    [DataContract]
    public class ConnectionConfig
    {
        [DataMember]
        public string ConnectionString { get; set; }
    }
}
