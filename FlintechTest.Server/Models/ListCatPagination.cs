namespace FlintechTest.Server.Models
{
    public class ListCatPagination
    {
        public IEnumerable<CatRoot> catRoots { get; set; }

        public Pagination pagination { get; set; }
    }
}
