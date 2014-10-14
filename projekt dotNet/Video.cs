using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt_dotNet
{
    public class Video
    {
        [Key]
        public int Id { get; set; }
        public string FileName { get; set; }
        public DateTime AddedTime { get; set; }
        public string Extension { get; set; }
        public long Lenght { get; set; }
        //public FileStream VidFile { get; set; }
    }
}
