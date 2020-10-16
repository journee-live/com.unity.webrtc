#include "pch.h"
#include "Debugger.h"

#include<stdio.h>
#include <string>
#include <stdio.h>
#include <sstream>

//-------------------------------------------------------------------
void  Debugger::Log(const char* message, int i) {
    if (callbackInstance != nullptr)
        callbackInstance(message, (int)i, (int)strlen(message));
}

void  Debugger::Log(const std::string message, int i) {
    const char* tmsg = message.c_str();
    if (callbackInstance != nullptr)
        callbackInstance(tmsg, (int)i, (int)strlen(tmsg));
}

void  Debugger::Log(const int message, int i) {
    std::stringstream ss;
    ss << message;
    send_log(ss, i);
}

void  Debugger::Log(const char message, int i) {
    std::stringstream ss;
    ss << message;
    send_log(ss, i);
}

void  Debugger::Log(const float message, int i) {
    std::stringstream ss;
    ss << message;
    send_log(ss, i);
}

void  Debugger::Log(const double message, int i) {
    std::stringstream ss;
    ss << message;
    send_log(ss, i);
}

void Debugger::Log(const bool message, int i) {
    std::stringstream ss;
    if (message)
        ss << "true";
    else
        ss << "false";

    send_log(ss, i);
}

void Debugger::send_log(const std::stringstream& ss, const int& i) {
    const std::string tmp = ss.str();
    const char* tmsg = tmp.c_str();
    if (callbackInstance != nullptr)
        callbackInstance(tmsg, (int)i, (int)strlen(tmsg));
}
//-------------------------------------------------------------------

//Create a callback delegate
void RegisterDebugCallback(FuncCallBack cb) {
    callbackInstance = cb;
}
