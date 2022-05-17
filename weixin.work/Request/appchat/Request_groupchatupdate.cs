using System;
using System.Collections.Generic;
using System.Text;

namespace weixin.work.Request.appchat
{
    public class Request_groupchatupdate
    {
        /// <summary>
        /// 群聊id
        /// </summary>
        public string chatid { get; set; }

        /// <summary>
        /// 新的群聊名。若不需更新，请忽略此参数。最多50个utf8字符，超过将截断
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 新群主的id。若不需更新，请忽略此参数
        /// </summary>
        public string owner { get; set; }

        /// <summary>
        /// 添加成员的id列表
        /// </summary>
        public List<string> add_user_list { get; set; }

        /// <summary>
        /// 踢出成员的id列表
        /// </summary>
        public List<string> del_user_list { get; set; }
    }
}
