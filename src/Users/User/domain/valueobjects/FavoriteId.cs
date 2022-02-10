namespace Users.User.domain
{
    public readonly struct FavoriteId: IEquatable<FavoriteId>
    {
        public Guid Value { get; }

        public FavoriteId() : this(Guid.NewGuid())
        {

        }
        public FavoriteId(Guid id)
        {
            Value = id;
        }

        public FavoriteId(string id)
        {
            Value = new Guid(id);
        }

        public override bool Equals(object? obj) =>
        obj is FavoriteId o && this.Equals(o);

        public bool Equals(FavoriteId other) => this.Value == other.Value;

        public override int GetHashCode() =>
            HashCode.Combine(this.Value);

        public static bool operator ==(FavoriteId left, FavoriteId right) => left.Equals(right);

        public static bool operator !=(FavoriteId left, FavoriteId right) => !(left == right);

        public override string ToString() => this.Value.ToString();
    }
}
