using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using Model;

namespace Controller.SignalR
{
    public class ProgrammingLanguagesHostedService : IHostedService, IDisposable
    {
        private readonly IHubContext<ProgrammingLanguagesHub> _programmingLanguageHub;
        private Timer _timer;

        public ProgrammingLanguagesHostedService(IHubContext<ProgrammingLanguagesHub> programmingLanguageHub)
        {
            _programmingLanguageHub = programmingLanguageHub;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(SendInfo, null, TimeSpan.Zero, TimeSpan.FromSeconds(2));
            return Task.CompletedTask;
        }

        private void SendInfo(object state)
        {
            IEnumerable<ProgrammingLanguage> programmingLanguage;

            using (var context = new BeadevContext())
            {
                programmingLanguage = context.ProgrammingLanguages.ToList();
            }

            try
            {
                var topThree = programmingLanguage.GroupBy(x => x.Name, d => d.SalaryRange)
              .Where(g => g.Count() > 0)
              .Select(y => new { Element = y.Key, Counter = y.Count(), SalaryRate = y.Average() })
              .OrderByDescending(r => r.Counter)
              .Take(3)
              .ToList();

                var topThreeSD = programmingLanguage.Where(q => q.Name == topThree[0].Element)
                    .GroupBy(x => x.StackDescription)
                    .Where(g => g.Count() > 1)
                    .Select(y => new { Element = y.Key, Counter = y.Count() })
                    .OrderByDescending(r => r.Counter)
                    .Take(1)
                    .ToList();

                var topThreeSD1 = programmingLanguage.Where(q => q.Name == topThree[1].Element)
                    .GroupBy(x => x.StackDescription)
                    .Where(g => g.Count() > 1)
                    .Select(y => new { Element = y.Key, Counter = y.Count() })
                    .OrderByDescending(r => r.Counter)
                    .Take(1)
                    .ToList();

                var topThreeSD2 = programmingLanguage.Where(q => q.Name == topThree[2].Element)
                    .GroupBy(x => x.StackDescription)
                    .Where(g => g.Count() > 1)
                    .Select(y => new { Element = y.Key, Counter = y.Count() })
                    .OrderByDescending(r => r.Counter)
                    .Take(1)
                    .ToList();
            
                List<dynamic> list = new List<dynamic>();

                var top1 = new
                {
                    Position = 1,
                    Name = topThree[0].Element,
                    Counter = topThree[0].Counter,
                    SalaryRate = topThree[0].SalaryRate,
                    topThreeStackDescList = topThreeSD[0].Element
                };

                var top2 = new
                {
                    Position = 2,
                    Name = topThree[1].Element,
                    Counter = topThree[1].Counter,
                    SalaryRate = topThree[1].SalaryRate,
                    topThreeStackDescList = topThreeSD1[0].Element
                };

                var top3 = new
                {
                    Position = 3,
                    Name = topThree[2].Element,
                    Counter = topThree[2].Counter,
                    SalaryRate = topThree[2].SalaryRate,
                    topThreeStackDescList = topThreeSD2[0].Element
                };

                list.Add(top1);
                list.Add(top2);
                list.Add(top3);
                _programmingLanguageHub.Clients.All.SendAsync("Receive", list);

            }
            catch (System.Exception)
            {
                _programmingLanguageHub.Clients.All.SendAsync("Receive", new List<dynamic>());
            }
        }
        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}