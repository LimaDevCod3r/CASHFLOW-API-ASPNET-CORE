using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Exception.ExceptionBase;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        [HttpPost]
        public IActionResult Register([FromBody] RequestRegisterExpenseJson request)
        {

            try
            {
                var useCase = new RegisterExpenseUseCase();

                var response = useCase.Execute(request);
                return Created(string.Empty, response);
            }
            catch (ErrorOnValidationExeception ex) 
            {
                var errorMessage = new ResponseErrorJson(ex.Erros);               
                return BadRequest(errorMessage);            
            }
            catch
            {
                var errorMessage = new ResponseErrorJson("unkwon error");
                return StatusCode(StatusCodes.Status500InternalServerError, errorMessage);
            }
        }
    }
}
