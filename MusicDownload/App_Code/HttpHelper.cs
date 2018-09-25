using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;

public class HttpHelper
    {
        /// <summary>
        /// HTTP 请求通用方法.
        /// </summary>
        /// <param name="httpReqest">Http请求参数</param>
        /// <param name="errorMsg">返回错误信息</param>
        /// <param name="httpStatusCode">返回HTTP状态</param>
        /// <returns>返回Http响应结果</returns>
        public static string HttpDo(HttpModel httpReqest, out string errorMsg, out HttpStatusCode httpStatusCode)
        {
            if (httpReqest == null)
            {
                errorMsg = "请求参数为空";
                httpStatusCode = HttpStatusCode.InternalServerError;
                return string.Empty;
            }
            if (string.IsNullOrEmpty(httpReqest.Method))
            {
                errorMsg = "请求参数Method为空";
                httpStatusCode = HttpStatusCode.InternalServerError;
                return string.Empty;
            }
            GC.Collect();
            HttpWebResponse response = null;
            HttpWebRequest request = null;
            string responseStr = null;

            //参数初始化
            if (httpReqest.TimeOut <= 0) httpReqest.TimeOut = 10;
            if (string.IsNullOrEmpty(httpReqest.ApplicationName)) httpReqest.ApplicationName = "TuanDai.HttpClient";
            if (string.IsNullOrEmpty(httpReqest.ContentType)) httpReqest.ContentType = "application/json";
            if (httpReqest.Encode == null) httpReqest.Encode = Encoding.UTF8;

            Stopwatch sw = new Stopwatch();
            sw.Start();
            Guid newid = Guid.NewGuid();
            try
            {
                if (httpReqest.Method.ToUpper() == "GET" && !string.IsNullOrEmpty(httpReqest.Param))
                {
                    httpReqest.Url = httpReqest.Url + (httpReqest.Url.Contains("?") ? "&" : "?") + httpReqest.Param.TrimStart('?').TrimEnd('&');
                    httpReqest.Param = "";
                }

                request = (HttpWebRequest)HttpWebRequest.Create(httpReqest.Url);
                request.Method = httpReqest.Method;
                request.ContentType = httpReqest.ContentType;
                request.Accept = "*/*";
                request.Timeout = 1000 * httpReqest.TimeOut;
                request.AllowAutoRedirect = false;
                request.KeepAlive = httpReqest.KeepAlive;

                if (httpReqest.Header != null && httpReqest.Header.Count > 0)
                {
                    foreach (var h in httpReqest.Header)
                    {
                        request.Headers.Add(h.Key, h.Value);
                    }
                }

                if (!string.IsNullOrEmpty(httpReqest.Param))
                {
                    var requestStream = new StreamWriter(request.GetRequestStream());
                    requestStream.Write(httpReqest.Param);
                    requestStream.Close();
                }
                response = (HttpWebResponse)request.GetResponse();
                httpStatusCode = response.StatusCode;
                if (response != null)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream(), httpReqest.Encode);
                    responseStr = reader.ReadToEnd();
                    reader.Close();
                }
                sw.Stop();
               
                errorMsg = string.Empty;
                return responseStr;
            }
            catch (WebException ex)
            {
                sw.Stop();
                errorMsg = ex.Message;
                if (ex.Response == null)
                {
                    httpStatusCode = HttpStatusCode.InternalServerError;
                    return responseStr;
                }
                response = (HttpWebResponse)ex.Response;
                httpStatusCode = response.StatusCode;
                if (response != null)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream(), httpReqest.Encode);
                    responseStr = reader.ReadToEnd();
                    reader.Close();
                }
                return responseStr;
            }
            catch (Exception ex)
            {
                sw.Stop();
                errorMsg = ex.Message;
                httpStatusCode = HttpStatusCode.InternalServerError;
                return string.Empty;
            }
            finally
            {
                request = null;
                response = null;
                if (sw.IsRunning)
                    sw.Stop();
            }
        }
    }
