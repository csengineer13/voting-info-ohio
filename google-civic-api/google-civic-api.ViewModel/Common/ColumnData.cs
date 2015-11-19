namespace google_civic_api.ViewModel.Common
{
    public class ColumnData
    {
        public ColumnData()
        {
            Format = new Format();
        }
        public string DisplayName { get; set; }
        public string ColumnName { get; set; }
        public string SortColumn { get; set; }
        public bool DisableSort { get; set; }
        public Format Format { get; set; }
        public bool IsHidden { get; set; }
        public bool IsSortedUp { get; set; }
        public bool IsSortedDown { get; set; }
    }
}