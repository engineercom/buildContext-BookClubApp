namespace BookClubApp.Web.ViewModels
{
    public class BookCreateViewModel
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime PublishedDate { get; set; }
        public int AuthorId { get; set; }

        public int[]? SelectedCategoryIds{ get; set; }
    }
}
