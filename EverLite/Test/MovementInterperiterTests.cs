using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Newtonsoft.Json.Linq;
using EverLite.ScriptInterperiter;
namespace EverLite.Test
{
    [TestFixture]
    class MovementInterperiterTests
    {
        [Test]
        public void TestInterperitObject()
        {
            JObject o = JObject.Parse("{\"type\" : \"A\", \"time\" : 1000, \"points\" : [ [10.5,23.5], [100.5]] }");
            MovementInterperiter mi = new MovementInterperiter();
            mi.Interperit(o);
        }
    }
}
