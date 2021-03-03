using System;
using System.IO;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace FunctionsNet5
{
    public static class BlobTrigger1
    {
        [Function("BlobTrigger1")]
        [BlobOutput("destinationcontainer1/{name}", Connection = "AzureWebJobsStorage")]
        public static Stream Run(
            [BlobTrigger("test-samples1/{name}", Connection = "AzureWebJobsStorage")] Stream myBlob,
            string name,
            FunctionContext context)
        {
            var logger = context.GetLogger("BlobTrigger1");
           logger.LogInformation($"C# Blob trigger function Processed blob\n Name:{name}: {myBlob}");
           return myBlob;
        }
    }
}
