using Amazon;
using Amazon.Runtime;
using Amazon.SQS;
using Consumer;

var builder = WebApplication.CreateBuilder(args);
 
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// string environment = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") ?? "Production";

var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.Development.json", optional: false, reloadOnChange: true)
    .Build();

var awsSettings = config.GetSection("AWS").Get<AwsSettings>();

var credentials = new BasicAWSCredentials(awsSettings.AccessKey, awsSettings.SecretKey);
var region = RegionEndpoint.GetBySystemName(awsSettings.Region);
var sqsClient = new AmazonSQSClient(credentials, region);

builder.Services.AddSingleton<IAmazonSQS>(_ => new AmazonSQSClient(credentials, region));

builder.Services.AddHostedService<SqsConsumerService>();

builder.Services.AddSingleton<MessageDispatcher>();

// builder.Services.AddScoped<CustomerCreatedHandler>();
// builder.Services.AddScoped<CustomerDeletedHandler>();
builder.Services.AddMessageHandlers();


var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
