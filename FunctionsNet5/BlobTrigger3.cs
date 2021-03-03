using System;
using System.IO;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Extensions.Logging;


namespace FunctionsNet5
{
    public static class BlobTrigger3
    {
        [Function("BlobTrigger3")]
        [BlobOutput("destinationcontainer3/{name}", Connection = "AzureWebJobsStorage")]
        public static string Run(
            [BlobTrigger("test-samples3/{name}", Connection = "AzureWebJobsStorage")] string myBlob,
            Uri uri,
            string name,
            BlobMetaDataProperties properties,
            //BlobProperties properties,
            FunctionContext context)
        {
            var logger = context.GetLogger("BlobTrigger3");

            logger.LogInformation("uri metadata: " + uri.ToString());
            logger.LogInformation("Blob type: " + properties.BlobType);
            logger.LogInformation($"C# Blob trigger function Processed blob\n Name:{name}: {myBlob}");
            
           return myBlob;
        }
    }

    public class BlobMetaDataProperties
    {
        public DateTimeOffset LastModified { get; }
        public string BlobType { get; }
    }
}
