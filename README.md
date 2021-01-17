# sm64pcport-phonecontroller
A phone controller for Super Mario 64 PC Port, currently only supporting Windows and Android.

# Prerequisites
You need to install ViGEmBus on your computer for this to work (https://github.com/ViGEm/ViGEmBus/releases/)
This is for emulating a controller on your computer.

# Phone installation
Copy the .apk file from build_android to your phone and run it.

# Computer installation
Copy the build_pc folder into wherever you want. You can even rename the folder.
Inside the folder, you can run the .exe to start the app.

# Connecting
Make sure you have the prerequisites listed above!
This app will only work if you have a network connection.

Run the apps both on your computer and on your phone.
Insert the IP address listed in your computer to your phone.
Make sure that the input display matches the buttons/joystick on your phone.

If you want less response time, you can click the button on the top right corner of your phone to change connection from TCP to UDP.
Note that the app won't seem to do anything unless you open a program that uses a controller (or sm64 pc port)

# Building
If you want to build the app yourself instead of using the pre-built ones (for whatever reason), you must install Unity 2019 (or higher).
Then, copy the repo into whatever folder you want.
After that, you can open that folder with Unity/Unity Hub.
After loading it, to build it you can go to File > Build Settings > (choose your operating system) > Build
You can even set the operating system to be other than Windows or Android if you checked the box for that operating system during installation of Unity!
