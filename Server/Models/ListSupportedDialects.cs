using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Server.Models
{
    [DataContract]
    public class ListSupportedDialects
    {
        /// <summary>
        /// List of dialects supported by the Service Provider
        /// </summary>
        [AllowNull]
        [DataMember]
        public List<Uri>? DataDialects { get; set; }
    }
}
