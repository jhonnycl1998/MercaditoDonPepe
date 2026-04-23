namespace ProyectoDSW_1.Services
{
    public class DeudaBackgroundService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public DeudaBackgroundService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var ahora = DateTime.Now;

                // calcular tiempo hasta medianoche
                var siguienteEjecucion = DateTime.Now.AddMinutes(1);
                var delay = siguienteEjecucion - ahora;

                await Task.Delay(delay, stoppingToken);

                using (var scope = _serviceProvider.CreateScope())
                {
                    var deudaService = scope.ServiceProvider.GetRequiredService<DeudaService>();

                    deudaService.GenerarDeudasAutomaticas();
                }
            }
        }
    }
}
