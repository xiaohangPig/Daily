using System;
using System.ComponentModel.DataAnnotations;

namespace Daily.Data.Models
{
    //事件类
    public class Event
    {
        //事件ID
        [Required]
        [Display(Name = "EventId")]
        public int EventId { get; set; }
        //描述
        [Required]
        [Display(Name = "Describe")]
        public string Describe { get; set; }
        //概要
        [Required]
        [Display(Name = "Summary")]
        public string Summary { get; set; }
        //起始时间
        [Required]
        [Display(Name = "StartTime")]
        public DateTime StartTime { get; set; }        
        //持续时间
        [Display(Name = "Duration")]
        public DateTime? Duration { get; set; }
        //邮箱
        [Display(Name = "Email")]
        public string Email { get; set; }
        //周期
        [Required]
        [Display(Name = "Period")]
        public DateTime Period { get; set; }
        //新周期
        [Display(Name = "NewPeriod")]
        public DateTime? NewPeriod { get; set; }
        //新周期时间
        [Display(Name = "NewPeriodTime")]
        public DateTime? NewPeriodTime { get; set; }

    }
}