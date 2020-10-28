using System;
using System.Collections.Generic;
using System.Text;
using TheNextCar.Model;

namespace TheNextCar.Controller
{
    class AccubatteryController
    {
        private Accubattery accubattery;
        private onPowerChanged callbackOnpowerCanged;

        public AccubatteryController(onPowerChanged callbackOnpowerCanged)
        {
            this.callbackOnpowerCanged = callbackOnpowerCanged;
            this.accubattery = new Accubattery(12);
        }

        public void turnOn()
        {
            this.accubattery.trunOn();
            this.callbackOnpowerCanged.onPowerChangedStatus("ON", "power is on");
        }

        public void trunOff()
        {
            this.accubattery.trunOff();
            this.callbackOnpowerCanged.onPowerChangedStatus("OFF", " power is off");
        }

        public bool accubatteryIson()
        {
            return this.accubattery.isOn();
        }
    }


    interface onPowerChanged
    {
        void onPowerChangedStatus(string value, string message);
    }
}
