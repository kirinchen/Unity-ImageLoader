// hcq 2017/3/23

namespace UnityImageLoader.Cache {
    public abstract class AbstractDiscCache : ICache<byte[]> {


        public abstract void Set(string url, byte[] data);
        public abstract byte[] Get(string url);


    }
}
