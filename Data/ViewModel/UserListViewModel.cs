using  STW_Spark.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace  STW_Spark.Data.ViewModel
{
    public class UserListViewModel
    {
        public List<ApplicationUser> applicationUsers { get; set; }
        public PagingInfo pagingInfo { get; set; }

    }
}
