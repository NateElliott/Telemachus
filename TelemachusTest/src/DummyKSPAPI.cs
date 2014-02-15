﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telemachus;

namespace TelemachusTest
{
    public class DummyKSPAPI : IKSPAPI
    {
        public DummyKSPAPI(FormatterProvider formatters, VesselChangeDetector vesselChangeDetector,
            Servers.AsynchronousServer.ServerConfiguration serverConfiguration)
        {
            APIHandlers.Add(new DummyHandler(formatters));
        }

        public override Vessel getVessel()
        {
            return null;
        }
    }

    public class DummyHandler : DataLinkHandler
    {
        Random r = new Random(DateTime.Now.Second);

        #region Initialisation

        public DummyHandler(FormatterProvider formatters)
            : base(formatters)
        {
            registerAPI(new PlotableAPIEntry(
                dataSources => { return r.NextDouble(); },
                "d.unitless", "Unitless", formatters.Default, APIEntry.UnitType.UNITLESS));
            registerAPI(new PlotableAPIEntry(
                dataSources => { return r.NextDouble(); },
                "d.string", "String", formatters.String, APIEntry.UnitType.STRING));
            registerAPI(new PlotableAPIEntry(
                dataSources => { return r.NextDouble(); },
                "d.run", "String", formatters.Default, APIEntry.UnitType.UNITLESS));
        }

        #endregion
    }
}
