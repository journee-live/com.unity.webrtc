#include "pch.h"
#include "HWSettings.h"

namespace unity {
    namespace webrtc {
        HWSettings * HWSettingsPtr_ = NULL;


        HWSettings* HWSettings::getPtr() {
            if (HWSettingsPtr_ == NULL) {
                HWSettingsPtr_ = new HWSettings();
            }
            return HWSettingsPtr_;
        };


        HWSettings::HWSettings() {
        }
    }

}
