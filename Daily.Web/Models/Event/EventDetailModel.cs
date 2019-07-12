using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Daily.Web.Models.Event
{
    public class EventDetailModel
    {
        //事件ID
        public int EventId { get; set; }
        //描述
        public string Describe { get; set; }
        //概要
        public string Summary { get; set; }
        //起始时间
        public DateTime StartTime { get; set; }
        //持续时间
        public DateTime? Duration { get; set; }
        //邮箱
        public string Email { get; set; }
        //周期
        public DateTime Period { get; set; }
        //新周期
        public DateTime? NewPeriod { get; set; }
        //新周期时间
        public DateTime? NewPeriodTime { get; set; }
    }
}
