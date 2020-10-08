using System;

namespace Unity.WebRTC
{
    public class RTCErrorException : Exception
    {
        private RTCError m_error;

        internal RTCErrorException(ref RTCError error) : base(error.message)
        {
            m_error = error;
        }
        public RTCErrorType ErrorType { get { return m_error.errorType; } }
    }
}
