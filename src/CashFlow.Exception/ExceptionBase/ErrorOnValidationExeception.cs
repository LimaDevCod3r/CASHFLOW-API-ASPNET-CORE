namespace CashFlow.Exception.ExceptionBase
{
    public class ErrorOnValidationExeception : CashFlowException
    {
        public List<string> Errors { get; set; }

        public ErrorOnValidationExeception(List<string> errorMessages)
        {
            Errors = errorMessages;
        }
    }
}
