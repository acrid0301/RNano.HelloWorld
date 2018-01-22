using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RNano.HelloWorld.ConsoleApp.Handler
{
    public class ProxyDelegatingHandler : DelegatingHandler
    {
        public ProxyDelegatingHandler()
        {
            InnerHandler = new System.Net.Http.HttpClientHandler();
        }

        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var r = await base.SendAsync(request, cancellationToken);
            return r.EnsureSuccessStatusCode();
        }
    }
}
