using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZipCodes.Pages.SearchPage;
public partial class SearchPage
{
    private string ErrorMessageUrl => "The URL does not contain 'order-received'";

    public void AssertSearchPageIsShown(string receiveOrderUrl)
    {
        Assert.That(receiveOrderUrl.Contains("https://www.zip-codes.com/search.asp"));
    }
    public void AssertOAdvanceSearchedUrl (string receiveOrderUrl)
    {
        Assert.That(receiveOrderUrl.Contains("Submit=Find+ZIP+Codes"), Is.True, ErrorMessageUrl);
    }
}

