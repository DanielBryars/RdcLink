using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using Newtonsoft.Json;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]
namespace nWAY
{
    public class API
    {
        /* A function to check if our API is up and running. */

        public APIGatewayProxyResponse CheckStatus(APIGatewayProxyRequest Request, ILambdaContext context) => new APIGatewayProxyResponse
        {
            StatusCode = 200,
            Headers = new Dictionary<string, string>() { { "Content-Type", "text/plain" } },
            Body = String.Format("Running version {0}.", context.FunctionVersion)

        };


        /* A function to get caller IP displayed. */

        public APIGatewayProxyResponse MyIP(APIGatewayProxyRequest Request, ILambdaContext context) => new APIGatewayProxyResponse
        {
            StatusCode = 200,
            Headers = new Dictionary<string, string>() { { "Content-Type", "text/plain" } },
            Body = Request.RequestContext?.Identity?.SourceIp ?? "undefined"
        };
    }
}