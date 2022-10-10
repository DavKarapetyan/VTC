namespace VTC.Common.ViewModels
{
    public class EventViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public string MainImage { get; set; }
    }
}
