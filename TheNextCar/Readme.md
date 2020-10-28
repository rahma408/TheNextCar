#THENEXTCAR
-
aplikasi ini mencangkup fungsi penggunaan maps pada mobil.

##SCOPE & FUNCTIONALITIES
-
- useer dapat memerintahkan mobil untuk membuka pintu
- user dapat memerintah kan untuk menutup pintu
- user dapat menyentuh tombol STARTED,CLOSE,LOCK,dan OFF

##  KEGUNAAN DoorController.cs

-digunakan untuk menjalankan program yag sudah ter dapat pada door.cs

'''c#

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

''' 

## kegunaan model door.cs

-kegunaan ini untuk memerintakan private bool locked dan closed.

'''c#  
      public void close()
        {
            this.closed = true;
        }

        public void open()
        {
            this.closed = false;
        }

        public void activatelock()
        {
            this.locked = true;
        }
'''

##kegunaan interface ondoochanged

berfungsi sebagai penghubung yang memudahkan penggunaan agar dapat menjalankan suatu program

''' c#

interface onDoorChanged

    {
        void onLockDoorStateChanged(string value, string message);
        void onDoorOpenStateChanged(string value, string message);
    }
'''