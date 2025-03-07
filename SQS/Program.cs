using Amazon;
using Amazon.Runtime;
using Amazon.SQS;
using Microsoft.Extensions.Configuration;
using SQS.Messages;
using SQS.Publisher;

string environment = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") ?? "Production";

var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.Development.json", optional: false, reloadOnChange: true)
    .Build();

var awsSettings = config.GetSection("AWS").Get<AwsSettings>();

var credentials = new BasicAWSCredentials(awsSettings.AccessKey, awsSettings.SecretKey);
var region = RegionEndpoint.GetBySystemName(awsSettings.Region);
var sqsClient = new AmazonSQSClient(credentials, region);

var publisher = new SqsPublisher(sqsClient);
 
await publisher.PublishAsync("test-queue", new CustomerCreated
{
    Id = 1,
    FullName = "Don Corleone"
});