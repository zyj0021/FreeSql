﻿//using FreeSql.Site.Entity;
using FreeSql.Site.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace FreeSql.Site.DAL
{
    public class DocumentTypeDAL
    {
        /// <summary>
        /// 新增方法
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public long Insert(DocumentType model)
        {
            return DataBaseType.MySql.DB().Insert<DocumentType>(model).ExecuteIdentity();
        }

        /// <summary>
        /// 修改方法
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(DocumentType model)
        {
            return DataBaseType.MySql.DB().Update<DocumentType>(model.ID).ExecuteUpdated().Count > 0;
        }

        /// <summary>
        /// 删除方法
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(long id)
        {
            return DataBaseType.MySql.DB().Delete<DocumentType>(id).ExecuteDeleted().Count > 0;
        }

        /// <summary>
        /// 获取一条数据
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DocumentType GetByOne(Expression<Func<DocumentType, bool>> where)
        {
            return DataBaseType.MySql.DB().Select<DocumentType>()
                 .Where(where).ToOne();
        }

        /// <summary>
        /// 查询方法
        /// </summary>
        /// <param name="where"></param>
        /// <param name="orderby"></param>
        /// <returns></returns>
        public List<DocumentType> Query(Expression<Func<DocumentType, bool>> where,
            Expression<Func<DocumentType, DocumentType>> orderby = null)
        {
            var list = DataBaseType.MySql.DB().Select<DocumentType>()
                .Where(where);
            if (orderby != null) list = list.OrderBy(b => b.CreateDt);
            return list.ToList();
        }
    }
}