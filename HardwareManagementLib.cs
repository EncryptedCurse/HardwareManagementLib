using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Encoding = System.Text.Encoding;

namespace HardwareManagementLib {
    public enum DeviceStatus {
        Disabled,
        Enabled,
        Unknown
    }

    public class Device {
        public string instancePath;
        public string hardwareId;
        public string friendlyName;
        public string description;
        public DeviceStatus status {
            get {
                Native.ReturnCode returnCode;
                uint devInst = 0;
                returnCode = Native.CM_Locate_DevNode(ref devInst, instancePath);
                if (returnCode == Native.ReturnCode.CR_SUCCESS) {
                    returnCode = Native.CM_Get_DevNode_Status(out uint cmStatus, out uint cmProblemNumber, devInst);
                    if (returnCode == Native.ReturnCode.CR_SUCCESS) {
                        return (cmStatus & (uint) Native.GetDevNodeStatusFlag.DN_STARTED) > 0 ? DeviceStatus.Enabled : DeviceStatus.Disabled;
                    }
                }
                return DeviceStatus.Unknown;
            }
        }

        public Native.ReturnCode Disable() {
            Native.ReturnCode returnCode;
            uint devInst = 0;
            returnCode = Native.CM_Locate_DevNode(ref devInst, instancePath);
            if (returnCode == Native.ReturnCode.CR_SUCCESS) {
                returnCode = Native.CM_Disable_DevNode(devInst);
            }
            return returnCode;
        }

        public Native.ReturnCode Enable() {
            Native.ReturnCode returnCode;
            uint devInst = 0;
            returnCode = Native.CM_Locate_DevNode(ref devInst, instancePath);
            if (returnCode == Native.ReturnCode.CR_SUCCESS) {
                returnCode = Native.CM_Enable_DevNode(devInst);
            }
            return returnCode;
        }

        // https://docs.microsoft.com/en-us/windows-hardware/drivers/install/porting-from-setupapi-to-cfgmgr32#restart-device
        public Native.ReturnCode Restart() {
            Native.ReturnCode returnCode;
            uint devInst = 0;
            returnCode = Native.CM_Locate_DevNode(ref devInst, instancePath);
            if (returnCode == Native.ReturnCode.CR_SUCCESS) {
                returnCode = Native.CM_Query_And_Remove_SubTree(
                    devInst,
                    out Native.PnpVetoType vetoType,
                    IntPtr.Zero,
                    0,
                    (uint) Native.QueryAndRemoveSubTreeFlag.CM_REMOVE_NO_RESTART
                );
                if (returnCode == Native.ReturnCode.CR_SUCCESS) {
                    returnCode = Native.CM_Setup_DevNode(
                        devInst,
                        (uint) Native.SetupDevNodeFlag.CM_SETUP_DEVNODE_READY
                    );
                }
            }
            return returnCode;
        }
    }

    public static class ConfigManager {
        // https://github.com/lostindark/DriverStoreExplorer/blob/master/Rapr/Utils/ConfigManager.cs
        // https://docs.microsoft.com/en-us/windows-hardware/drivers/install/porting-from-setupapi-to-cfgmgr32#get-a-list-of-present-devices-and-retrieve-a-property-for-each-device
        public static List<Device> GetAllDevices() {
            List<Device> deviceList = new List<Device>();
            // get device ID list size
            if (Native.CM_Get_Device_ID_List_Size(out uint devicesBufferLength, null) == Native.ReturnCode.CR_SUCCESS) {
                // create buffer to hold device ID list + null terminator
                byte[] devicesBuffer = new byte[devicesBufferLength * sizeof(char) + 2];
                if (Native.CM_Get_Device_ID_List(null, devicesBuffer, devicesBufferLength) == Native.ReturnCode.CR_SUCCESS) {
                    string[] instancePaths = Encoding.Default.GetString(devicesBuffer).Split(new[] { '\0' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string instancePath in instancePaths) {
                        Device device = GetDeviceByInstancePath(instancePath);
                        if (device != null) {
                            deviceList.Add(device);
                        }
                    }
                }
            }
            return deviceList.Count == 0 ? null : deviceList;
        }

        public static Device GetDeviceByInstancePath(string instancePath) {
            uint devInst = 0;
            if (!string.IsNullOrWhiteSpace(instancePath) && Native.CM_Locate_DevNode(ref devInst, instancePath) == Native.ReturnCode.CR_SUCCESS) {
                string description = GetDevNodeProperty(devInst, Native.GetDevNodePropertyFlag.DEVPKEY_Device_DeviceDesc);
                string friendlyName = GetDevNodeProperty(devInst, Native.GetDevNodePropertyFlag.DEVPKEY_Device_FriendlyName);
                string hardwareId = GetDevNodeProperty(devInst, Native.GetDevNodePropertyFlag.DEVPKEY_Device_HardwareIds);
                return new Device {
                    description = description,
                    friendlyName = friendlyName,
                    instancePath = instancePath,
                    hardwareId = hardwareId
                };
            } else {
                return null;
            }
        }

        public static List<Device> GetDevicesByHardwareId(string hardwareId) {
            return GetAllDevices()?.FindAll(device => device.hardwareId != null && device.hardwareId.Equals(hardwareId));
        }

        private static string GetDevNodeProperty(uint devInst, Native.DevPropKey property) {
            string propertyString = null;
            // initialize result buffer
            IntPtr propertyBuffer = Marshal.AllocHGlobal(1);
            // make initial call to set propertyBufferSize
            Native.CM_Get_DevNode_PropertyW(
                devInst,
                ref property,
                out Native.DevPropType propertyType,
                IntPtr.Zero,
                out uint propertyBufferSize
            );
            // resize result buffer to propertyBufferSize
            propertyBuffer = Marshal.ReAllocHGlobal(propertyBuffer, (IntPtr) propertyBufferSize);
            // make second call to populate result buffer
            if (Native.CM_Get_DevNode_PropertyW(
                devInst,
                ref property,
                out propertyType,
                propertyBuffer,
                out propertyBufferSize
            ) == Native.ReturnCode.CR_SUCCESS) {
                // if second call succeeds, convert the result buffer to a string
                propertyString = Marshal.PtrToStringAuto(propertyBuffer);
            }
            Marshal.FreeHGlobal(propertyBuffer);
            return propertyString;
        }
    }
}
