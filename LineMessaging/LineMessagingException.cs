using System;

namespace LineMessaging
{
    public class LineMessagingException : Exception
    {
        public string Path { get; }

        public LineOAuthErrorResponse OAuthErrorResponse { get; }

        public LineErrorResponse ErrorResponse { get; }

        public LineMessagingException(string path, LineErrorResponse errorResponse)
            : base(errorResponse.ToString())
        {
            Path = path ?? throw new ArgumentNullException(nameof(path));
            ErrorResponse = errorResponse;
        }

        public LineMessagingException(string path, LineOAuthErrorResponse oAuthErrorResponse)
            : base(oAuthErrorResponse.ToString())
        {
            Path = path ?? throw new ArgumentNullException(nameof(path));
            OAuthErrorResponse = oAuthErrorResponse;
        }

        public LineMessagingException(string path, string message)
            : base(message)
        {
            Path = path ?? throw new ArgumentNullException(nameof(path));
        }

        public override string ToString()
        {
            return $"The request to {Path} has thrown an exception: {base.ToString()}";
        }
    }
}
