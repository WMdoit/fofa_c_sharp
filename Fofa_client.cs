using System;
using System.Text;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;


namespace fofa_client
{
    public class Client
    {
        public string email = "";//填入自己的email及key
        public string key = "";
                
        public string base_url = "https://fofa.so";
        public string search_api_url = "/api/v1/search/all";
        public string login_api_url = "/api/v1/info/my";

        public string html;

        public static string[] Unpack_data(string html)
        {
            Regex r = new Regex("results"); // 定义一个Regex对象实例
            Match m = r.Match(html); // 在字符串中匹配
            html = html.Remove(0, m.Index + 11);
            html = html.Remove(html.Length - 3, 3);
            html = html.Replace("],[", "@");
            html = html.Replace("\"", "");
            Console.WriteLine(html);
            string[] html2 = html.Split('@');
            return html2;
        }

        public string get_userinfo()
        {
            string param = string.Format("?email={0}&key={1}", email, key);
            string url = base_url + login_api_url;
            string res = get_http(url, param);
            return res;
        }

        public string get_data(string query_str, int page, string fields)
        {
            query_str = Convert.ToBase64String(Encoding.UTF8.GetBytes(query_str));
            string param = string.Format("?qbase64={0}&page={1}&fields={2}&email={3}&key={4}", query_str,page, fields,email,key);
            string url = base_url + search_api_url+ param;
            string data = get_http(url, param);
            return data;
        }


        public string get_http(string url, string param)//定义查询方法
        {

            string url2 = url + param;
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url2);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader streamReader = new StreamReader(responseStream, Encoding.UTF8);
                html = streamReader.ReadToEnd();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.Source);
                Console.WriteLine(e.StackTrace);

            }
            return html;
        }
    }

}
