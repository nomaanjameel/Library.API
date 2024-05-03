namespace Library.API.Domain
{
    public abstract class ABook
    {
        public string Category { get; protected set; }
        public string Index { get; set; }
        public bool Available { get; set; }

        public abstract void SetCategory();
    }
}
