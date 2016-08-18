using System.Collections.Generic;
using System.Threading.Tasks;
using Canvas.LMS.Demo.Core.Domain;
using Canvas.LMS.Demo.Core.RestClient;
using RestSharp;

namespace Canvas.LMS.Demo.Core.Coordinators
{
    /// <summary>
    /// Coordinator for accessing account data.
    /// </summary>
    public class AccountsCoordinator
    {
        private readonly CanvasClient _canvasClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountsCoordinator"/> class.
        /// </summary>
        public AccountsCoordinator()
        {
            _canvasClient = new CanvasClient();
        }

        /// <summary>
        /// Returns the list of accounts that the current user can view or manage.
        /// </summary>
        public async Task<IEnumerable<AccountDto>> GetAccounts()
        {
            RestRequest restRequest = new RestRequest("accounts", Method.GET);
            return await _canvasClient.Execute<List<AccountDto>>(restRequest);
        }
    }
}