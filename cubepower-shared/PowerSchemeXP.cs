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
        public bool Update(PowerSchemeElement item) {
            if (this.Find(item.Name) == null) return this.Add(item);

            foreach (KeyValuePair<uint, PowerSchemeElement> elem in _Elements) {
                if (elem.Value.Name == item.Name) {
                    POWER_POLICY policy = item.Policy;
                    uint index = elem.Key;
                    return NativeMethods.WritePwrScheme(ref index, item.Name, item.Description, ref policy);
                }
            }
            return false;
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
                    return NativeMethods.SetActivePwrScheme((uint)elem.Key, IntPtr.Zero, IntPtr.Zero);
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
            [DllImport("powrprof.dll", SetLastError = true, CharSet = CharSet.Unicode)]
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