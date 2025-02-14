﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PartPicker.Infrastructure
{
    public static class UrlHelpers
    {
        public static string ImagesPath(this UrlHelper helper, string name)
        {
            var ImagesPath = AppConfig.ImagesFolder;
            var path = Path.Combine(ImagesPath, name);
            var directPath = helper.Content(path);

            return directPath;
        }

        public static string ShopsImagesPath(this UrlHelper helper, string name)
        {
            var ShopsImagesPath = AppConfig.ShopsImagesFolder;
            var path = Path.Combine(ShopsImagesPath, name);
            var directPath = helper.Content(path);

            return directPath;
        }

        public static string BanersImagesPath(this UrlHelper helper)
        {
            var BanersImagesPath = AppConfig.BanersImagesFolder;
            Random random = new Random();
            string name = "baner" + random.Next(1, 4) + ".jpg";
            var path = Path.Combine(BanersImagesPath, name);
            var directPath = helper.Content(path);

            return directPath;
        }

        public static string BuildsImagesPath(this UrlHelper helper, string name)
        {
            var BuildsImagesPath = AppConfig.BuildsImagesFolder;
            var path = Path.Combine(BuildsImagesPath, name);
            var directPath = helper.Content(path);
            
            return directPath;
        }

        public static string CpusImagesPath(this UrlHelper helper, string name)
        {
            var CpusImagesPath = AppConfig.CpusImagesFolder;
            var path = Path.Combine(CpusImagesPath, name);
            var directPath = helper.Content(path);

            return directPath;
        }

        public static string GpusImagesPath(this UrlHelper helper, string name)
        {
            var GpusImagesPath = AppConfig.GpusImagesFolder;
            var path = Path.Combine(GpusImagesPath, name);
            var directPath = helper.Content(path);

            return directPath;
        }

        public static string RamsImagesPath(this UrlHelper helper, string name)
        {
            var RamsImagesPath = AppConfig.RamsImagesFolder;
            var path = Path.Combine(RamsImagesPath, name);
            var directPath = helper.Content(path);

            return directPath;
        }

        public static string MobosImagesPath(this UrlHelper helper, string name)
        {
            var MoboImagesPath = AppConfig.MobosImagesFolder;
            var path = Path.Combine(MoboImagesPath, name);
            var directPath = helper.Content(path);

            return directPath;
        }

        public static string CasesImagesPath(this UrlHelper helper, string name)
        {
            var CaseImagesPath = AppConfig.CasesImagesFolder;
            var path = Path.Combine(CaseImagesPath, name);
            var directPath = helper.Content(path);

            return directPath;
        }

        public static string StoragesImagesPath(this UrlHelper helper, string name)
        {
            var StoragesImagesPath = AppConfig.StoragesImagesFolder;
            var path = Path.Combine(StoragesImagesPath, name);
            var directPath = helper.Content(path);

            return directPath;
        }

        public static string PsusImagesPath(this UrlHelper helper, string name)
        {
            var PsusImagesPath = AppConfig.PsusImagesFolder;
            var path = Path.Combine(PsusImagesPath, name);
            var directPath = helper.Content(path);

            return directPath;
        }

        public static string ManufacturersImagesPath(this UrlHelper helper, string name)
        {
            var ManufacturersImagesPath = AppConfig.ManufacturersImagesFolder;
            var path = Path.Combine(ManufacturersImagesPath, name);
            var directPath = helper.Content(path);

            return directPath;
        }
    }
}