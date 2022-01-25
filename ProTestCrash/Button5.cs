﻿using ArcGIS.Core.CIM;
using ArcGIS.Core.Data;
using ArcGIS.Core.Geometry;
using ArcGIS.Desktop.Catalog;
using ArcGIS.Desktop.Core;
using ArcGIS.Desktop.Editing;
using ArcGIS.Desktop.Extensions;
using ArcGIS.Desktop.Framework;
using ArcGIS.Desktop.Framework.Contracts;
using ArcGIS.Desktop.Framework.Dialogs;
using ArcGIS.Desktop.Framework.Threading.Tasks;
using ArcGIS.Desktop.Layouts;
using ArcGIS.Desktop.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using ArcGIS.Desktop.Internal.Catalog.PropertyPages.NetworkDataset;
// ReSharper disable IntDivisionByZero

namespace ProTestCrash
{
    internal class Button5 : Button
    {
        protected override void OnClick()
        {

            try
            {
                _ = Shared.DoCrash("demo5");

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

      

    }
}
