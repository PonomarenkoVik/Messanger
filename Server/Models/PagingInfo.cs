﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Server.Models
{
    public class PagingInfo
    {
        public long TotalItems { get; set; } // common number of messages
        public int ItemsPerPage { get; set; } //number of messages per page
        public int CurrentPage { get; set; } // number of current page

        public int TotalPages => (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage); // common number of pages
    }
}