using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MessangerDataLayer;
using MessangerDataLayer.Abstraction;
using MessangerUI.Models;

namespace MessangerUI.Controllers
{
    public class MessageController : Controller
    {
        private const int PageSize= 5;
        private readonly IDataRepository _repository;

        public MessageController()
        {
            _repository = new MessageDatabaseContext();
        }
        // GET: Message

        public ViewResult ListMessage(int page = 1)
        {
            MessageListViewModel model = new MessageListViewModel()
            {       
                Message = _repository.Messages
                    .OrderBy(message => message.MessageId)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo()
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = _repository.Messages.Count()
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