//using Azure.Core;

//namespace ScaleArch.ApiTemplate.Client;

//public partial class ApiClientOptions : ClientOptions
//{
//    private const ServiceVersion LatestVersion = ServiceVersion.V1;

//    /// <summary> The version of the service to use. </summary>
//    public enum ServiceVersion
//    {
//        /// <summary> Service version "v1". </summary>
//        V1 = 1,
//    }

//    internal string Version { get; }

//    /// <summary> Initializes new instance of ApiClientOptions. </summary>
//    public ApiClientOptions(ServiceVersion version = LatestVersion)
//    {
//        Version = version switch
//        {
//            ServiceVersion.V1 => "v1",
//            _ => throw new NotSupportedException()
//        };
//    }
//}
