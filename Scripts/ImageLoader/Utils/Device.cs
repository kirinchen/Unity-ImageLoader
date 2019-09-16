// hcq 2017/3/26
using UnityEngine;

namespace UnityImageLoader.Utils {
    public static class Device {
        static AndroidJavaClass GetEnvironmentClass() {
            return new AndroidJavaClass("android.os.Environment");
        }


        public static long GetMaxMemory() {

#if (UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN)
            return SystemInfo.systemMemorySize;
            // throw new NotImplementedException();

#elif UNITY_ANDROID
            using (AndroidJavaClass runtime = new AndroidJavaClass("java.lang.Runtime"))
            {
                using (AndroidJavaObject run = runtime.CallStatic<AndroidJavaObject>("getRuntime"))
                {
                    long maxMemory = run.Call<long>("maxMemory");
                    return maxMemory;
                }
            }

#endif
        }


        static AndroidJavaObject GetActivity() {
            using (AndroidJavaClass unityPlayerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer")) {
                return unityPlayerClass.GetStatic<AndroidJavaObject>("currentActivity");
            }
        }
    }
}