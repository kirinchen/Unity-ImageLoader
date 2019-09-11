using System;
using System.Collections;
using System.IO;
using UnityEngine;

namespace UnityImageLoader.Cache {
    public class LRUDiscCache : AbstractDiscCache {


        public static readonly string cachePath = "@ImageLoader_";


        public override  void Set(string url, byte[] data) {
            if (data == null || data.Length <= 0) {
                return;
            }
            string path = GetPath(url);
            string base64Tex = System.Convert.ToBase64String(data);
            // write string to playerpref
            PlayerPrefs.SetString(path, base64Tex);
            PlayerPrefs.Save();

        }


        public override  byte[] Get(string url) {
            string path = GetPath(url);
            if (PlayerPrefs.HasKey(path)) {
                string bytext = PlayerPrefs.GetString(path);
                return System.Convert.FromBase64String(bytext);
            }
            return null;
        }

        public virtual void Access(string url) {
            string path = GetPath(url);
            if (File.Exists(path)) {
                File.SetLastAccessTime(path, DateTime.Now);
            }
        }

        public virtual string GetPath(string url) {
            return cachePath + Animator.StringToHash(url);
        }

        protected internal class FileDateSort : IComparer {
            #region IComparer Members

            public int Compare(object x, object y) {
                if (x == null && y == null) {
                    return 0;
                }
                if (x == null) {
                    return -1;
                }
                if (y == null) {
                    return 1;
                }
                FileInfo xInfo = (FileInfo)x;
                FileInfo yInfo = (FileInfo)y;


                return xInfo.LastAccessTime.CompareTo(yInfo.LastAccessTime);

            }

            #endregion

        }

    }
}

