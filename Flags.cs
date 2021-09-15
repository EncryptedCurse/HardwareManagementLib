using Flags = System.FlagsAttribute;

namespace HardwareManagementLib {
    public static partial class Native {
        // https://github.com/tpn/winsdk-10/blob/master/Include/10.0.16299.0/um/cfgmgr32.h#L4509
        [Flags]
        public enum ReturnCode : uint {
            CR_SUCCESS = 0x0,
            CR_DEFAULT = 0x1,
            CR_OUT_OF_MEMORY = 0x2,
            CR_INVALID_POINTER = 0x3,
            CR_INVALID_FLAG = 0x4,
            CR_INVALID_DEVNODE = 0x5,
            CR_INVALID_DEVINST = CR_INVALID_DEVNODE,
            CR_INVALID_RES_DES = 0x6,
            CR_INVALID_LOG_CONF = 0x7,
            CR_INVALID_ARBITRATOR = 0x8,
            CR_INVALID_NODELIST = 0x9,
            CR_DEVNODE_HAS_REQS = 0xA,
            CR_DEVINST_HAS_REQS = CR_DEVNODE_HAS_REQS,
            CR_INVALID_RESOURCEID = 0xB,
            CR_DLVXD_NOT_FOUND = 0xC,                           // Windows 95 only
            CR_NO_SUCH_DEVNODE = 0xD,
            CR_NO_SUCH_DEVINST = CR_NO_SUCH_DEVNODE,
            CR_NO_MORE_LOG_CONF = 0xE,
            CR_NO_MORE_RES_DES = 0xF,
            CR_ALREADY_SUCH_DEVNODE = 0x10,
            CR_ALREADY_SUCH_DEVINST = CR_ALREADY_SUCH_DEVNODE,
            CR_INVALID_RANGE_LIST = 0x11,
            CR_INVALID_RANGE = 0x12,
            CR_FAILURE = 0x13,
            CR_NO_SUCH_LOGICAL_DEV = 0x14,
            CR_CREATE_BLOCKED = 0x15,
            CR_NOT_SYSTEM_VM = 0x16,                            // Windows 95 only
            CR_REMOVE_VETOED = 0x17,
            CR_APM_VETOED = 0x18,
            CR_INVALID_LOAD_TYPE = 0x19,
            CR_BUFFER_SMALL = 0x1A,
            CR_NO_ARBITRATOR = 0x1B,
            CR_NO_REGISTRY_HANDLE = 0x1C,
            CR_REGISTRY_ERROR = 0x1D,
            CR_INVALID_DEVICE_ID = 0x1E,
            CR_INVALID_DATA = 0x1F,
            CR_INVALID_API = 0x20,
            CR_DEVLOADER_NOT_READY = 0x21,
            CR_NEED_RESTART = 0x22,
            CR_NO_MORE_HW_PROFILES = 0x23,
            CR_DEVICE_NOT_THERE = 0x24,
            CR_NO_SUCH_VALUE = 0x25,
            CR_WRONG_TYPE = 0x26,
            CR_INVALID_PRIORITY = 0x27,
            CR_NOT_DISABLEABLE = 0x28,
            CR_FREE_RESOURCES = 0x29,
            CR_QUERY_VETOED = 0x2A,
            CR_CANT_SHARE_IRQ = 0x2B,
            CR_NO_DEPENDENT = 0x2C,
            CR_SAME_RESOURCES = 0x2D,
            CR_NO_SUCH_REGISTRY_KEY = 0x2E,
            CR_INVALID_MACHINENAME = 0x2F,                      // NT only
            CR_REMOTE_COMM_FAILURE = 0x30,                      // NT only
            CR_MACHINE_UNAVAILABLE = 0x31,                      // NT only
            CR_NO_CM_SERVICES = 0x32,                           // NT only
            CR_ACCESS_DENIED = 0x33,                            // NT only
            CR_CALL_NOT_IMPLEMENTED = 0x34,
            CR_INVALID_PROPERTY = 0x35,
            CR_DEVICE_INTERFACE_ACTIVE = 0x36,
            CR_NO_SUCH_DEVICE_INTERFACE = 0x37,
            CR_INVALID_REFERENCE_STRING = 0x38,
            CR_INVALID_CONFLICT_LIST = 0x39,
            CR_INVALID_INDEX = 0x3A,
            CR_INVALID_STRUCTURE_SIZE = 0x3B,
            NUM_CR_RESULTS = 0x3C
        }

