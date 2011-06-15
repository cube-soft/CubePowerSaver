/* ------------------------------------------------------------------------- */
/*
 *  PowerSchemeXP.cs
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
    /// PowerScheme
    /* --------------------------------------------------------------------- */
    public class PowerSchemeXP : IPowerScheme {
        /* ----------------------------------------------------------------- */
        /// constructor
        /* ----------------------------------------------------------------- */
        public PowerSchemeXP() {
            this.GetAllElements();
        }

        /* ----------------------------------------------------------------- */
        /// Update
        /* ----------------------------------------------------------------- */
        public bool Update(PowerSchemeItem item) {
            if (this.Find(item.Name) == null) return this.Add(item);

            bool status = true;
            foreach (KeyValuePair<uint, PowerSchemeItem> elem in _Elements) {
                if (elem.Value.Name == item.Name) {
                    POWER_POLICY policy = elem.Value.Policy;
                    policy.user.VideoTimeoutAc = item.Policy.user.VideoTimeoutAc;
                    policy.user.SpindownTimeoutAc = item.Policy.user.SpindownTimeoutAc;
                    policy.user.IdleTimeoutAc = item.Policy.user.IdleTimeoutAc;
                    policy.mach.DozeS4TimeoutAc = item.Policy.mach.DozeS4TimeoutAc;

                    uint index = elem.Key;
                    status = NativeMethods.WritePwrScheme(ref index, item.Name, item.Description, ref policy);
                    elem.Value.Policy = policy;
                    break;
                }
            }

            return status;
        }

        /* ----------------------------------------------------------------- */
        /// Add
        /* ----------------------------------------------------------------- */
        public bool Add(PowerSchemeItem item) {
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
            foreach (KeyValuePair<uint, PowerSchemeItem> item in _Elements) {
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
        public PowerSchemeItem Find(string name) {
            foreach (KeyValuePair<uint, PowerSchemeItem> elem in _Elements) {
                if (elem.Value.Name == name) return elem.Value;
            }
            return null;
        }

        /* ----------------------------------------------------------------- */
        /// Activate
        /* ----------------------------------------------------------------- */
        public bool Activate(string name) {
            foreach (KeyValuePair<uint, PowerSchemeItem> elem in _Elements) {
                if (elem.Value.Name == name) {
                    return NativeMethods.SetActivePwrScheme((uint)elem.Key, IntPtr.Zero, IntPtr.Zero);
                }
            }
            return false;
        }

        /* ----------------------------------------------------------------- */
        //  �v���p�e�B
        /* ----------------------------------------------------------------- */
        #region Properties

        /* ----------------------------------------------------------------- */
        /// Elements
        /* ----------------------------------------------------------------- */
        public List<PowerSchemeItem> Elements {
            get {
                List<PowerSchemeItem> dest = new List<PowerSchemeItem>();
                foreach (KeyValuePair<uint, PowerSchemeItem> elem in this._Elements) dest.Add(elem.Value);
                return dest;
            }
        }

        /* ----------------------------------------------------------------- */
        /// Active
        /* ----------------------------------------------------------------- */
        public PowerSchemeItem Active {
            get {
                uint index = 0;
                NativeMethods.GetActivePwrScheme(ref index);
                return _Elements[index];
            }
        }

        #endregion

        /* ----------------------------------------------------------------- */
        //  ���̑��̃��\�b�h
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
        //  �����o�ϐ��̒�`
        /* ----------------------------------------------------------------- */
        #region variables
        private int _Count;
        private Dictionary<uint, PowerSchemeItem> _Elements = new Dictionary<uint, PowerSchemeItem>();
        #endregion

        /* ----------------------------------------------------------------- */
        //  PowerScheme �Ŏg�p���� Win32 API �Q�D
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
            [DllImport("powrprof.dll", SetLastError = true, CharSet = CharSet.Unicode)]
            public static extern bool DeletePwrScheme(uint uiIndex);
        }
        #endregion

        /* ----------------------------------------------------------------- */
        //  PowerScheme �����Ŏg�p����R�[���o�b�N�֐��Q�D
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
            PowerSchemeItem elem = new PowerSchemeItem();
            elem.Name = sName;
            elem.Description = sDesc;
            elem.Policy = pp;
            _Elements.Add(uiIndex, elem);
            return true;
        }
        #endregion
    }
}