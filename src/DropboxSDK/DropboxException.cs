using System;
using System.Net;
using Foundation;

namespace DropboxSDK
{
	public class DropboxException: Exception
	{
		public HttpStatusCode StatusCode { get; private set; }

		public NSError Error { get; private set; }

		public DropboxException (NSError error, HttpStatusCode statusCode = HttpStatusCode.OK)
		{
			Error = error;
			StatusCode = statusCode;
		}
	}
}