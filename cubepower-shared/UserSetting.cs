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
            get { return this._First; }
            set { this._First = value; }
        }

        /* ----------------------------------------------------------------- */
        /// Last
        /* ----------------------------------------------------------------- */
        public DateTime Last {
            get { return this._Last; }
            set { this._Last = value; }
        }

        /* ----------------------------------------------------------------- */
        /// ProfileName
        /* ----------------------------------------------------------------- */
        public string ProfileName {
            get { return this._ProfileName; }
            set { this._ProfileName = value; }
        }

        #endregion // Properties

        /* ----------------------------------------------------------------- */
        //  変数宣言
        /* ----------------------------------------------------------------- */
        #region Variables
        DateTime _First = DateTime.Parse("00:00");
        DateTime _Last  = DateTime.Parse("23:59");
        string _ProfileName = "";
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
            this._Scheme = new PowerScheme();
            this._DefaultSetting.ProfileName = this._Scheme.Active.Name;
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
                    if (child.Name == XML_DEFAULT_SETTING) this.LoadDefaultSetting(child);
                    else if (child.Name == XML_SCHEDULE) this.LoadSchedule(child);
                }
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
        public PowerScheme Scheme {
            get { return this._Scheme; }
            set { this._Scheme = value; }
        }

        /* ----------------------------------------------------------------- */
        /// Schedule
        /* ----------------------------------------------------------------- */
        public List<ScheduleItem> Schedule {
            get { return this._Schedule; }
            set { this._Schedule = value; }
        }

        /* ----------------------------------------------------------------- */
        /// DefaultSetting
        /* ----------------------------------------------------------------- */
        public ScheduleItem DefaultSetting {
            get { return this._DefaultSetting; }
            set { this._DefaultSetting = value; }
        }

        #endregion // Properties

        /* ----------------------------------------------------------------- */
        //  その他のメソッド
        /* ----------------------------------------------------------------- */
        #region Other methods

        /* ----------------------------------------------------------------- */
        /// LoadDefaultSetting
        /* ----------------------------------------------------------------- */
        private void LoadDefaultSetting(XmlNode root) {
            for (XmlNode child = root.FirstChild; child != null; child = child.NextSibling) {
                if (child.Name == XML_PROFILE && child.HasChildNodes && this._Scheme.Find(child.ChildNodes[0].Value) != null) {
                    this._DefaultSetting.ProfileName = child.ChildNodes[0].Value;
                }
            }
        }

        /* ----------------------------------------------------------------- */
        /// LoadSchedule
        /* ----------------------------------------------------------------- */
        private void LoadSchedule(XmlNode root) {
            for (XmlNode child = root.FirstChild; child != null; child = child.NextSibling) {
                if (child.Name != XML_SCHEDULE_ITEM) continue;
                this._Schedule.Add(this.GetScheduleItem(child));
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
            }
            return dest;
        }

        #endregion // Other methods

        /* ----------------------------------------------------------------- */
        //  変数宣言
        /* ----------------------------------------------------------------- */
        #region Variables
        ScheduleItem _DefaultSetting = new ScheduleItem();
        List<ScheduleItem> _Schedule = new List<ScheduleItem>();
        PowerScheme _Scheme;
        #endregion // Variables

        /* ----------------------------------------------------------------- */
        //  定数宣言
        /* ----------------------------------------------------------------- */
        #region Constant variables
        private const string XML_ROOT = "cubepower";
        private const string XML_DEFAULT_SETTING = "default";
        private const string XML_SCHEDULE = "schedule";
        private const string XML_SCHEDULE_ITEM = "item";
        private const string XML_FIRST_TIME = "first";
        private const string XML_LAST_TIME = "last";
        private const string XML_PROFILE = "profile";
        #endregion // Constant variables
    }
}