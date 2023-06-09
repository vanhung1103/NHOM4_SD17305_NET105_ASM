namespace NHOM5_NET105_SD17305.Views.Models
{
    public class Paging
    {
        public int CurrentPage { get; set; }
        public int CountPage { get; set; }
        public Func<int?, string> GeneralUrl { get; set; }
    }
}
