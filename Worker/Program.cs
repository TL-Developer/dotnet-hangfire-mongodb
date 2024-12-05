using Hangfire;
using Hangfire.Mongo;
using Hangfire.Mongo.Migration.Strategies.Backup;
using Hangfire.Mongo.Migration.Strategies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddHangfire(config =>
    {
        config.UseMongoStorage(builder.Configuration.GetConnectionString("MongoConnectionString"), new MongoStorageOptions
        {
            MigrationOptions = new MongoMigrationOptions
            {
                MigrationStrategy = new MigrateMongoMigrationStrategy(),
                BackupStrategy = new CollectionMongoBackupStrategy(),
            },
            Prefix = "hangfire.mongo",
            CheckConnection = true,
            CheckQueuedJobsStrategy = CheckQueuedJobsStrategy.TailNotificationsCollection
        });
    });

builder.Services.AddHangfireServer(serverOptions =>
{
    serverOptions.ServerName = "Hangfire.Mongo server 1";
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseHangfireDashboard();

app.Run();