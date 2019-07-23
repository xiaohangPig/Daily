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
        //持续天数
        public int? Duration { get; set; }
        //邮箱
        public string Email { get; set; }
        //重复频率
        public int Period { get; set; }
        //新重复天数
        public int? NewPeriod { get; set; }
        //新重复开始时间
        public DateTime? NewPeriodTime { get; set; }
    }
}
