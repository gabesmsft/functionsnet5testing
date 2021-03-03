using System;
using System.IO;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace FunctionsNet5
{
    public static class BlobTrigger2
    {
        [Function("BlobTrigger2")]
        [BlobOutput("destinationcontainer2/{name}", Connection = "AzureWebJobsStorage")]
        public static string Run(
            [BlobTrigger("test-samples2/{name}", Connection = "AzureWebJobsStorage")] string myBlob,
            string name,
            FunctionContext context)
        {
            var logger = context.GetLogger("BlobTrigger1");
           logger.LogInformation($"C# Blob trigger function Processed blob\n Name:{name}: {myBlob}");
           return myBlob;
        }
    }
}
