/* ------------------------------------------------------------------------- */
/*
 *  Parameter.cs
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

namespace CubePower {
    /* --------------------------------------------------------------------- */
    /// Parameter
    /* --------------------------------------------------------------------- */
    public abstract class Parameter {
        public enum ExpireTypes : int {
            One,            // 1分後
            Two,            // 2分後
            Three,          // 3分後
            Five,           // 5分後
            Ten,            // 10分後
            Fifteen,        // 15分後
            Twenty,         // 20分後
            TwentyFive,     // 25分後
            Thrity,         // 30分後
            FortyFive,      // 45分後
            OneHour,        // 1時間後
            TwoHour,        // 2時間後
            ThreeHour,      // 3時間後
            FourHour,       // 4時間後
            FiveHour,       // 5時間後
            None,           // なし
        }
    }
    
    /* --------------------------------------------------------------------- */
    ///
    /// Translator
    ///
    /// <summary>
    /// Parameter とコンボボックスの値を相互変換するための関数を集めた
    /// クラス．
    /// </summary>
    ///
    /* --------------------------------------------------------------------- */
    public abstract class Translator {
        public static int ExpireTypeToIndex(Parameter.ExpireTypes id) {
            return (int)id;
        }

        public static Parameter.ExpireTypes IndexToExpireType(int index) {
            return (Parameter.ExpireTypes)index;
        }

        public static Parameter.ExpireTypes SecondToExpireType(uint sec) {
            if (sec == 0) return Parameter.ExpireTypes.None;
            else if (sec < 2 * 60) return Parameter.ExpireTypes.One;
            else if (sec < 3 * 60) return Parameter.ExpireTypes.Two;
            else if (sec < 5 * 60) return Parameter.ExpireTypes.Three;
            else if (sec < 10 * 60) return Parameter.ExpireTypes.Five;
            else if (sec < 15 * 60) return Parameter.ExpireTypes.Ten;
            else if (sec < 20 * 60) return Parameter.ExpireTypes.Fifteen;
            else if (sec < 25 * 60) return Parameter.ExpireTypes.Twenty;
            else if (sec < 30 * 60) return Parameter.ExpireTypes.TwentyFive;
            else if (sec < 45 * 60) return Parameter.ExpireTypes.Thrity;
            else if (sec < 60 * 60) return Parameter.ExpireTypes.FortyFive;
            else if (sec < 2 * 60 * 60) return Parameter.ExpireTypes.OneHour;
            else if (sec < 3 * 60 * 60) return Parameter.ExpireTypes.TwoHour;
            else if (sec < 4 * 60 * 60) return Parameter.ExpireTypes.ThreeHour;
            else if (sec < 5 * 60 * 60) return Parameter.ExpireTypes.FourHour;
            
            return Parameter.ExpireTypes.FiveHour;
        }

        public static uint ExpireTypeToSecond(Parameter.ExpireTypes id) {
            switch (id) {
            case Parameter.ExpireTypes.One: return 60;
            case Parameter.ExpireTypes.Two: return 2 * 60;
            case Parameter.ExpireTypes.Three: return 3 * 60;
            case Parameter.ExpireTypes.Five: return 5 * 60;
            case Parameter.ExpireTypes.Ten: return 10 * 60;
            case Parameter.ExpireTypes.Fifteen: return 15 * 60;
            case Parameter.ExpireTypes.Twenty: return 20 * 60;
            case Parameter.ExpireTypes.TwentyFive: return 25 * 60;
            case Parameter.ExpireTypes.Thrity: return 30 * 60;
            case Parameter.ExpireTypes.FortyFive: return 45 * 60;
            case Parameter.ExpireTypes.OneHour: return 60 * 60;
            case Parameter.ExpireTypes.TwoHour: return 2 * 60 * 60;
            case Parameter.ExpireTypes.ThreeHour: return 3 * 60 * 60;
            case Parameter.ExpireTypes.FourHour: return 4 * 60 * 60;
            case Parameter.ExpireTypes.FiveHour: return 5 * 60 * 60;
            default: break;
            }
            return 0;
        }

        public static int PowerThrottlePolicyToIndex(PowerThrottlePolicy id) {
            switch (id) {
            case PowerThrottlePolicy.PO_THROTTLE_NONE: return 0;
            case PowerThrottlePolicy.PO_THROTTLE_CONSTANT: return 1;
            case PowerThrottlePolicy.PO_THROTTLE_ADAPTIVE: return 2;
            default: break;
            }
            return 2;
        }

        public static PowerThrottlePolicy IndexToPowerThrottlePolicy(int index) {
            switch (index) {
            case 0: return PowerThrottlePolicy.PO_THROTTLE_NONE;
            case 1: return PowerThrottlePolicy.PO_THROTTLE_CONSTANT;
            case 2: return PowerThrottlePolicy.PO_THROTTLE_ADAPTIVE;
            default: break;
            }
            return PowerThrottlePolicy.PO_THROTTLE_ADAPTIVE;
        }
    }
    
    /* --------------------------------------------------------------------- */
    /// Appearance
    /* --------------------------------------------------------------------- */
    public abstract class Appearance {
        public static string ExpireTypeString(Parameter.ExpireTypes id) {
            switch (id) {
            case Parameter.ExpireTypes.One: return "1分後";
            case Parameter.ExpireTypes.Two: return "2分後";
            case Parameter.ExpireTypes.Three: return "3分後";
            case Parameter.ExpireTypes.Five: return "5分後";
            case Parameter.ExpireTypes.Ten: return "10分後";
            case Parameter.ExpireTypes.Fifteen: return "15分後";
            case Parameter.ExpireTypes.Twenty: return "20分後";
            case Parameter.ExpireTypes.TwentyFive: return "25分後";
            case Parameter.ExpireTypes.Thrity: return "30分後";
            case Parameter.ExpireTypes.FortyFive: return "45分後";
            case Parameter.ExpireTypes.OneHour: return "1時間後";
            case Parameter.ExpireTypes.TwoHour: return "2時間後";
            case Parameter.ExpireTypes.ThreeHour: return "3時間後";
            case Parameter.ExpireTypes.FourHour: return "4時間後";
            case Parameter.ExpireTypes.FiveHour: return "5時間後";
            default: break;
            }
            return "なし";
        }

        public static string PowerThrottlePolicyString(PowerThrottlePolicy id) {
            switch (id) {
            case PowerThrottlePolicy.PO_THROTTLE_NONE: return "最大のパフォーマンス";
            case PowerThrottlePolicy.PO_THROTTLE_CONSTANT: return "最小のパフォーマンス";
            case PowerThrottlePolicy.PO_THROTTLE_DEGRADE: return "バッテリの低下に応じる";
            case PowerThrottlePolicy.PO_THROTTLE_ADAPTIVE: return "パフォーマンスを動的に変更";
            default: break;
            }
            return "不明";
        }
    }
}
