namespace Library.API.Domain
{
    public abstract class BookDecorator : ABook
    {
        protected ABook _aBook;

        public BookDecorator(ABook aBook)
        {
            _aBook = aBook;
        }

        public void SetBook(ABook aBook)
        {
            _aBook = aBook;
        }

        public override void SetCategory()
        {
            if (_aBook != null)
            {
                _aBook.SetCategory();
            }
        }
    }
}
