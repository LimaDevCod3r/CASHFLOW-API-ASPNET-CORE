using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.Expenses.Register
{
    public class RegisterExpenseUseCase
    {

        public ResponseRegisteredExpenseJson Execute(RequestRegisterExpenseJson request)
        {
            return new ResponseRegisteredExpenseJson();
        }

        private void validate(RequestRegisterExpenseJson request)
        {
            var titleIsEmpty = string.IsNullOrEmpty(request.Title);

            if (titleIsEmpty) 
            {
                throw new ArgumentException("The title is required.");
            }

            if(request.Amount <= 0)
            {
                throw new ArgumentException("The Amount must be greated than zero.");
            }

            var compareDate = DateTime.Compare(request.Date, DateTime.UtcNow);

            if (compareDate < 0) 
            {
                throw new ArgumentException("Expenses cannot be for the future.");
            }

            var paymentTypeIsValid = Enum.IsDefined(typeof(PaymentType), request.PaymentType);

            if (!paymentTypeIsValid) 
            {
                throw new ArgumentException("Payment Type is not valid.");
            }
        }
    }
}
