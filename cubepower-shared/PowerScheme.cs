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
    /// PowerThrottlePolicy
    /* --------------------------------------------------------------------- */
    [Flags]
    public enum PowerThrottlePolicy : uint {
        PO_THROTTLE_NONE = 0x0000,
        PO_THROTTLE_CONSTANT = 0x0001,
        PO_THROTTLE_DEGRADE = 0x0002,
        PO_THROTTLE_ADAPTIVE = 0x0003,
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
    /// PowerSchemeItem
    /* --------------------------------------------------------------------- */
    public class PowerSchemeItem {
        /* ----------------------------------------------------------------- */
        //  プロパティ
        /* ----------------------------------------------------------------- */
        #region Properties
        /* ----------------------------------------------------------------- */
        /// Name
        /* ----------------------------------------------------------------- */
        public string Name {
            get { return _name; }
            set { _name = value; }
        }

        /* ----------------------------------------------------------------- */
        /// Description
        /* ----------------------------------------------------------------- */
        public string Description {
            get { return _description; }
            set { _description = value; }
        }

        /* ----------------------------------------------------------------- */
        /// Policy
        /* ----------------------------------------------------------------- */
        public POWER_POLICY Policy {
            get { return _policy; }
            set { _policy = value; }
        }

        /* ----------------------------------------------------------------- */
        /// DimTimeout
        /* ----------------------------------------------------------------- */
        public uint DimTimeout {
            get { return _dim; }
            set { _dim = value; }
        }

        /* ----------------------------------------------------------------- */
        /// Brightness
        /* ----------------------------------------------------------------- */
        public uint Brightness {
            get { return _brightness; }
            set { _brightness = value; }
        }

        /* ----------------------------------------------------------------- */
        /// DimBrightness
        /* ----------------------------------------------------------------- */
        public uint DimBrightness {
            get { return _dim_brightness; }
            set { _dim_brightness = value; }
        }

        /* ----------------------------------------------------------------- */
        /// MinThrottle
        /* ----------------------------------------------------------------- */
        public uint MinThrottle {
            get { return _min_throttle; }
            set { _min_throttle = value; }
        }

        /* ----------------------------------------------------------------- */
        /// MaxThrottle
        /* ----------------------------------------------------------------- */
        public uint MaxThrottle {
            get { return _max_throttle; }
            set { _max_throttle = value; }
        }

        #endregion

        /* ----------------------------------------------------------------- */
        //  メンバ変数の定義
        /* ----------------------------------------------------------------- */
        #region variables
        private string _name = "";
        private string _description = "";
        private POWER_POLICY _policy = new POWER_POLICY();

        // extended
        private uint _dim = 0;
        private uint _brightness = 100;
        private uint _dim_brightness = 100;
        private uint _min_throttle = 5;
        private uint _max_throttle = 100;

        #endregion
    }

    /* --------------------------------------------------------------------- */
    ///
    /// IPowerSchemeItem
    ///
    /// <summary>
    /// TODO: PowerSchemeElement を IPowerSchemeItem のインターフェースに
    /// する．
    /// </summary>
    ///
    /* --------------------------------------------------------------------- */
    public interface IPowerSchemeItem {
        string Name { get; set; }
        string Description { get; set; }
        uint MonitorTimeout { get; set; }
        uint DiskTimeout { get; set; }
        uint StandbyTimeout { get; set; }
        uint HibernationTimeout { get; set; }
    }

    /* --------------------------------------------------------------------- */
    /// IPowerScheme
    /* --------------------------------------------------------------------- */
    public interface IPowerScheme {
        bool Update(PowerSchemeItem item);
        bool Add(PowerSchemeItem item);
        bool Remove(string name);
        PowerSchemeItem Find(string name);
        bool Activate(string name);
        void Dump(System.IO.StreamWriter output); // for debug

        List<PowerSchemeItem> Elements { get; }
        PowerSchemeItem Active { get; }
    }
}
