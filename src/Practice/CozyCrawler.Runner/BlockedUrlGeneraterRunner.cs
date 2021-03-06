﻿using CozyCrawler.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CozyCrawler.Runner
{
    public class BlockedUrlGeneraterRunner : IUrlGeneraterRunner
    {
        IUrlGenerater gen_ = null;
        IUrlIn to_ = null;

        public void OnNewUrl(string url)
        {
            to_?.OnNewUrl(url);
        }

        public void From(IUrlGenerater i)
        {
            gen_ = i;
        }

        public void To(IUrlIn to)
        {
            to_ = to;
        }

        public void Start()
        {
            gen_?.To(this);
            gen_?.Start();
        }

        public void Stop()
        {
            gen_?.Stop();
        }
    }
}
