using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BoardSystem.Filters
{
    public class ApiExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.Result = new ObjectResult($"Ocorreu um erro ao processar sua solicitacão! Mensagem de erro: {context.Exception.Message}")
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };
        }
    }
}
