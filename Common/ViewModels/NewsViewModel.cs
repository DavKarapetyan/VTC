namespace VTC.Common.ViewModels
{
    public class NewsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public string MainImage { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
