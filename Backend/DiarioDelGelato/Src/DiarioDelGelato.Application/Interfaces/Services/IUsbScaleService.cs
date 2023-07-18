using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiarioDelGelato.Application.Interfaces.Services
{
    // specify usb scale services to be used by application
    // usb scale service implementation will be done on infrastructure.usbcommunication
    public interface IUsbScaleService
    {
        public bool SwitchOn();
        public bool SwitchOff();
        public int Weight();
        public bool Tare();
        public bool Zero();
    }
}
