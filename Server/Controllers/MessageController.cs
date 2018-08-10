using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Abstract;
using BL;
using MessangerDataLayer;
using Server.Models;

namespace Server.Controllers
{
    public class MessageController : Controller
    {
        private const int PageSize = 5;
        private readonly IBLMessanger _blMessanger;

        public MessageController(IBLMessanger blMessanger)
        {
            _blMessanger = blMessanger;
        }
        // GET: Messages

        public async Task<ViewResult> ListMessage(int page = 1)
        {
            PagingInfo pagingInfo = new PagingInfo()
            {
                CurrentPage = page,
                ItemsPerPage = PageSize,
            };
            MessageListViewModel model = new MessageListViewModel();

            pagingInfo.TotalItems = await _blMessanger.GetCountMessages();
            model.PagingInfo = pagingInfo;
            model.Messages = await _blMessanger.GetMessagesByPage(page, PageSize);




            return View(model);
        }

        public ActionResult Index()
        {
            return RedirectToAction("ListMessage");
        }
    }
}