using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using weixin.work.Response.department;

namespace weixin.work.BLL
{
    /// <summary>
    /// 企业微信》部门
    /// </summary>
    public class department
    {
        /// <summary>
        /// 所有部门 api URL
        /// </summary>
        private static string listurl =
            @"https://qyapi.weixin.qq.com/cgi-bin/department/list?access_token={0}&id={1}";

        private static string _accesstoken = "";

        public department(string accesstoken)
        {
            _accesstoken = accesstoken;
        }

        /// <summary>
        /// 获取部门列表,请求方式： GET（HTTPS）
        /// </summary>
        /// <returns></returns>
        public async Task<Response_departmentlist> list()
        {
            var result = new Response_departmentlist();
            try
            {
                var response = await HttpHelper.HttpGet(string.Format(listurl, _accesstoken, ""));
                if (!string.IsNullOrWhiteSpace(response))
                {
                    result = JsonConvert.DeserializeObject<Response_departmentlist>(response);
                }
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }
    }
}
