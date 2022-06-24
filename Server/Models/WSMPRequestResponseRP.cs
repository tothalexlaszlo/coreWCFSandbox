using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Server.Models
{
    /// <summary>
    /// GetResourcePropertyDocumentResponse message
    /// </summary>
    [DataContract]
    public class WSMPRequestResponseRP
    {
        [DataMember]
        [AllowNull]
        public ListSupportedDialects? ReadDialects { get; set; }

        [DataMember]
        [AllowNull]
        public WSMPProfiles? WSMPProfiles { get; set; }
    }
}
