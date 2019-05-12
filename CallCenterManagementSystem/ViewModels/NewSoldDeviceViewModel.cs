using CallCenterManagementSystem.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CallCenterManagementSystem.ViewModels
{
    public class NewSoldDeviceViewModel
    {
        public SoldDevice SoldDevice { get; set; }
        public IEnumerable<DeviceSupplier> DeviceSuppliers { get; set; }

    }
}