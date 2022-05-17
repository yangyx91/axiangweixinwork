using System;
using System.Collections.Generic;
using System.Text;

namespace weixin.work.Request.appchat
{
    public class Request_groupchatcreate
    {
        /// <summary>
        /// 群聊名，最多50个utf8字符，超过将截断
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 指定群主的id。如果不指定，系统会随机从userlist中选一人作为群主
        /// </summary>
        public string owner { get; set; }

        /// <summary>
        /// 群成员id列表。至少2人，至多2000人
        /// </summary>
        public List<string> userlist { get; set; }

        /// <summary>
        /// 群聊的唯一标志，不能与已有的群重复；字符串类型，最长32个字符。只允许字符0-9及字母a-zA-Z。如果不填，系统会随机生成群id
        /// </summary>
        public string chatid { get; set; }
    }
}
