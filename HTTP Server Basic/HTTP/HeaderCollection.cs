using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace HTTP_Server_Basic.HTTP
{
    public class HeaderCollection : IEnumerable<Header>
    {
        private readonly Dictionary<string, Header> headers; //= new Dictionary<string, Header>();

        public HeaderCollection() 
            => headers = new Dictionary<string, Header>();

        public string this[string name] 
            => headers[name].Value;

        public int Count => headers.Count;

        public bool Contains(string name) 
            => headers.ContainsKey(name);

        public void Add(string name, string value)
            => headers[name] = new Header(name, value);
        

        public IEnumerator<Header> GetEnumerator()
            => this.headers.Values.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();
    }
}
