﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartPicker.Infrastructure
{
    public interface ISessionManager
    {
        T Get<T>(string key);
        void Set<T>(string name, T value);
        void Abandon();
        T TryGet<T>(string key);
    }
}
