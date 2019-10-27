using PartPicker.DAL;
using PartPicker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartPicker.Infrastructure
{
    public class BuildManager
    {
        private PickerContext context;
        private ISessionManager session;

        public BuildManager(ISessionManager session, PickerContext context)
        {
            this.session = session;
            this.context = context;
        }

        public NewBuild NewBuild()
        {
            NewBuild build;

            if(session.Get<NewBuild>(SessionNames.BuildSessionKey)==null)
            {
                build = new NewBuild();
            }
            else
            {
                build = session.Get<NewBuild>(SessionNames.BuildSessionKey) as NewBuild;
            }

            return build;
        }

        /// CPU
        public void CpuAddToBuild(Cpu cpu)
        {
            var build = NewBuild();
            build.Cpu = cpu;
            session.Set(SessionNames.BuildSessionKey, build);
        }

        public void CpuDeleteFromBuild()
        {
            var build = NewBuild();
            build.Cpu = null;
        }

        public Cpu GetCpu()
        {
            NewBuild build;
            if (session.Get<NewBuild>(SessionNames.BuildSessionKey)==null)
            {
                build = new NewBuild();
            }
            else
            {
                build = session.Get<NewBuild>(SessionNames.BuildSessionKey) as NewBuild;
            }

            return build.Cpu;

        }

        /// GPU
        public void GpuAddToBuild(Gpu gpu)
        {
            var build = NewBuild();
            build.Gpu = gpu;
            session.Set(SessionNames.BuildSessionKey, build);
        }

        public void GpuDeleteFromBuild()
        {
            var build = NewBuild();
            build.Gpu = null;
        }

        public Gpu GetGpu()
        {
            NewBuild build;
            if (session.Get<NewBuild>(SessionNames.BuildSessionKey) == null)
            {
                build = new NewBuild();
            }
            else
            {
                build = session.Get<NewBuild>(SessionNames.BuildSessionKey) as NewBuild;
            }

            return build.Gpu;

        }

        /// MOBO
        public void MoboAddToBuild(Mobo mobo)
        {
            var build = NewBuild();
            build.Mobo = mobo;
            session.Set(SessionNames.BuildSessionKey, build);
        }

        public void MoboDeleteFromBuild()
        {
            var build = NewBuild();
            build.Mobo = null;
        }

        public Mobo GetMobo()
        {
            NewBuild build;
            if (session.Get<NewBuild>(SessionNames.BuildSessionKey) == null)
            {
                build = new NewBuild();
            }
            else
            {
                build = session.Get<NewBuild>(SessionNames.BuildSessionKey) as NewBuild;
            }

            return build.Mobo;

        }

        /// CASE
        public void CaseAddToBuild(Case casee)
        {
            var build = NewBuild();
            build.Case = casee;
            session.Set(SessionNames.BuildSessionKey, build);
        }

        public void CaseDeleteFromBuild()
        {
            var build = NewBuild();
            build.Case = null;
        }

        public Case GetCase()
        {
            NewBuild build;
            if (session.Get<NewBuild>(SessionNames.BuildSessionKey) == null)
            {
                build = new NewBuild();
            }
            else
            {
                build = session.Get<NewBuild>(SessionNames.BuildSessionKey) as NewBuild;
            }

            return build.Case;

        }

        /// PSU
        public void PsuAddToBuild(Psu psu)
        {
            var build = NewBuild();
            build.Psu = psu;
            session.Set(SessionNames.BuildSessionKey, build);
        }

        public void PsuDeleteFromBuild()
        {
            var build = NewBuild();
            build.Psu = null;
        }

        public Psu GetPsu()
        {
            NewBuild build;
            if (session.Get<NewBuild>(SessionNames.BuildSessionKey) == null)
            {
                build = new NewBuild();
            }
            else
            {
                build = session.Get<NewBuild>(SessionNames.BuildSessionKey) as NewBuild;
            }

            return build.Psu;

        }

        /// RAM
        public void RamAddToBuild(Ram ram)
        {
            var build = NewBuild();
            build.Ram = ram;
            session.Set(SessionNames.BuildSessionKey, build);
        }

        public void RamDeleteFromBuild()
        {
            var build = NewBuild();
            build.Ram = null;
        }

        public Ram GetRam()
        {
            NewBuild build;
            if (session.Get<NewBuild>(SessionNames.BuildSessionKey) == null)
            {
                build = new NewBuild();
            }
            else
            {
                build = session.Get<NewBuild>(SessionNames.BuildSessionKey) as NewBuild;
            }

            return build.Ram;

        }

        /// STORAGE
        public void StorageAddToBuild(Storage storage)
        {
            var build = NewBuild();
            build.Storage = storage;
            session.Set(SessionNames.BuildSessionKey, build);
        }

        public void StorageDeleteFromBuild()
        {
            var build = NewBuild();
            build.Storage = null;
        }

        public Storage GetStorage()
        {
            NewBuild build;
            if (session.Get<NewBuild>(SessionNames.BuildSessionKey) == null)
            {
                build = new NewBuild();
            }
            else
            {
                build = session.Get<NewBuild>(SessionNames.BuildSessionKey) as NewBuild;
            }

            return build.Storage;

        }

        public Build CreateBuild(NewBuild createdBuild, int userId)
        {
            var build = NewBuild();
            var buildToAdd = new Build()
            {
                Name = build.Name,
                UserId = userId,
                Date = DateTime.Now,
                Hidden = false,
                CpuId = createdBuild.Cpu.CpuId,
                MoboId = createdBuild.Mobo.MoboId,
                GpuId = createdBuild.Gpu.GpuId,
                PsuId = createdBuild.Psu.PsuId,
                CaseId = createdBuild.Case.CaseId,
                RamId = createdBuild.Ram.RamId,
                StorageId = createdBuild.Storage.StorageId,
                Image = "basic.png"
            };

            context.Build.Add(buildToAdd);
            context.SaveChanges();

            return buildToAdd;
        }

        public void EmptyBuild()
        {
            session.Set<NewBuild>(SessionNames.BuildSessionKey, null);
        }
    }
}