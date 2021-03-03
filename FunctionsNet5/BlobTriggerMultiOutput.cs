using System;
using System.IO;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace FunctionsNet5
{
    public static class BlobTriggerMultiOutput
    {
        [Function("BlobTriggerMultiOutput")]
        public static MyOutputType Run([BlobTrigger("test-samples4/{name}", Connection = "AzureWebJobsStorage")] string myBlob, string name,
            FunctionContext context)
        {
            var logger = context.GetLogger("BlobTriggerMultiOutput");
            logger.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Data: {myBlob}");

            return new MyOutputType()
            {
                QueueOutput = name,
                BlobOutput = myBlob
            };
        }
    }

    public class MyOutputType
    {
        [QueueOutput("destinationqueue", Connection = "AzureWebJobsStorage")]
        public string QueueOutput { get; set; }

        [BlobOutput("destinationcontainer4/{name}", Connection = "AzureWebJobsStorage")]
        public string BlobOutput { get; set; }
    }
}
