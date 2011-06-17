/* ------------------------------------------------------------------------- */
/*
 *  PowerSchemeVista.cs
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
using System.Text;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace CubePower {
    /* --------------------------------------------------------------------- */
    /// PowerSchemeVista
    /* --------------------------------------------------------------------- */
    public class PowerSchemeVista : IPowerScheme {
        /* ----------------------------------------------------------------- */
        /// constructor
        /* ----------------------------------------------------------------- */
        public PowerSchemeVista() {
            this.GetAllElements();
        }

        /* ----------------------------------------------------------------- */
        /// Update
        /* ----------------------------------------------------------------- */
        public bool Update(PowerSchemeItem item) {
            if (this.Find(item.Name) == null) return this.Add(item);
            foreach (KeyValuePair<Guid, PowerSchemeItem> elem in this._elements) {
                if (elem.Value.Name == item.Name) {
                    bool status = true;
                    Guid scheme = elem.Key;
                    status &= this.SetACValue(scheme, GUID_VIDEO_SUBGROUP, GUID_VIDEO_TIMEOUT, item.Policy.user.VideoTimeoutAc);
                    status &= this.SetACValue(scheme, GUID_DISK_SUBGROUP, GUID_DISK_TIMEOUT, item.Policy.user.SpindownTimeoutAc);
                    status &= this.SetACValue(scheme, GUID_SLEEP_SUBGROUP, GUID_STANDBY_TIMEOUT, item.Policy.user.IdleTimeoutAc);
                    status &= this.SetACValue(scheme, GUID_SLEEP_SUBGROUP, GUID_HIBERNATION_TIMEOUT, item.Policy.mach.DozeS4TimeoutAc);
                    status &= this.SetACValue(scheme, GUID_VIDEO_SUBGROUP, GUID_VIDEO_DIM_TIMEOUT, item.DimTimeout);
                    status &= this.SetACValue(scheme, GUID_VIDEO_SUBGROUP, GUID_VIDEO_BRIGHTNESS, item.Brightness);
                    status &= this.SetACValue(scheme, GUID_VIDEO_SUBGROUP, GUID_VIDEO_DIM_BRIGHTNESS, item.DimBrightness);

                    return status;
                }
            }
            return false;
        }

        /* ----------------------------------------------------------------- */
        /// Add
        /* ----------------------------------------------------------------- */
        public bool Add(PowerSchemeItem item) {
            if (item == null) return false;

            Guid active = Guid.Empty;
            Guid dest = Guid.Empty;
            IntPtr active_handle = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(IntPtr)));
            IntPtr dest_handle = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(IntPtr)));
            try {
                if (NativeMethods.PowerGetActiveScheme(IntPtr.Zero, out active_handle) != 0) return false;
                active = (Guid)Marshal.PtrToStructure(active_handle, typeof(Guid));
                if (NativeMethods.PowerDuplicateScheme(IntPtr.Zero, ref active, out dest_handle) != 0) return false;
                dest = (Guid)Marshal.PtrToStructure(dest_handle, typeof(Guid));

                bool status = true;
                status &= this.SetProfileName(dest, item.Name);
                status &= this.SetACValue(dest, GUID_VIDEO_SUBGROUP, GUID_VIDEO_TIMEOUT, item.Policy.user.VideoTimeoutAc);
                status &= this.SetACValue(dest, GUID_DISK_SUBGROUP, GUID_DISK_TIMEOUT, item.Policy.user.SpindownTimeoutAc);
                status &= this.SetACValue(dest, GUID_SLEEP_SUBGROUP, GUID_STANDBY_TIMEOUT, item.Policy.user.IdleTimeoutAc);
                status &= this.SetACValue(dest, GUID_SLEEP_SUBGROUP, GUID_HIBERNATION_TIMEOUT, item.Policy.mach.DozeS4TimeoutAc);
                status &= this.SetACValue(dest, GUID_VIDEO_SUBGROUP, GUID_VIDEO_DIM_TIMEOUT, item.DimTimeout);
                status &= this.SetACValue(dest, GUID_VIDEO_SUBGROUP, GUID_VIDEO_BRIGHTNESS, item.Brightness);
                status &= this.SetACValue(dest, GUID_VIDEO_SUBGROUP, GUID_VIDEO_DIM_BRIGHTNESS, item.DimBrightness);

                if (!status) {
                    NativeMethods.PowerDeleteScheme(IntPtr.Zero, ref dest);
                    return false;
                }

                this._elements.Add(dest, item);
                return status;
            }
            finally {
                if (active_handle != null) Marshal.FreeHGlobal(active_handle);
                if (dest_handle != null) Marshal.FreeHGlobal(dest_handle);
            }
        }
        
        /* ----------------------------------------------------------------- */
        /// Remove
        /* ----------------------------------------------------------------- */
        public bool Remove(string name) {
            if (name == null) return false;

            Guid guid = Guid.Empty;
            foreach (KeyValuePair<Guid, PowerSchemeItem> item in this._elements) {
                if (item.Value.Name == name) {
                    guid = item.Key;
                    break;
                }
            }

            uint status = NativeMethods.PowerDeleteScheme(IntPtr.Zero, ref guid);
            if (status == 0) this._elements.Remove(guid);
            return status == 0;
        }

        /* ----------------------------------------------------------------- */
        /// Find
        /* ----------------------------------------------------------------- */
        public PowerSchemeItem Find(string name) {
            foreach (KeyValuePair<Guid, PowerSchemeItem> elem in this._elements) {
                if (elem.Value.Name == name) return elem.Value;
            }
            return null;
        }

        /* ----------------------------------------------------------------- */
        /// Activate
        /* ----------------------------------------------------------------- */
        public bool Activate(string name) {
            foreach (KeyValuePair<Guid, PowerSchemeItem> elem in this._elements) {
                if (elem.Value.Name == name) {
                    Guid scheme = elem.Key;
                    return NativeMethods.PowerSetActiveScheme(IntPtr.Zero, ref scheme) == 0;
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
        public List<PowerSchemeItem> Elements {
            get {
                List<PowerSchemeItem> dest = new List<PowerSchemeItem>();
                foreach (KeyValuePair<Guid, PowerSchemeItem> elem in this._elements) dest.Add(elem.Value);
                return dest;
            }
        }

        /* ----------------------------------------------------------------- */
        /// Active
        /* ----------------------------------------------------------------- */
        public PowerSchemeItem Active {
            get {
                Guid scheme = Guid.Empty;
                IntPtr handle = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(IntPtr)));
                try {
                    if (NativeMethods.PowerGetActiveScheme(IntPtr.Zero, out handle) == 0) {
                        scheme = (Guid)Marshal.PtrToStructure(handle, typeof(Guid));
                        if (this._elements.ContainsKey(scheme)) return this._elements[scheme];
                    }
                }
                finally {
                    if (handle != null) Marshal.FreeHGlobal(handle);
                }
                return null;
            }
        }

        #endregion // Properties

        /* ----------------------------------------------------------------- */
        //  その他のメソッド
        /* ----------------------------------------------------------------- */
        #region Other methods

        /* ----------------------------------------------------------------- */
        /// GetAllElements
        /* ----------------------------------------------------------------- */
        private void GetAllElements() {
            Guid scheme = Guid.Empty;
            uint index = 0;
            uint size = (uint)Marshal.SizeOf(scheme);

            while (NativeMethods.PowerEnumerate(IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, NativeMethods.POWER_DATA_ACCESSOR.ACCESS_SCHEME, index, ref scheme, ref size) == 0) {
                PowerSchemeItem item = new PowerSchemeItem();
                item.Name = this.GetProfileName(scheme);

                POWER_POLICY policy = item.Policy;
                policy.user.VideoTimeoutAc = this.GetACValue(scheme, GUID_VIDEO_SUBGROUP, GUID_VIDEO_TIMEOUT);
                policy.user.SpindownTimeoutAc = this.GetACValue(scheme, GUID_DISK_SUBGROUP, GUID_DISK_TIMEOUT);
                policy.user.IdleTimeoutAc = this.GetACValue(scheme, GUID_SLEEP_SUBGROUP, GUID_STANDBY_TIMEOUT);
                policy.mach.DozeS4TimeoutAc = this.GetACValue(scheme, GUID_SLEEP_SUBGROUP, GUID_HIBERNATION_TIMEOUT);
                item.Policy = policy;

                item.DimTimeout = this.GetACValue(scheme, GUID_VIDEO_SUBGROUP, GUID_VIDEO_DIM_TIMEOUT);
                item.Brightness = this.GetACValue(scheme, GUID_VIDEO_SUBGROUP, GUID_VIDEO_BRIGHTNESS);
                item.DimBrightness = this.GetACValue(scheme, GUID_VIDEO_SUBGROUP, GUID_VIDEO_DIM_BRIGHTNESS);

                this._elements.Add(scheme, item);
                index++;
            }
        }

        /* ----------------------------------------------------------------- */
        /// GetProfileName
        /* ----------------------------------------------------------------- */
        private string GetProfileName(Guid scheme) {
            UInt32 size = 0;
            if (NativeMethods.PowerReadFriendlyName(IntPtr.Zero, ref scheme, IntPtr.Zero, IntPtr.Zero, null, ref size) != 0) return null;
            StringBuilder name = new StringBuilder((int)size);
            NativeMethods.PowerReadFriendlyName(IntPtr.Zero, ref scheme, IntPtr.Zero, IntPtr.Zero, name, ref size);
            return name.ToString();
        }

        /* ----------------------------------------------------------------- */
        /// SetProfileName
        /* ----------------------------------------------------------------- */
        private bool SetProfileName(Guid scheme, string name) {
            UInt32 size = (UInt32)(name.Length * sizeof(char)); 
            return NativeMethods.PowerWriteFriendlyName(IntPtr.Zero, ref scheme, IntPtr.Zero, IntPtr.Zero, name, size) == 0;
        }

        /* ----------------------------------------------------------------- */
        /// GetACValue
        /* ----------------------------------------------------------------- */
        private UInt32 GetACValue(Guid scheme, Guid subgroup, Guid setting) {
            UInt32 dest = 0;
            NativeMethods.PowerReadACValueIndex(IntPtr.Zero, ref scheme, ref subgroup, ref setting, ref dest);
            return dest;
        }

        /* ----------------------------------------------------------------- */
        /// SetACValue
        /* ----------------------------------------------------------------- */
        private bool SetACValue(Guid scheme, Guid subgroup, Guid setting, UInt32 value) {
            return NativeMethods.PowerWriteACValueIndex(IntPtr.Zero, ref scheme, ref subgroup, ref setting, value) == 0;
        }

        #endregion // Other methods

        /* ----------------------------------------------------------------- */
        //  PowerScheme で使用する Win32 API 群．
        /* ----------------------------------------------------------------- */
        #region Win32 APIs

        /* ----------------------------------------------------------------- */
        /// NativeMethods
        /* ----------------------------------------------------------------- */
        internal class NativeMethods {
            /* ------------------------------------------------------------- */
            /// POWER_DATA_ACCESSOR
            /* ------------------------------------------------------------- */
            public enum POWER_DATA_ACCESSOR {
                ACCESS_SCHEME               = 16,
                ACCESS_SUBGROUP             = 17,
                ACCESS_INDIVIDUAL_SETTING   = 18
            }

            /* ------------------------------------------------------------- */
            ///
            /// PowerEnumerate
            ///
            /// <summary>
            /// http://msdn.microsoft.com/en-us/library/aa372730.aspx
            /// </summary>
            ///
            /* ------------------------------------------------------------- */
            [DllImport("PowrProf.dll")]
            public static extern UInt32 PowerEnumerate(IntPtr RootPowerKey, IntPtr SchemeGuid, IntPtr SubGroupOfPowerettingsGuid, POWER_DATA_ACCESSOR AccessFlags, UInt32 Index, ref Guid Buffer, ref UInt32 BufferSize);

            /* ------------------------------------------------------------- */
            ///
            /// PowerReadFriendlyName
            ///
            /// <summary>
            /// http://msdn.microsoft.com/en-us/library/aa372740.aspx
            /// http://pinvoke.net/default.aspx/powrprof/PowerReadFriendlyName.html
            /// </summary>
            ///
            /* ------------------------------------------------------------- */
            [DllImport("PowrProf.dll", CharSet = CharSet.Unicode)]
            public static extern UInt32 PowerReadFriendlyName(IntPtr RootPowerKey, ref Guid SchemeGuid, IntPtr SubGroupOfPowerSettingsGuid, IntPtr PowerSettingGuid, StringBuilder Buffer, ref UInt32 BufferSize);

            /* ------------------------------------------------------------- */
            ///
            /// PowerWriteFriendlyName
            ///
            /// <summary>
            /// http://msdn.microsoft.com/en-us/library/aa372773.aspx
            /// http://pinvoke.net/default.aspx/powrprof/PowerWriteFriendlyName.html
            /// </summary>
            ///
            /* ------------------------------------------------------------- */
            [DllImport("PowrProf.dll", CharSet = CharSet.Unicode)]
            public static extern UInt32 PowerWriteFriendlyName(IntPtr RootPowerKey, ref Guid SchemeGuid, IntPtr SubGroupOfPowerSettingsGuid, IntPtr PowerSettingGuid, string Buffer, UInt32 BufferSize);

            /* ------------------------------------------------------------- */
            ///
            /// PowerReadACValueIndex
            ///
            /// <summary>
            /// http://msdn.microsoft.com/en-us/library/aa372735.aspx
            /// </summary>
            ///
            /* ------------------------------------------------------------- */
            [DllImport("PowrProf.dll", CharSet = CharSet.Unicode)]
            public static extern UInt32 PowerReadACValueIndex(IntPtr RootPowerKey, ref Guid SchemeGuid, ref Guid SubGroupOfPowerSettingsGuid, ref Guid PowerSettingGuid, ref UInt32 AcValueIndex);

            /* ------------------------------------------------------------- */
            ///
            /// PowerWriteACValueIndex
            ///
            /// <summary>
            /// http://msdn.microsoft.com/en-us/library/aa372735.aspx
            /// </summary>
            ///
            /* ------------------------------------------------------------- */
            [DllImport("PowrProf.dll", CharSet = CharSet.Unicode)]
            public static extern UInt32 PowerWriteACValueIndex(IntPtr RootPowerKey, ref Guid SchemeGuid, ref Guid SubGroupOfPowerSettingsGuid, ref Guid PowerSettingGuid, UInt32 AcValueIndex);

            /* ------------------------------------------------------------- */
            ///
            /// PowerGetActiveScheme
            ///
            /// <summary>
            /// http://msdn.microsoft.com/en-us/library/aa372731.aspx
            /// </summary>
            ///
            /* ------------------------------------------------------------- */
            [DllImport("PowrProf.dll", CharSet = CharSet.Unicode)]
            public static extern UInt32 PowerGetActiveScheme(IntPtr UserPowerKey, out IntPtr ActivePolicyGuid);

            /* ------------------------------------------------------------- */
            ///
            /// PowerSetActiveScheme
            ///
            /// <summary>
            /// http://msdn.microsoft.com/en-us/library/aa372731.aspx
            /// </summary>
            ///
            /* ------------------------------------------------------------- */
            [DllImport("PowrProf.dll", CharSet = CharSet.Unicode)]
            public static extern UInt32 PowerSetActiveScheme(IntPtr UserPowerKey, ref Guid ActivePolicyGuid);

            /* ------------------------------------------------------------- */
            ///
            /// PowerDuplicateScheme
            ///
            /// <summary>
            /// http://msdn.microsoft.com/en-us/library/aa372729.aspx
            /// </summary>
            ///
            /* ------------------------------------------------------------- */
            [DllImport("PowrProf.dll", CharSet = CharSet.Unicode)]
            public static extern UInt32 PowerDuplicateScheme(IntPtr RootPowerKey, ref Guid SourceSchemeGuid, out IntPtr DestinationSchemeGuid);

            /* ------------------------------------------------------------- */
            ///
            /// PowerDeleteScheme
            ///
            /// <summary>
            /// http://msdn.microsoft.com/en-us/library/aa372727.aspx
            /// </summary>
            ///
            /* ------------------------------------------------------------- */
            [DllImport("PowrProf.dll", CharSet = CharSet.Unicode)]
            public static extern UInt32 PowerDeleteScheme(IntPtr RootPowerKey, ref Guid SchemeGuid);
        }

        #endregion // Win32 APIs

        /* ----------------------------------------------------------------- */
        //  定数
        /* ----------------------------------------------------------------- */
        #region Constant variables

        // ディスプレイ関連
        private static readonly Guid GUID_VIDEO_SUBGROUP        = new Guid("7516b95f-f776-4464-8c53-06167f40cc99");
        private static readonly Guid GUID_VIDEO_DIM_TIMEOUT             = new Guid("17aaa29b-8b43-4b94-aafe-35f64daaf1ee");
        private static readonly Guid GUID_VIDEO_TIMEOUT         = new Guid("3c0bc021-c8a8-4e07-a973-6b14cbcb2b7e");
        private static readonly Guid GUID_VIDEO_BRIGHTNESS      = new Guid("aded5e82-b909-4619-9949-f5d71dac0bcb");
        private static readonly Guid GUID_VIDEO_DIM_BRIGHTNESS  = new Guid("f1fbfde2-a960-4165-9f88-50667911ce96");

        // ハードディスク関連
        private static readonly Guid GUID_DISK_SUBGROUP         = new Guid("0012ee47-9041-4b5d-9b77-535fba8b1442");
        private static readonly Guid GUID_DISK_TIMEOUT          = new Guid("6738e2c4-e8a5-4a42-b16a-e040e769756e");

        // システムスタンバイ/休止状態
        private static readonly Guid GUID_SLEEP_SUBGROUP        = new Guid("238C9FA8-0AAD-41ED-83F4-97BE242C8F20");
        private static readonly Guid GUID_STANDBY_TIMEOUT       = new Guid("29f6c1db-86da-48c5-9fdb-f2b67b1f44da");
        private static readonly Guid GUID_HIBERNATION_TIMEOUT   = new Guid("9d7815a6-7ee4-497e-8888-515a05f02364");

        // その他
        private static readonly Guid NO_SUBGROUP_GUID           = new Guid("fea3413e-7e05-4911-9a71-700331f1c294");

        #endregion // Constant variables

        /* ----------------------------------------------------------------- */
        //  メンバ変数
        /* ----------------------------------------------------------------- */
        #region Variables
        private Dictionary<Guid, PowerSchemeItem> _elements = new Dictionary<Guid, PowerSchemeItem>();
        #endregion // Variables
    }
}
