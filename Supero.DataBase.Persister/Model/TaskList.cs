using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Supero.DataBase.Persister.Model
{
    [Table("TaskList", Schema = "public")]

    public class TaskList
    {

        public TaskList()
        {

        }

        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("title")]
        public string Title { get; set; }

        [Column("status")]
        public string Status { get; set; }

        [Column("creation_date")]
        public DateTime CreationDate { get; set; }

        [Column("last_edit")]
        public DateTime LastEdit { get; set; }

        [Column("removed_on")]
        public DateTime RemovedOn { get; set; }

        [Column("conclusion")]
        public DateTime Conclusion { get; set; }

    }
}
