using System.Collections.Generic;
using MyWebServer.Demo.Data.Models;

namespace MyWebServer.Demo.Data
{
    public interface IData
    {
        IEnumerable<Cat> Cats { get; }
    }
}
