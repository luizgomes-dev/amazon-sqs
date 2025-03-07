using System.Text.Json.Serialization;

namespace SQS.Messages;

public class CustomerCreated : IMessage
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("fullName")]
    public string FullName { get; set; } = default!; 

    public string MessageTypeName => nameof(CustomerCreated);
}