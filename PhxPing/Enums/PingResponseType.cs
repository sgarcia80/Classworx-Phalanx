using System;

namespace PhxPing
{
	public enum PingResponseType
	{
		Ok = 0,
		CouldNotResolveHost,
		RequestTimedOut,
		ConnectionError,
		InternalError,
		Canceled
	}
}
