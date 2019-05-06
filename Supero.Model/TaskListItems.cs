using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supero.Model
{
    public class TaskListItems
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public string Status { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime LastEdit { get; set; }

        public DateTime RemovedOn { get; set; }

        public DateTime Conclusion { get; set; }

    }
}
