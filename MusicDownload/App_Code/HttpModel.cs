using System.Collections.Generic;
using System.Text;

public class HttpModel
    {
        public string ApplicationName { get; set; }
        public string Url { get; set; }
        public string Method { get; set; }
        public string ContentType { get; set; }
        public string Param { get; set; }
        public Dictionary<string, string> Header { get; set; }
        public int TimeOut { get; set; }
        public Encoding Encode { get; set; }
        public bool KeepAlive { get; set; }
        public bool IsTraceLog { get; set; }
    }
