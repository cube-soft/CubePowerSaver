/* ------------------------------------------------------------------------- */
/*
 *  PowerScheme.cs
 *
 *  Copyright (c) 2011 CubeSoft Inc. All rights reserved.
 *
 *  This program is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  along with this program.  If not, see < http://www.gnu.org/licenses/ >.
 */
/* ------------------------------------------------------------------------- */
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace CubePower {
    /* --------------------------------------------------------------------- */
    /// SYSTEM_POWER_STATE
    /* --------------------------------------------------------------------- */
    public enum SYSTEM_POWER_STATE {
        PowerSystemUnspecified = 0,
        PowerSystemWorking     = 1,
        PowerSystemSleeping1   = 2,
        PowerSystemSleeping2   = 3,
        PowerSystemSleeping3   = 4,
        PowerSystemHibernate   = 5,
        PowerSystemShutdown    = 6,
        PowerSystemMaximum     = 7
    }

    /* --------------------------------------------------------------------- */
    /// POWER_ACTION
    /* --------------------------------------------------------------------- */
    public enum POWER_ACTION : uint {
        PowerActionNone = 0,       // No system power action. 
        PowerActionReserved,       // Reserved; do not use. 
        PowerActionSleep,          // Sleep. 
        PowerActionHibernate,      // Hibernate. 
        PowerActionShutdown,       // Shutdown. 
        PowerActionShutdownReset,  // Shutdown and reset. 
        PowerActionShutdownOff,    // Shutdown and power off. 
        PowerActionWarmEject,      // Warm eject.
    }

    /* --------------------------------------------------------------------- */
    /// PowerActionFlags
    /* --------------------------------------------------------------------- */
    [Flags]
    public enum PowerActionFlags : uint {
        POWER_ACTION_QUERY_ALLOWED  = 0x00000001, // Broadcasts a PBT_APMQUERYSUSPEND event to each application to request permission to suspend operation.
        POWER_ACTION_UI_ALLOWED     = 0x00000002, // Applications can prompt the user for directions on how to prepare for suspension. Sets bit 0 in the Flags parameter passed in the lParam parameter of WM_POWERBROADCAST.
        POWER_ACTION_OVERRIDE_APPS  = 0x00000004, // Ignores applications that do not respond to the PBT_APMQUERYSUSPEND event broadcast in the WM_POWERBROADCAST message.
        POWER_ACTION_LIGHTEST_FIRST = 0x10000000, // Uses the first lightest available sleep state.
        POWER_ACTION_LOCK_CONSOLE   = 0x20000000, // Requires entry of the system password upon resume from one of the system standby states.
        POWER_ACTION_DISABLE_WAKES  = 0x40000000, // Disables all wake events.
        POWER_ACTION_CRITICAL       = 0x80000000, // Forces a critical suspension.
    }

    /* --------------------------------------------------------------------- */
    /// PowerActionEventCode
    /* --------------------------------------------------------------------- */
    [Flags]
    public enum PowerActionEventCode : uint {
        POWER_LEVEL_USER_NOTIFY_TEXT  = 0x00000001, // User notified using the UI. 
        POWER_LEVEL_USER_NOTIFY_SOUND = 0x00000002, // User notified using sound. 
        POWER_LEVEL_USER_NOTIFY_EXEC  = 0x00000004, // Specifies a program to be executed. 
        POWER_USER_NOTIFY_BUTTON      = 0x00000008, // Indicates that the power action is in response to a user power button press. 
        POWER_USER_NOTIFY_SHUTDOWN    = 0x00000010, // Indicates a power action of shutdown/off.
        POWER_FORCE_TRIGGER_RESET     = 0x80000000, // Clears a user power button press. 
    }

    /* --------------------------------------------------------------------- */
    /// POWER_ACTION_POLICY
    /* --------------------------------------------------------------------- */
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct POWER_ACTION_POLICY {
        public POWER_ACTION Action;
        public PowerActionFlags Flags;
        public PowerActionEventCode EventCode;
    }

    /* --------------------------------------------------------------------- */
    ///
    /// USER_POWER_POLICY
    /// 
    /// <summary>
    /// http://pinvoke.net/default.aspx/Structures/USER_POWER_POLICY.html
    /// </summary>
    /// 
    /* --------------------------------------------------------------------- */
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct USER_POWER_POLICY {
        public uint Revision;
        public POWER_ACTION_POLICY IdleAc;
        public POWER_ACTION_POLICY IdleDc;
        public uint IdleTimeoutAc;
        public uint IdleTimeoutDc;
        public byte IdleSensitivityAc;
        public byte IdleSensitivityDc;
        public byte ThrottlePolicyAc;
        public byte ThrottlePolicyDc;
        public SYSTEM_POWER_STATE MaxSleepAc;
        public SYSTEM_POWER_STATE MaxSleepDc;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public uint[] Reserved;
        public uint VideoTimeoutAc;
        public uint VideoTimeoutDc;
        public uint SpindownTimeoutAc;
        public uint SpindownTimeoutDc;
        [MarshalAs(UnmanagedType.I1)]
        public bool OptimizeForPowerAc;
        [MarshalAs(UnmanagedType.I1)]
        public bool OptimizeForPowerDc;
        public byte FanThrottleToleranceAc;
        public byte FanThrottleToleranceDc;
        public byte ForcedThrottleAc;
        public byte ForcedThrottleDc;
    }

    /* --------------------------------------------------------------------- */
    ///
    /// MACHINE_POWER_POLICY
    /// 
    /// <summary>
    /// http://pinvoke.net/default.aspx/Structures/MACHINE_POWER_POLICY.html
    /// </summary>
    /// 
    /* --------------------------------------------------------------------- */
    public struct MACHINE_POWER_POLICY {
        public uint Revision;
        public SYSTEM_POWER_STATE MinSleepAc;
        public SYSTEM_POWER_STATE MinSleepDc;
        public SYSTEM_POWER_STATE ReducedLatencySleepAc;
        public SYSTEM_POWER_STATE ReducedLatencySleepDc;
        public uint DozeTimeoutAc;
        public uint DozeTimeoutDc;
        public uint DozeS4TimeoutAc;
        public uint DozeS4TimeoutDc;
        public byte MinThrottleAc;
        public byte MinThrottleDc;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] pad1;
        public POWER_ACTION_POLICY OverThrottledAc;
        public POWER_ACTION_POLICY OverThrottledDc;
    }

    /* --------------------------------------------------------------------- */
    ///
    /// POWER_POLICY
    /// 
    /// <summary>
    /// http://www.pinvoke.net/default.aspx/Structures/POWER_POLICY.html
    /// </summary>
    /// 
    /* --------------------------------------------------------------------- */
    public struct POWER_POLICY {
        public USER_POWER_POLICY user;
        public MACHINE_POWER_POLICY mach;
    }

    /* --------------------------------------------------------------------- */
    /// PowerSchemeElement
    /* --------------------------------------------------------------------- */
    public class PowerSchemeElement {
        /* ----------------------------------------------------------------- */
        //  プロパティ
        /* ----------------------------------------------------------------- */
        #region Properties
        /* ----------------------------------------------------------------- */
        /// Name
        /* ----------------------------------------------------------------- */
        public string Name {
            get { return name_; }
            set { name_ = value; }
        }

        /* ----------------------------------------------------------------- */
        /// Description
        /* ----------------------------------------------------------------- */
        public string Description {
            get { return description_; }
            set { description_ = value; }
        }

        /* ----------------------------------------------------------------- */
        /// Policy
        /* ----------------------------------------------------------------- */
        public POWER_POLICY Policy {
            get { return policy_; }
            set { policy_ = value; }
        }
        #endregion

        /* ----------------------------------------------------------------- */
        //  メンバ変数の定義
        /* ----------------------------------------------------------------- */
        #region variables
        private string name_ = "";
        private string description_ = "";
        private POWER_POLICY policy_ = new POWER_POLICY();
        #endregion
    }

    /* --------------------------------------------------------------------- */
    /// PowerScheme
    /* --------------------------------------------------------------------- */
    public class PowerScheme {
        /* ----------------------------------------------------------------- */
        /// constructor
        /* ----------------------------------------------------------------- */
        public PowerScheme() {
            this.GetAllElements();
        }

        /* ----------------------------------------------------------------- */
        /// Add
        /* ----------------------------------------------------------------- */
        public bool Add(PowerSchemeElement item) {
            if (item == null) return false;

            uint index = 0;
            while (this._Elements.ContainsKey(index)) index++;
            POWER_POLICY policy = item.Policy;
            bool status = NativeMethods.WritePwrScheme(ref index, item.Name, item.Description, ref policy);
            if (status) {
                this._Elements.Add(index, item);
                this._Count++;
            }
            return status;
        }

        /* ----------------------------------------------------------------- */
        /// Remove
        /* ----------------------------------------------------------------- */
        public bool Remove(string name) {
            if (name == null) return false;

            uint index = 0;
            foreach (KeyValuePair<uint, PowerSchemeElement> item in _Elements) {
                if (item.Value.Name == name) {
                    index = item.Key;
                    break;
                }
            }

            bool status = NativeMethods.DeletePwrScheme(index);
            if (status) this._Elements.Remove(index);
            return status;
        }

        /* ----------------------------------------------------------------- */
        /// Find
        /* ----------------------------------------------------------------- */
        public PowerSchemeElement Find(string name) {
            foreach (KeyValuePair<uint, PowerSchemeElement> elem in _Elements) {
                if (elem.Value.Name == name) return elem.Value;
            }
            return null;
        }

        /* ----------------------------------------------------------------- */
        /// Activate
        /* ----------------------------------------------------------------- */
        public bool Activate(string name) {
            foreach (KeyValuePair<uint, PowerSchemeElement> elem in _Elements) {
                if (elem.Value.Name == name) {
                    //return NativeMethods.SetActivePwrScheme((uint)elem.Key, IntPtr.Zero, IntPtr.Zero);
                    bool status = NativeMethods.SetActivePwrScheme((uint)elem.Key, IntPtr.Zero, IntPtr.Zero);
                    System.Windows.Forms.MessageBox.Show(status.ToString());
                }
            }
            return false;
        }

        /* ----------------------------------------------------------------- */
        //  プロパティ
        /* ----------------------------------------------------------------- */
        #region Properties

        /* ----------------------------------------------------------------- */
        /// Elements
        /* ----------------------------------------------------------------- */
        public List<PowerSchemeElement> Elements {
            get {
                List<PowerSchemeElement> dest = new List<PowerSchemeElement>();
                foreach (KeyValuePair<uint, PowerSchemeElement> elem in this._Elements) dest.Add(elem.Value);
                return dest;
            }
        }

        /* ----------------------------------------------------------------- */
        /// Active
        /* ----------------------------------------------------------------- */
        public PowerSchemeElement Active {
            get {
                uint index = 0;
                NativeMethods.GetActivePwrScheme(ref index);
                return _Elements[index];
            }
        }

        #endregion

        /* ----------------------------------------------------------------- */
        //  その他のメソッド
        /* ----------------------------------------------------------------- */
        #region Other methods

        /* ----------------------------------------------------------------- */
        /// GetAllElements
        /* ----------------------------------------------------------------- */
        private void GetAllElements() {
            NativeMethods.EnumPwrSchemes(PwrSchemesEnumProcFunction, 0);
        }

        #endregion // Other methids

        /* ----------------------------------------------------------------- */
        //  メンバ変数の定義
        /* ----------------------------------------------------------------- */
        #region variables
        private int _Count;
        private Dictionary<uint, PowerSchemeElement> _Elements = new Dictionary<uint, PowerSchemeElement>();
        #endregion
        
        /* ----------------------------------------------------------------- */
        //  PowerScheme で使用する Win32 API 群．
        /* ----------------------------------------------------------------- */
        #region Win32 APIs
        internal class NativeMethods {
            /* ------------------------------------------------------------- */
            ///
            /// PwrSchemesEnumProc
            /// 
            /// <summary>
            /// http://www.pinvoke.net/default.aspx/Delegates/PwrSchemesEnumProc.html
            /// </summary>
            /// 
            /// <param name="uiIndex">The power scheme index.</param>
            /// <param name="dwName">The size of the power scheme name string, in bytes.</param>
            /// <param name="sName">The name of the power scheme.</param>
            /// <param name="dwDesc">The size of the description string, in bytes.</param>
            /// <param name="sDesc">The description.</param>
            /// <param name="pp">Receives the power policy.</param>
            /// <param name="lParam">User-defined value.</param>
            /// 
            /// <returns></returns>
            /// 
            /* ------------------------------------------------------------- */
            public delegate bool PwrSchemesEnumProc(uint uiIndex, UInt32 dwName, [MarshalAs(UnmanagedType.LPWStr)] string sName, UInt32 dwDesc, [MarshalAs(UnmanagedType.LPWStr)] string sDesc, ref POWER_POLICY pp, int lParam);

            /* ------------------------------------------------------------- */
            ///
            /// EnumPwrSchemes
            /// 
            /// <summary>
            /// http://www.pinvoke.net/default.aspx/powrprof/EnumPwrSchemes.html
            /// </summary>
            ///
            /* ------------------------------------------------------------- */
            [DllImport("powrprof.dll", SetLastError = true, CharSet = CharSet.Unicode)]
            public static extern bool EnumPwrSchemes(PwrSchemesEnumProc lpfnPwrSchemesEnumProc, int lParam);

            /* ------------------------------------------------------------- */
            ///
            /// GetActivePwrScheme
            /// 
            /// <summary>
            /// http://www.pinvoke.net/default.aspx/powrprof/GetActivePwrScheme.html
            /// </summary>
            ///
            /* ------------------------------------------------------------- */
            [DllImport("powrprof.dll", SetLastError = true, CharSet = CharSet.Unicode)]
            public static extern bool GetActivePwrScheme(ref uint puiID);

            /* ------------------------------------------------------------- */
            ///
            /// SetActivePwrScheme
            /// 
            /// <summary>
            /// http://www.pinvoke.net/default.aspx/powrprof/SetActivePwrScheme.html
            /// </summary>
            ///
            /* ------------------------------------------------------------- */
            [DllImport("powrprof.dll", SetLastError = true, CharSet = CharSet.Unicode)]
            public static extern bool SetActivePwrScheme(uint uiID, IntPtr lpGlobalPowerPolicy, IntPtr lpPowerPolicy);

            /* ------------------------------------------------------------- */
            ///
            /// ReadPwrScheme
            /// 
            /// <summary>
            /// http://www.pinvoke.net/default.aspx/powrprof/ReadPwrScheme.html
            /// </summary>
            ///
            /* ------------------------------------------------------------- */
            [DllImport("powrprof.dll", SetLastError = true, CharSet = CharSet.Unicode)]
            public static extern bool ReadPwrScheme(uint uiID, out POWER_POLICY pPowerPolicy);

            /* ------------------------------------------------------------- */
            ///
            /// WritePwrScheme
            ///
            /// <summary>
            /// http://msdn.microsoft.com/en-us/library/aa373253.aspx
            /// </summary>
            ///
            /* ------------------------------------------------------------- */
            [DllImport("powrprof.dll", SetLastError = true, CharSet = CharSet.Unicode)]
            public static extern bool WritePwrScheme(ref uint puiID, string lpszName, string lpszDescription, ref POWER_POLICY pPowerPolicy);

            /* ------------------------------------------------------------- */
            ///
            /// DeletePwrScheme
            ///
            /// <summary>
            /// http://msdn.microsoft.com/en-us/library/aa372678.aspx
            /// </summary>
            ///
            /* ------------------------------------------------------------- */
            [DllImport("powrprof.dll", SetLastError = true, CharSet=CharSet.Unicode)]
            public static extern bool DeletePwrScheme(uint uiIndex);
        }
        #endregion
        
        /* ----------------------------------------------------------------- */
        //  PowerScheme 内部で使用するコールバック関数群．
        /* ----------------------------------------------------------------- */
        #region Callback functions
        /* ----------------------------------------------------------------- */
        ///
        /// PwrSchemesEnumProcFunction
        /// 
        /// <summary>
        /// Callback function for the EnumPwrSchemes function.
        /// </summary>
        /// 
        /* ----------------------------------------------------------------- */
        private bool PwrSchemesEnumProcFunction(uint uiIndex, UInt32 dwName, [MarshalAs(UnmanagedType.LPWStr)] string sName, UInt32 dwDesc, [MarshalAs(UnmanagedType.LPWStr)] string sDesc, ref POWER_POLICY pp, int lParam) {
            _Count += 1;
            PowerSchemeElement elem = new PowerSchemeElement();
            elem.Name = sName;
            elem.Description = sDesc;
            elem.Policy = pp;
            _Elements.Add(uiIndex, elem);
            return true;
        }
        #endregion
    }
}
