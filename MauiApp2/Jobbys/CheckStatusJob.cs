using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Shiny.Jobs;
using ShinyJobs = Shiny.Jobs;

namespace SlotShark.MobileApp.Core.Jobs
{
    public class FartJob : ShinyJobs.IJob
    {
        public Task Run(JobInfo jobInfo, CancellationToken cancelToken)
        {
            throw new NotImplementedException();
        }
    }
    public class CheckStatusJob : Job// ShinyJobs.IJob
    {
        /// <doc>
        /// <assembly>
        /// <name>Shiny.Jobs</name>
        /// </assembly>
        /// <members>
        /// <member name="F:Shiny.Jobs.PowerState.Unknown">
        /// <summary>
        /// Power state hasn't been checked yet or it is in an unknown state
        /// </summary>
        /// </member>
        public CheckStatusJob(ILogger logger)
            : base(logger)
        {
        }

        protected override Task Run(CancellationToken cancelToken)
        {
            throw new NotImplementedException();
        }

        public async Task Run(ShinyJobs.JobInfo jobInfo, CancellationToken cancelToken)
        {
            int loops = 5;
            for (var i = 0; i < loops; i++)
            {
                if (cancelToken.IsCancellationRequested)
                    break;

                await Task.Delay(1000, cancelToken).ConfigureAwait(false);
            }
        }

        public static JobInfo GetJobInfo(IServiceCollection services)
        {
            var job = new JobInfo("", typeof(CheckStatusJob), RunOnForeground: true, RequiredInternetAccess: InternetAccess.Any);

            return job;

            //var job = new JobInfo
            //{
            //    Name = "YourJobName",
            //    Type = typeof(YourJob),

            //    // these are criteria that must be met in order for your job to run
            //    BatteryNotLow = true,
            //    DeviceCharging = false,
            //    RunInForeground = true,
            //    NetworkType = NetworkType.Any,
            //    Repeat = true; //defaults to true, set to false to run once OR set it inside a job to cancel further execution
            //};
        }
    }
}
