using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace NDVida_Site.Wymbe
{
    public class WymbeLoggingHandler : DelegatingHandler
    {
        public WymbeLoggingHandler(HttpMessageHandler innerHandler) : base(innerHandler)
        {
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("Request:");
            Console.WriteLine(request.ToString());

            if (request.Content != null)
            {
                Console.WriteLine(await request.Content.ReadAsStringAsync());
            }

            Console.WriteLine();
            Console.WriteLine();

            HttpResponseMessage response = await base.SendAsync(request, cancellationToken);

            Console.WriteLine("Response:");
            Console.WriteLine(response.ToString());

            if (response.Content!= null)
            {
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }

            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------------");

            return response;
        }
    }
}