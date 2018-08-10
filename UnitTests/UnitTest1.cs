using System;
using System.Collections.Generic;
using System.Web.Mvc;
using MessangerDataLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Server.HtmlHelpers;
using Server.Models;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CanGeneratePageLinks()
        {
            HtmlHelper myHelper = null;
            PagingInfo pagingInfo = new PagingInfo()
            {
                CurrentPage = 1,
                TotalItems = 6,
                ItemsPerPage = 5
            };
            Func<int, string> pageUrlDelegate = i => "Page" + i;

            MvcHtmlString result = myHelper.PageLinks(pagingInfo, pageUrlDelegate);
        }
    }
}
