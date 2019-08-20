using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using PartPicker.Models;

namespace PartPicker.DAL
{
    public class PickerInitializer : CreateDatabaseIfNotExists<PickerContext>
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
                new Shop() { ShopId = 1, Name = "Media Expert", Logo = "https://www.mediaexpert.pl/common2/images/logo.png?v=1229",
                            Class = "price" },

                new Shop() { ShopId = 2, Name = "Vobis", Logo ="https://vobis.pl/common/images/logos/logo.png",
                            Class = "m-priceBox" },

                new Shop() { ShopId = 3, Name = "Morele", Logo = "https://www.morele.net/static/img/shop/logo/img-logo-morele.svg",
                            Class = "price-new" },

                new Shop() { ShopId = 4, Name = "Sferis", Logo = "https://www.sferis.pl/img/logo.svg?v=7",
                            Class = "prices solo" }
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

                new FormFactor() { FormFactorId = 6, Name = "WTX", Description = "Rodzaj płyty głównej stworzonej przez firmę Intel w 1998 roku."}
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

                new GpuRam () { GpuRamId = 3, Name = "GDDR6", Description = "Opis GDDR5" }
            };

            gpuRams.ForEach(s => context.GpuRam.Add(s));
            context.SaveChanges();

            var sockets = new List<Socket>
            {
                new Socket () { SocketId = 1, Name = "Socket 1151", Description = "Opis Socketu 1151"},

                new Socket () { SocketId = 2, Name = "Socket 2011-3", Description = "Opis Socketu 2011-3"},

                new Socket () { SocketId = 3, Name = "Socket 2066", Description = "Opis Socketu 2066"},

                new Socket () { SocketId = 4, Name = "Socket AM4", Description = "Opis Socketu AM4"},

                new Socket () { SocketId = 5, Name = "Socket FM2/FM2+", Description = "Opis Socketu FM/FM2+"},

                new Socket () { SocketId = 6, Name = "Socket TR4", Description = "Opis Socketu TR4"}
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

            var cases = new List<Case>
            {
                new Case () { CaseId = 1, Name = "NZXT H500 (Black)", Manufacturer = "NZXT",
                            Model = "H500", Link = "https://www.morele.net/obudowa-nzxt-h500-okno-bialy-ca-h500b-w1-4596293/",
                            FormFactorId = 2, MoboType = "ATX", GpuLenght = 381, Image = "/images/case/nzxt.jpg", ShopId = 3 },

                new Case () { CaseId = 2, Name = "Phanteks Eclipse P300 Tempered Glass (Black)", Manufacturer = "Phanteks",
                            Model = "Eclipse P300",  Link = "https://www.morele.net/obudowa-phanteks-eclipse-p300-ph-ec300ptg-bk-1603218/",
                            FormFactorId = 2, MoboType = "ATX", GpuLenght = 330, Image = "/images/case/phanteks.jpg", ShopId = 3 },

                new Case () { CaseId = 3, Name = "Cooler Master MasterBox Q300L", Manufacturer = "Cooler Master",
                            Model = "MasterBox Q300L", Link = "https://www.morele.net/obudowa-cooler-master-masterbox-q300l-mcb-q300l-kann-s00-1804692/",
                            FormFactorId = 3, MoboType = "microATX", GpuLenght = 360, Image = "/images/case/masterbox.jpg", ShopId = 3 }
            };

            cases.ForEach(s => context.Case.Add(s));
            context.SaveChanges();

            var cpus = new List<Cpu>
            {

                new Cpu () { CpuId = 1, Name = "AMD Ryzen 5 2600", Manufacturer = "AMD",
                            Model = "Ryzen 5", Link = "https://www.morele.net/procesor-amd-ryzen-5-2600-3-9ghz-16mb-box-yd2600bbafbox-980255/",
                            SocketId = 4, Cores = 6, Frequency = 3.4, Turbo = 3.9, Gpu = "Brak", Benchmark = 2000,
                            Image = "/images/cpu/ryzen52600.jpg", ShopId = 3},

                new Cpu () { CpuId = 2, Name = "AMD Ryzen 7 2700X", Manufacturer = "AMD",
                            Model = "Ryzen 7", Link = "https://www.morele.net/procesor-amd-ryzen-7-2700x-3-7ghz-20mb-box-yd270xbgafbox-980258/",
                            SocketId = 4, Cores = 8, Frequency = 3.7, Turbo = 4.2, Gpu = "Brak", Benchmark = 3000,
                            Image = "/images/cpu/ryzen72700x.jpg", ShopId = 3},

                new Cpu () { CpuId = 3, Name = "AMD Ryzen 5 2600X", Manufacturer = "AMD",
                            Model = "Ryzen 5", Link = "https://www.morele.net/procesor-amd-ryzen-5-2600x-3-6ghz-16mb-box-wraith-spire-yd260xbcafbox-980256/",
                            SocketId = 4, Cores = 6, Frequency = 3.6, Turbo = 4.2, Gpu = "Brak", Benchmark = 2500,
                            Image = "/images/cpu/ryzen52600x", ShopId = 3},

                new Cpu () { CpuId = 4, Name = "AMD Ryzen 5 2600X", Manufacturer = "AMD",
                            Model = "Ryzen 5", Link = "https://www.sferis.pl/procesor-amd-ryzen-5-2600x-ryzen-5-yd260xbcafbox-3600-mhz-min-4200-mhz-max-am4-p599440?nobid",
                            SocketId = 4, Cores = 6, Frequency = 3.6, Turbo = 4.2, Gpu = "Brak", Benchmark = 2500,
                            Image = "/images/cpu/ryzen52600x", ShopId = 4}
            };

            cpus.ForEach(s => context.Cpu.Add(s));
            context.SaveChanges();

            var gpus = new List<Gpu>
            {
                new Gpu ()  { GpuId = 1, Name = "MSI RX 580 ARMOR 8G OC", Manufacturer = "MSI",
                            Model = "RX 580", Link = "https://www.morele.net/karta-graficzna-msi-radeon-rx-580-armor-8g-oc-8gb-dl-dvi-d-hdmi-2-dp-2-atx-rx-580-armor-8g-oc-1220555/",
                            Ram = 8, GpuRamId = 1, Frequency = 1.257, FrequencyBoost = 1.366, Length = 269, Benchmark = 1000,
                            Image = "/images/gpu/msirx580.jpg", ShopId = 3},

                new Gpu ()  { GpuId = 2, Name = "Gigabyte GeForce RTX 2070 WINDFORCE 8G", Manufacturer = "Gigabyte",
                            Model = "GeForce RTX 2070", Link = "https://www.morele.net/karta-graficzna-gigabyte-geforce-rtx-2070-windforce-8g-8gb-gddr6-256-bit-3xhdmi-3xdp-usb-c-box-gv-n2070wf3-8gc-4142730/",
                            Ram = 8, GpuRamId = 3, Frequency = 1.620, FrequencyBoost = 1.740, Length = 280, Benchmark = 2000,
                            Image = "/images/gpu/gigabytertx2070.jpg", ShopId = 3},

                new Gpu ()  { GpuId = 3, Name = "MSI GTX 1660 Ti VENTUS XS 6G OC", Manufacturer = "MSI",
                            Model = "GeForce GTX 1660 Ti", Link = "https://www.morele.net/karta-graficzna-msi-gtx-1660-ti-ventus-xs-6g-oc-6gb-gddr6-gtx-1660-ti-ventus-xs-6g-oc-4144268/",
                            Ram = 6, GpuRamId = 3, Frequency = 1.500, FrequencyBoost = 1.830, Length = 204, Benchmark = 1500,
                            Image = "/images/gpu/msigtx1660ti.jpg", ShopId = 3}
            };

            gpus.ForEach(s => context.Gpu.Add(s));
            context.SaveChanges();

            var mobos = new List<Mobo>
            {
                new Mobo () { MoboId = 1, Name = "MSI B450 TOMAHAWK", Manufacturer = "MSI",
                            Model = "B450 TOMAHAWK", Link = "https://www.morele.net/plyta-glowna-msi-b450-tomahawk-4141464/",
                            FormFactorId = 2, SocketId = 4, RamSlots = 4, RamTypeId = 2, MaxRam = 64, SataSlots = 6,
                            Image = "/images/mobo/tomahawk.jpg", ShopId = 3},

                new Mobo () { MoboId = 2, Name = "Asus ROG STRIX B450-F GAMING", Manufacturer = "MSI",
                            Model = "ROG STRIX B450-F", Link = "https://www.morele.net/plyta-glowna-asus-rog-strix-b450-f-gaming-4780976/",
                            FormFactorId = 2, SocketId = 4, RamSlots = 4, RamTypeId = 2, MaxRam = 64, SataSlots = 6,
                            Image = "/images/mobo/asusrogstrix.jpg", ShopId = 3},

                new Mobo () { MoboId = 3, Name = "Gigabyte B450M DS3H", Manufacturer = "Gigabyte",
                            Model = "B450M DS3H", Link = "https://www.morele.net/plyta-glowna-gigabyte-b450m-ds3h-4141320/",
                            FormFactorId = 3, SocketId = 4, RamSlots = 4, RamTypeId = 2, MaxRam = 64, SataSlots = 4,
                            Image = "/images/mobo/gigabyteb450m.jpg", ShopId = 3}
            };

            mobos.ForEach(s => context.Mobo.Add(s));
            context.SaveChanges();

            var psus = new List<Psu>
            {
                new Psu ()  { PsuId = 1, Name = "EVGA SuperNOVA 750", Manufacturer = "EVGA",
                            Model = "SuperNOVA 750", Link = "https://www.morele.net/zasilacz-evga-supernova-g2-750w-220-g2-0750-x2-867278/",
                            FormFactorId = 2, Power = 750, Efficiency = "80+ Gold", Image = "/images/psu/supernova750.jpg", ShopId = 3},

                new Psu ()  { PsuId = 2, Name = "Corsair CX550M", Manufacturer = "Corsair",
                            Model = "CX550M", Link = "https://www.morele.net/zasilacz-corsair-cx-550w-cp-9020102-eu-855753/",
                            FormFactorId = 2, Power = 550, Efficiency = "80+ Bronze", Image = "/images/psu/cx550m.jpg", ShopId = 3},

                new Psu ()  { PsuId = 3, Name = "EVGA SuperNOVA 650", Manufacturer = "EVGA",
                            Model = "SuperNOVA 650", Link = "https://www.morele.net/zasilacz-evga-supernova-650-g2-650w-220-g2-0650-y2-798167/",
                            FormFactorId = 2, Power = 650, Efficiency = "80+ Gold", Image = "/images/psu/supernova650.jpg", ShopId = 3}
            };

            psus.ForEach(s => context.Psu.Add(s));
            context.SaveChanges();

            var rams = new List<Ram>
            {
                new Ram ()  { RamId = 1, Name = "Corsair Vengeance LPX 2x8", Manufacturer = "Corsair",
                            Model = "Vengeance LPX", Link = "https://www.morele.net/pamiec-corsair-vengeance-lpx-ddr4-16-gb-3000mhz-cl15-cmk16gx4m2b3000c15r-776918/",
                            RamTypeId = 2, Amount = 2, Size = 8, Frequency = 3000, Cl = 15,
                            Image = "/images/ram/corsairvengeance2.jpg", ShopId = 3},

                new Ram ()  { RamId = 2, Name = "G.Skill Trident Z RGB 2x8",  Manufacturer = "G.Skill",
                            Model = "Trident Z RGB", Link = "https://www.morele.net/pamiec-g-skill-trident-z-rgb-ddr4-16-gb-3000mhz-cl16-f4-3000c16d-16gtzr-1118470/",
                            RamTypeId = 2, Amount = 2, Size = 8, Frequency = 3200, Cl = 16,
                            Image = "/images/gskilltrident.jpg", ShopId = 3},

                new Ram ()  { RamId = 3, Name = "Corsair Vengeance LPX 1x16", Manufacturer = "Corsair",
                            Model = "Vengeance LPX", Link = "https://www.morele.net/pamiec-corsair-vengeance-lpx-ddr4-16-gb-3000mhz-cl15-cmk16gx4m1b3000c15-839294/",
                            RamTypeId = 2, Amount = 1, Size = 16, Frequency = 3000, Cl = 15,
                            Image = "/images/ram/corsairvengeance.jpg", ShopId = 3}
            };

            rams.ForEach(s => context.Ram.Add(s));
            context.SaveChanges();

            var storages = new List<Storage>
            {
                new Storage ()  { StorageId = 1, Name = "KINGSTON A400 SSD 240GB",  Manufacturer = "Kingston",
                                Model = "A400", Link = "https://www.mediaexpert.pl/?ds_rl=1259140&ds_rl=1259140&gclid=EAIaIQobChMIuJbux6XP4QIVnsmyCh3p8gBBEAAYASAAEgK4HvD_BwE&gclsrc=aw.ds",
                                Type = "SSD", Capacity = 240, InterfaceId = 2, Size = 2.5, Image = "/images/disks/kingstona400.jpg",
                                ShopId = 1},

                new Storage ()  { StorageId = 2, Name = "KINGSTON A400 SSD 240GB", Manufacturer = "Kingston",
                                Model = "A400", Link = "https://www.morele.net/dysk-ssd-kingston-a400-240gb-sata3-sa400s37-240g-1235881/",
                                Type = "SSD", Capacity = 240, InterfaceId = 2, Size = 2.5, Image = "/images/disks/kingstona400.jpg",
                                ShopId = 3},

                new Storage ()  { StorageId = 3, Name = "Seagate Enterprise Capacity HDD 6TB", Manufacturer = "Seagate",
                                Model = "Enterprise Capacity", Link = "https://vobis.pl/komputery/komponenty-serwerowe/dyski-twarde/dysk-seagate-enterprise-capacity-hdd-3-5-6tb-sas-7200rpm-256mb-1",
                                Type = "HDD", Capacity = 6000, InterfaceId = 6, Size = 3.5, Image = "/images/disks/seagate6tb.jpg",
                                ShopId = 2},

                new Storage ()  { StorageId = 4, Name = "WD Blue 500GB SSD WDS500G2B0A", Manufacturer = "Western Digital",
                                Model = "Blue", Link = "https://www.sferis.pl/dysk-500-gb-wd-blue-wds500g2b0a-25-sata-iii-p517640",
                                Type = "SSD", Capacity = 500, InterfaceId = 2, Size = 2.5, Image = "/images/disks/wdblue.jpg",
                                ShopId = 4},

                new Storage ()  { StorageId = 5, Name = "ADATA 256GB SU800", Manufacturer = "ADATA",
                                Model = "SU800", Link = "https://www.sferis.pl/dysk-256-gb-adata-su800-asu800ss-256gt-c-25-sata-iii-p455459",
                                Type = "SSD", Capacity = 256, InterfaceId = 2, Size = 2.5, Image = "/images/disks/adatasu800.jpg",
                                ShopId = 4},

                new Storage ()  { StorageId = 6, Name = "HDD Seagate Barracuda 1 TB", Manufacturer = "Seagate",
                                Model = "Barracuda", Link = "https://www.sferis.pl/dysk-hdd-seagate-st1000dm010-barracuda-1-tb-35-sata-iii-7200-obr-min-64-mb-p455378",
                                Type = "HDD", Capacity = 1000, InterfaceId = 2, Size = 3.5, Image = "/images/disks/barracuda.jpg",
                                ShopId = 4},

                new Storage ()  { StorageId = 7, Name = "Western Digital HDD 1TB WD10EZEX", Manufacturer = "Western Digital",
                                Model = "Blue", Link = "https://www.morele.net/dysk-western-digital-caviar-blue-3-5-1tb-sata-600-7200rpm-64mb-cache-wd10ezex-479659/",
                                Type = "HDD", Capacity = 1000, InterfaceId = 2, Size = 3.5, Image = "/images/disks/wdhdd1tb.jpg",
                                ShopId = 3},

                new Storage ()  { StorageId = 8, Name = "Seagate HDD 2TB ST2000DM006", Manufacturer = "Seagate",
                                Model = "Barracuda", Link = "https://www.morele.net/dysk-seagate-barracuda-2tb-sata-600-st2000dm006-958505/",
                                Type = "HDD", Capacity = 2000, InterfaceId = 2, Size = 3.5, Image = "/images/disks/seagatehdd2tb.jpg",
                                ShopId = 3},

                new Storage ()  { StorageId = 9, Name = "Samsung SSD 500GB MZ-76E500B/AM", Manufacturer = "Samsung",
                                Model = "860 Evo", Link = "https://www.morele.net/dysk-ssd-samsung-860-evo-500gb-sata3-mz-76e500b-eu-1773653/",
                                Type = "SSD", Capacity = 500, InterfaceId = 2, Size = 2.5, Image = "/images/disks/samsungssd500gb.jpg",
                                ShopId = 3}
            };

            storages.ForEach(s => context.Storage.Add(s));
            context.SaveChanges();

            var builds = new List<Build>
            {
                new Build () { BuildId = 1, Name = "Pierwsza", UserId = 1, Date = DateTime.Now, Hidden = false,
                             CpuId = 1, MoboId = 1, GpuId = 1, PsuId = 1, CaseId = 1, RamId = 1, StorageId = 1, Price = 3000 },

                new Build () { BuildId = 2, Name = "Druga", UserId = 1, Date = DateTime.Now, Hidden = false,
                             CpuId = 2, MoboId = 2, GpuId = 2, PsuId = 2, CaseId = 2, RamId = 2, StorageId = 2, Price = 3500 },

                new Build () { BuildId = 3, Name = "Ostatnia", UserId = 1, Date = DateTime.Now, Hidden = false,
                             CpuId = 3, MoboId = 3, GpuId = 3, PsuId = 3, CaseId = 3, RamId = 3, StorageId = 3, Price = 2000 }
            };

            builds.ForEach(s => context.Build.Add(s));
            context.SaveChanges();

            var rates = new List<Rate>
            {
                new Rate () { RateId = 1, BuildId = 1, UserId = 1, Grade = 5},

                new Rate () { RateId = 2, BuildId = 2, UserId = 1, Grade = 4},

                new Rate () { RateId = 3, BuildId = 3, UserId = 1, Grade = 2},

                new Rate () { RateId = 4, BuildId = 1, UserId = 2, Grade = 3},

                new Rate () { RateId = 5, BuildId = 2, UserId = 2, Grade = 5},

                new Rate () { RateId = 6, BuildId = 3, UserId = 2, Grade = 3},

                new Rate () { RateId = 7, BuildId = 1, UserId = 3, Grade = 2},

                new Rate () { RateId = 8, BuildId = 2, UserId = 3, Grade = 5},

                new Rate () { RateId = 9, BuildId = 3, UserId = 3, Grade = 1}
            };

            rates.ForEach(s => context.Rate.Add(s));
            context.SaveChanges();
        }
    }
}