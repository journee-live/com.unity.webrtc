#pragma once

#include <string>

namespace unity
{
    namespace webrtc
    {


        class HWSettings {
        public:

            int maxBitrate;
            int minBitrate;
            int maxFramerate;
            std::string rateControlMode;
            int minQP;
            int width;
            int height;
            int minFramerate;
            std::string msg;

            HWSettings();
            static HWSettings* getPtr();
        };



    }
}
