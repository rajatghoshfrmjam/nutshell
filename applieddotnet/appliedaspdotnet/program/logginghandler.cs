using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace appliedaspdotnet.program
{
    class logginghandler : DelegatingHandler
    {
        StreamWriter _writer;

        public logginghandler(Stream stream)
        {
            _writer = new StreamWriter(stream);
        }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                _writer.WriteLine("{0}\t{1}\t{2}", request.RequestUri,
                    (int)response.StatusCode, response.Headers.Date);
            }
            return response;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _writer.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}