using System.Runtime.InteropServices;
using IntPtr = System.IntPtr;

namespace HardwareManagementLib {
    // A: ANSI, W: Unicode
    public static partial class Native {
        // https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_get_device_id_list_sizew
        [DllImport("CfgMgr32.dll", SetLastError = true)]
        internal static extern ReturnCode CM_Get_Device_ID_List_Size(
            out uint devicesBufferSize,
            string filter,
            uint flags = (uint) GetIdListFilter.CM_GETIDLIST_FILTER_NONE
        );

        // https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_get_device_id_listw
        [DllImport("CfgMgr32.dll", SetLastError = true)]
        internal static extern ReturnCode CM_Get_Device_ID_List(
            string filter,
            byte[] devicesBuffer,
            uint devicesBufferLength,
            uint flags = (uint) GetIdListFilter.CM_GETIDLIST_FILTER_NONE
        );

        // https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_locate_devnodew
        [DllImport("CfgMgr32.dll", SetLastError = true)]
        internal static extern ReturnCode CM_Locate_DevNode(
            ref uint devInst,
            string deviceId,
            uint flags = (uint) LocateDevNodeFilter.CM_LOCATE_DEVNODE_NORMAL
        );

        // https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_get_devnode_propertyw
        [DllImport("CfgMgr32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern ReturnCode CM_Get_DevNode_PropertyW(
            uint devInst,
            ref DevPropKey propertyKey,
            out DevPropType propertyType,
            IntPtr propertyBuffer,
            out uint propertyBufferSize,
            uint flags = 0
        );

        // https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_get_devnode_status
        [DllImport("CfgMgr32.dll", SetLastError = true)]
        internal static extern ReturnCode CM_Get_DevNode_Status(
            out uint status,
            out uint problemNumber,
            uint devInst,
            uint flags = 0
        );

        // https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_enable_devnode
        [DllImport("CfgMgr32.dll", SetLastError = true)]
        internal static extern ReturnCode CM_Enable_DevNode(
            uint devInst,
            uint flags = 0
        );

        // https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_disable_devnode
        [DllImport("CfgMgr32.dll", SetLastError = true)]
        internal static extern ReturnCode CM_Disable_DevNode(
            uint devInst,
            uint flags = (uint) DisableDevNodeFlag.CM_DISABLE_PERSIST
        );

        // https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_setup_devnode
        [DllImport("CfgMgr32.dll", SetLastError = true)]
        internal static extern ReturnCode CM_Setup_DevNode(
            uint devInst,
            uint flags = 0
        );

        // https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_query_and_remove_subtreew
        [DllImport("CfgMgr32.dll", SetLastError = true)]
        internal static extern ReturnCode CM_Query_And_Remove_SubTree(
            uint devInstAncestor,
            out PnpVetoType vetoType,
            IntPtr vetoName,
            int vetoNameLength,
            uint flags = 0
        );

        /*
        // https://docs.microsoft.com/en-us/windows/win32/api/cfgmgr32/nf-cfgmgr32-cm_mapcrtowin32err
        [DllImport("CfgMgr32.dll", SetLastError = true)]
        internal static extern ReturnCode CM_MapCrToWin32Err(
            ReturnCode returnCode,
            int defaultError
        );
        */
    }
}
