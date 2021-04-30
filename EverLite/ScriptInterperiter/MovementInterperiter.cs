﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Newtonsoft.Json.Linq;
namespace EverLite.ScriptInterperiter
{
    public class MovementInterperiter
    {
        public MovementInterperiter()
        {
        }

        public Movement Interperit(JToken json)
        {
            Movement move;
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

            }
            else
            {

            }
            return null;
        }
        
        
        
    }
}