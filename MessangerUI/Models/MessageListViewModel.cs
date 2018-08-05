using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MessangerDataLayer;

namespace MessangerUI.Models
{
    public class MessageListViewModel
    {
        public IEnumerable<Message> Message { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}