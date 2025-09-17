namespace Application.PipelineBehaviors;

public class ExceptionHandlingPipelineBehavior<TRequest, TResponse>(ILogger<ExceptionHandlingPipelineBehavior<TRequest, TResponse>> logger) :
    IPipelineBehavior<TRequest, TResponse>
    where TRequest : class {

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken) {

        try{
            return await next(cancellationToken);
        }
        catch (Exception ex){
            var requestName = typeof(TRequest).Name;
            logger.LogError("Unhandled exception for {RequestName} with {@Error}", requestName, ex);
            throw;
        }
    }
}