using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace PartPicker.Infrastructure
{
    public class AppConfig
    {
        private static string _imagesFolder = ConfigurationManager.AppSettings["Images"];

        public static string ImagesFolder
        {
            get
            {
                return _imagesFolder;
            }
        }

        private static string _buildsImagesFolder = ConfigurationManager.AppSettings["BuildsImages"];
        
        public static string BuildsImagesFolder
        {
            get
            {
                return _buildsImagesFolder;
            }
        }

        private static string _banersImagesFolder = ConfigurationManager.AppSettings["BanersImages"];

        public static string BanersImagesFolder
        {
            get
            {
                return _banersImagesFolder;
            }
        }
    }
}