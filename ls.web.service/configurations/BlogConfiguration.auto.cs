﻿// <autogenerated>
//   This file was generated by T4 code generator ConfigurationTextTemplate.tt.
//   Any changes made to this file manually will be lost next time the file is regenerated.
// </autogenerated>

// BlogConfiguration
// 刘帅   849351660@qq.com
// 09/18/2015 18:41:30 Copyright © . All Rights Reserved.
using ls.web.service.models;
using System;
using ls.core;

namespace ls.web.service.configurations
{
    public partial class BlogConfiguration : EntityConfigurationBase<Blog, Int32>
    {
        public BlogConfiguration()
        {
            BlogConfigurationAppend();
        }
		partial void BlogConfigurationAppend();
    }
}
