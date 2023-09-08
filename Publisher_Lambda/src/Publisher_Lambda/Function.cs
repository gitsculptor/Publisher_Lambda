using Amazon.Lambda.Core;
using Amazon.Lambda.SQSEvents;
using Amazon.SQS;
using Amazon.SQS.Model;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace Publisher_Lambda;

public class Publisher
{
    private readonly IAmazonSQS _sqsClient;
    private readonly string _queueUrl; 

    public Publisher()
    {
        _sqsClient = new AmazonSQSClient();
        _queueUrl = "https://sqs.us-east-1.amazonaws.com/727071572862/myFirstQueue";
    }

    public async Task FunctionHandler(SQSEvent sqsEvent, ILambdaContext context)
    {
        foreach (var record in sqsEvent.Records)
        {
            var message = record.Body;
            await SendMessageAsync(_sqsClient, _queueUrl, message);
        }
    }

    private async Task SendMessageAsync(IAmazonSQS sqsClient, string queueUrl, string message)
    {
        var request = new SendMessageRequest
        {
            QueueUrl = queueUrl,
            MessageBody = message
        };

        await sqsClient.SendMessageAsync(request);
    }
}