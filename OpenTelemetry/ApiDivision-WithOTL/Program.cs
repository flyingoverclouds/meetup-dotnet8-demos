using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;

var builder = WebApplication.CreateBuilder(args);


// Ajout du service OpenTelemetry et configuration des métriques à collecter
builder.Services.AddOpenTelemetry()
.WithMetrics(metrics =>
{
    #region Metrics
    // https://learn.microsoft.com/en-us/dotnet/core/diagnostics/built-in-metrics-aspnetcore
    metrics.AddMeter("Microsoft.AspNetCore.Hosting"); // dotnet 8 !
    metrics.AddMeter("Microsoft.AspNetCore.Server.Kestrel"); // dotnet 8 !
    metrics.AddMeter("System.Net.Http"); // dotnet 8 !

    // https://learn.microsoft.com/en-us/dotnet/core/diagnostics/built-in-metrics-system-net
    metrics.AddMeter("http.client.request.duration");
    #endregion

    #region Exporters
    metrics.AddConsoleExporter();

    //  Par defaut , l'exporter OpenTelemetry utilise la variable d'environnement OTEL_EXPORTER_OTLP_ENDPOINT pour 
    // récupérer le endpoint OTLP a alimenter. Dans cette démo, elle est définie dans le fichier launchSettings.json (Properties)
    //      "OTEL_EXPORTER_OTLP_ENDPOINT" : "http://127.0.0.1:16083"
    metrics.AddOtlpExporter();
    #endregion
});



// ajout du logger OpenTelemetry
builder.Logging.AddOpenTelemetry(options =>
{
    options.AddConsoleExporter();

    //  Par defaut , l'exporter OpenTelemetry utilise la variable d'environnement OTEL_EXPORTER_OTLP_ENDPOINT pour 
    // récupérer le endpoint OTLP a alimenter. Dans cette démo, elle est définie dans le fichier launchSettings.json (Properties)
    //      "OTEL_EXPORTER_OTLP_ENDPOINT" : "http://127.0.0.1:16083"
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
