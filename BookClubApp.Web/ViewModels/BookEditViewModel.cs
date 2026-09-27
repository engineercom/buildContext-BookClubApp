namespace BookClubApp.Web.ViewModels
{
    public class BookEditViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int AuthorId { get; set; }
        public IEnumerable<int>? SelectedCategoryIds { get; set; }
    }
}
