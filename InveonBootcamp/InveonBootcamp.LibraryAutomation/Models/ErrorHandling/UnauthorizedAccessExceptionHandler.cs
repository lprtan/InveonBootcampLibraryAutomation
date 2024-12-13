using Microsoft.AspNetCore.Diagnostics;

namespace InveonBootcamp.LibraryAutomation.Models.ErrorHandling
{
    public class UnauthorizedAccessExceptionHandler(ILogger<UnauthorizedAccessExceptionHandler> logger) : IExceptionHandler
    {
        public ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if (exception is not UnauthorizedAccessException)
                return new ValueTask<bool>(false);

            string errorMessageDeveloper = $"Bir hata oluştu: {exception.Message}";
            string errorMessageProduct = "Erişim Yetkiniz Bulunmamaktadır.";

            logger.LogError(errorMessageDeveloper);

            var errorViewModel = new ErrorViewModel
            {
                RequestId = httpContext.TraceIdentifier,
                ErrorMessage = errorMessageProduct
            };

            httpContext.Response.Redirect($"/Home/Error?requestId={errorViewModel.RequestId}");
            return new ValueTask<bool>(true);
        }
    }
}
