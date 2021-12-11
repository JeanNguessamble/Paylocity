using System;

namespace Paylocity.Common
{
    public class Entity
    {
        public class request
        {
            public int id;
            public string action;
            public string body;
        }
        public class response
        {
            public status status;
            public int count;
            public object data;
        }
        public class status
        {
            public Enums.status code;
            public string detail;
            public string message { get { return code.ToString(); } }
        }
        public class company
        {
            public int id;
            public string name;
            public Enums.PayFrequency pay_frequency;
            public DateTime? date;
            public bool active;
            public string _date { get { return date == null || !date.HasValue ? "" : date.Value.ToShortDateString(); } }
        }
        public class name
        {
            public string first;
            public string last;
            public string full { get { return first + " " + last; } }
        }
        public class pay_check
        {
            public int id;
            public employee employee;
            public decimal amount;
            public DateTime? date;
            public string _date { get { return date == null || !date.HasValue ? "" : date.Value.ToShortDateString(); } }
        }
        public class employee
        {
            public int id;
            public company company;
            public name name;
            public DateTime? date;
            public bool active;
            public string _date { get { return date == null || !date.HasValue ? "" : date.Value.ToShortDateString(); } }
        }
        public class check_frequency
        {
            public int id;
            public employee employee;
            public int frequency;
        }
        public class deduction
        {
            public int id;
            public company company;
            public decimal employee;
            public decimal dependent;
        }
        public class dependent
        {
            public int? id;
            public employee employee;
            public name name;
            public Enums.relationship? relationship;
        }
        public class log
        {
            public class contribution
            {
                public int id;
                public deduction deduction;
                public pay_check pay_check;
                public decimal amount;
                public DateTime? date;
                public string _date { get { return date == null || !date.HasValue ? "" : date.Value.ToShortDateString(); } }
            }
            public class pay_check
            {
                public int id;
                public employee employee;
                public decimal amount;
                public DateTime? date;
                public string _date { get { return date == null || !date.HasValue ? "" : date.Value.ToShortDateString(); } }
            }
        }
    }
}
