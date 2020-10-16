#include "pch.h"
#include "HWSettings.h"

namespace unity {
    namespace webrtc {
        HWSettings* HWSettingsPtr_ = NULL;


        HWSettings* HWSettings::getPtr() {
            if (HWSettingsPtr_ == NULL) {
                HWSettingsPtr_ = new HWSettings();
            }
            return HWSettingsPtr_;
        };


        HWSettings::HWSettings() {
            minBitrate = 500000;
            maxBitrate = 5000000;
            rateControlMode = 0;
            minQP = 20;
            maxQP = 60;
            width = 1280;
            height = 720;
            minFramerate = 10;
            intraRefreshPeriod = 30;
            intraRefreshCount = 10;
            enableAQ = true;
            maxNumRefFrames = 0;
            infiniteGOP = false;

            b_maxBitrate = false;
            b_minBitrate = false;
            b_maxFramerate = false;
            b_rateControlMode = false;
            b_minQP = false;
            b_maxQP = false;
            b_width = false;
            b_height = false;
            b_minFramerate = false;
            b_intraRefreshPeriod = false;
            b_intraRefreshCount = false;
            b_enableAQ = false;
            b_maxNumRefFrames = false;
            b_infiniteGOP = false;
        }
    }

}
