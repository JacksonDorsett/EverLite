using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using EverLite.Behaviour;
using Microsoft.Xna.Framework;
using Newtonsoft.Json.Linq;
namespace EverLite.ScriptInterperiter
{
    public class MovementInterperiter
    {
        static Dictionary<string, Movement> presets;
        public MovementInterperiter()
        {
            if (presets == null)
            {
                presets = new Dictionary<string, Movement>();
                InitPresets();
            }
        }

        private void InitPresets()
        {
            JObject obj = JObject.Parse(File.ReadAllText("MovementPreset.json"));
            foreach (KeyValuePair<string,JToken> pair in obj)
            {
                presets[pair.Key] = Interperit(obj[pair.Key]);
            }
        }

        public Movement Interperit(JToken json)
        {
            if (json.Type == JTokenType.Object)
            {
                string type = json["type"].ToString();
                int lifetime = json["time"].ToObject<int>();
                List<Vector2> points = new List<Vector2>();
                foreach(var p in json["points"])
                {
                    points.Add(new Vector2(p[0].ToObject<float>(), p[1].ToObject<float>()));
                }
                Console.WriteLine($"type: {type}, lifetime: {lifetime}, points: {string.Join(',', points)}");
                return MovementFactory.Create(type, lifetime, points);
            }
            if(json.Type == JTokenType.String)
            {
                return presets[json.ToString()].Clone();
            }
            else
            {
                List<Movement> move = new List<Movement>();
                foreach(JToken p in json)
                {
                    move.Add(Interperit(p));
                }
                return new AggregateMovement(move.ToArray());
            }
        }
        
        
        
    }
}
