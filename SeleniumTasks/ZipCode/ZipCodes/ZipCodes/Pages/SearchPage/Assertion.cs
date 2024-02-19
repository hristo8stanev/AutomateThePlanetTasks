using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZipCodes.Pages.SearchPage;
public partial class SearchPage
{
    private string errorMessageUrl => "The URL does not contain 'order-received'";
    public void AssertOAdvanceSearchedUrl (string receiveOrderUrl)
    {
        Assert.That(receiveOrderUrl.Contains("Submit=Find+ZIP+Codes"), Is.True, errorMessageUrl);
    }
}

