using Hangfire;

namespace Worker.Services
{
    public class WorkerService
    {
        public static void Agendamento()
        {
            BackgroundJob.Schedule(() => Console.WriteLine("Agendamento", null), TimeSpan.FromSeconds(5));
        }
    }
}
