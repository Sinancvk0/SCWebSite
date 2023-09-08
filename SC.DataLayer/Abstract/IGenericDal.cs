﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;       
using System.Threading.Tasks;

namespace SC.DataLayer.Abstract
{
    public interface IGenericDal<T>where T : class
    {
        void Insert(T t);
        void Delete(T t);
        void Update(T t);
        List<T> GetList();
        T GetById(int id);
    }
}
