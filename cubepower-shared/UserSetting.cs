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

        #endregion // Properties

        /* ----------------------------------------------------------------- */
        //  変数宣言
        /* ----------------------------------------------------------------- */
        #region Variables
        uint _monitor = 0;
        uint _disk = 0;
        uint _standby = 0;
        uint _hibernation = 0;
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
            OperatingSystem info = Environment.OSVersion;
            if (info.Version.Major > 5) this._scheme = new PowerSchemeVista();
            else this._scheme = new PowerSchemeXP();
            this._default.ProfileName = this._scheme.Active.Name;
            this._default.ACValues.MonitorTimeout = this._scheme.Active.Policy.user.VideoTimeoutAc;
            this._default.ACValues.DiskTimeout = this._scheme.Active.Policy.user.SpindownTimeoutAc;
            this._default.ACValues.StandByTimeout = this._scheme.Active.Policy.user.IdleTimeoutAc;
            this._default.ACValues.HibernationTimeout = this._scheme.Active.Policy.mach.DozeS4TimeoutAc;
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

            root.AppendChild(parent);
        }

        #endregion // Other methods

        /* ----------------------------------------------------------------- */
        //  変数宣言
        /* ----------------------------------------------------------------- */
        #region Variables
        ScheduleItem _default = new ScheduleItem();
        List<ScheduleItem> _schedule = new List<ScheduleItem>();
        IPowerScheme _scheme;
        #endregion // Variables

        /* ----------------------------------------------------------------- */
        //  定数宣言
        /* ----------------------------------------------------------------- */
        #region Constant variables
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
        #endregion // Constant variables
    }
}