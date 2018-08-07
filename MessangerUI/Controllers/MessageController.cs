using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Abstract;
using MessangerDataLayer;
using MessangerUI.Models;

namespace MessangerUI.Controllers
{
    public class MessageController : Controller
    {
        private const int PageSize= 5;
        private readonly IBLMessanger _blMessanger;

        public MessageController(IBLMessanger blMessanger)
        {
            _blMessanger = blMessanger;
        }
        // GET: Messages

        public ViewResult ListMessage(int page = 1)
        {
            MessageListViewModel model = new MessageListViewModel()
            {       
                Messages = _blMessanger.GetMessagesByPage(page, PageSize),
                PagingInfo = new PagingInfo()
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = _blMessanger.CountMessages
                }
                
        };
            return View(model);
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}