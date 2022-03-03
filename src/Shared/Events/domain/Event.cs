
namespace Shared.Events.Domain
{
    public class Event
    {
        private string AggregateId { get; }
        private string Message { get; }
        private string Type { get; }

        public Event(string AggregateId, string Message, string Type)
        {
            this.AggregateId = AggregateId;
            this.Message = Message;
            this.Type = Type;
        }

    }
}
