# HardwareManagementLib

C# library that provides a simplified interface for the [CfgMgr API](https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/) to manage hardware devices on Windows.


## Usage

1. Download `HardwareManagementLib.dll` from [Releases](https://github.com/EncryptedCurse/HardwareManagementLib/releases) and place it in your project directory
2. In Visual Studio's Solution Explorer, right click `References`
3. Click `Add Reference...`
4. Click `Browse...` and select the DLL

```csharp
using System.Collections.Generic;
using HardwareManagementLib;

namespace ExampleApp {
    public class Example {
        public Example() {
	        ...
	        List<Device> deviceList = CfgMgr.GetAllDevices();
	        ...
        }
    }
}
```

See the [Wiki](https://github.com/EncryptedCurse/HardwareManagementLib/wiki) for further documentation.
