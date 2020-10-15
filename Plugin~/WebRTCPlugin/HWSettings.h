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
            int rateControlMode;
            int minQP ;
            int maxQP ;
            int width ;
            int height;
            int minFramerate ;
            int intraRefreshPeriod ;
            int intraRefreshCount ;
            bool AQ;
            int maxNumRefFrames;
            bool GOP;

            bool b_maxBitrate;
            bool b_minBitrate;
            bool b_maxFramerate;
            bool b_rateControlMode;
            bool b_minQP;
            bool b_maxQP;
            bool b_width;
            bool b_height;
            bool b_minFramerate;
            bool b_intraRefreshPeriod;
            bool b_intraRefreshCount;
            bool b_AQ;
            bool b_maxNumRefFrames;
            bool b_GOP;





            std::string msg;

            HWSettings();
            static HWSettings* getPtr();
        };



    }
}
