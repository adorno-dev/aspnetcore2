using AspnetCore2.Mvc.DependencyInjections.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetCore2.Mvc.DependencyInjections.Data.Services
{
    public class StatisticService
    {
        private readonly ITodoItemRepository _repository;

        public StatisticService(ITodoItemRepository repository) => _repository = repository;

        public int GetCount() => _repository.List().Count();

        public int GetCompletedCount() => _repository.List().Count(c => c.IsDone);

        public double GetAveragePriority() => _repository.List().Count().Equals(0) ? .0 : _repository.List().Average(a => a.Priority);
    }
}
