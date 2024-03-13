

namespace OGA.SharedKernel.QueryHelpers
{
	/// <summary>
	/// Pagination Filter class.
	/// Used by response classes of upper layers for creating paginated query responses.
	/// </summary>
    public class PaginationFilter
	{
		const int maxPageSize = 50;

		private int _pagesize;

		/// <summary>
		/// Number of records to include on a page.
		/// </summary>
		public int pageSize
		{
			get
			{
				return _pagesize;
			}
			set
			{
				this._pagesize = DetermineInRange_PageSize(value);
			}
		}

		/// <summary>
		/// Current Page Number of returned data.
		/// </summary>
		public int pageNumber { get; set; } = 1;

		/// <summary>
		/// Default Constructor.
		/// </summary>
		public PaginationFilter()
        {
			this.pageNumber = 1;

			this._pagesize = 10;
        }

		/// <summary>
		/// Call this method to pass in the page filtering (page index and page size).
		/// </summary>
		/// <param name="pageindex"></param>
		/// <param name="pagesize"></param>
		public PaginationFilter(int pageindex, int pagesize)
        {
			// Ensure the page index is in range...
			this.pageNumber = DetermineInRange_PageIndex(pageindex);

			// Ensure the page size is positive and does not exceed the max...
			this._pagesize = DetermineInRange_PageSize(pagesize);
        }

		private int DetermineInRange_PageSize(int val)
        {
			// Ensure the page size is positive and does not exceed the max...
			if (val < 1)
				return 1;
			else
				return (val > maxPageSize) ? maxPageSize : val;
        }

		private int DetermineInRange_PageIndex(int val)
        {
			// Ensure the page index is positive...
			if (val < 1)
				return 1;
			else
				return val;
        }
	}
}
