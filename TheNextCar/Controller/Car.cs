using System;
using System.Collections.Generic;
using System.Text;

namespace TheNextCar.Controller
{
    class Car
    {
        private DoorController doorController;
        private AccubatteryController accubatteryController;
        private onCarEngineStateChanged callback;

        public Car(DoorController doorController, AccubatteryController accubatteryController, onCarEngineStateChanged callback)
        {
            this.doorController = doorController;
            this.accubatteryController = accubatteryController;
            this.callback = callback;
        }

        private bool doorIsClosed()
        {
            return this.doorController.isClose();
        }
        private bool doorIsLocked()
        {
            return this.doorController.isLocked();
        }
        private bool powerIsReady()
        {
            return this.accubatteryController.accubatteryIson();
        }

        public void startEngine()
        {
            if (!doorIsClosed())
            {
                this.callback.onCarEngineStateChanged("STOPED", "close the door");
                return;
            }
            if (!doorIsLocked())
            {
                this.callback.onCarEngineStateChanged("STOPED", "Lock the door");
                return;
            }
            if (!powerIsReady())
            {
                this.callback.onCarEngineStateChanged("STOPED", "no power available");
                return;
            }

            this.callback.onCarEngineStateChanged("STARTED", "Engine Started");
        }
        public void toggleTheLockDoorButton()
        {
            if (!doorIsLocked())
            {
                this.doorController.activatelock();
            }
            else
            {
                this.doorController.unlock();
            }
        }
        public void toggleTheOpenDoorButton()
        {
            
            if (!doorIsClosed())
            {
                this.doorController.close();
            }
            else
            {
                this.doorController.open();
            }
        }
        public void togglePowerButton()
        {
            if (!powerIsReady())
            {
                this.accubatteryController.turnOn();
            }
            else
            {
                this.accubatteryController.trunOff();
            }
        }
    }

    interface onCarEngineStateChanged
    {
        void onCarEngineStateChanged(string value, string message);
    }
}
