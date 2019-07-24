using System;
using SQLite;

namespace XamCalc.Models
{
    public class Entry
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Text { get; set; }
        public string Result { get; set; }
        public DateTime Date { get; set; }
    }
}