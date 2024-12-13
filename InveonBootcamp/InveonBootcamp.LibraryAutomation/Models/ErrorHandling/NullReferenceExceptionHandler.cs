using Microsoft.AspNetCore.Diagnostics;

namespace InveonBootcamp.LibraryAutomation.Models.ErrorHandling
{
    public class NullReferenceExceptionHandler(ILogger<NullReferenceExceptionHandler> logger) : IExceptionHandler
    {
        public ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if (exception is not NullReferenceException)
                return new ValueTask<bool>(false);

            string errorMessageDeveloper = $"Bir hata oluştu: {exception.Message}";
            string errorMessageProduct = "Aranılan öğe bulunamadı";

            logger.LogError(errorMessageDeveloper);

            httpContext.Items["ErrorMessage"] = errorMessageProduct;
            httpContext.Items["RequestId"] = httpContext.TraceIdentifier;

            return new ValueTask<bool>(true);
        }
    }
}
