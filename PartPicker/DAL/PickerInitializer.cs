using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using PartPicker.Models;

namespace PartPicker.DAL
{
    public class PickerInitializer : DropCreateDatabaseAlways<PickerContext>
    {
        protected override void Seed(PickerContext context)
        {
            SeedPickerData(context);
            base.Seed(context);
        }

        private void SeedPickerData(PickerContext context)
        {
            var shops = new List<Shop>
            {
                new Shop() { ShopId = 1, Name = "Media Expert", Logo = "mediaexpert.png",
                            Class = "price" },

                new Shop() { ShopId = 2, Name = "Vobis", Logo ="vobis.png",
                            Class = "m-priceBox" },

                new Shop() { ShopId = 3, Name = "Morele", Logo = "morele.png",
                            Class = "price-new" },

                new Shop() { ShopId = 4, Name = "Sferis", Logo = "sferis.png",
                            Class = "prices multi" }
            };

            shops.ForEach(s => context.Shop.Add(s));
            context.SaveChanges();

            var formFactors = new List<FormFactor>
            {
                new FormFactor() { FormFactorId = 1, Name = "AT", Description = "Obecnie wyparty przez ATX."},

                new FormFactor() { FormFactorId = 2, Name = "ATX", Description = "Następca AT"},

                new FormFactor() { FormFactorId = 3, Name = "microATX", Description = "Jest zmodyfikowaną wersją standardu ATX."},

                new FormFactor() { FormFactorId = 4, Name = "BTX", Description = "Opis BTX"},

                new FormFactor() { FormFactorId = 5, Name = "Mobile-ITX", Description = "Jeden z najmniejszych standardów produkcji płyt głównych"},

                new FormFactor() { FormFactorId = 6, Name = "WTX", Description = "Rodzaj płyty głównej stworzonej przez firmę Intel w 1998 roku."},

                new FormFactor() { FormFactorId = 7, Name = "miniITX", Description = "Opis miniITX"},

                new FormFactor() { FormFactorId = 8, Name = "nanoITX", Description = "Opis nanoITX"},

                new FormFactor() { FormFactorId = 9, Name = "extendedATX", Description = "Opis extendedATX"}
            };

            formFactors.ForEach(s => context.FormFactor.Add(s));
            context.SaveChanges();

            var interfaces = new List<Interface>
            {
                new Interface() { InterfaceId = 1, Name = "ATA", Description = "Opis ATA"},

                new Interface() { InterfaceId = 2, Name = "SATA", Description = "Opis SATA"},

                new Interface() { InterfaceId = 3, Name = "M.2 (SATA)", Description = "Opis M2 pod SATA"},

                new Interface() { InterfaceId = 4, Name = "M.2 (PCI-E)", Description = "Opis M2 pod PCI-E"},

                new Interface() { InterfaceId = 5, Name = "mSATA", Description = "Opis mSATA"},

                new Interface() { InterfaceId = 6, Name = "SAS", Description = "Opis SAS"}
            };

            interfaces.ForEach(s => context.Interface.Add(s));
            context.SaveChanges();

            var ramTypes = new List<RamType>
            {
                new RamType() { RamTypeId = 1, Name = "DDR3", Description = "Opis DDR3"},

                new RamType() { RamTypeId = 2, Name = "DDR4", Description = "Opis DDR4"}
            };

            ramTypes.ForEach(s => context.RamType.Add(s));
            context.SaveChanges();

            var gpuRams = new List<GpuRam>
            {
                new GpuRam () { GpuRamId = 1, Name = "GDDR5", Description = "Opis GDDR5" },

                new GpuRam () { GpuRamId = 2, Name = "GDDR5X", Description = "Opis GDDR5X" },

                new GpuRam () { GpuRamId = 3, Name = "GDDR6", Description = "Opis GDDR6" }
            };

            gpuRams.ForEach(s => context.GpuRam.Add(s));
            context.SaveChanges();

            var sockets = new List<Socket>
            {
                new Socket () { SocketId = 1, Name = "1151", Description = "Opis Socketu 1151"},

                new Socket () { SocketId = 2, Name = "2011-3", Description = "Opis Socketu 2011-3"},

                new Socket () { SocketId = 3, Name = "2066", Description = "Opis Socketu 2066"},

                new Socket () { SocketId = 4, Name = "AM4", Description = "Opis Socketu AM4"},

                new Socket () { SocketId = 5, Name = "FM2/FM2+", Description = "Opis Socketu FM/FM2+"},

                new Socket () { SocketId = 6, Name = "TR4", Description = "Opis Socketu TR4"}
            };

            sockets.ForEach(s => context.Socket.Add(s));
            context.SaveChanges();

            var users = new List<User>
            {
                new User () { UserId = 1, Login = "adam", Nickname = "adam",
                            Email = "adam@o2.pl", Password = "adam", Permission = true},

                new User () { UserId = 2, Login = "adrian", Nickname = "adrian",
                            Email = "adrian@o2.pl", Password = "adrian", Permission = false},

                new User () { UserId = 3, Login = "jacek", Nickname = "jacek",
                            Email = "jacek@o2.pl", Password = "jacek", Permission = false},

                new User () { UserId = 4, Login = "admin", Nickname = "admin",
                            Email = "admin@o2.pl", Password = "admin", Permission = true},

                new User () { UserId = 5, Login = "test", Nickname = "test",
                            Email = "test@o2.pl", Password = "test", Permission = false}
            };

            users.ForEach(s => context.User.Add(s));
            context.SaveChanges();

            var manufacturers = new List<Manufacturer>
            {
                new Manufacturer() { ManufacturerId = 1, Name = "AMD", Image = "amd.png"},

                new Manufacturer() { ManufacturerId = 2, Name = "Intel", Image = "intel.png" },

                new Manufacturer() { ManufacturerId = 3, Name = "MSI", Image = "msi.png" },

                new Manufacturer() { ManufacturerId = 4, Name = "Gigabyte", Image = "gigabyte.png" },

                new Manufacturer() { ManufacturerId = 5, Name = "ASUS", Image = "asus.png" },

                new Manufacturer() { ManufacturerId = 6, Name = "EVGA", Image = "evga.png" },

                new Manufacturer() { ManufacturerId = 7, Name = "Corsair", Image = "corsair.png" },

                new Manufacturer() { ManufacturerId = 8, Name = "G.Skill", Image = "gskill.png" },

                new Manufacturer() { ManufacturerId = 9, Name = "Kingston", Image = "kingston.png" },

                new Manufacturer() { ManufacturerId = 10, Name = "Seagate", Image = "seagate.png" },

                new Manufacturer() { ManufacturerId = 11, Name = "Western Digital", Image = "wd.png" },

                new Manufacturer() { ManufacturerId = 12, Name = "ADATA", Image = "adata.png" },

                new Manufacturer() { ManufacturerId = 13, Name = "Samsung", Image = "samsung.png" },

                new Manufacturer() { ManufacturerId = 14, Name = "NXZT", Image = "nxzt.png" },

                new Manufacturer() { ManufacturerId = 15, Name = "Phanteks", Image = "phanteks.png" },

                new Manufacturer() { ManufacturerId = 16, Name = "Cooler Master", Image = "coolermaster.png" },

                new Manufacturer() { ManufacturerId = 17, Name = "ASRock", Image = "asrock.png" },

                new Manufacturer() { ManufacturerId = 18, Name = "SilentiumPC", Image = "silentium.png" },

                new Manufacturer() { ManufacturerId = 19, Name = "be quiet!", Image = "bequiet.png" }
            };

            manufacturers.ForEach(s => context.Manufacturer.Add(s));
            context.SaveChanges();

            var series = new List<Series>
            {
                new Series() { SeriesId = 1, Name = "Ryzen 5" },

                new Series() { SeriesId = 2, Name = "Ryzen 7" },

                new Series() { SeriesId = 3, Name = "i3" },

                new Series() { SeriesId = 4, Name = "i5" },

                new Series() { SeriesId = 5, Name = "i7" },

                new Series() { SeriesId = 6, Name = "Radeon" },

                new Series() { SeriesId = 7, Name = "NVIDIA GeForce" }
            };

            series.ForEach(s => context.Series.Add(s));
            context.SaveChanges();

            var products = new List<Product>
            {
                new Product() { ProductId = 1, ManufacturerId = 1, SeriesId = 1, Description = "Opis Ryzen 5"},

                new Product() { ProductId = 2, ManufacturerId = 1, SeriesId = 2, Description = "Opis Ryzen 7"},

                new Product() { ProductId = 3, ManufacturerId = 2, SeriesId = 4, Description = "Opis Intel i5"},

                new Product() { ProductId = 4, ManufacturerId = 2, SeriesId = 3, Description = "Opis Intel i3"},

                new Product() { ProductId = 5, ManufacturerId = 2, SeriesId = 5, Description = "Opis Intel i7"},

                new Product() { ProductId = 6, ManufacturerId = 3, SeriesId = 6, Description = "Opis Radeona"},

                new Product() { ProductId = 7, ManufacturerId = 4, SeriesId = 7, Description = "Opis NVIDIA GeForce"},

                new Product() { ProductId = 8, ManufacturerId = 3, SeriesId = 7, Description = "Opis NVIDIA GeForce"},

                new Product() { ProductId = 9, ManufacturerId = 17, SeriesId = 6, Description = "Opis Radeona"},

                new Product() { ProductId = 10, ManufacturerId = 5, SeriesId = 6, Description = "Opis Radeona"}
            };

            products.ForEach(s => context.Product.Add(s));
            context.SaveChanges();


            var cases = new List<Case>
            {
                new Case () { CaseId = 1, Name = "NZXT H500 (Black)", ManufacturerId = 14,
                            Model = "H500", Link = "https://www.morele.net/obudowa-nzxt-h500-okno-bialy-ca-h500b-w1-4596293/",
                            FormFactorId = 2, MoboType = "ATX, Micro ATX, Mini ITX", GpuLenght = 381,
                            Image = "nzxt.png", ShopId = 3 },

                new Case () { CaseId = 2, Name = "Phanteks Eclipse P300 Tempered Glass (Black)", ManufacturerId = 15,
                            Model = "Eclipse P300",  Link = "https://www.morele.net/obudowa-phanteks-eclipse-p300-ph-ec300ptg-bk-1603218/",
                            FormFactorId = 2, MoboType = "ATX, Micro ATX, Mini ITX", GpuLenght = 330,
                            Image = "phanteks.png", ShopId = 3 },

                new Case () { CaseId = 3, Name = "Cooler Master MasterBox Q300L", ManufacturerId = 16,
                            Model = "MasterBox Q300L", Link = "https://www.morele.net/obudowa-cooler-master-masterbox-q300l-mcb-q300l-kann-s00-1804692/",
                            FormFactorId = 3, MoboType = "Micro ATX, Mini ITX", GpuLenght = 360,
                            Image = "masterbox.png", ShopId = 3 },

                new Case () { CaseId = 4, Name = "Cooler Master Silencio 352", ManufacturerId = 16,
                            Model = "Silencio 352", Link = "https://www.morele.net/obudowa-cooler-master-silencio-352-sil-352m-kkn1-604750/",
                            FormFactorId = 3, MoboType = "Micro ATX, Mini ITX", GpuLenght = 355,
                            Image = "silencio352.png", ShopId = 3 },

                new Case () { CaseId = 5, Name = "Cooler Master MasterCase H500P Mesh Gunmetal", ManufacturerId = 16,
                            Model = "MasterCase H500P", Link = "https://www.morele.net/obudowa-cooler-master-mastercase-h500p-mesh-gunmetal-mcm-h500p-mgnn-s10-4196809/",
                            FormFactorId = 2, MoboType = "ATX, Micro ATX, Mini ITX", GpuLenght = 412,
                            Image = "mastercaseh500p.png", ShopId = 3 },

                new Case () { CaseId = 6, Name = "Cooler Master CM 590 III ", ManufacturerId = 16,
                            Model = "CM 590 III", Link = "https://www.morele.net/obudowa-cooler-master-cm-590-iii-rc-593-kwn2-1254363/",
                            FormFactorId = 2, MoboType = "ATX, Micro ATX, Mini ITX", GpuLenght = 405,
                            Image = "cm590.png", ShopId = 3 },

                new Case () { CaseId = 7, Name = "Cooler Master N200", ManufacturerId = 16,
                            Model = "N200", Link = "https://www.morele.net/obudowa-cooler-master-n200-nse-200-kkn1-584078/",
                            FormFactorId = 3, MoboType = "Micro ATX, Mini ITX", GpuLenght = 355,
                            Image = "n200.png", ShopId = 3 },

                new Case () { CaseId = 8, Name = "Cooler Master Elite 130 ", ManufacturerId = 16,
                            Model = "Elite 130", Link = "https://www.morele.net/obudowa-cooler-master-elite-130-rc-130-kkn1-608939/",
                            FormFactorId = 7, MoboType = "Mini ITX", GpuLenght = 343,
                            Image = "elite130.png", ShopId = 3 },

                new Case () { CaseId = 9, Name = "Nzxt H700 (White)", ManufacturerId = 14,
                            Model = "H700", Link = "https://www.morele.net/obudowa-nzxt-h700-okno-bialy-ca-h700b-w1-4596291/",
                            FormFactorId = 3, MoboType = "Extended ATX, ATX, Micro ATX, Mini ITX", GpuLenght = 413,
                            Image = "h700.png", ShopId = 3 },

                new Case () { CaseId = 10, Name = "Nzxt H400i (Black)", ManufacturerId = 14,
                            Model = "H400i", Link = "https://www.morele.net/obudowa-nzxt-h400i-matowa-czarna-ca-h400w-bb-1683598/",
                            FormFactorId = 7, MoboType = "Micro ATX, Mini ITX", GpuLenght = 411,
                            Image = "h400i.png", ShopId = 3 }
            };

            cases.ForEach(s => context.Case.Add(s));
            context.SaveChanges();

            var cpus = new List<Cpu>
            {

                new Cpu () { CpuId = 1, Name = "AMD Ryzen 5 2600", ProductId = 1,
                            Model = "2600", Link = "https://www.morele.net/procesor-amd-ryzen-5-2600-3-9ghz-16mb-box-yd2600bbafbox-980255/",
                            SocketId = 4, Cores = 6, Frequency = 3.4, Turbo = 3.9, Gpu = "Brak", Benchmark = 2000,
                            Image = "ryzen52600.png", ShopId = 3},

                new Cpu () { CpuId = 2, Name = "AMD Ryzen 7 2700X", ProductId = 2,
                            Model = "2700X", Link = "https://www.morele.net/procesor-amd-ryzen-7-2700x-3-7ghz-20mb-box-yd270xbgafbox-980258/",
                            SocketId = 4, Cores = 8, Frequency = 3.7, Turbo = 4.2, Gpu = "Brak", Benchmark = 3000,
                            Image = "ryzen72700x.png", ShopId = 3},

                new Cpu () { CpuId = 3, Name = "AMD Ryzen 5 2600X", ProductId = 1,
                            Model = "2600X", Link = "https://www.morele.net/procesor-amd-ryzen-5-2600x-3-6ghz-16mb-box-wraith-spire-yd260xbcafbox-980256/",
                            SocketId = 4, Cores = 6, Frequency = 3.6, Turbo = 4.2, Gpu = "Brak", Benchmark = 2500,
                            Image = "ryzen52600x.png", ShopId = 3},

                new Cpu () { CpuId = 4, Name = "AMD Ryzen 5 2600X", ProductId = 1,
                            Model = "2600X", Link = "https://www.sferis.pl/procesor-amd-ryzen-5-2600x-ryzen-5-yd260xbcafbox-3600-mhz-min-4200-mhz-max-am4-p599440?nobid",
                            SocketId = 4, Cores = 6, Frequency = 3.6, Turbo = 4.2, Gpu = "Brak", Benchmark = 2500,
                            Image = "ryzen52600x.png", ShopId = 4},

                new Cpu () { CpuId = 5, Name = "Intel Core i5-9400F", ProductId = 3,
                            Model = "9400F", Link = "https://www.morele.net/procesor-intel-core-i5-9400f-2-9ghz-9mb-box-bx80684i59400f-5668892/",
                            SocketId = 1, Cores = 6, Frequency = 2.9, Turbo = 4.1, Gpu = "Brak", Benchmark = 2500,
                            Image = "i59400f.png", ShopId = 3},

                new Cpu () { CpuId = 6, Name = "Intel Core i5-9600K", ProductId = 3,
                            Model = "9600K", Link = "https://www.morele.net/procesor-intel-core-i5-9600k-3-7ghz-9mb-box-bx80684i59600k-4142643/",
                            SocketId = 1, Cores = 6, Frequency = 3.7, Turbo = 4.6, Gpu = "Intel UHD Graphics 630", Benchmark = 3500,
                            Image = "i59600k.png", ShopId = 3},

                new Cpu () { CpuId = 7, Name = "Intel Core i3-9100F", ProductId = 4,
                            Model = "9100F", Link = "https://www.morele.net/procesor-intel-core-i3-9100f-3-6ghz-6mb-box-bx80684i39100f-5954267/",
                            SocketId = 1, Cores = 4, Frequency = 3.6, Turbo = 4.2, Gpu = "Brak", Benchmark = 2000,
                            Image = "i39100f.png", ShopId = 3},

                new Cpu () { CpuId = 8, Name = "Intel Core i7-8700K", ProductId = 5,
                            Model = "8700K", Link = "https://www.morele.net/procesor-intel-core-i3-9100f-3-6ghz-6mb-box-bx80684i39100f-5954267/",
                            SocketId = 1, Cores = 6, Frequency = 3.7, Turbo = 4.7, Gpu = "Intel UHD Graphics 630", Benchmark = 4000,
                            Image = "i78700k.png", ShopId = 3},

                new Cpu () { CpuId = 9, Name = "Intel Core i7-9700K", ProductId = 5,
                            Model = "9700K", Link = "https://www.morele.net/procesor-intel-core-i3-9100f-3-6ghz-6mb-box-bx80684i39100f-5954267/",
                            SocketId = 1, Cores = 8, Frequency = 3.6, Turbo = 4.9, Gpu = "Intel UHD Graphics 630", Benchmark = 4500,
                            Image = "i79700k.png", ShopId = 3},

                new Cpu () { CpuId = 10, Name = "Intel Core i5-9600K", ProductId = 3,
                            Model = "9600K", Link = "https://www.sferis.pl/procesor-intel-core-i5-9600k-core-i5-9600k-bx80684i59600k-984505-3700-mhz-min-4600-mhz-max-lga-1151-p615821",
                            SocketId = 1, Cores = 6, Frequency = 3.7, Turbo = 4.6, Gpu = "Intel UHD Graphics 630", Benchmark = 3500,
                            Image = "i59600k.png", ShopId = 4}
            };

            cpus.ForEach(s => context.Cpu.Add(s));
            context.SaveChanges();

            var gpus = new List<Gpu>
            {
                new Gpu ()  { GpuId = 1, Name = "MSI RX 580 ARMOR 8G OC", ProductId = 6,
                            Model = "RX 580", Link = "https://www.morele.net/karta-graficzna-msi-radeon-rx-580-armor-8g-oc-8gb-dl-dvi-d-hdmi-2-dp-2-atx-rx-580-armor-8g-oc-1220555/",
                            Ram = 8, GpuRamId = 1, Frequency = 1.257, FrequencyBoost = 1.366, Length = 269, Benchmark = 1000,
                            Image = "msirx580.png", ShopId = 3},

                new Gpu ()  { GpuId = 2, Name = "Gigabyte GeForce RTX 2070 WINDFORCE 8G", ProductId = 7,
                            Model = "RTX 2070", Link = "https://www.morele.net/karta-graficzna-gigabyte-geforce-rtx-2070-windforce-8g-8gb-gddr6-256-bit-3xhdmi-3xdp-usb-c-box-gv-n2070wf3-8gc-4142730/",
                            Ram = 8, GpuRamId = 3, Frequency = 1.620, FrequencyBoost = 1.740, Length = 280, Benchmark = 2000,
                            Image = "gigabytertx2070.png", ShopId = 3},

                new Gpu ()  { GpuId = 3, Name = "MSI GTX 1660 Ti VENTUS XS 6G OC", ProductId = 8,
                            Model = "GTX 1660 Ti", Link = "https://www.morele.net/karta-graficzna-msi-gtx-1660-ti-ventus-xs-6g-oc-6gb-gddr6-gtx-1660-ti-ventus-xs-6g-oc-4144268/",
                            Ram = 6, GpuRamId = 3, Frequency = 1.500, FrequencyBoost = 1.830, Length = 204, Benchmark = 1500,
                            Image = "msigtx1660ti.png", ShopId = 3},

                new Gpu ()  { GpuId = 4, Name = "ASRock Radeon RX 5700 8GB GDDR6", ProductId = 9,
                            Model = "RX 5700", Link = "https://www.morele.net/karta-graficzna-asrock-radeon-rx-5700-8gb-gddr6-hdmi-3xdp-box-radeon-rx-5700-8g-5938951/",
                            Ram = 8, GpuRamId = 3, Frequency = 1.465, FrequencyBoost = 1.765, Length = 281, Benchmark = 1600,
                            Image = "asrockrx5700.png", ShopId = 3},

                new Gpu ()  { GpuId = 5, Name = "Asus RX5700XT-8G 8GB GDDR6", ProductId = 10,
                            Model = "RX 5700 XT", Link = "https://www.morele.net/karta-graficzna-asus-rx5700xt-8g-8gb-gddr6-hdmi-3xdp-box-rx5700xt-8g-5938878/",
                            Ram = 8, GpuRamId = 3, Frequency = 1.605, FrequencyBoost = 1.905, Length = 285, Benchmark = 1900,
                            Image = "asrockrx5700xt.png", ShopId = 3},

                new Gpu ()  { GpuId = 6, Name = "MSI Radeon RX 5700 XT EVOKE OC 8GB GDDR6", ProductId = 6,
                            Model = "RX 5700 XT", Link = "https://www.morele.net/karta-graficzna-msi-radeon-rx-5700-xt-evoke-oc-8gb-gddr6-rx-5700-xt-evoke-oc-5939418/",
                            Ram = 8, GpuRamId = 3, Frequency = 1.695, FrequencyBoost = 1.945, Length = 285, Benchmark = 1900,
                            Image = "msirx5700xt.png", ShopId = 3},

                new Gpu ()  { GpuId = 7, Name = "MSI GeForce GTX 1650 VENTUS XS 4G OC", ProductId = 8,
                            Model = "GTX 1650", Link = "https://www.morele.net/karta-graficzna-msi-geforce-gtx-1650-ventus-xs-4g-oc-4gb-gddr5-gtx-1650-ventus-xs-4g-oc-5887879/",
                            Ram = 4, GpuRamId = 1, Frequency = 1.485, FrequencyBoost = 1.740, Length = 177, Benchmark = 900,
                            Image = "msigtx1650ventus.png", ShopId = 3},

                new Gpu ()  { GpuId = 8, Name = "MSI GeForce GTX 1650 GAMING X 4G", ProductId = 8,
                            Model = "GTX 1650", Link = "https://www.morele.net/karta-graficzna-msi-geforce-gtx-1650-gaming-x-4g-4gb-gddr5-gtx-1650-gaming-x-4g-5887878/",
                            Ram = 4, GpuRamId = 1, Frequency = 1.485, FrequencyBoost = 1.860, Length = 245, Benchmark = 950,
                            Image = "msigtx1650gaming.png", ShopId = 3},

                new Gpu ()  { GpuId = 9, Name = "MSI GeForce GTX 1650 GAMING X 4G", ProductId = 8,
                            Model = "GTX 1650", Link = "https://www.mediaexpert.pl/karty-graficzne/karta-graficzna-msi-geforce-gtx-1650-gaming-x-4g,id-1362616",
                            Ram = 4, GpuRamId = 1, Frequency = 1.485, FrequencyBoost = 1.860, Length = 245, Benchmark = 950,
                            Image = "msigtx1650gaming.png", ShopId = 1},

                new Gpu ()  { GpuId = 10, Name = "ASRock Radeon RX 5700 8GB GDDR6", ProductId = 9,
                            Model = "RX 5700", Link = "https://www.mediaexpert.pl/karty-graficzne/karta-graficzna-asrock-radeon-rx-5700-8gb,id-1400020",
                            Ram = 8, GpuRamId = 3, Frequency = 1.465, FrequencyBoost = 1.765, Length = 281, Benchmark = 1600,
                            Image = "asrockrx5700.png", ShopId = 1}

            };

            gpus.ForEach(s => context.Gpu.Add(s));
            context.SaveChanges();

            var mobos = new List<Mobo>
            {
                new Mobo () { MoboId = 1, Name = "MSI B450 TOMAHAWK", ManufacturerId = 3,
                            Model = "B450 TOMAHAWK", Link = "https://www.morele.net/plyta-glowna-msi-b450-tomahawk-4141464/",
                            FormFactorId = 2, SocketId = 4, RamSlots = 4, RamTypeId = 2, MaxRam = 64, SataSlots = 6,
                            Image = "tomahawk.png", ShopId = 3},

                new Mobo () { MoboId = 2, Name = "Asus ROG STRIX B450-F GAMING", ManufacturerId = 5,
                            Model = "ROG STRIX B450-F", Link = "https://www.morele.net/plyta-glowna-asus-rog-strix-b450-f-gaming-4780976/",
                            FormFactorId = 2, SocketId = 4, RamSlots = 4, RamTypeId = 2, MaxRam = 64, SataSlots = 6,
                            Image = "asusrogstrix.png", ShopId = 3},

                new Mobo () { MoboId = 3, Name = "Gigabyte B450M DS3H", ManufacturerId = 4,
                            Model = "B450M DS3H", Link = "https://www.morele.net/plyta-glowna-gigabyte-b450m-ds3h-4141320/",
                            FormFactorId = 3, SocketId = 4, RamSlots = 4, RamTypeId = 2, MaxRam = 64, SataSlots = 4,
                            Image = "gigabyteb450m.png", ShopId = 3},

                new Mobo () { MoboId = 4, Name = "Gigabyte B365M D3H", ManufacturerId = 4,
                            Model = "B365M D3H", Link = "https://www.morele.net/plyta-glowna-gigabyte-b365m-d3h-6152502/",
                            FormFactorId = 3, SocketId = 1, RamSlots = 4, RamTypeId = 2, MaxRam = 64, SataSlots = 6,
                            Image = "gigabyteb365m.png", ShopId = 3},

                new Mobo () { MoboId = 5, Name = "MSI H310M PRO-VH PLUS", ManufacturerId = 3,
                            Model = "H310M PRO-VH PLUS", Link = "https://www.morele.net/plyta-glowna-msi-h310m-pro-vh-plus-5814970/",
                            FormFactorId = 3, SocketId = 1, RamSlots = 2, RamTypeId = 2, MaxRam = 32, SataSlots = 4,
                            Image = "msih310mpro-vhplus.png", ShopId = 3},

                new Mobo () { MoboId = 6, Name = "Gigabyte X470 AORUS ULTRA GAMING", ManufacturerId = 4,
                            Model = "X470 AORUS ULTRA GAMING", Link = "https://www.morele.net/plyta-glowna-gigabyte-x470-aorus-ultra-gaming-980414/",
                            FormFactorId = 2, SocketId = 4, RamSlots = 4, RamTypeId = 2, MaxRam = 64, SataSlots = 6,
                            Image = "gigabytex470aorusultragaming.png", ShopId = 3},

                new Mobo () { MoboId = 7, Name = "ASRocK X370 Gaming ITX/AC", ManufacturerId = 17,
                            Model = "X370 Gaming ITX/AC", Link = "https://www.mediaexpert.pl/plyty-glowne/plyta-glowna-asrock-x370-gaming-itx-ac,id-960530",
                            FormFactorId = 7, SocketId = 4, RamSlots = 2, RamTypeId = 2, MaxRam = 32, SataSlots = 4,
                            Image = "x370gamingitxac.png", ShopId = 1},

                new Mobo () { MoboId = 8, Name = "ASRock H110M DVS R3.0", ManufacturerId = 17,
                            Model = "H110M DVS R3.0", Link = "https://www.morele.net/plyta-glowna-asrock-h110m-dvs-r3-0-90-mxb4a0-a0uayz-1096449/",
                            FormFactorId = 3, SocketId = 1, RamSlots = 2, RamTypeId = 2, MaxRam = 32, SataSlots = 4,
                            Image = "asrockh110mdvsr30.png", ShopId = 3},

                new Mobo () { MoboId = 9, Name = "MSI B360M BAZOOKA", ManufacturerId = 3,
                            Model = "B360M BAZOOKA", Link = "https://www.morele.net/plyta-glowna-msi-b360m-bazooka-4073726/",
                            FormFactorId = 3, SocketId = 1, RamSlots = 4, RamTypeId = 2, MaxRam = 64, SataSlots = 6,
                            Image = "msib360mbazooka.png", ShopId = 3},

                new Mobo () { MoboId = 10, Name = "Gigabyte AX370 Gaming 3", ManufacturerId = 4,
                            Model = "AX370 Gaming 3", Link = "https://www.morele.net/plyta-glowna-gigabyte-ax370-gaming-3-1780813/",
                            FormFactorId = 2, SocketId = 4, RamSlots = 4, RamTypeId = 2, MaxRam = 64, SataSlots = 6,
                            Image = "gigabyteax370gaming3.png", ShopId = 3}
            };

            mobos.ForEach(s => context.Mobo.Add(s));
            context.SaveChanges();

            var psus = new List<Psu>
            {
                new Psu ()  { PsuId = 1, Name = "EVGA SuperNOVA 750", ManufacturerId = 6,
                            Model = "SuperNOVA", Link = "https://www.morele.net/zasilacz-evga-supernova-g2-750w-220-g2-0750-x2-867278/",
                            FormFactorId = 2, Power = 750, Efficiency = "80+ Gold",
                            Image = "evgasupernova750.png", ShopId = 3},

                new Psu ()  { PsuId = 2, Name = "Corsair CX550M", ManufacturerId = 7,
                            Model = "CX550M", Link = "https://www.morele.net/zasilacz-corsair-cx-550w-cp-9020102-eu-855753/",
                            FormFactorId = 2, Power = 550, Efficiency = "80+ Bronze",
                            Image = "corsaircx550m.png", ShopId = 3},

                new Psu ()  { PsuId = 3, Name = "EVGA SuperNOVA 650", ManufacturerId = 6,
                            Model = "SuperNOVA", Link = "https://www.morele.net/zasilacz-evga-supernova-650-g2-650w-220-g2-0650-y2-798167/",
                            FormFactorId = 2, Power = 650, Efficiency = "80+ Gold",
                            Image = "evgasupernova650.png", ShopId = 3},

                new Psu ()  { PsuId = 4, Name = "SilentiumPC Vero L2 600W", ManufacturerId = 18,
                            Model = "Vero L2", Link = "https://www.morele.net/zasilacz-silentiumpc-vero-l2-600w-spc165-977143/",
                            FormFactorId = 2, Power = 600, Efficiency = "80+ Bronze",
                            Image = "silentiumpcverol2600w.png", ShopId = 3},

                new Psu ()  { PsuId = 5, Name = "be quiet! SYSTEM POWER 9 500W", ManufacturerId = 19,
                            Model = "SYSTEM POWER 9", Link = "https://www.morele.net/zasilacz-be-quiet-system-power-9-500w-bn246-1766271/",
                            FormFactorId = 2, Power = 500, Efficiency = "80+ Bronze",
                            Image = "bequiet!systempower9500w.png", ShopId = 3},

                new Psu ()  { PsuId = 6, Name = "SilentiumPC Vero M2 Bronze 600W", ManufacturerId = 18,
                            Model = "Vero M2 Bronze", Link = "https://www.morele.net/zasilacz-silentiumpc-vero-m2-bronze-600-w-spc166-977144/",
                            FormFactorId = 2, Power = 600, Efficiency = "80+ Bronze",
                            Image = "silentiumpcverom2bronze600w.png", ShopId = 3},

                new Psu ()  { PsuId = 7, Name = "be quiet! SYSTEM POWER 9 600W", ManufacturerId = 19,
                            Model = "SYSTEM POWER 9", Link = "https://www.morele.net/zasilacz-be-quiet-system-power-9-600w-bn247-1771362/",
                            FormFactorId = 2, Power = 600, Efficiency = "80+ Bronze",
                            Image = "bequiet!systempower9600w.png", ShopId = 3},

                new Psu ()  { PsuId = 8, Name = "Corsair RM750x 750W", ManufacturerId = 7,
                            Model = "RM750x", Link = "https://www.morele.net/zasilacz-corsair-rm750x-750w-cp-9020179-eu-1790294/",
                            FormFactorId = 2, Power = 750, Efficiency = "80+ Gold",
                            Image = "corsairrm750x750w.png", ShopId = 3},

                new Psu ()  { PsuId = 9, Name = "SilentiumPC Supremo M2 Gold 550W", ManufacturerId = 18,
                            Model = "Supremo M2 Gold", Link = "https://www.morele.net/zasilacz-silentiumpc-supremo-m2-gold-550w-spc140-774137/",
                            FormFactorId = 2, Power = 550, Efficiency = "80+ Gold",
                            Image = "silentiumpcsupremom2gold550w.png", ShopId = 3},

                new Psu ()  { PsuId = 10, Name = "Corsair Builder CX 750W", ManufacturerId = 7,
                            Model = "Builder CX", Link = "https://www.morele.net/zasilacz-corsair-builder-cx-750w-cp-9020061-eu-541540/",
                            FormFactorId = 2, Power = 750, Efficiency = "80+ Bronze",
                            Image = "corsairbuildercx750w.png", ShopId = 3}
            };

            psus.ForEach(s => context.Psu.Add(s));
            context.SaveChanges();

            var rams = new List<Ram>
            {
                new Ram ()  { RamId = 1, Name = "Corsair Vengeance LPX", ManufacturerId = 7,
                            Model = "Vengeance LPX", Link = "https://www.morele.net/pamiec-corsair-vengeance-lpx-ddr4-16-gb-3000mhz-cl15-cmk16gx4m2b3000c15r-776918/",
                            RamTypeId = 2, Amount = 2, Size = 8, Frequency = 3000, Cl = 15,
                            Image = "corsairvengeancelpx2x8.png", ShopId = 3},

                new Ram ()  { RamId = 2, Name = "G.Skill Trident Z RGB",  ManufacturerId = 8,
                            Model = "Trident Z RGB", Link = "https://www.morele.net/pamiec-g-skill-trident-z-rgb-ddr4-16-gb-3000mhz-cl16-f4-3000c16d-16gtzr-1118470/",
                            RamTypeId = 2, Amount = 2, Size = 8, Frequency = 3200, Cl = 16,
                            Image = "gskilltridentzrgb2x8.png", ShopId = 3},

                new Ram ()  { RamId = 3, Name = "Corsair Vengeance LPX", ManufacturerId = 7,
                            Model = "Vengeance LPX", Link = "https://www.morele.net/pamiec-corsair-vengeance-lpx-ddr4-16-gb-3000mhz-cl15-cmk16gx4m1b3000c15-839294/",
                            RamTypeId = 2, Amount = 1, Size = 16, Frequency = 3000, Cl = 15,
                            Image = "corsairvengeancelpx1x16.png", ShopId = 3},

                new Ram ()  { RamId = 4, Name = "ADATA DDR4", ManufacturerId = 12,
                            Model = "ADATA DDR4, 8GB", Link = "https://www.morele.net/pamiec-adata-ddr4-8-gb-2666mhz-cl16-ax4u266638g16-sbg-1640286/",
                            RamTypeId = 2, Amount = 1, Size = 8, Frequency = 2666, Cl = 16,
                            Image = "adataddr48gb2666hzcl16.png", ShopId = 3},

                new Ram ()  { RamId = 5, Name = "Corsair Vengeance RGB PRO", ManufacturerId = 7,
                            Model = "Vengeance RGB PRO", Link = "https://www.morele.net/pamiec-corsair-vengeance-rgb-pro-ddr4-16-gb-3200mhz-cl16-cmw16gx4m2c3200c16-4596109/",
                            RamTypeId = 2, Amount = 2, Size = 8, Frequency = 3200, Cl = 16,
                            Image = "corsairvengancergbproddr416gb3200mhzcl16.png", ShopId = 3},

                new Ram ()  { RamId = 6, Name = "G.Skill Ripjaws V", ManufacturerId = 8,
                            Model = "Ripjaws V", Link = "https://www.morele.net/pamiec-g-skill-ripjaws-v-ddr4-16-gb-3200mhz-cl16-f4-3200c16d-16gvkb-788195/",
                            RamTypeId = 2, Amount = 2, Size = 8, Frequency = 3200, Cl = 16,
                            Image = "gskillripjawsvddr416gb3200mhzcl16.png", ShopId = 3},

                new Ram ()  { RamId = 7, Name = "Corsair Vengeance LPX", ManufacturerId = 7,
                            Model = "Vengeance LPX", Link = "https://www.morele.net/pamiec-corsair-vengeance-lpx-ddr4-8-gb-3000mhz-cl16-cmk8gx4m2c3000c16-1678490/",
                            RamTypeId = 2, Amount = 2, Size = 4, Frequency = 3000, Cl = 16,
                            Image = "corsairvengeancelpx2x4.png", ShopId = 3},

                new Ram ()  { RamId = 8, Name = "G.Skill TridentX", ManufacturerId = 8,
                            Model = "TridentX", Link = "https://www.morele.net/pamiec-g-skill-tridentx-ddr3-16-gb-2400mhz-cl10-f3-2400c10d-16gtx-478220/",
                            RamTypeId = 1, Amount = 2, Size = 8, Frequency = 2400, Cl = 10,
                            Image = "gskilltridentxddr316gb2400mhzcl10.png", ShopId = 3},

                new Ram ()  { RamId = 9, Name = "Corsair Vengeance", ManufacturerId = 7,
                            Model = "Vengeance", Link = "https://www.morele.net/pamiec-corsair-vengeance-ddr3-4-gb-1600mhz-cl9-cmz4gx3m1a1600c9-360407/",
                            RamTypeId = 1, Amount = 1, Size = 4, Frequency = 1600, Cl = 9,
                            Image = "corsairvengeanceddr34gb1660hzcl9.png", ShopId = 3},

                new Ram ()  { RamId = 10, Name = "G.Skill Ripjaws V", ManufacturerId = 8,
                            Model = "Ripjaws V", Link = "https://www.morele.net/pamiec-g-skill-ripjaws-v-ddr4-16-gb-3000mhz-cl15-f4-3000c15d-16gvgb-831832/",
                            RamTypeId = 2, Amount = 2, Size = 16, Frequency = 3000, Cl = 15,
                            Image = "gskillripjawsvddr416gb3000mhzcl15.png", ShopId = 3}
            };

            rams.ForEach(s => context.Ram.Add(s));
            context.SaveChanges();

            var storages = new List<Storage>
            {
                new Storage ()  { StorageId = 1, Name = "KINGSTON A400 SSD 240GB",  ManufacturerId = 9,
                                Model = "A400", Link = "https://www.mediaexpert.pl/?ds_rl=1259140&ds_rl=1259140&gclid=EAIaIQobChMIuJbux6XP4QIVnsmyCh3p8gBBEAAYASAAEgK4HvD_BwE&gclsrc=aw.ds",
                                Type = "SSD", Capacity = 240, InterfaceId = 2, Size = 2.5,
                                Image = "kingstona400.jpg", ShopId = 1},

                new Storage ()  { StorageId = 2, Name = "KINGSTON A400 SSD 240GB", ManufacturerId = 9,
                                Model = "A400", Link = "https://www.morele.net/dysk-ssd-kingston-a400-240gb-sata3-sa400s37-240g-1235881/",
                                Type = "SSD", Capacity = 240, InterfaceId = 2, Size = 2.5,
                                Image = "kingstona400.jpg", ShopId = 3},

                new Storage ()  { StorageId = 3, Name = "Seagate Enterprise Capacity HDD 6TB", ManufacturerId = 10,
                                Model = "Enterprise Capacity", Link = "https://vobis.pl/komputery/komponenty-serwerowe/dyski-twarde/dysk-seagate-enterprise-capacity-hdd-3-5-6tb-sas-7200rpm-256mb-1",
                                Type = "HDD", Capacity = 6000, InterfaceId = 6, Size = 3.5,
                                Image = "seagate6tb.jpg", ShopId = 2},

                new Storage ()  { StorageId = 4, Name = "WD Blue 500GB SSD WDS500G2B0A", ManufacturerId = 11,
                                Model = "Blue", Link = "https://www.sferis.pl/dysk-500-gb-wd-blue-wds500g2b0a-25-sata-iii-p517640",
                                Type = "SSD", Capacity = 500, InterfaceId = 2, Size = 2.5,
                                Image = "wdblue.jpg", ShopId = 4},

                new Storage ()  { StorageId = 5, Name = "ADATA 256GB SU800", ManufacturerId = 12,
                                Model = "SU800", Link = "https://www.sferis.pl/dysk-256-gb-adata-su800-asu800ss-256gt-c-25-sata-iii-p455459",
                                Type = "SSD", Capacity = 256, InterfaceId = 2, Size = 2.5,
                                Image = "adatasu800.jpg", ShopId = 4},

                new Storage ()  { StorageId = 6, Name = "HDD Seagate Barracuda 1 TB", ManufacturerId = 10,
                                Model = "Barracuda", Link = "https://www.sferis.pl/dysk-hdd-seagate-st1000dm010-barracuda-1-tb-35-sata-iii-7200-obr-min-64-mb-p455378",
                                Type = "HDD", Capacity = 1000, InterfaceId = 2, Size = 3.5,
                                Image = "barracuda.jpg", ShopId = 4},

                new Storage ()  { StorageId = 7, Name = "Western Digital HDD 1TB WD10EZEX", ManufacturerId = 11,
                                Model = "Blue", Link = "https://www.morele.net/dysk-western-digital-caviar-blue-3-5-1tb-sata-600-7200rpm-64mb-cache-wd10ezex-479659/",
                                Type = "HDD", Capacity = 1000, InterfaceId = 2, Size = 3.5,
                                Image = "wdhdd1tb.jpg", ShopId = 3},

                new Storage ()  { StorageId = 8, Name = "Seagate HDD 2TB ST2000DM006", ManufacturerId = 10,
                                Model = "Barracuda", Link = "https://www.morele.net/dysk-seagate-barracuda-2tb-sata-600-st2000dm006-958505/",
                                Type = "HDD", Capacity = 2000, InterfaceId = 2, Size = 3.5,
                                Image = "seagatehdd2tb.jpg", ShopId = 3},

                new Storage ()  { StorageId = 9, Name = "Samsung SSD 500GB MZ-76E500B/AM", ManufacturerId = 13,
                                Model = "860 Evo", Link = "https://www.morele.net/dysk-ssd-samsung-860-evo-500gb-sata3-mz-76e500b-eu-1773653/",
                                Type = "SSD", Capacity = 500, InterfaceId = 2, Size = 2.5,
                                Image = "samsungssd500gb.jpg", ShopId = 3}
            };

            storages.ForEach(s => context.Storage.Add(s));
            context.SaveChanges();

            var builds = new List<Build>
            {
                new Build () { BuildId = 1, Name = "Pierwsza", UserId = 1, Date = DateTime.Now, Hidden = false,
                             CpuId = 1, MoboId = 1, GpuId = 1, PsuId = 1, CaseId = 1, RamId = 1, StorageId = 1,
                             Image = "basic.png", Description = "AWESOME PC TO WORK" },

                new Build () { BuildId = 2, Name = "Druga", UserId = 1, Date = DateTime.Now, Hidden = false,
                             CpuId = 2, MoboId = 2, GpuId = 2, PsuId = 2, CaseId = 2, RamId = 3, StorageId = 2,
                             Image = "basic.png", Description = "AWESOME PC TO WORK" },

                new Build () { BuildId = 3, Name = "Trzecia", UserId = 1, Date = DateTime.Now, Hidden = false,
                             CpuId = 3, MoboId = 3, GpuId = 3, PsuId = 3, CaseId = 6, RamId = 2, StorageId = 6,
                             Image = "basic.png", Description = "AWESOME PC TO WORK" },

                new Build () { BuildId = 4, Name = "Czwarta", UserId = 1, Date = DateTime.Now, Hidden = false,
                             CpuId = 4, MoboId = 1, GpuId = 4, PsuId = 4, CaseId = 5, RamId = 1, StorageId = 2,
                             Image = "basic.png", Description = "AWESOME PC TO WORK" },

                new Build () { BuildId = 5, Name = "Piąta", UserId = 1, Date = DateTime.Now, Hidden = false,
                             CpuId = 5, MoboId = 4, GpuId = 5, PsuId = 5, CaseId = 2, RamId = 6, StorageId = 7,
                             Image = "basic.png", Description = "AWESOME PC TO GAMES" },

                new Build () { BuildId = 6, Name = "Szusta", UserId = 1, Date = DateTime.Now, Hidden = false,
                             CpuId = 6, MoboId = 5, GpuId = 6, PsuId = 6, CaseId = 2, RamId = 3, StorageId = 1,
                             Image = "basic.png", Description = "AWESOME PC TO GAMES" },

                new Build () { BuildId = 7, Name = "Siódma", UserId = 1, Date = DateTime.Now, Hidden = false,
                             CpuId = 7, MoboId = 8, GpuId = 7, PsuId = 7, CaseId = 5, RamId = 4, StorageId = 7,
                             Image = "basic.png", Description = "AWESOME PC TO GAMES" },

                new Build () { BuildId = 8, Name = "ósma", UserId = 2, Date = DateTime.Now, Hidden = false,
                             CpuId = 8, MoboId = 9, GpuId = 8, PsuId = 8, CaseId = 1, RamId = 1, StorageId = 1,
                             Image = "basic.png", Description = "AWESOME PC TO GAMES" }
            };

            builds.ForEach(s => context.Build.Add(s));
            context.SaveChanges();

            var rates = new List<Rate>
            {
                new Rate () { RateId = 1, BuildId = 1, UserId = 1, Grade = 5, Added = DateTime.Now, Comment = "Nice!"},

                new Rate () { RateId = 2, BuildId = 2, UserId = 1, Grade = 4, Added = DateTime.Now, Comment = "Nice!"},

                new Rate () { RateId = 3, BuildId = 3, UserId = 1, Grade = 2, Added = DateTime.Now, Comment = "Nice!"},

                new Rate () { RateId = 4, BuildId = 5, UserId = 1, Grade = 5, Added = DateTime.Now, Comment = "Gooood!"},

                new Rate () { RateId = 5, BuildId = 6, UserId = 1, Grade = 1, Added = DateTime.Now, Comment =" Meh!"},

                new Rate () { RateId = 6, BuildId = 7, UserId = 1, Grade = 4, Added = DateTime.Now, Comment = "Change Cpu!"},

                new Rate () { RateId = 7, BuildId = 1, UserId = 2, Grade = 5, Added= DateTime.Now, Comment = "Nice!"},

                new Rate () { RateId = 8, BuildId = 4, UserId = 2, Grade = 5, Added = DateTime.Now, Comment = "Nice!"},

                new Rate () { RateId = 9, BuildId = 7, UserId = 2, Grade = 3, Added = DateTime.Now, Comment = "Nice!"},

                new Rate () { RateId = 10, BuildId = 2, UserId = 2, Grade = 3, Added = DateTime.Now, Comment = "Wow!"},
                 
                new Rate () { RateId = 11, BuildId = 6, UserId = 2, Grade = 3, Added = DateTime.Now, Comment = "Great!"},

                new Rate () { RateId = 7, BuildId = 1, UserId = 3, Grade = 4, Added = DateTime.Now, Comment = "Awesome!"},

                new Rate () { RateId = 8, BuildId = 2, UserId = 3, Grade = 5, Added = DateTime.Now, Comment = "Superb!"},

                new Rate () { RateId = 9, BuildId = 3, UserId = 3, Grade = 1, Added = DateTime.Now, Comment = "Bad!"}
            };

            rates.ForEach(s => context.Rate.Add(s));
            context.SaveChanges();
        }
    }
}