using System;
using System.Collections.Generic;
using System.Text;

namespace CubePower {
    public class Scheduler {
        public Scheduler() {
            OperatingSystem info = Environment.OSVersion;
            if (info.Version.Major > 5) this._scheme = new PowerSchemeVista();
            else this._scheme = new PowerSchemeXP();
        }

        public void Execute() {
            UserSetting setting = new UserSetting();
            System.Reflection.Assembly exec = System.Reflection.Assembly.GetEntryAssembly();
            string dir = System.IO.Path.GetDirectoryName(exec.Location);
            setting.Load(dir + @"\cubepower.xml");

            this.Update(setting.DefaultSetting);

            int index = 0;
            
            // 実行時点で既に時間の過ぎているスケジュールを順に適用していく．
            while (index < setting.Schedule.Count && IsPassed(setting.Schedule[index].First)) {
                this.Update(setting.Schedule[index]);
                index++;
            }

            for (; index < setting.Schedule.Count; index++) {
                DateTime now = DateTime.Now;
                DateTime compared = setting.Schedule[index].First;
                TimeSpan span = compared.TimeOfDay - now.TimeOfDay;
                System.Threading.Thread.Sleep((int)span.TotalMilliseconds);
                this.Update(setting.Schedule[index]);

                // スケジュールの終了時刻までスリープしてデフォルト設定に戻す
                compared = setting.Schedule[index].Last;
                span = compared - now;
                System.Threading.Thread.Sleep((int)span.TotalMilliseconds);
                this.Update(setting.DefaultSetting);
            }
        }

        private bool IsPassed(DateTime compared) {
            DateTime now = DateTime.Now;
            return now.TimeOfDay > compared.TimeOfDay;
        }

        private bool Update(ScheduleItem item) {
            PowerSchemeItem elem = this._scheme.Active;
            elem.Name = CUBEPOWER_PROFILENAME;
            elem.Description = CUBEPOWER_DESCRIPTION;
            POWER_POLICY policy = elem.Policy;
            policy.user.VideoTimeoutAc = item.ACValues.MonitorTimeout;
            policy.user.SpindownTimeoutAc = item.ACValues.DiskTimeout;
            policy.user.IdleTimeoutAc = item.ACValues.StandByTimeout;
            policy.mach.DozeS4TimeoutAc = item.ACValues.HibernationTimeout;
            elem.Policy = policy;

            bool status = true;
            if (this._scheme.Find(CUBEPOWER_PROFILENAME) == null) status &= this._scheme.Add(elem);
            else status &= this._scheme.Update(elem);
            status &= this._scheme.Activate(elem.Name);

            return status;
        }
        
        private IPowerScheme _scheme;
        private static readonly string CUBEPOWER_PROFILENAME = "CubePowerSaver の電源設定";
        private static readonly string CUBEPOWER_DESCRIPTION = "CubePowerSaver によって管理されている電源設定です。";
    }
}
