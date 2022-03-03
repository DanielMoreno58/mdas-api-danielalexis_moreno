
namespace Shared.Events.Domain
{
    public class DomainEvent
    {
        public string AggregateId { get; }
        public string Message { get; }
        public string Type { get; }

        public DomainEvent(string AggregateId, string Message, string Type)
        {
            this.AggregateId = AggregateId;
            this.Message = Message;
            this.Type = Type;
        }

    }
}
