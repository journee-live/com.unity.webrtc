#include "pch.h"
#include "UnityVideoDecoderFactory.h"
#include "absl/strings/match.h"

#if defined(__APPLE__)
#import "sdk/objc/components/video_codec/RTCDefaultVideoDecoderFactory.h"
#import "sdk/objc/native/api/video_decoder_factory.h"
#endif

namespace unity
{
namespace webrtc
{
    webrtc::VideoDecoderFactory* CreateDecoderFactory()
    {
#if defined(__APPLE__)
        return webrtc::ObjCToNativeVideoDecoderFactory(
            [[RTCDefaultVideoDecoderFactory alloc] init]).release();
#endif
        return new webrtc::InternalDecoderFactory();
    }

    UnityVideoDecoderFactory::UnityVideoDecoderFactory()
    : internal_decoder_factory_(CreateDecoderFactory())
    {
    }

    std::vector<webrtc::SdpVideoFormat> UnityVideoDecoderFactory::GetSupportedFormats() const
    {
//        std::vector<webrtc::SdpVideoFormat> formats;
//
//        formats.push_back(webrtc::SdpVideoFormat(cricket::kVp8CodecName));
//
//        for (const webrtc::SdpVideoFormat& format : webrtc::SupportedVP9Codecs())
//        {
//            formats.push_back(format);
//        }
//        return formats;
        return internal_decoder_factory_->GetSupportedFormats();
    }

    std::unique_ptr<webrtc::VideoDecoder> UnityVideoDecoderFactory::CreateVideoDecoder(const webrtc::SdpVideoFormat & format)
    {
//        if (absl::EqualsIgnoreCase(format.name, cricket::kVp8CodecName))
//        {
//            return webrtc::VP8Decoder::Create();
//        }
//
//        if (absl::EqualsIgnoreCase(format.name, cricket::kVp9CodecName))
//        {
//            return webrtc::VP9Decoder::Create();
//        }
//
//        return nullptr;
        return internal_decoder_factory_->CreateVideoDecoder(format);
    }

}  // namespace webrtc
}  // namespace unity
