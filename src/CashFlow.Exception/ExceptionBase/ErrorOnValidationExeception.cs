namespace CashFlow.Exception.ExceptionBase
{
    public class ErrorOnValidationExeception : CashFlowException
    {
        public List<string> Erros { get; }

        public ErrorOnValidationExeception(List<string> errorMessages)
        {
            Erros = errorMessages;
        }
    }
}
