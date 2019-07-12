using Daily.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Daily.Data
{
    public interface IEventService
    {
        //获取所有列表
        IEnumerable<Event> GetAll();
        //根据ID获取
        Event Get(int id);
        //添加
        void Add(Event newEvent);
        //根据ID删除
        void DeletById(int id);
        //根据ID更新
        void UpdateById(int id);
    }
}
