using System.Runtime.InteropServices;
using Guid = System.Guid;

namespace HardwareManagementLib {
    public static partial class Native {
        // https://docs.microsoft.com/en-us/windows-hardware/drivers/install/DevPropKey
        // https://github.com/lostindark/DriverStoreExplorer/blob/master/Rapr/Utils/DeviceHelper.cs
        [StructLayout(LayoutKind.Sequential)]
        internal struct DevPropKey {
            public Guid fmtid;
            public uint pid;

            public DevPropKey(Guid fmtid, uint pid) {
                this.fmtid = fmtid;
                this.pid = pid;
            }

            public DevPropKey(uint a, ushort b, ushort c, byte d, byte e, byte f, byte g, byte h, byte i, byte j, byte k, uint pid) {
                this.fmtid = new Guid(a, b, c, d, e, f, g, h, i, j, k);
                this.pid = pid;
            }
        }

        // https://docs.microsoft.com/en-us/windows-hardware/drivers/install/property-data-type-identifiers
        // https://github.com/tpn/winsdk-10/blob/master/Include/10.0.16299.0/shared/devpropdef.h#L39
        internal enum DevPropType : uint {
            TYPEMOD_ARRAY = 0x1000,                     // array of fixed-sized data elements
            TYPEMOD_LIST = 0x2000,                      // list of variable-sized data elements
            EMPTY = 0x0,                                // nothing, no property data
            NULL = 0x1,                                 // null property data
            SBYTE = 0x2,                                // 8-bit signed int (SBYTE)
            BYTE = 0x3,                                 // 8-bit unsigned int (BYTE)
            INT16 = 0x4,                                // 16-bit signed int (SHORT)
            UINT16 = 0x5,                               // 16-bit unsigned int (USHORT)
            INT32 = 0x6,                                // 32-bit signed int (LONG)
            UINT32 = 0x7,                               // 32-bit unsigned int (ULONG)
            INT64 = 0x8,                                // 64-bit signed int (LONG64)
            UINT64 = 0x9,                               // 64-bit unsigned int (ULONG64)
            FLOAT = 0xa,                                // 32-bit floating-point (FLOAT)
            DOUBLE = 0xb,                               // 64-bit floating-point (DOUBLE)
            DECIMAL = 0xc,                              // 128-bit data (DECIMAL)
            GUID = 0xd,                                 // 128-bit unique identifier (GUID)
            CURRENCY = 0xe,                             // 64-bit signed int currency value (CURRENCY)
            DATE = 0xf,                                 // date (DATE)
            FILETIME = 0x10,                            // file time (FILETIME)
            BOOLEAN = 0x11,                             // 8-bit boolean (DEVPROP_BOOLEAN)
            STRING = 0x12,                              // null-terminated string
            STRING_LIST = STRING | TYPEMOD_LIST,        // multi-sz string list
            SECURITY_DESCRIPTOR = 0x13,                 // self-relative binary SECURITY_DESCRIPTOR
            SECURITY_DESCRIPTOR_STRING = 0x14,          // security descriptor string (SDDL format)
            DEVPROPKEY = 0x15,                          // device property key (DEVPROPKEY)
            DEVPROPTYPE = 0x16,                         // device property type (DEVPROPTYPE)
            BINARY = BYTE | TYPEMOD_ARRAY,              // custom binary data
            ERROR = 0x17,                               // 32-bit Win32 system error code
            NTSTATUS = 0x18,                            // 32-bit NTSTATUS code
            STRING_INDIRECT = 0x19                      // string resource (@[path\]<dllname>,-<strid>)
        }

        // https://docs.microsoft.com/en-us/windows/win32/api/cfg/ne-cfg-pnp_veto_type
        // https://github.com/tpn/winsdk-10/blob/master/Include/10.0.16299.0/shared/cfg.h#L47
        internal enum PnpVetoType : int {
            PNP_VetoTypeUnknown = 0,
            PNP_VetoLegacyDevice = 1,
            PNP_VetoPendingClose = 2,
            PNP_VetoWindowsApp = 3,
            PNP_VetoWindowsService = 4,
            PNP_VetoOutstandingOpen = 5,
            PNP_VetoDevice = 6,
            PNP_VetoDriver = 7,
            PNP_VetoIllegalDeviceRequest = 8,
            PNP_VetoInsufficientPower = 9,
            PNP_VetoNonDisableable = 10,
            PNP_VetoLegacyDriver = 11,
            PNP_VetoInsufficientRights = 12,
            PNP_VetoAlreadyRemoved = 13
        }
    }
}
