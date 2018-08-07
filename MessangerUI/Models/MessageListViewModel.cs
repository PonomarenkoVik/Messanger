using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Abstract.Classes;
using MessangerDataLayer;

namespace MessangerUI.Models
{
    public class MessageListViewModel
    {
        public IEnumerable<AMessage> Messages { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}