namespace Template.API.QueryParameters
{
	public class FinanceUnitQueryParameters
	{
		public string? SearchQuery { get; set; }
		public int PageNumber { get; set; } = 1;
		const int maxPageSize = 30;
		private int _pageSize = 10;
		public int PageSize
		{
			get => _pageSize;
			set => _pageSize = (value > maxPageSize) ? maxPageSize : value;
		}
	}
}
