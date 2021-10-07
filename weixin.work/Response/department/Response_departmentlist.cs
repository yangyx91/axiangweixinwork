using System;
using System.Collections.Generic;
using System.Text;

namespace weixin.work.Response.department
{
    public class Response_departmentlist : Response_base
    {
        /// <summary>
        /// 部门列表数据。
        /// </summary>
        public List<departmentItem> department { get; set; }

        public class departmentItem
        {
            /// <summary>
            /// 创建的部门id
            /// </summary>
            public int id { get; set; }
            /// <summary>
            /// 部门名称，代开发自建应用需要管理员授权才返回
            /// </summary>
            public string name { get; set; }
            /// <summary>
            /// 英文名称
            /// </summary>
            public string name_en { get; set; }
            /// <summary>
            /// 父部门id。根部门为1
            /// </summary>
            public int parentid { get; set; }
            /// <summary>
            /// 在父部门中的次序值。order值大的排序靠前。值范围是[0, 2^32)
            /// </summary>
            public int order { get; set; }
        }
    }
}
