using Amazon.Lambda.Core;
using Amazon.Lambda.SQSEvents;
using Amazon.SQS;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace Consumer_Lambda;

public class Consumer
{
    private readonly IAmazonSQS _sqsClient;
    private readonly string _queueUrl; 

    public Consumer()
    {
        _sqsClient = new AmazonSQSClient();
        _queueUrl = "https://sqs.us-east-1.amazonaws.com/727071572862/myFirstQueue"; 
    }
    public async Task FunctionHandler(SQSEvent sqsEvent, ILambdaContext context)
    {
        foreach (var record in sqsEvent.Records)
        {
            var message = record.Body;
            // Implement your message processing logic here
        }
    }
}