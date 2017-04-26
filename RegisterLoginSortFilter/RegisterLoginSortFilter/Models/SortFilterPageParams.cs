using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegisterLoginSortFilter.Models
{
    public class SortFilterPageParams
    {
        public string sortOrder { get; set; }
        public string currentFilter { get; set; }
        public string searchNameString { get; set; }
        public string searchEmailString { get; set; }
        public int? page { get; set; }
    }
}