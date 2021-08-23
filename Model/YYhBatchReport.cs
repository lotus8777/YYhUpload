﻿//<auto-generated>
using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace YYhUpload.Model
{

    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false, ElementName = "messages")]
    public class YYhBatchReport
    {
        /// <summary>
        /// 用于检测服务活性，整型，可选值为0（非服务活性检测），1（服务活性检测），默认值为0
        /// </summary>
        public int heartbeat { get; set; } = 0;

        /// <summary>
        /// 用于消息交换的定义
        /// </summary>
        public BatchReportSwitchset switchset { get; set; }

        /// <summary>
        /// 用于装载服务提供者需要的入参数据
        /// </summary>
        public BatchReportBusiness business { get; set; }

        /// <summary>
        /// 必填：N 用于标准扩展或特殊业务需求
        /// </summary>
        public string extendset { get; set; } = "";
    }

  
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class BatchReportSwitchset
    {
     
        public BatchReportSwitchsetAuthority authority { get; set; }

   
        public BatchReportSwitchsetVisitor visitor { get; set; }

      
        public BatchReportSwitchsetServiceinf serviceinf { get; set; }

     
        public BatchReportSwitchsetProvider provider { get; set; }

        /// <summary>
        /// 用于记录服务路由信息，字符串，其格式为：
        /// （1）按服务编码路由：scenecode:serviceename [/route]
        /// （2）按机构编码路由：scenecode。其中，scenecode，serviceename由卫生服务总线管理员分配。
        /// </summary>
        public string route { get; set; } = "";

        /// <summary>
        /// 用于记录服务流程编排相关信息，字符串
        /// </summary>
        public string process { get; set; } = "";
    }

    //
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class BatchReportSwitchsetAuthority
    {
        /// <summary>
        /// 用于定义消息交换的安全配置类型，整型，可取值为0（无安全配置），1（使用用户名/密码），2（使用授权码），3（使用数字证书），9（其他安全配置），默认值为0
        /// </summary>
        public int authoritytype { get; set; } = 0;

        /// <summary>
        /// 用于存储服务提供方要求的用户名，字符串
        /// </summary>
        public string username { get; set; }

        /// <summary>
        /// 用于存储服务提供方要求的与用户名对应的密码，字符串
        /// </summary>
        public string userpwd { get; set; }

        /// <summary>
        /// 用于存储服务提供方要求的授权码，字符串
        /// </summary>
        public string license { get; set; }
    }

    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class BatchReportSwitchsetVisitor
    {
        /// <summary>
        /// 用于存储服务消费方所在机构编码，字符串
        /// </summary>
        public string sourceorgan { get; set; } = "3301110000000000000000";

        /// <summary>
        /// 用于存储服务消费方所使用的接入系统编码，字符串
        /// </summary>
        public string sourcedomain { get; set; } = "3301000029";
    }

    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class BatchReportSwitchsetServiceinf
    {
        /// <summary>
        /// 用于存储请求的服务在服务注册中心的唯一服务编码。servicecode在以下三种情况下取值不同，具体如下：
        /// 1. 第一种情况：服务提供方在开发服务时，取值为“服务编码”,即servicecode；
        /// 2. 第二种情况:服务调用方在使用服务时，通过卫生服务总线进行服务调用，取值为“场景编码:服务标识”，格式为scenecode:serviceename；
        /// 3. 第三种情况:服务调用方在使用服务时，直接调用服务（即不通过卫生服务总线进行服务调用），取值为“服务编码”，即servicecode。
        /// 以上描述中的“场景编码”、“服务标识”、“服务编码”由卫生服务总线管理员分配
        /// </summary>
        public string servicecode { get; set; } = "";
    }

    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class BatchReportSwitchsetProvider
    {
        /// <summary>
        /// 用于存储服务提供方所在的机构编码，字符串
        /// </summary>
        public string targetorgan { get; set; } = "";

        /// <summary>
        /// 用于存储服务提供方所在的接入系统编码，字符串
        /// </summary>
        public string targetdomain { get; set; } = "";
    }

    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class BatchReportBusiness
    {
        /// <summary>
        /// 用于设置服务提供者入参数据所依赖的交换标准在标准管理系统中的编码，字符串
        /// </summary>
        public string standardcode { get; set; } = "";

        /// <summary>
        /// 用于定义数据请求时数据查询条件和返回数据的分页设置参数
        /// </summary>
        public BatchReportBusinessRequestset requestset { get; set; }

        /// <summary>
        /// 用于定义服务提供方要求的入参业务数据是否进行压缩，0（不压缩），1（压缩），默认值为0
        /// </summary>
        public int datacompress { get; set; } = 0;

        /// <summary>
        /// 用于设置采集任务的标识号
        /// </summary>
        public string daqtaskid { get; set; } = "";

        /// <summary>
        /// 用于装载服务提供方所要求的入参业务数据
        /// </summary>
        public string businessdata { get; set; } = "";
    }

    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class BatchReportBusinessRequestset
    {
        /// <summary>
        /// 用于记录用于数据查询的条件/用于单条数据查询条件
        /// </summary>
        public BatchReportReqcondition reqcondition { get; set; }

        /// <summary>
        /// 用于定义返回数据时是否进行分页处理，整型，0（不分页），1（分页），默认值为0
        /// </summary>
        public int reqpaging { get; set; } = 0;

        /// <summary>
        /// 用于定义返回分页数据时返回的页索引，整型，必须大于等于-1，默认值为-1
        /// </summary>
        public int reqpageindex { get; set; } = -1;

        /// <summary>
        /// 用于定义返回分页数据时页的数据行数，整型，必须大于等于0，默认值为0
        /// </summary>
        public int reqpageset { get; set; } = 0;
    }

    //
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class BatchReportReqcondition
    {
        //
        public BatchReportReqconditionCondition condition { get; set; }
    }

    //
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class BatchReportReqconditionCondition
    {
        /// <summary>
        /// 码值描述（0:增量采集）
        /// 增量上传数据（定时触发上传）：填写0
        /// </summary>
        public int collecttype { get; set; } = 0;
    }
}
