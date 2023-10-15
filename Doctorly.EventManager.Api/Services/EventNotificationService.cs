namespace Doctorly.EventManager.Api.Services
{
    public class EventNotificationService : IHostedService, IDisposable
    {
        //TODO: Add logic to fire off timer or cron job to get all events for current date even 5 min. Check if any of the events start in 15 min from current time, if true send notification. Add config for the 15 min so that it is easy to ajust.

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
