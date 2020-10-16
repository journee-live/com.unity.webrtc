#pragma once

#include <string>

namespace unity
{
    namespace webrtc
    {


        class HWSettings {
        public:

            bool b_rateControlMode;
            int rateControlMode;

            bool b_maxBitrate;
            int maxBitrate;

            bool b_minBitrate;
            int minBitrate;

            bool b_width;
            int width;

            bool b_height;
            int height;

            bool b_minFramerate;
            int minFramerate;

            bool b_maxFramerate;
            int maxFramerate;

            bool b_minQP;
            int minQP;

            bool b_maxQP;
            int maxQP;

            bool b_intraRefreshPeriod;
            int intraRefreshPeriod;

            bool b_intraRefreshCount;
            int intraRefreshCount;

            bool b_enableAQ;
            bool enableAQ;

            bool b_maxNumRefFrames;
            int maxNumRefFrames;

            bool b_infiniteGOP;
            bool infiniteGOP;






            std::string msg;

            HWSettings();
            static HWSettings* getPtr();
        };



    }
}