        // https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_get_device_id_listw#parameters
        // https://github.com/tpn/winsdk-10/blob/master/Include/10.0.16299.0/um/cfgmgr32.h#L964
        [Flags]
        internal enum GetIdListFilter : uint {
            CM_GETIDLIST_FILTER_NONE = 0x0,
            CM_GETIDLIST_FILTER_ENUMERATOR = 0x1,
            CM_GETIDLIST_FILTER_SERVICE = 0x2,
            CM_GETIDLIST_FILTER_EJECTRELATIONS = 0x4,
            CM_GETIDLIST_FILTER_REMOVALRELATIONS = 0x8,
            CM_GETIDLIST_FILTER_POWERRELATIONS = 0x10,
            CM_GETIDLIST_FILTER_BUSRELATIONS = 0x20,
            CM_GETIDLIST_FILTER_TRANSPORTRELATIONS = 0x80,
            CM_GETIDLIST_FILTER_PRESENT = 0x100,
            CM_GETIDLIST_FILTER_CLASS = 0x200,
            CM_GETIDLIST_FILTER_DONOTGENERATE = 0x10000040
        }

        // https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_locate_devnodew#parameters
        // https://github.com/tpn/winsdk-10/blob/master/Include/10.0.16299.0/um/cfgmgr32.h#L1101
        [Flags]
        internal enum LocateDevNodeFilter : uint {
            CM_LOCATE_DEVNODE_NORMAL = 0x0,             // device is currently configured in the device tree
            CM_LOCATE_DEVNODE_PHANTOM = 0x1,            // present, configured device or nonpresent, unconfigured device
            CM_LOCATE_DEVNODE_CANCELREMOVE = 0x2,       // cancel removal of device if it's in the process of being removed
            CM_LOCATE_DEVNODE_NOVALIDATION = 0x4        // not used
        }

        // https://github.com/tpn/winsdk-10/blob/master/Include/10.0.16299.0/um/cfgmgr32.h#L1187
        internal enum SetupDevNodeFlag : uint {
            CM_SETUP_DEVNODE_READY = 0x0,               // restart device that's running because of a device configuration issue
            CM_SETUP_DEVNODE_RESET = 0x4                // reset device that has the 'no restart' status flag set (by CM_Query_And_Remove_SubTree + CM_REMOVE_NO_RESTART)
        }

        // https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_query_and_remove_subtreew#remarks
        // https://github.com/tpn/winsdk-10/blob/master/Include/10.0.16299.0/um/cfgmgr32.h#L1124
        [Flags]
        internal enum QueryAndRemoveSubTreeFlag : uint {
            CM_REMOVE_UI_OK = 0x0,                      // allow a user dialog box that indicates veto reason to be displayed
            CM_REMOVE_UI_NOT_OK = 0x1,                  // suppress user dialog box that indicates veto reason
            CM_REMOVE_NO_RESTART = 0x2                  // configure device status such that the device cannot be restarted until after the device status is reset
        }

        // https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_disable_devnode#parameters
        // https://github.com/tpn/winsdk-10/blob/master/Include/10.0.16299.0/um/cfgmgr32.h#L954
        [Flags]
        internal enum DisableDevNodeFlag : uint {
            CM_DISABLE_POLITE = 0x0,                    // ask the driver
            CM_DISABLE_ABSOLUTE = 0x1,                  // don't ask the driver
            CM_DISABLE_HARDWARE = 0x2,                  // don't ask the driver and won't be restarteable
            CM_DISABLE_UI_NOT_OK = 0x4,                 // don't popup any veto API
            CM_DISABLE_PERSIST = 0x8                    // persist through restart by setting CONFIGFLAG_DISABLED in the registry
        }

