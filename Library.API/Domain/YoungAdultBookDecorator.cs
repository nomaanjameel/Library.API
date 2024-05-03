namespace Library.API.Domain
{
    public class YoungAdultBookDecorator : BookDecorator
    {
        private const string CATEGORY = "Young Adult Fiction";
        public YoungAdultBookDecorator(ABook aBook) : base(aBook)
        {
        }

        public override void SetCategory()
        {
            base.Category = CATEGORY;
        }
    }
}
