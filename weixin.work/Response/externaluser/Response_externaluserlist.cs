using System;
using System.Collections.Generic;
using System.Text;

namespace weixin.work.Response.externaluser
{
    public class Response_externaluserlist:Response_base
    {
        public List<externalcontact> external_contact_list { get; set; }

        public string next_cursor { get; set; }

        public class externalcontact
        {
            public externaluserDetail external_contact { get; set; }

            /// <summary>
            /// 添加了此外部联系人的企业成员
            /// </summary>
            public followinfo follow_info { get; set; }
        }
        public class externaluserDetail
        {
            /// <summary>
            /// 外部联系人的userid
            /// </summary>
            public string external_userid { get; set; }
            /// <summary>
            /// 外部联系人的名称
            /// </summary>
            public string name { get; set; }
            /// <summary>
            /// 外部联系人头像，代开发自建应用需要管理员授权才可以获取，第三方不可获取
            /// </summary>
            public string avatar { get; set; }
            /// <summary>
            /// 外部联系人的类型，1表示该外部联系人是微信用户，2表示该外部联系人是企业微信用户
            /// </summary>
            public int type { get; set; }
            /// <summary>
            /// 外部联系人性别 0-未知 1-男性 2-女性
            /// </summary>
            public int gender { get; set; }
            /// <summary>
            /// 外部联系人在微信开放平台的唯一身份标识（微信unionid），通过此字段企业可将外部联系人与公众号/小程序用户关联起来。仅当联系人类型是微信用户，且企业或第三方服务商绑定了微信开发者ID有此字段
            /// </summary>
            public string unionid { get; set; }
            /// <summary>
            /// 外部联系人的职位，如果外部企业或用户选择隐藏职位，则不返回，仅当联系人类型是企业微信用户时有此字段
            /// </summary>
            public string position { get; set; }
            /// <summary>
            /// 外部联系人所在企业的简称，仅当联系人类型是企业微信用户时有此字段
            /// </summary>
            public string corp_name { get; set; }
            /// <summary>
            /// 外部联系人所在企业的主体名称，仅当联系人类型是企业微信用户时有此字段
            /// </summary>
            public string corp_full_name { get; set; }
            /// <summary>
            /// 外部联系人的自定义展示信息，可以有多个字段和多种类型，包括文本，网页和小程序，仅当联系人类型是企业微信用户时有此字段
            /// </summary>
            public object external_profile { get; set; }
           
            
        }

        public class followinfo 
        {
            /// <summary>
            /// 添加了此外部联系人的企业成员userid
            /// </summary>
            public string userid { get; set; }
            /// <summary>
            /// 该成员对此外部联系人的备注
            /// </summary>
            public string remark { get; set; }
            /// <summary>
            /// 该成员对此外部联系人的描述
            /// </summary>
            public string description { get; set; }
            /// <summary>
            /// 该成员添加此外部联系人的时间
            /// </summary>
            public long createtime { get; set; }
            /// <summary>
            /// 该成员添加此外部联系人所打企业标签的id，用户自定义类型标签（type=2）不返回
            /// </summary>
            public List<string> tag_id { get; set; }
            /// <summary>
            /// 该成员对此客户备注的企业名称
            /// </summary>
            public string remark_corp_name { get; set; }
            /// <summary>
            /// 该成员对此客户备注的手机号码，代开发自建应用需要管理员授权才可以获取
            /// </summary>
            public List<string> remark_mobiles { get; set; }
            /// <summary>
            /// 该成员添加此客户的来源
            /// </summary>
            public int add_way { get; set; }
            /// <summary>
            /// 发起添加的userid，如果成员主动添加，为成员的userid；如果是客户主动添加，则为客户的外部联系人userid；如果是内部成员共享/管理员分配，则为对应的成员/管理员userid
            /// </summary>
            public string oper_userid { get; set; }
            /// <summary>
            /// 企业自定义的state参数，用于区分客户具体是通过哪个「联系我」添加，由企业通过创建「联系我」方式指定
            /// </summary>
            public string state { get; set; }
        }
    }
}
