namespace ExamApp.Middlewares
{
    public class Error
    {
        public string Title { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public int Status { get; set; }
        public string Detail { get; set; } = string.Empty;
    }
}
