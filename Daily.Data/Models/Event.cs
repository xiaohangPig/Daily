using System;
using System.ComponentModel.DataAnnotations;

namespace Daily.Data.Models
{
    //事件类
    public class Event
    {
        //事件ID
        [Required]
        [Display(Name = "事件ID")]
        public int EventId { get; set; }
        //描述
        [Required]
        [Display(Name = "描述")]
        public string Describe { get; set; }
        //概要
        [Required]
        [Display(Name = "概要")]
        public string Summary { get; set; }
        //起始时间
        [Required]
        [Display(Name = "起始时间")]
        public DateTime StartTime { get; set; }        
        //持续天数
        [Display(Name = "持续天数")]
        public int? Duration { get; set; }
        //邮箱
        [Display(Name = "邮箱")]
        public string Email { get; set; }
        //重复频率
        [Required]
        [Display(Name = "重复频率")]
        public int Period { get; set; }
        //新重复天数
        [Display(Name = "新重复天数")]
        public int? NewPeriod { get; set; }
        //新重复开始时间
        [Display(Name = "新重复开始时间")]
        public DateTime? NewPeriodTime { get; set; }

        public Calendar Calendar { get; set; }

    }
}