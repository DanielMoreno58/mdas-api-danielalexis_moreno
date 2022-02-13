namespace Users.User.domain
{
    public class UserId: IEquatable<UserId>
    {
        public Guid Value { get; }

        public UserId(Guid id)
        {
            Value = id;
        }

        public bool Equals(UserId other) => this.Value == other.Value;

        public static bool operator ==(UserId left, UserId right) => left.Equals(right);

        public static bool operator !=(UserId left, UserId right) => !(left == right);

        public override string ToString() => this.Value.ToString();
    }
}
