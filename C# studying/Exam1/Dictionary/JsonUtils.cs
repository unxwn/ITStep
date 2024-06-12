using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Exam1
{
    internal class JsonUtils
    {
        static public string Serialize(object obj, bool FormatAsIndented = true)
        {
            if (obj == null)
            {
                throw new NullReferenceException();
            }
            if (FormatAsIndented) { return JsonConvert.SerializeObject(obj, Formatting.Indented); }
            else { return JsonConvert.SerializeObject(obj); }
        }

        //static public object Deserialize(string json) {
        //    try
        //    {
        //        return JsonConvert.DeserializeObject(json);
        //    }
        //    catch (Exception ex)
        //    {

        //        Console.Write("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!\n\n\n!!!!!!");
        //        return "Just return";
        //    }
            
                
        //}
    }
}
