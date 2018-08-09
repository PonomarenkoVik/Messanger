using System;
using System.Collections.Generic;
using System.Web.Mvc;
using MessangerDataLayer;
using MessangerUI.HtmlHelpers;
using MessangerUI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

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
