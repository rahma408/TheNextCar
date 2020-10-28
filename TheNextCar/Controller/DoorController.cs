using System;
using System.Collections.Generic;
using System.Text;
using TheNextCar.Model;

namespace TheNextCar.Controller
{
    class DoorController
    {
        private Door door;
        private onDoorChanged callbackOnDoorChanged;

        public DoorController(onDoorChanged callbackOnDoorChanged)
        {
            this.callbackOnDoorChanged = callbackOnDoorChanged;
            this.door = new Door();
        }
        public void close()
        {
            this.door.close();
            this.callbackOnDoorChanged.onDoorOpenStateChanged("CLOSED", "door closed");
        }
        public void open()
        {
            this.door.open();
            this.callbackOnDoorChanged.onDoorOpenStateChanged("OPENED", "door opened");
        }
        public void activatelock()
        {
            this.door.activatelock();
            this.callbackOnDoorChanged.onDoorOpenStateChanged("LOCKED", "door locked");
        }
        public void unlock()
        {
            this.door.unlock();
            this.callbackOnDoorChanged.onLockDoorStateChanged("UNLOCKED", "door unlocked");
        }
        public bool isClose()
        {
            return this.door.isclosed();
        }
        public bool isLocked()
        {
            return this.door.islocked();
        }

    }

    interface onDoorChanged
    {
        void onLockDoorStateChanged(string value, string message);
        void onDoorOpenStateChanged(string value, string message);
    }
   
}