        // https://github.com/tpn/winsdk-10/blob/master/Include/10.0.16299.0/shared/cfg.h#L170
        [Flags]
        internal enum GetDevNodeStatusFlag : uint {
            DN_ROOT_ENUMERATED = 0x1,                   // was enumerated by ROOT
            DN_DRIVER_LOADED = 0x2,                     // has Register_Device_Driver
            DN_ENUM_LOADED = 0x4,                       // has Register_Enumerator
            DN_STARTED = 0x8,                           // is currently configured
            DN_MANUAL = 0x10,                           // manually installed
            DN_NEED_TO_ENUM = 0x20,                     // may need reenumeration
            DN_NOT_FIRST_TIME = 0x40,                   // has received a config
            DN_HARDWARE_ENUM = 0x80,                    // enum generates hardware ID
            DN_LIAR = 0x100,                            // lied about can reconfig once
            DN_HAS_MARK = 0x200,                        // not CM_Create_DevInst lately
            DN_HAS_PROBLEM = 0x400,                     // need device installer
            DN_FILTERED = 0x800,                        // is filtered
            DN_MOVED = 0x1000,                          // has been moved
            DN_DISABLEABLE = 0x2000,                    // can be disabled
            DN_REMOVABLE = 0x4000,                      // can be removed
            DN_PRIVATE_PROBLEM = 0x8000,                // has a private problem
            DN_MF_PARENT = 0x10000,                     // multi function parent
            DN_MF_CHILD = 0x20000,                      // multi function child
            DN_WILL_BE_REMOVED = 0x40000,               // DevInst is being removed
            // Windows 4 OPK2
            DN_NOT_FIRST_TIMEE = 0x80000,               // S: has received a config enumerate
            DN_STOP_FREE_RES = 0x100000,                // S: when child is stopped, free resources
            DN_REBAL_CANDIDATE = 0x200000,              // S: don't skip during rebalance
            DN_BAD_PARTIAL = 0x400000,                  // S: this devnode's log_confs do not have same resources
            DN_NT_ENUMERATOR = 0x800000,                // S: this devnode's is an NT enumerator
            DN_NT_DRIVER = 0x1000000,                   // S: this devnode's is an NT driver
            // Windows 4.1
            DN_NEEDS_LOCKING = 0x2000000,               // S: devnode need lock resume processing
            DN_ARM_WAKEUP = 0x4000000,                  // S: devnode can be the wakeup device
            DN_APM_ENUMERATOR = 0x8000000,              // S: APM aware enumerator
            DN_APM_DRIVER = 0x10000000,                 // S: APM aware driver
            DN_SILENT_INSTALL = 0x20000000,             // S: silent install
            DN_NO_SHOW_IN_DM = 0x40000000,              // S: no show in device manager
            DN_BOOT_LOG_PROB = 0x80000000,              // S: had a problem during preassignment of boot log conf
            // Windows NT
            DN_NEED_RESTART = DN_LIAR,                  // system needs to be restarted for this Devnode to work properly
            DN_DRIVER_BLOCKED = DN_NOT_FIRST_TIME,      // one or more drivers are blocked from loading for this devnode
            DN_LEGACY_DRIVER = DN_MOVED,                // this device is using a legacy driver
            DN_CHILD_WITH_INVALID_ID = DN_HAS_MARK,     // one or more children have invalid ID(s)
            DN_DEVICE_DISCONNECTED = DN_NEEDS_LOCKING,  // the function driver for a device reported that the device is not connected; typically this means a wireless device is out of range
            DN_QUERY_REMOVE_PENDING = DN_MF_PARENT,     // device is part of a set of related devices collectively pending query-removal
            DN_QUERY_REMOVE_ACTIVE = DN_MF_CHILD        // device is actively engaged in a query-remove IRP
        }

