using AOT;
using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class RenderStreamDebugger : MonoBehaviour
{
    private static RenderStreamDebugger instance = null;

    public int averageBitrate;
    public int frameRateNum;

    void OnEnable()
    {
        RegisterDebugCallback(OnDebugCallback);
    }

    // Game Instance Singleton
    public static RenderStreamDebugger Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        // if the singleton hasn't been initialized yet
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
    }
    //------------------------------------------------------------------------------------------------
    [DllImport("WebRTC.Lib", CallingConvention = CallingConvention.Cdecl)]
    static extern void RegisterDebugCallback(debugCallback cb);
    delegate void debugCallback(IntPtr request, int i, int size);
    [MonoPInvokeCallback(typeof(debugCallback))]
    static void OnDebugCallback(IntPtr request, int i, int size)
    {
        string key = Marshal.PtrToStringAnsi(request, size);
        string debug_string = "[WebRTC] " + key + " " + i.ToString();
        if (key == "averageBitrate" && instance != null) instance.averageBitrate = i;
        if (key == "frameRateNum" && instance != null) instance.frameRateNum = i;
        UnityEngine.Debug.Log(debug_string);
    }
}
