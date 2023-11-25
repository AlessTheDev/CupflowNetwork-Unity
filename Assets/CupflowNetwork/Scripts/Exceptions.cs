using System;

namespace CupflowNetwork
{
    public class CupflowNetworkException : Exception
    {
        public CupflowNetworkException() : base() { }
        public CupflowNetworkException(string message) : base(message) { }
    }
    public class CupflowNetworkNotOpenException : Exception
    {
        public CupflowNetworkNotOpenException() : base() { }
        public CupflowNetworkNotOpenException(string message) : base(message) { }
    }

    public class CupflowNetworkNotConnectedException : Exception
    {
        public CupflowNetworkNotConnectedException() : base() { }
        public CupflowNetworkNotConnectedException(string message) : base(message) { }
    }
}