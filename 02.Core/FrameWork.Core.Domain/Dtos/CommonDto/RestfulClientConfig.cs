namespace FrameWork.Core.Domain.Dtos.CommonDto
{
    public class WebServiceOptions
    {
        public string BaseUrl { get; set; }
        public string ApiKey { get; set; }
        public string SecretKey { get; set; }
    }

    public class RestfulClientConfig
    {
        public WebServiceOptions SmsWebServiceOptions { get; set; }
        public WebServiceOptions MessengerServiceOptions { get; set; }
        public WebServiceOptions FaceEngineOptions { get; set; }
        public WebServiceOptions AuthWebServiceOptions { get; set; }
        public WebServiceOptions UserInfoServiceOptions { get; set; }
        public WebServiceOptions LicenseServiceOptions { get; set; }
        public WebServiceOptions UserActivityLoggerServiceOption { get; set; }
    }
}
