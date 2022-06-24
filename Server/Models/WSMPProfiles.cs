using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Server.Models
{
    /// <summary>
    /// List of WSMP profiles implemented by the Service Provider
    /// </summary>
    [DataContract]
    public class WSMPProfiles
    {
        [DataMember]
        [AllowNull]
        public List<Uri>? MessageTransmissionProfile { get; set; }

        [DataMember]
        public List<Uri> COIProfile { get; set; } = new(1);
    }
}
