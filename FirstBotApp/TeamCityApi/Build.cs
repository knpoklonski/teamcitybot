namespace TeamCityApi
{
    public class Build
    {
        public long Id { get; set; }
        public string Status { get; set; }
        public string State { get; set; }
        public string Href { get; set; }
        public string StatusText { get; set; }
        public string StartDate { get; set; }
        public string FinishDate { get; set; }

        public Triggered Triggered { get; set; }

    }
}