using System.Net;


namespace CheckReceiptSDK.Tests;


internal class HttpMessageHandlerMock : HttpMessageHandler
{

    private readonly HttpStatusCode _statusCode;
    private readonly string _content;


    internal HttpMessageHandlerMock ( HttpStatusCode statusCode , string content )
    {
        _statusCode = statusCode;
        _content = content;
    }

    protected override Task<HttpResponseMessage> SendAsync ( HttpRequestMessage request , CancellationToken cancellationToken )
    {
        return Task.FromResult(new HttpResponseMessage()
        {
            StatusCode = _statusCode ,
            Content = new StringContent(_content)
        });
    }

    internal static HttpClient GetHttpClient ( HttpStatusCode statusCode , string content )
    {
        return new HttpClient(new HttpMessageHandlerMock(statusCode , content));
    }
}
