using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using WebSocketSharp;

namespace Unity.WebRTC
{
    public class RTCRtpEncodingParameters
    {

        public bool active;

        // [autr] newly added parameters for NVIDIA SDK

        public uint? rateControlMode;
        public ulong? maxBitrate;
        public ulong? minBitrate;
        public uint? minFramerate;
        public uint? maxFramerate;
        public uint? width;
        public uint? height;
        public uint? minQP;
        public uint? maxQP;
        public uint? intraRefreshPeriod;
        public uint? intraRefreshCount;
        public bool enableAQ;
        public uint? maxNumRefFrames;
        public bool infiniteGOP;
        public double? scaleResolutionDownBy;
        public string rid;


        public RTCRtpEncodingParameters() {
            
        }
        public RTCRtpEncodingParameters(RTCRtpEncodingParametersInternal parameter)
        {
            active = parameter.active;


            // [autr] newly added parameters for NVIDIA SDK

            if (parameter.hasValueRateControlMode)
                rateControlMode = parameter.rateControlMode;
            if (parameter.hasValueMaxBitrate)
                maxBitrate = parameter.maxBitrate;
            if (parameter.hasValueMinBitrate)
                minBitrate = parameter.minBitrate;
            if (parameter.hasValueMinFramerate)
                minFramerate = parameter.minFramerate;
            if (parameter.hasValueMaxFramerate)
                maxFramerate = parameter.maxFramerate;
            if (parameter.hasValueWidth)
                width = parameter.width;
            if (parameter.hasValueHeight)
                height = parameter.height;
            if (parameter.hasValueMinQP)
                minQP = parameter.minQP;
            if (parameter.hasValueMaxQP)
                maxQP = parameter.maxQP;
            if (parameter.hasValueIntraRefreshPeriod)
                intraRefreshPeriod = parameter.intraRefreshPeriod;
            if (parameter.hasValueIntraRefreshCount)
                intraRefreshCount = parameter.intraRefreshCount;
            if (parameter.hasValueEnableAQ)
               enableAQ = parameter.enableAQ;
            if (parameter.hasValueMaxNumRefFrames)
               maxNumRefFrames = parameter.maxNumRefFrames;
            if (parameter.hasValueInfiniteGOP)
               infiniteGOP = parameter.infiniteGOP;

               
            if (parameter.hasValueScaleResolutionDownBy)
                scaleResolutionDownBy = parameter.scaleResolutionDownBy;
            if(parameter.rid != IntPtr.Zero)
                rid = parameter.rid.AsAnsiStringWithFreeMem();

        }

        public void CopyInternal(ref RTCRtpEncodingParametersInternal instance)
        {
            instance.active = active;

            instance.hasValueMaxBitrate = maxBitrate.HasValue;
            if(maxBitrate.HasValue)
                instance.maxBitrate = maxBitrate.Value;

            instance.hasValueMinBitrate = minBitrate.HasValue;
            if (minBitrate.HasValue)
                instance.minBitrate = minBitrate.Value;

            instance.hasValueMaxFramerate = maxFramerate.HasValue;
            if (maxFramerate.HasValue)
                instance.maxFramerate = maxFramerate.Value;

            instance.hasValueScaleResolutionDownBy = scaleResolutionDownBy.HasValue;
            if (scaleResolutionDownBy.HasValue)
                instance.scaleResolutionDownBy = scaleResolutionDownBy.Value;

            // [autr] newly added parameters for NVIDIA SDK

            instance.hasValueRateControlMode = rateControlMode.HasValue;
            if (rateControlMode.HasValue)
                instance.rateControlMode = rateControlMode.Value;

            instance.hasValueMinFramerate = minFramerate.HasValue;
            if (minFramerate.HasValue)
                instance.minFramerate = minFramerate.Value;

            instance.hasValueWidth = width.HasValue;
            if (width.HasValue)
                instance.width = width.Value;

            instance.hasValueHeight = height.HasValue;
            if (height.HasValue)
                instance.height = height.Value;

            instance.hasValueMinQP = minQP.HasValue;
            if (minQP.HasValue)
                instance.minQP = minQP.Value;

            instance.hasValueMaxQP = maxQP.HasValue;
            if (maxQP.HasValue)
                instance.maxQP = maxQP.Value;
                
            instance.hasValueIntraRefreshPeriod = intraRefreshPeriod.HasValue;
            if (intraRefreshPeriod.HasValue)
                instance.intraRefreshPeriod = intraRefreshPeriod.Value;

            instance.hasValueIntraRefreshCount = intraRefreshCount.HasValue;
            if (intraRefreshCount.HasValue)
                instance.intraRefreshCount = intraRefreshCount.Value;

            instance.enableAQ = enableAQ;

            instance.hasValueMaxNumRefFrames = maxNumRefFrames.HasValue;
            if (maxNumRefFrames.HasValue)
               instance.maxNumRefFrames = maxNumRefFrames.Value;
                
            instance.infiniteGOP = infiniteGOP;

            instance.rid = string.IsNullOrEmpty(rid) ? IntPtr.Zero : Marshal.StringToCoTaskMemAnsi(rid);
        }
    }

