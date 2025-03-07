using System.Text.Json.Serialization; 

namespace SQS.Messages
{
    public class CustomerDeleted : IMessage
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        public string MessageTypeName => nameof(CustomerDeleted);
    }
}
