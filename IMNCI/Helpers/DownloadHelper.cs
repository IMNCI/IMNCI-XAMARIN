using System;
using System.Net;
using System.Threading.Tasks;

namespace IMNCI.Helpers
{
    public class DownloadHelper
    {
        public static readonly int BufferSize = 4096;
        private string url = "";

        public DownloadHelper(string fileUrl)
        {
            this.url = fileUrl;
        }

        public static async Task<int> CreateDownloadTask(string urlToDownload, IProgress<DownloadBytesProgress> progessReporter)
        {
            int receivedBytes = 0;
            int totalBytes = 0;
            WebClient client = new WebClient();

            using (var stream = await client.OpenReadTaskAsync(urlToDownload))
            {
                byte[] buffer = new byte[BufferSize];
                totalBytes = Int32.Parse(client.ResponseHeaders[HttpResponseHeader.ContentLength]);

                for (; ; )
                {
                    int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                    if (bytesRead == 0)
                    {
                        await Task.Yield();
                        break;
                    }

                    receivedBytes += bytesRead;
                    if (progessReporter != null)
                    {
                        DownloadBytesProgress args = new DownloadBytesProgress(urlToDownload, receivedBytes, totalBytes);
                        progessReporter.Report(args);
                    }
                }
            }

            return receivedBytes;
        }
    }
}
