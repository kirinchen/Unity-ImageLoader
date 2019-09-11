using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityImageLoader;

namespace surfm.tool.imageloader {

    public class Demo : MonoBehaviour {

        public string[] imgUrl = {
            "https://upload.wikimedia.org/wikipedia/commons/thumb/8/88/Ward_Cunningham_-_Commons-1.jpg/220px-Ward_Cunningham_-_Commons-1.jpg",
            "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b6/WikiWiki.jpg/250px-WikiWiki.jpg",
            "https://upload.wikimedia.org/wikipedia/commons/thumb/4/42/HNL_Wiki_Wiki_Bus.jpg/300px-HNL_Wiki_Wiki_Bus.jpg",
            "https://upload.wikimedia.org/wikipedia/commons/thumb/3/38/Inside_and_Rear_of_Webserver.jpg/220px-Inside_and_Rear_of_Webserver.jpg",
            "https://upload.wikimedia.org/wikipedia/commons/thumb/f/f6/SunFire-X4200.jpg/220px-SunFire-X4200.jpg",
            "https://upload.wikimedia.org/wikipedia/commons/thumb/1/12/Usage_share_of_web_servers_%28Source_Netcraft%29.svg/220px-Usage_share_of_web_servers_%28Source_Netcraft%29.svg.png",
            "https://upload.wikimedia.org/wikipedia/commons/9/91/CircularMound.jpg",
            "https://upload.wikimedia.org/wikipedia/commons/thumb/3/3f/TempleHeaven2.jpg/1280px-TempleHeaven2.jpg",
            "https://upload.wikimedia.org/wikipedia/commons/thumb/a/aa/Beijing_Sun_Temple_Park-2.jpg/1280px-Beijing_Sun_Temple_Park-2.jpg"

        };

        public List<Image> images = null;

        void Awake() {
            images = new List<Image>(FindObjectsOfType<Image>());
        }

        public void onTestClick() {
            images.ForEach(i=> {
                string iurl = imgUrl[Random.Range(0, imgUrl.Length)];
                setupImg(i, iurl);
            });
            //setupImg(images[0], imgUrl[0]);
        }

        private void setupImg(Image img,string _url) {
           
            ImageLoader.GetInstance().Display(img, _url);
        }
    }
}