        // https://github.com/lostindark/DriverStoreExplorer/blob/master/Rapr/Utils/DeviceHelper.cs#L76
        internal static class GetDevNodePropertyFlag {
            internal static readonly DevPropKey DEVPKEY_Device_DeviceDesc = new DevPropKey(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0, 2);                  // DEVPROP_TYPE_STRING
            internal static readonly DevPropKey DEVPKEY_Device_HardwareIds = new DevPropKey(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0, 3);                 // DEVPROP_TYPE_STRING_LIST
            internal static readonly DevPropKey DEVPKEY_Device_CompatibleIds = new DevPropKey(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0, 4);               // DEVPROP_TYPE_STRING_LIST
            internal static readonly DevPropKey DEVPKEY_Device_Service = new DevPropKey(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0, 6);                     // DEVPROP_TYPE_STRING
            internal static readonly DevPropKey DEVPKEY_Device_Class = new DevPropKey(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0, 9);                       // DEVPROP_TYPE_STRING
            internal static readonly DevPropKey DEVPKEY_Device_ClassGuid = new DevPropKey(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0, 10);                  // DEVPROP_TYPE_GUID
            internal static readonly DevPropKey DEVPKEY_Device_Driver = new DevPropKey(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0, 11);                     // DEVPROP_TYPE_STRING
            internal static readonly DevPropKey DEVPKEY_Device_ConfigFlags = new DevPropKey(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0, 12);                // DEVPROP_TYPE_UINT32
            internal static readonly DevPropKey DEVPKEY_Device_Manufacturer = new DevPropKey(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0, 13);               // DEVPROP_TYPE_STRING
            internal static readonly DevPropKey DEVPKEY_Device_FriendlyName = new DevPropKey(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0, 14);               // DEVPROP_TYPE_STRING
            internal static readonly DevPropKey DEVPKEY_Device_LocationInfo = new DevPropKey(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0, 15);               // DEVPROP_TYPE_STRING
            internal static readonly DevPropKey DEVPKEY_Device_PDOName = new DevPropKey(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0, 16);                    // DEVPROP_TYPE_STRING
            internal static readonly DevPropKey DEVPKEY_Device_Capabilities = new DevPropKey(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0, 17);               // DEVPROP_TYPE_UNINT32
            internal static readonly DevPropKey DEVPKEY_Device_UINumber = new DevPropKey(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0, 18);                   // DEVPROP_TYPE_STRING
            internal static readonly DevPropKey DEVPKEY_Device_UpperFilters = new DevPropKey(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0, 19);               // DEVPROP_TYPE_STRING_LIST
            internal static readonly DevPropKey DEVPKEY_Device_LowerFilters = new DevPropKey(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0, 20);               // DEVPROP_TYPE_STRING_LIST
            internal static readonly DevPropKey DEVPKEY_Device_BusTypeGuid = new DevPropKey(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0, 21);                // DEVPROP_TYPE_GUID
            internal static readonly DevPropKey DEVPKEY_Device_LegacyBusType = new DevPropKey(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0, 22);              // DEVPROP_TYPE_UINT32
            internal static readonly DevPropKey DEVPKEY_Device_BusNumber = new DevPropKey(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0, 23);                  // DEVPROP_TYPE_UINT32
            internal static readonly DevPropKey DEVPKEY_Device_EnumeratorName = new DevPropKey(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0, 24);             // DEVPROP_TYPE_STRING
            internal static readonly DevPropKey DEVPKEY_Device_Security = new DevPropKey(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0, 25);                   // DEVPROP_TYPE_SECURITY_DESCRIPTOR
            internal static readonly DevPropKey DEVPKEY_Device_SecuritySDS = new DevPropKey(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0, 26);                // DEVPROP_TYPE_SECURITY_DESCRIPTOR_STRING
            internal static readonly DevPropKey DEVPKEY_Device_DevType = new DevPropKey(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0, 27);                    // DEVPROP_TYPE_UINT32
            internal static readonly DevPropKey DEVPKEY_Device_Exclusive = new DevPropKey(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0, 28);                  // DEVPROP_TYPE_BOOLEAN
            internal static readonly DevPropKey DEVPKEY_Device_Characteristics = new DevPropKey(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0, 29);            // DEVPROP_TYPE_UINT32
            internal static readonly DevPropKey DEVPKEY_Device_Address = new DevPropKey(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0, 30);                    // DEVPROP_TYPE_UINT32
            internal static readonly DevPropKey DEVPKEY_Device_UINumberDescFormat = new DevPropKey(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0, 31);         // DEVPROP_TYPE_STRING
            internal static readonly DevPropKey DEVPKEY_Device_PowerData = new DevPropKey(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0, 32);                  // DEVPROP_TYPE_BINARY
            internal static readonly DevPropKey DEVPKEY_Device_RemovalPolicy = new DevPropKey(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0, 33);              // DEVPROP_TYPE_UINT32
            internal static readonly DevPropKey DEVPKEY_Device_RemovalPolicyDefault = new DevPropKey(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0, 34);       // DEVPROP_TYPE_UINT32
            internal static readonly DevPropKey DEVPKEY_Device_RemovalPolicyOverride = new DevPropKey(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0, 35);      // DEVPROP_TYPE_UINT32
            internal static readonly DevPropKey DEVPKEY_Device_InstallState = new DevPropKey(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0, 36);               // DEVPROP_TYPE_UINT32
            internal static readonly DevPropKey DEVPKEY_Device_LocationPaths = new DevPropKey(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0, 37);              // DEVPROP_TYPE_STRING_LIST
            internal static readonly DevPropKey DEVPKEY_Device_BaseContainerId = new DevPropKey(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0, 38);            // DEVPROP_TYPE_GUID
            internal static readonly DevPropKey DEVPKEY_Device_DebuggerSafe = new DevPropKey(0xa45c254e, 0xdf1c, 0x4efd, 0x80, 0x20, 0x67, 0xd1, 0x46, 0xa8, 0x50, 0xe0, 39);               // DEVPROP_TYPE_UINT32
            internal static readonly DevPropKey DEVPKEY_Device_DevNodeStatus = new DevPropKey(0x4340a6c5, 0x93fa, 0x4706, 0x97, 0x2c, 0x7b, 0x64, 0x80, 0x08, 0xa5, 0xa7, 2);               // DEVPROP_TYPE_UINT32
            internal static readonly DevPropKey DEVPKEY_Device_ProblemCode = new DevPropKey(0x4340a6c5, 0x93fa, 0x4706, 0x97, 0x2c, 0x7b, 0x64, 0x80, 0x08, 0xa5, 0xa7, 3);                 // DEVPROP_TYPE_UINT32
            internal static readonly DevPropKey DEVPKEY_Device_EjectionRelations = new DevPropKey(0x4340a6c5, 0x93fa, 0x4706, 0x97, 0x2c, 0x7b, 0x64, 0x80, 0x08, 0xa5, 0xa7, 4);           // DEVPROP_TYPE_STRING_LIST
            internal static readonly DevPropKey DEVPKEY_Device_RemovalRelations = new DevPropKey(0x4340a6c5, 0x93fa, 0x4706, 0x97, 0x2c, 0x7b, 0x64, 0x80, 0x08, 0xa5, 0xa7, 5);            // DEVPROP_TYPE_STRING_LIST
            internal static readonly DevPropKey DEVPKEY_Device_PowerRelations = new DevPropKey(0x4340a6c5, 0x93fa, 0x4706, 0x97, 0x2c, 0x7b, 0x64, 0x80, 0x08, 0xa5, 0xa7, 6);              // DEVPROP_TYPE_STRING_LIST
            internal static readonly DevPropKey DEVPKEY_Device_BusRelations = new DevPropKey(0x4340a6c5, 0x93fa, 0x4706, 0x97, 0x2c, 0x7b, 0x64, 0x80, 0x08, 0xa5, 0xa7, 7);                // DEVPROP_TYPE_STRING_LIST
            internal static readonly DevPropKey DEVPKEY_Device_Parent = new DevPropKey(0x4340a6c5, 0x93fa, 0x4706, 0x97, 0x2c, 0x7b, 0x64, 0x80, 0x08, 0xa5, 0xa7, 8);                      // DEVPROP_TYPE_STRING
            internal static readonly DevPropKey DEVPKEY_Device_Children = new DevPropKey(0x4340a6c5, 0x93fa, 0x4706, 0x97, 0x2c, 0x7b, 0x64, 0x80, 0x08, 0xa5, 0xa7, 9);                    // DEVPROP_TYPE_STRING_LIST
            internal static readonly DevPropKey DEVPKEY_Device_Siblings = new DevPropKey(0x4340a6c5, 0x93fa, 0x4706, 0x97, 0x2c, 0x7b, 0x64, 0x80, 0x08, 0xa5, 0xa7, 10);                   // DEVPROP_TYPE_STRING_LIST
            internal static readonly DevPropKey DEVPKEY_Device_TransportRelations = new DevPropKey(0x4340a6c5, 0x93fa, 0x4706, 0x97, 0x2c, 0x7b, 0x64, 0x80, 0x08, 0xa5, 0xa7, 11);         // DEVPROP_TYPE_STRING_LIST
            internal static readonly DevPropKey DEVPKEY_Device_Reported = new DevPropKey(0x80497100, 0x8c73, 0x48b9, 0xaa, 0xd9, 0xce, 0x38, 0x7e, 0x19, 0xc5, 0x6e, 2);                    // DEVPROP_TYPE_BOOLEAN
            internal static readonly DevPropKey DEVPKEY_Device_Legacy = new DevPropKey(0x80497100, 0x8c73, 0x48b9, 0xaa, 0xd9, 0xce, 0x38, 0x7e, 0x19, 0xc5, 0x6e, 3);                      // DEVPROP_TYPE_BOOLEAN
            internal static readonly DevPropKey DEVPKEY_Device_ContainerId = new DevPropKey(0x8c7ed206, 0x3f8a, 0x4827, 0xb3, 0xab, 0xae, 0x9e, 0x1f, 0xae, 0xfc, 0x6c, 2);                 // DEVPROP_TYPE_GUID
            internal static readonly DevPropKey DEVPKEY_Device_InLocalMachineContainer = new DevPropKey(0x8c7ed206, 0x3f8a, 0x4827, 0xb3, 0xab, 0xae, 0x9e, 0x1f, 0xae, 0xfc, 0x6c, 4);     // DEVPROP_TYPE_BOOLEAN
            internal static readonly DevPropKey DEVPKEY_Device_ModelId = new DevPropKey(0x80d81ea6, 0x7473, 0x4b0c, 0x82, 0x16, 0xef, 0xc1, 0x1a, 0x2c, 0x4c, 0x8b, 2);                     // DEVPROP_TYPE_GUID
            internal static readonly DevPropKey DEVPKEY_Device_FriendlyNameAttributes = new DevPropKey(0x80d81ea6, 0x7473, 0x4b0c, 0x82, 0x16, 0xef, 0xc1, 0x1a, 0x2c, 0x4c, 0x8b, 3);      // DEVPROP_TYPE_UINT32
            internal static readonly DevPropKey DEVPKEY_Device_ManufacturerAttributes = new DevPropKey(0x80d81ea6, 0x7473, 0x4b0c, 0x82, 0x16, 0xef, 0xc1, 0x1a, 0x2c, 0x4c, 0x8b, 4);      // DEVPROP_TYPE_UINT32
            internal static readonly DevPropKey DEVPKEY_Device_PresenceNotForDevice = new DevPropKey(0x80d81ea6, 0x7473, 0x4b0c, 0x82, 0x16, 0xef, 0xc1, 0x1a, 0x2c, 0x4c, 0x8b, 5);        // DEVPROP_TYPE_BOOLEAN
            internal static readonly DevPropKey DEVPKEY_Device_SignalStrength = new DevPropKey(0x80d81ea6, 0x7473, 0x4b0c, 0x82, 0x16, 0xef, 0xc1, 0x1a, 0x2c, 0x4c, 0x8b, 6);              // DEVPROP_TYPE_INT32
            internal static readonly DevPropKey DEVPKEY_Device_IsAssociateableByUserAction = new DevPropKey(0x80d81ea6, 0x7473, 0x4b0c, 0x82, 0x16, 0xef, 0xc1, 0x1a, 0x2c, 0x4c, 0x8b, 7); // DEVPROP_TYPE_BOOLEAN
            internal static readonly DevPropKey DEVPKEY_Numa_Proximity_Domain = new DevPropKey(0x540b947e, 0x8b40, 0x45bc, 0xa8, 0xa2, 0x6a, 0x0b, 0x89, 0x4c, 0xbd, 0xa2, 1);              // DEVPROP_TYPE_UINT32
            internal static readonly DevPropKey DEVPKEY_Device_DHP_Rebalance_Policy = new DevPropKey(0x540b947e, 0x8b40, 0x45bc, 0xa8, 0xa2, 0x6a, 0x0b, 0x89, 0x4c, 0xbd, 0xa2, 2);        // DEVPROP_TYPE_UINT32
            internal static readonly DevPropKey DEVPKEY_Device_Numa_Node = new DevPropKey(0x540b947e, 0x8b40, 0x45bc, 0xa8, 0xa2, 0x6a, 0x0b, 0x89, 0x4c, 0xbd, 0xa2, 3);                   // DEVPROP_TYPE_UINT32
            internal static readonly DevPropKey DEVPKEY_Device_BusReportedDeviceDesc = new DevPropKey(0x540b947e, 0x8b40, 0x45bc, 0xa8, 0xa2, 0x6a, 0x0b, 0x89, 0x4c, 0xbd, 0xa2, 4);       // DEVPROP_TYPE_STRING
            internal static readonly DevPropKey DEVPKEY_Device_IsPresent = new DevPropKey(0x540b947e, 0x8b40, 0x45bc, 0xa8, 0xa2, 0x6a, 0x0b, 0x89, 0x4c, 0xbd, 0xa2, 5);                   // DEVPROP_TYPE_BOOL
            internal static readonly DevPropKey DEVPKEY_Device_HasProblem = new DevPropKey(0x540b947e, 0x8b40, 0x45bc, 0xa8, 0xa2, 0x6a, 0x0b, 0x89, 0x4c, 0xbd, 0xa2, 6);                  // DEVPROP_TYPE_BOOL
            internal static readonly DevPropKey DEVPKEY_Device_ConfigurationId = new DevPropKey(0x540b947e, 0x8b40, 0x45bc, 0xa8, 0xa2, 0x6a, 0x0b, 0x89, 0x4c, 0xbd, 0xa2, 7);             // DEVPROP_TYPE_STRING
            internal static readonly DevPropKey DEVPKEY_Device_ReportedDeviceIdsHash = new DevPropKey(0x540b947e, 0x8b40, 0x45bc, 0xa8, 0xa2, 0x6a, 0x0b, 0x89, 0x4c, 0xbd, 0xa2, 8);       // DEVPROP_TYPE_UINT32
            internal static readonly DevPropKey DEVPKEY_Device_PhysicalDeviceLocation = new DevPropKey(0x540b947e, 0x8b40, 0x45bc, 0xa8, 0xa2, 0x6a, 0x0b, 0x89, 0x4c, 0xbd, 0xa2, 9);      // DEVPROP_TYPE_BINARY
            internal static readonly DevPropKey DEVPKEY_Device_BiosDeviceName = new DevPropKey(0x540b947e, 0x8b40, 0x45bc, 0xa8, 0xa2, 0x6a, 0x0b, 0x89, 0x4c, 0xbd, 0xa2, 10);             // DEVPROP_TYPE_STRING
            internal static readonly DevPropKey DEVPKEY_Device_DriverProblemDesc = new DevPropKey(0x540b947e, 0x8b40, 0x45bc, 0xa8, 0xa2, 0x6a, 0x0b, 0x89, 0x4c, 0xbd, 0xa2, 11);          // DEVPROP_TYPE_STRING
            internal static readonly DevPropKey DEVPKEY_Device_SessionId = new DevPropKey(0x83da6326, 0x97a6, 0x4088, 0x94, 0x53, 0xa1, 0x92, 0x3f, 0x57, 0x3b, 0x29, 6);                   // DEVPROP_TYPE_UINT32
            internal static readonly DevPropKey DEVPKEY_Device_InstallDate = new DevPropKey(0x83da6326, 0x97a6, 0x4088, 0x94, 0x53, 0xa1, 0x92, 0x3f, 0x57, 0x3b, 0x29, 100);               // DEVPROP_TYPE_FILETIME
            internal static readonly DevPropKey DEVPKEY_Device_FirstInstallDate = new DevPropKey(0x83da6326, 0x97a6, 0x4088, 0x94, 0x53, 0xa1, 0x92, 0x3f, 0x57, 0x3b, 0x29, 101);          // DEVPROP_TYPE_FILETIME
            internal static readonly DevPropKey DEVPKEY_Device_LastArrivalDate = new DevPropKey(0x83da6326, 0x97a6, 0x4088, 0x94, 0x53, 0xa1, 0x92, 0x3f, 0x57, 0x3b, 0x29, 102);           // DEVPROP_TYPE_FILETIME
            internal static readonly DevPropKey DEVPKEY_Device_LastRemovalDate = new DevPropKey(0x83da6326, 0x97a6, 0x4088, 0x94, 0x53, 0xa1, 0x92, 0x3f, 0x57, 0x3b, 0x29, 103);           // DEVPROP_TYPE_FILETIME
            internal static readonly DevPropKey DEVPKEY_Device_NoConnectSound = new DevPropKey(0xa8b865dd, 0x2e3d, 0x4094, 0xad, 0x97, 0xe5, 0x93, 0xa7, 0xc, 0x75, 0xd6, 17);              // DEVPROP_TYPE_BOOLEAN
            internal static readonly DevPropKey DEVPKEY_Device_GenericDriverInstalled = new DevPropKey(0xa8b865dd, 0x2e3d, 0x4094, 0xad, 0x97, 0xe5, 0x93, 0xa7, 0xc, 0x75, 0xd6, 18);      // DEVPROP_TYPE_BOOLEAN
            internal static readonly DevPropKey DEVPKEY_Device_AdditionalSoftwareRequested = new DevPropKey(0xa8b865dd, 0x2e3d, 0x4094, 0xad, 0x97, 0xe5, 0x93, 0xa7, 0xc, 0x75, 0xd6, 19); // DEVPROP_TYPE_BOOLEAN
            internal static readonly DevPropKey DEVPKEY_Device_SafeRemovalRequired = new DevPropKey(0xafd97640, 0x86a3, 0x4210, 0xb6, 0x7c, 0x28, 0x9c, 0x41, 0xaa, 0xbe, 0x55, 2);         // DEVPROP_TYPE_BOOLEAN
            internal static readonly DevPropKey DEVPKEY_Device_SafeRemovalRequiredOverride = new DevPropKey(0xafd97640, 0x86a3, 0x4210, 0xb6, 0x7c, 0x28, 0x9c, 0x41, 0xaa, 0xbe, 0x55, 3); // DEVPROP_TYPE_BOOLEAN                                  
            internal static readonly DevPropKey DEVPKEY_DeviceClass_Name = new DevPropKey(0x259abffc, 0x50a7, 0x47ce, 0xaf, 0x8, 0x68, 0xc9, 0xa7, 0xd7, 0x33, 0x66, 2);                    // DEVPROP_TYPE_STRING
            internal static readonly DevPropKey DEVPKEY_DeviceClass_ClassName = new DevPropKey(0x259abffc, 0x50a7, 0x47ce, 0xaf, 0x8, 0x68, 0xc9, 0xa7, 0xd7, 0x33, 0x66, 3);               // DEVPROP_TYPE_STRING
            internal static readonly DevPropKey DEVPKEY_DeviceClass_Icon = new DevPropKey(0x259abffc, 0x50a7, 0x47ce, 0xaf, 0x8, 0x68, 0xc9, 0xa7, 0xd7, 0x33, 0x66, 4);                    // DEVPROP_TYPE_STRING
            internal static readonly DevPropKey DEVPKEY_DeviceClass_ClassInstaller = new DevPropKey(0x259abffc, 0x50a7, 0x47ce, 0xaf, 0x8, 0x68, 0xc9, 0xa7, 0xd7, 0x33, 0x66, 5);          // DEVPROP_TYPE_STRING
            internal static readonly DevPropKey DEVPKEY_DeviceClass_PropPageProvider = new DevPropKey(0x259abffc, 0x50a7, 0x47ce, 0xaf, 0x8, 0x68, 0xc9, 0xa7, 0xd7, 0x33, 0x66, 6);        // DEVPROP_TYPE_STRING
            internal static readonly DevPropKey DEVPKEY_DeviceClass_NoInstallClass = new DevPropKey(0x259abffc, 0x50a7, 0x47ce, 0xaf, 0x8, 0x68, 0xc9, 0xa7, 0xd7, 0x33, 0x66, 7);          // DEVPROP_TYPE_BOOLEAN
            internal static readonly DevPropKey DEVPKEY_DeviceClass_NoDisplayClass = new DevPropKey(0x259abffc, 0x50a7, 0x47ce, 0xaf, 0x8, 0x68, 0xc9, 0xa7, 0xd7, 0x33, 0x66, 8);          // DEVPROP_TYPE_BOOLEAN
            internal static readonly DevPropKey DEVPKEY_DeviceClass_SilentInstall = new DevPropKey(0x259abffc, 0x50a7, 0x47ce, 0xaf, 0x8, 0x68, 0xc9, 0xa7, 0xd7, 0x33, 0x66, 9);           // DEVPROP_TYPE_BOOLEAN
            internal static readonly DevPropKey DEVPKEY_DeviceClass_NoUseClass = new DevPropKey(0x259abffc, 0x50a7, 0x47ce, 0xaf, 0x8, 0x68, 0xc9, 0xa7, 0xd7, 0x33, 0x66, 10);             // DEVPROP_TYPE_BOOLEAN
            internal static readonly DevPropKey DEVPKEY_DeviceClass_DefaultService = new DevPropKey(0x259abffc, 0x50a7, 0x47ce, 0xaf, 0x8, 0x68, 0xc9, 0xa7, 0xd7, 0x33, 0x66, 11);         // DEVPROP_TYPE_STRING
            internal static readonly DevPropKey DEVPKEY_DeviceClass_IconPath = new DevPropKey(0x259abffc, 0x50a7, 0x47ce, 0xaf, 0x8, 0x68, 0xc9, 0xa7, 0xd7, 0x33, 0x66, 12);               // DEVPROP_TYPE_STRING_LIST
        }
    }
}