    public class RTCRtpSendParameters
    {
        public string TransactionId => _transactionId;

        public RTCRtpEncodingParameters[] Encodings => _encodings;

        readonly RTCRtpEncodingParameters[] _encodings;
        readonly string _transactionId;

        internal RTCRtpSendParameters(RTCRtpSendParametersInternal parameters)
        {
            int length = parameters.encodingsLength;
            RTCRtpEncodingParametersInternal[] encodings =
                parameters.encodings.AsArray<RTCRtpEncodingParametersInternal>(length);
            _encodings = Array.ConvertAll(encodings, _ => new RTCRtpEncodingParameters(_));
            _transactionId = parameters.transactionId.AsAnsiStringWithFreeMem();
        }

        internal IntPtr CreatePtr()
        {
            RTCRtpEncodingParametersInternal[] encodings =
                new RTCRtpEncodingParametersInternal[_encodings.Length];
            for(int i = 0; i < _encodings.Length; i++)
            {
                _encodings[i].CopyInternal(ref encodings[i]);
            }
            RTCRtpSendParametersInternal instance = default;
            instance.encodingsLength = _encodings.Length;
            instance.encodings = IntPtrExtension.ToPtr(encodings);
            instance.transactionId = Marshal.StringToCoTaskMemAnsi(_transactionId);
            IntPtr ptr = Marshal.AllocCoTaskMem(Marshal.SizeOf(instance));
            Marshal.StructureToPtr(instance, ptr, false);
            return ptr;
        }

        static internal void DeletePtr(IntPtr ptr)
        {
            var instance = Marshal.PtrToStructure<RTCRtpSendParametersInternal>(ptr);
            Marshal.FreeCoTaskMem(instance.encodings);
            Marshal.FreeCoTaskMem(ptr);
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct RTCRtpSendParametersInternal
    {
        public int encodingsLength;
        public IntPtr encodings;
        public IntPtr transactionId;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RTCRtpEncodingParametersInternal
    {
        [MarshalAs(UnmanagedType.U1)]
        public bool active;

        [MarshalAs(UnmanagedType.U1)]
        public bool hasValueRateControlMode;
        public uint rateControlMode;

        [MarshalAs(UnmanagedType.U1)]
        public bool hasValueMaxBitrate;
        public ulong maxBitrate;

        [MarshalAs(UnmanagedType.U1)]
        public bool hasValueMinBitrate;
        public ulong minBitrate;

        [MarshalAs(UnmanagedType.U1)]
        public bool hasValueWidth;
        public uint width;

        [MarshalAs(UnmanagedType.U1)]
        public bool hasValueHeight;
        public uint height;

        [MarshalAs(UnmanagedType.U1)]
        public bool hasValueMinFramerate;
        public uint minFramerate;

        [MarshalAs(UnmanagedType.U1)]
        public bool hasValueMaxFramerate;
        public uint maxFramerate;

        [MarshalAs(UnmanagedType.U1)]
        public bool hasValueMinQP;
        public uint minQP;

        [MarshalAs(UnmanagedType.U1)]
        public bool hasValueMaxQP;
        public uint maxQP;

        [MarshalAs(UnmanagedType.U1)]
        public bool hasValueIntraRefreshPeriod;
        public uint intraRefreshPeriod;

        [MarshalAs(UnmanagedType.U1)]
        public bool hasValueIntraRefreshCount;
        public uint intraRefreshCount;

        [MarshalAs(UnmanagedType.U1)]
        public bool hasValueEnableAQ;
        [MarshalAs(UnmanagedType.U1)]
        public bool enableAQ;

        [MarshalAs(UnmanagedType.U1)]
        public bool hasValueMaxNumRefFrames;
        public uint maxNumRefFrames;

        [MarshalAs(UnmanagedType.U1)]
        public bool hasValueInfiniteGOP;
        [MarshalAs(UnmanagedType.U1)]
        public bool infiniteGOP;

        [MarshalAs(UnmanagedType.U1)]
        public bool hasValueScaleResolutionDownBy;
        public double scaleResolutionDownBy;

        public IntPtr rid;
    }
}
