namespace APIGW.Services
{
    public abstract class ServiceBase
    {
        protected readonly ILogger Logger;

        protected ServiceBase(ILogger logger)
        {
            Logger = logger;
        }

        // Add common methods or properties here
    }
}
