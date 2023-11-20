using Azure.Monitor.OpenTelemetry.Exporter;
using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;

var builder = WebApplication.CreateBuilder(args);


// Ajout du service OpenTelemetry et configuration des métriques à collecter
builder.Services.AddOpenTelemetry()
.WithMetrics(metrics =>
{
    // https://learn.microsoft.com/en-us/dotnet/core/diagnostics/built-in-metrics-aspnetcore
    metrics.AddMeter("Microsoft.AspNetCore.Hosting"); // dotnet 8 !
    metrics.AddMeter("Microsoft.AspNetCore.Server.Kestrel"); // dotnet 8 !
    metrics.AddMeter("System.Net.Http"); // dotnet 8 !

    // https://learn.microsoft.com/en-us/dotnet/core/diagnostics/built-in-metrics-system-net
    metrics.AddMeter("http.client.request.duration");


    metrics.AddConsoleExporter(); // Pour affichier les traces ... sur la console :)

    
    // Configurer la variable d'env OTEL_EXPORTER_OTLP_ENDPOINT http://localhost:16083
    // pour alimenter n'importe quel endpoint compatible OpenTelemetry ( dashboard Aspire par exemple )
    metrics.AddOtlpExporter(); 
});

// ajout du logger OpenTelemetry
builder.Logging.AddOpenTelemetry(options =>
{
    options.AddConsoleExporter();
    options.AddOtlpExporter();
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
