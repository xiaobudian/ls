﻿using ls.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ls.webbase
{
    /// <summary>
    /// 数据处理初始化器，反射程序集进行功能信息，实体信息的数据初始化
    /// </summary>
    public class DataHandlerInitializer : IDataHandlerInitializer
    {
        //private IFunctionHandler _functionHandler;
        private IEntityInfoHandler _entityInfoHandler;

        /// <summary>
        /// 初始化一个<see cref="DataHandlerInitializer"/>类型的新实例
        /// </summary>
        public DataHandlerInitializer()
        {
            //FunctionHandler = new DefaultFunctionHandler();
            EntityInfoHandler = new DefaultEntityInfoHandler();
        }

        /// <summary>
        /// 获取或设置 功能信息处理器
        /// </summary>
        //public IFunctionHandler FunctionHandler
        //{
        //    get { return _functionHandler; }
        //    set
        //    {
        //        _functionHandler = value;
        //        OSharpContext.Current.FunctionHandler = value;
        //    }
        //}

        /// <summary>
        /// 获取或设置 数据实体信息处理器
        /// </summary>
        public IEntityInfoHandler EntityInfoHandler
        {
            get { return _entityInfoHandler; }
            set
            {
                _entityInfoHandler = value;
                OSharpContext.Current.EntityInfoHandler = value;
            }
        }

        /// <summary>
        /// 执行数据处理初始化
        /// </summary>
        public void Initialize()
        {
            //FunctionHandler.Initialize();
            EntityInfoHandler.Initialize();
        }
    }
}