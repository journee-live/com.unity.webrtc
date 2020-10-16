#pragma once
#include<stdio.h>
#include <string>
#include <stdio.h>
#include <sstream>

#define DLLExport __declspec(dllexport)

extern "C"
{
    //Create a callback delegate
    typedef void(*FuncCallBack)(const char* message, int i, int size);
    static FuncCallBack callbackInstance = nullptr;
    DLLExport void RegisterDebugCallback(FuncCallBack cb);
}


class  Debugger
{
public:
    static void Log(const char* message, int i = 999);
    static void Log(const std::string message, int i = 999);
    static void Log(const int message, int i = 999);
    static void Log(const char message, int i = 999);
    static void Log(const float message, int i = 999);
    static void Log(const double message, int i = 999);
    static void Log(const bool message, int i = 999);

private:
    static void send_log(const std::stringstream& ss, const int& i);
};
