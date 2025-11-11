namespace MekashronTestTask1.Models.Responses
{
    public class ResponseBase
    {
        public int ResultCode { get; set; }

        public string ResultMessage { get; set; } = string.Empty;

        public ResponseStatus ResponseStatus => ResultCode != 0 ? ResponseStatus.Error : ResponseStatus.Undefined;
    }
}
