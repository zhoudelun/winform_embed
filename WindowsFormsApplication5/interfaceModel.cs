/*----------------------------------------------------------------
// 文件功能描述： 接口对应关系类
//  
//
// 创建标识：2021-12-29 by kevin
//
// 修改标识：
// 修改描述：
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iPlant.IEMS.Util
{
    /// <summary>
    /// 实例对应关系类
    /// 外壳 （相关属性不需要）
    /// </summary>
    public class AccModel
    {
        /// <summary>
        /// 9个实例
        /// </summary>
        public string key { get; set; }

        /// <summary>
        /// 地址exe
        /// </summary>
        public string addrUrl { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 进程id
        /// -1表示未运行
        /// </summary>
        public int ProcessID { get; set; }

        /// <summary>
        /// 服务组合
        /// </summary>
        public AddrProcess[] Child { get; set; }
    }

    /// <summary>
    /// 组合
    /// </summary>
    public class ServiceMonitorConfigGroup
    {
        /// <summary>
        /// 服务
        /// </summary>
        public AddrProcess Service { get; set; }

        /// <summary>
        /// 监视
        /// </summary>
        public AddrProcess Monitor { get; set; }

        /// <summary>
        /// 配置
        /// </summary>
        public AddrProcess Config { get; set; }

    }

    /// <summary>
    /// 位置线程
    /// </summary>
    public class AddrProcess
    {
        /// <summary>
        /// 唯一标识
        /// </summary>
        public string key { get; set; }

        /// <summary>
        /// 地址exe
        /// </summary>
        public string addrUrl { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 进程id
        /// 0表示未运行
        /// </summary>
        public int ProcessID { get; set; }

        /// <summary>
        /// 窗口handle
        /// </summary>
        public string MainWindowHandle { get; set; }

        /// <summary>
        /// 0未嵌入
        /// </summary>
        public int embedResult { get; set; }
    }
}
