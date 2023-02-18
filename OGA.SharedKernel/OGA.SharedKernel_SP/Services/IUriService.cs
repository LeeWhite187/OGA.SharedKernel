using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGA.SharedKernel.Services
{
    /// <summary>
    /// Interface for the URI mapping service, that composes routes for REST calls like pagination urls.
    /// The interface is in SharedKernel (and available via DI) for services that require url mapping.
    /// </summary>
    public interface IUriService
    {
#if NET452
        Uri GetPageUri(OGA.SharedKernel.QueryHelpers.PaginationFilter filter, string route);
#elif (NET5 || NET6)
        public Uri GetPageUri(OGA.SharedKernel.QueryHelpers.PaginationFilter filter, string route);

        /// <summary>
        /// Will create a complete URL for the given route.
        /// </summary>
        /// <param name="route"></param>
        /// <returns></returns>
        public Uri Compose_Url_to_Route(string route);
        /// <summary>
        /// Will create a complete URL for the given route and list of query parameters.
        /// </summary>
        /// <param name="route"></param>
        /// <returns></returns>
        public Uri Compose_Url_to_Route(string route, List<KeyValuePair<string, string>> queryparms);
#endif
    }
}
