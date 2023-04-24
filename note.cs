using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eee
{
    internal class Note
    {
        private string name, type;
        private int price;
        private bool accounting;
        private DateTime date;
        public Note(string name, string type, int price, bool accounting, DateTime date)
        {
            this.Date = date;
            this.Name = name;
            this.Type = type;
            this.Price = price;
            this.Accounting = accounting;
        }
        public string Name { get; private set; }
        public string Type { get; private set; }
        public int Price { get; private set; }
        public bool Accounting
        {
            get { return accounting; }
            set
            {
                if (Price > 0)
                {
                    accounting = true;
                }
                else
                {
                    accounting = false;
                }
            }
        }
        public DateTime Date { get; set; }
    }
}