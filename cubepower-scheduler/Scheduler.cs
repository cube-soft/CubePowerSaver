using System;
using System.Collections.Generic;
using System.Text;

namespace CubePower {
    public class Scheduler {
        public Scheduler() {
            string dir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            dir += @"\CubeSoft\CubePowerSaver";
            string path = dir + @"\cubepower.xml";
            if (System.IO.File.Exists(path)) this._setting.Load(path);
        }

        public void Execute() {
            this.Update(this._setting.DefaultSetting);

            int index = 0;
            while (this._setting.Schedule.Count > 0) {
                DateTime now   = DateTime.Now;
                DateTime first = DateTime.Parse(this._setting.Schedule[index].First.ToString("HH:mm"));
                DateTime last  = DateTime.Parse(this._setting.Schedule[index].Last.ToString("HH:mm"));
                if (first > last) last = last.AddDays(1);

                if (now > first && now > last) {
                    index++;
                    if (index >= this._setting.Schedule.Count) {
                        DateTime tomorrow = DateTime.Parse("00:00");
                        tomorrow = tomorrow.AddDays(1);
                        this.Sleep(tomorrow);
                        index = 0;
                    }
                    continue;
                }

                if (now < first) this.Sleep(first);
                this.Update(this._setting.Schedule[index]);
                this.Sleep(last);
                this.Update(this._setting.DefaultSetting);

                index++;
                if (index >= this._setting.Schedule.Count) index = 0;
            }
        }

        public void Reset() {
            this.Update(this._setting.DefaultSetting);
        }

        private void Sleep(DateTime expire) {
            TimeSpan upper_limit = new TimeSpan(0, 10, 0);
            do {
                TimeSpan span = expire - DateTime.Now;
                System.Threading.Thread.Sleep(span < upper_limit ? span : upper_limit);
            } while (DateTime.Now < expire);
        }

        private bool Update(ScheduleItem item) {
            PowerSchemeItem elem = new PowerSchemeItem();
            elem.Name = CUBEPOWER_PROFILENAME;
            elem.Description = CUBEPOWER_DESCRIPTION;
            POWER_POLICY policy = elem.Policy;
            policy.user.VideoTimeoutAc = item.ACValues.MonitorTimeout;
            policy.user.SpindownTimeoutAc = item.ACValues.DiskTimeout;
            policy.user.IdleTimeoutAc = item.ACValues.StandByTimeout;
            policy.mach.DozeS4TimeoutAc = item.ACValues.HibernationTimeout;
            policy.user.ThrottlePolicyAc = (byte)item.ACValues.ThrottlePolicy;
            elem.Policy = policy;
            elem.DimTimeout = item.ACValues.DimTimeout;
            elem.Brightness = item.ACValues.Brightness;
            elem.DimBrightness = item.ACValues.DimBrightness;

            bool status = true;
            if (this._setting.Scheme.Find(CUBEPOWER_PROFILENAME) == null) status &= this._setting.Scheme.Add(elem);
            else status &= this._setting.Scheme.Update(elem);
            status &= this._setting.Scheme.Activate(elem.Name);
            
            return status;
        }
        
        private UserSetting _setting = new UserSetting();
        private static readonly string CUBEPOWER_PROFILENAME = "CubePowerSaver の電源設定";
        private static readonly string CUBEPOWER_DESCRIPTION = "CubePowerSaver によって管理されている電源設定です。";
    }
}
