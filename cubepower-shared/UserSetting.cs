/* ------------------------------------------------------------------------- */
/*
 *  UserSetting.cs
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
using System.Xml;
using Microsoft.Win32;

namespace CubePower {
    /* --------------------------------------------------------------------- */
    /// PowerSetting
    /* --------------------------------------------------------------------- */
    public class PowerSetting {
        /* ----------------------------------------------------------------- */
        //  各種プロパティ
        /* ----------------------------------------------------------------- */
        #region Properties

        /* ----------------------------------------------------------------- */
        /// MonitorTimeout
        /* ----------------------------------------------------------------- */
        public uint MonitorTimeout {
            get { return this._monitor; }
            set { this._monitor = value; }
        }

        /* ----------------------------------------------------------------- */
        /// DiskTimeout
        /* ----------------------------------------------------------------- */
        public uint DiskTimeout {
            get { return this._disk; }
            set { this._disk = value; }
        }

        /* ----------------------------------------------------------------- */
        /// StandByTimeout
        /* ----------------------------------------------------------------- */
        public uint StandByTimeout {
            get { return this._standby; }
            set { this._standby = value; }
        }

        /* ----------------------------------------------------------------- */
        /// HibernationTimeout
        /* ----------------------------------------------------------------- */
        public uint HibernationTimeout {
            get { return this._hibernation; }
            set { this._hibernation = value; }
        }

        /* ----------------------------------------------------------------- */
        /// DimTimeout
        /* ----------------------------------------------------------------- */
        public uint DimTimeout {
            get { return this._dim; }
            set { this._dim = value; }
        }

        /* ----------------------------------------------------------------- */
        /// Brightness
        /* ----------------------------------------------------------------- */
        public uint Brightness {
            get { return this._brightness; }
            set { this._brightness = value; }
        }

        /* ----------------------------------------------------------------- */
        /// DimBrightness
        /* ----------------------------------------------------------------- */
        public uint DimBrightness {
            get { return this._dim_brightness; }
            set { this._dim_brightness = value; }
        }

        /* ----------------------------------------------------------------- */
        /// ThrottlePolicy
        /* ----------------------------------------------------------------- */
        public PowerThrottlePolicy ThrottlePolicy {
            get { return this._throttle; }
            set { this._throttle = value; }
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

        #endregion // Properties

        /* ----------------------------------------------------------------- */
        //  変数宣言
        /* ----------------------------------------------------------------- */
        #region Variables
        uint _monitor = 0;
        uint _disk = 0;
        uint _standby = 0;
        uint _hibernation = 0;
        uint _dim = 0;
        uint _brightness = 100;
        uint _dim_brightness = 100;
        PowerThrottlePolicy _throttle = PowerThrottlePolicy.PO_THROTTLE_NONE;
        private uint _min_throttle = 5;
        private uint _max_throttle = 100;
        #endregion // Variables
    }

    /* --------------------------------------------------------------------- */
    /// ScheduleItem
    /* --------------------------------------------------------------------- */
    public class ScheduleItem {
        /* ----------------------------------------------------------------- */
        //  各種プロパティ
        /* ----------------------------------------------------------------- */
        #region Properties

        /* ----------------------------------------------------------------- */
        /// First
        /* ----------------------------------------------------------------- */
        public DateTime First {
            get { return this._first; }
            set { this._first = value; }
        }

        /* ----------------------------------------------------------------- */
        /// Last
        /* ----------------------------------------------------------------- */
        public DateTime Last {
            get { return this._last; }
            set { this._last = value; }
        }

        /* ----------------------------------------------------------------- */
        /// ProfileName
        /* ----------------------------------------------------------------- */
        public string ProfileName {
            get { return this._profile; }
            set { this._profile = value; }
        }

        /* ----------------------------------------------------------------- */
        /// ACValues
        /* ----------------------------------------------------------------- */
        public PowerSetting ACValues {
            get { return this._ac; }
            set { this._ac = value; }
        }

        #endregion // Properties

        /* ----------------------------------------------------------------- */
        //  変数宣言
        /* ----------------------------------------------------------------- */
        #region Variables
        DateTime _first = DateTime.Parse("00:00");
        DateTime _last  = DateTime.Parse("23:59");
        string _profile = "";
        PowerSetting _ac = new PowerSetting();
        #endregion // Variables
    }

    /* --------------------------------------------------------------------- */
    /// UserSetting
    /* --------------------------------------------------------------------- */
    public class UserSetting {
        /* ----------------------------------------------------------------- */
        /// constructor
        /* ----------------------------------------------------------------- */
        public UserSetting() {
            try {
                RegistryKey subkey = Registry.LocalMachine.OpenSubKey(REG_ROOT, false);
                if (subkey != null) {
                    _version = subkey.GetValue(REG_PRODUCT_VERSION, REG_VALUE_UNKNOWN) as string;
                }

                OperatingSystem info = Environment.OSVersion;
                if (info.Version.Major > 5) this._scheme = new PowerSchemeVista();
                else this._scheme = new PowerSchemeXP();
                this._default.ProfileName = this._scheme.Active.Name;
                this._default.ACValues.MonitorTimeout = this._scheme.Active.Policy.user.VideoTimeoutAc;
                this._default.ACValues.DiskTimeout = this._scheme.Active.Policy.user.SpindownTimeoutAc;
                this._default.ACValues.StandByTimeout = this._scheme.Active.Policy.user.IdleTimeoutAc;
                this._default.ACValues.HibernationTimeout = this._scheme.Active.Policy.mach.DozeS4TimeoutAc;
                this._default.ACValues.ThrottlePolicy = (PowerThrottlePolicy)this._scheme.Active.Policy.user.ThrottlePolicyAc;
                this._default.ACValues.DimTimeout = this._scheme.Active.DimTimeout;
            }
            catch (Exception /* err */) {
                // Nothing to do
            }
        }

        /* ----------------------------------------------------------------- */
        /// Load
        /* ----------------------------------------------------------------- */
        public bool Load(string path) {
            XmlDocument doc = new XmlDocument();
            try {
                doc.Load(path);
                XmlElement root = doc.DocumentElement;
                if (!root.HasChildNodes) return true;
                for (XmlNode child = root.FirstChild; child != null; child = child.NextSibling) {
                    if (child.Name == XML_DEFAULT_SETTING) this._default = this.GetScheduleItem(child);
                    else if (child.Name == XML_SCHEDULE) this.LoadSchedule(child);
                }
            }
            catch (Exception /* err */) {
                return false;
            }

            return true;
        }

        /* ----------------------------------------------------------------- */
        /// Save
        /* ----------------------------------------------------------------- */
        public bool Save(string path) {
            try {
                XmlDocument doc = new XmlDocument();
                XmlDeclaration declr = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                
                XmlElement root = doc.CreateElement(XML_ROOT);

                doc.AppendChild(declr);
                doc.AppendChild(root);

                XmlElement setting = doc.CreateElement(XML_DEFAULT_SETTING);
                XmlElement profile = doc.CreateElement(XML_PROFILE);
                profile.InnerText = this._default.ProfileName;
                setting.AppendChild(profile);
                this.SetPowerSetting(setting, doc, this._default);
                root.AppendChild(setting);

                XmlElement schedule = doc.CreateElement(XML_SCHEDULE);
                this.SetScheduleItem(schedule, doc, this._schedule);
                root.AppendChild(schedule);

                doc.Save(path);
            }
            catch (Exception /* err */) {
                return false;
            }

            return true;
        }

        /* ----------------------------------------------------------------- */
        //  各種プロパティ
        /* ----------------------------------------------------------------- */
        #region Properties

        /* ----------------------------------------------------------------- */
        /// Version
        /* ----------------------------------------------------------------- */
        public string Version {
            get { return this._version; }
            set { this._version = value; }
        }

        /* ----------------------------------------------------------------- */
        /// Scheme
        /* ----------------------------------------------------------------- */
        public IPowerScheme Scheme {
            get { return this._scheme; }
            set { this._scheme = value; }
        }

        /* ----------------------------------------------------------------- */
        /// Schedule
        /* ----------------------------------------------------------------- */
        public List<ScheduleItem> Schedule {
            get { return this._schedule; }
            set { this._schedule = value; }
        }

        /* ----------------------------------------------------------------- */
        /// DefaultSetting
        /* ----------------------------------------------------------------- */
        public ScheduleItem DefaultSetting {
            get { return this._default; }
            set { this._default = value; }
        }

        #endregion // Properties

        /* ----------------------------------------------------------------- */
        //  その他のメソッド
        /* ----------------------------------------------------------------- */
        #region Other methods

        /* ----------------------------------------------------------------- */
        /// LoadSchedule
        /* ----------------------------------------------------------------- */
        private void LoadSchedule(XmlNode root) {
            this._schedule.Clear();
            for (XmlNode child = root.FirstChild; child != null; child = child.NextSibling) {
                if (child.Name != XML_SCHEDULE_ITEM) continue;
                this._schedule.Add(this.GetScheduleItem(child));
            }
        }

        /* ----------------------------------------------------------------- */
        /// GetScheduleItem
        /* ----------------------------------------------------------------- */
        private ScheduleItem GetScheduleItem(XmlNode root) {
            ScheduleItem dest = new ScheduleItem();
            for (XmlNode child = root.FirstChild; child != null; child = child.NextSibling) {
                if (child.Name == XML_FIRST_TIME && child.HasChildNodes) dest.First = DateTime.Parse(child.ChildNodes[0].Value);
                else if (child.Name == XML_LAST_TIME && child.HasChildNodes) dest.Last = DateTime.Parse(child.ChildNodes[0].Value);
                else if (child.Name == XML_PROFILE && child.HasChildNodes) dest.ProfileName = child.ChildNodes[0].Value;
                else if (child.Name == XML_POWER_SETTING && child.HasChildNodes) dest.ACValues = this.GetPowerSetting(child);
            }
            return dest;
        }

        /* ----------------------------------------------------------------- */
        /// GetPowerSetting
        /* ----------------------------------------------------------------- */
        private PowerSetting GetPowerSetting(XmlNode root) {
            PowerSetting dest = new PowerSetting();
            for (XmlNode child = root.FirstChild; child != null; child = child.NextSibling) {
                if (child.Name == XML_MONITOR_TIMEOUT && child.HasChildNodes) dest.MonitorTimeout = UInt32.Parse(child.ChildNodes[0].Value);
                else if (child.Name == XML_DISK_TIMEOUT && child.HasChildNodes) dest.DiskTimeout = UInt32.Parse(child.ChildNodes[0].Value);
                else if (child.Name == XML_STANDBY_TIMEOUT && child.HasChildNodes) dest.StandByTimeout = UInt32.Parse(child.ChildNodes[0].Value);
                else if (child.Name == XML_HIBERNATION_TIMEOUT && child.HasChildNodes) dest.HibernationTimeout = UInt32.Parse(child.ChildNodes[0].Value);
                else if (child.Name == XML_DIM_TIMEOUT && child.HasChildNodes) dest.DimTimeout = UInt32.Parse(child.ChildNodes[0].Value);
                else if (child.Name == XML_BRIGHTNESS && child.HasChildNodes) dest.Brightness = UInt32.Parse(child.ChildNodes[0].Value);
                else if (child.Name == XML_DIM_BRIGHTNESS && child.HasChildNodes) dest.DimBrightness = UInt32.Parse(child.ChildNodes[0].Value);
                else if (child.Name == XML_PROCESSOR_POLICY && child.HasChildNodes) {
                    dest.ThrottlePolicy = (PowerThrottlePolicy)UInt32.Parse(child.ChildNodes[0].Value);
                    foreach (XmlAttribute attr in child.Attributes) {
                        if (attr.Name == "min") dest.MinThrottle = UInt32.Parse(attr.Value);
                        else if (attr.Name == "max") dest.MaxThrottle = UInt32.Parse(attr.Value);
                    }
                }
            }
            return dest;
        }

        /* ----------------------------------------------------------------- */
        /// SetScheduleItem
        /* ----------------------------------------------------------------- */
        private void SetScheduleItem(XmlNode root, XmlDocument doc, List<ScheduleItem> src) {
            foreach (ScheduleItem item in src) {
                XmlElement parent = doc.CreateElement(XML_SCHEDULE_ITEM);

                XmlElement first = doc.CreateElement(XML_FIRST_TIME);
                first.InnerText = item.First.ToString("HH:mm");
                parent.AppendChild(first);

                XmlElement last = doc.CreateElement(XML_LAST_TIME);
                last.InnerText = item.Last.ToString("HH:mm");
                parent.AppendChild(last);

                XmlElement name = doc.CreateElement(XML_PROFILE);
                name.InnerText = item.ProfileName;
                parent.AppendChild(name);

                this.SetPowerSetting(parent, doc, item);
                
                root.AppendChild(parent);
            }
        }

        /* ----------------------------------------------------------------- */
        /// SetPowerSetting
        /* ----------------------------------------------------------------- */
        private void SetPowerSetting(XmlNode root, XmlDocument doc, ScheduleItem src) {
            PowerSetting item = src.ACValues;
            XmlElement parent = doc.CreateElement(XML_POWER_SETTING);

            XmlElement monitor = doc.CreateElement(XML_MONITOR_TIMEOUT);
            monitor.InnerText = item.MonitorTimeout.ToString();
            parent.AppendChild(monitor);

            XmlElement disk = doc.CreateElement(XML_DISK_TIMEOUT);
            disk.InnerText = item.DiskTimeout.ToString();
            parent.AppendChild(disk);

            XmlElement standby = doc.CreateElement(XML_STANDBY_TIMEOUT);
            standby.InnerText = item.StandByTimeout.ToString();
            parent.AppendChild(standby);

            XmlElement hibernation = doc.CreateElement(XML_HIBERNATION_TIMEOUT);
            hibernation.InnerText = item.HibernationTimeout.ToString();
            parent.AppendChild(hibernation);

            XmlElement processor = doc.CreateElement(XML_PROCESSOR_POLICY);
            processor.InnerText = ((int)item.ThrottlePolicy).ToString();
            processor.SetAttribute("min", item.MinThrottle.ToString());
            processor.SetAttribute("max", item.MaxThrottle.ToString());
            parent.AppendChild(processor);

            XmlElement dim = doc.CreateElement(XML_DIM_TIMEOUT);
            dim.InnerText = item.DimTimeout.ToString();
            parent.AppendChild(dim);

            XmlElement brightness = doc.CreateElement(XML_BRIGHTNESS);
            brightness.InnerText = item.Brightness.ToString();
            parent.AppendChild(brightness);

            XmlElement dim_brightness = doc.CreateElement(XML_DIM_BRIGHTNESS);
            dim_brightness.InnerText = item.DimBrightness.ToString();
            parent.AppendChild(dim_brightness);

            root.AppendChild(parent);
        }

        #endregion // Other methods

        /* ----------------------------------------------------------------- */
        //  変数宣言
        /* ----------------------------------------------------------------- */
        #region Variables
        string _version = REG_VALUE_UNKNOWN;
        ScheduleItem _default = new ScheduleItem();
        List<ScheduleItem> _schedule = new List<ScheduleItem>();
        IPowerScheme _scheme;
        #endregion // Variables

        /* ----------------------------------------------------------------- */
        //  定数宣言
        /* ----------------------------------------------------------------- */
        #region Constant variables
        private const string REG_ROOT                   = @"Software\CubeSoft\CubePowerSaver";
        private const string REG_INSTALL_PATH           = "InstallPath";
        private const string REG_PRODUCT_VERSION        = "Version";
        private const string REG_VALUE_UNKNOWN          = "Unknown";
        private const string XML_ROOT                   = "cubepower";
        private const string XML_DEFAULT_SETTING        = "default";
        private const string XML_SCHEDULE               = "schedule";
        private const string XML_SCHEDULE_ITEM          = "item";
        private const string XML_FIRST_TIME             = "first";
        private const string XML_LAST_TIME              = "last";
        private const string XML_PROFILE                = "profile";
        private const string XML_POWER_SETTING          = "setting";
        private const string XML_MONITOR_TIMEOUT        = "monitor";
        private const string XML_DISK_TIMEOUT           = "disk";
        private const string XML_STANDBY_TIMEOUT        = "standby";
        private const string XML_HIBERNATION_TIMEOUT    = "hibernation";
        private const string XML_PROCESSOR_POLICY       = "processor";
        private const string XML_DIM_TIMEOUT            = "dim";
        private const string XML_BRIGHTNESS             = "brightness";
        private const string XML_DIM_BRIGHTNESS         = "dimbrightness";

        #endregion // Constant variables
    }
}