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
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace iPlant.IEMS.Util
{
    /// <summary>
    /// 数据管理类
    /// </summary>
    public class MyResourceManager
    {
        /// <summary>
        /// Interfaces
        /// </summary>
        public static List<AccModel> _Interfaces = new List<AccModel>();

        /// <summary>
        /// Interface Resource Pool
        /// </summary>
        public static AccModel GetInterface(string key)
        {
            if (_Interfaces != null && _Interfaces.Count > 0)
            {
                if (_Interfaces.Any(t => t.key.Equals(key)))
                {
                    return _Interfaces.Find(t => t.key.Equals(key));
                }
            }
            return null;
        }

        public static void Init()
        {
            //1. Init Resource
            InitResource();
        }

        /// <summary>
        /// 初始化配置资源
        /// </summary>
        internal static void InitResource()
        {
            //获取接口路径
            //System.Configuration.ConfigurationSettings.AppSettings["InterfaceResourcePath"];

            String resourcePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resource", "InterfaceResource.xml");

            XmlDocument xmldoc = new XmlDocument();

            xmldoc.Load(resourcePath);

            //过滤指定接口节点
            XmlNodeList elements = xmldoc.DocumentElement.SelectNodes("/Accs/Acc");

            foreach (XmlElement element in elements)
            {
                var key = element.Attributes["key"].Value;
                var service= element.ChildNodes.Item(0).Attributes;
                var monitor= element.ChildNodes.Item(1).Attributes;
                var config= element.ChildNodes.Item(2).Attributes;

                var childs = new AddrProcess   []{ 
                    new AddrProcess { key = key, ProcessID = int.Parse(service["ProcessID"].Value), MainWindowHandle =  service["MainWindowHandle"].Value , addrUrl = service["addrUrl"].Value, name = service["name"].Value }, 
                    new AddrProcess { key = key, ProcessID = int.Parse(monitor["ProcessID"].Value), MainWindowHandle =  monitor["MainWindowHandle"].Value , addrUrl = monitor["addrUrl"].Value, name = monitor["name"].Value }, 
                    new AddrProcess { key = key, ProcessID = int.Parse(config["ProcessID"].Value), MainWindowHandle =   config["MainWindowHandle"].Value , addrUrl = config["addrUrl"].Value, name = config["name"].Value } 
                  
                };
                _Interfaces.Add(new AccModel()
                {
                    key = key,
                    //addrUrl = element.Attributes["addrUrl"].Value,
                    name = element.Attributes["name"].Value,
                    //ProcessID = int.Parse( element.Attributes["ProcessID"].Value),
                    Child = childs
                });
            }
        }

        /// <summary>
        /// 重新开启 写入xml 
        /// </summary>
        public static void WriteResource(AddrProcess app)
        {
            string key = app.key;
            String resourcePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resource", "InterfaceResource.xml");

            XmlDocument xmldoc = new XmlDocument();

            xmldoc.Load(resourcePath);
            XmlNode node;
            node = xmldoc.DocumentElement;
            foreach (XmlNode node1 in node.ChildNodes)
            {
                if (app.key == node1.Attributes.Item(0).Value)
                {
                    //node1.Attributes.GetNamedItem("ProcessID").Value=  app.ProcessID.ToString();

                    foreach (XmlNode node2 in node1.ChildNodes)
                    {
                        if (node2.Name == app.name )
                        {
                            node2.Attributes.GetNamedItem("ProcessID").Value = app.ProcessID.ToString();
                            node2.Attributes.GetNamedItem("MainWindowHandle").Value = app.MainWindowHandle.ToString();
                            node2.Attributes.GetNamedItem("embedResult").Value =  app.embedResult.ToString();
                            
                            break;
                        }
                    }
                }

                //// if(node1.Attributes.Item(0).InnerText)
                //foreach (XmlNode node2 in node1.ChildNodes)
                //{
                //    if (node2.Name == "price")
                //    {
                //        Decimal price = Decimal.Parse(node2.InnerText);
                //        // Increase all the book prices by 20%
                //        String newprice = ((Decimal)price * (new Decimal(1.20))).ToString("#.00");
                //        Console.WriteLine("Old Price = " + node2.InnerText + "/tNew price = " + newprice);
                //        node2.InnerText = newprice;
                //    }
                //}
            }
            //修改后xml没能记下来。只是内存修改
            xmldoc.Save(resourcePath);
            //修改根目录下的xml
            xmldoc.Save(resourcePath.Replace("\\bin\\Debug",""));            //exe运行起来后，需将processid写入xml or DB
        }

        /// <summary>
        /// 修改所有 嵌入状态0  
        /// </summary>
        public static void WriteResource()
        { 
            String resourcePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resource", "InterfaceResource.xml");

            XmlDocument xmldoc = new XmlDocument();

            xmldoc.Load(resourcePath);
            XmlNode node;
            node = xmldoc.DocumentElement;
            foreach (XmlNode node1 in node.ChildNodes)
            {
                foreach (XmlNode node2 in node1.ChildNodes)
                {
                    node2.Attributes.GetNamedItem("embedResult").Value = "0";
                }
            }
            //修改后xml没能记下来。只是内存修改
            xmldoc.Save(resourcePath);
            //修改根目录下的xml
            xmldoc.Save(resourcePath.Replace("\\bin\\Debug",""));            //exe运行起来后，需将processid写入xml or DB
        }
    }
}
