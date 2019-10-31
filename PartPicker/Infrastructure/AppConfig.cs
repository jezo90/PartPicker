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

        private static string _shopsImagesFolder = ConfigurationManager.AppSettings["ShopsImages"];

        public static string ShopsImagesFolder
        {
            get
            {
                return _shopsImagesFolder;
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


        private static string _buildsImagesFolder = ConfigurationManager.AppSettings["BuildsImages"];

        public static string BuildsImagesFolder
        {
            get
            {
                return _buildsImagesFolder;
            }
        }


        private static string _cpusImagesFolder = ConfigurationManager.AppSettings["CpusImages"];

        public static string CpusImagesFolder
        {
            get
            {
                return _cpusImagesFolder;
            }
        }


        private static string _gpusImagesFolder = ConfigurationManager.AppSettings["GpusImages"];

        public static string GpusImagesFolder
        {
            get
            {
                return _gpusImagesFolder;
            }
        }

        private static string _ramsImagesFolder = ConfigurationManager.AppSettings["RamsImages"];

        public static string RamsImagesFolder
        {
            get
            {
                return _ramsImagesFolder;
            }
        }

        private static string _psusImagesFolder = ConfigurationManager.AppSettings["PsusImages"];

        public static string PsusImagesFolder
        {
            get
            {
                return _psusImagesFolder;
            }
        }

        private static string _mobosImagesFolder = ConfigurationManager.AppSettings["MobosImages"];

        public static string MobosImagesFolder
        {
            get
            {
                return _mobosImagesFolder;
            }
        }

        private static string _storagesImagesFolder = ConfigurationManager.AppSettings["StoragesImages"];

        public static string StoragesImagesFolder
        {
            get
            {
                return _storagesImagesFolder;
            }
        }

        private static string _casesImagesFolder = ConfigurationManager.AppSettings["CasesImages"];

        public static string CasesImagesFolder
        {
            get
            {
                return _casesImagesFolder;
            }
        }

        private static string _manufacturersImagesFolder = ConfigurationManager.AppSettings["ManufacturersImages"];

        public static string ManufacturersImagesFolder
        {
            get
            {
                return _manufacturersImagesFolder;
            }
        }
    }
}