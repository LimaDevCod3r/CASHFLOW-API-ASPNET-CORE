namespace CashFlow.Communication.Responses
{
    public class ResponseErrorJson
    {
        public string ErrorMessage { get; set; }


        public ResponseErrorJson(string ErrorMessage)
        {
            this.ErrorMessage = ErrorMessage;
        }
    }
}
