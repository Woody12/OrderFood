using System;
using UnityEngine;

public class JSONHelper
{
    [Serializable]
    public struct JsonArrayWrapper<T>
    {
        public T wrap_result;
    }

    public static T ParseJsonArray<T>(string json)
    {
        // Note: "wrap_result" needs to match the property name in JSONArrayWrapper
        var temp = JsonUtility.FromJson<JsonArrayWrapper<T>>("{\"wrap_result\":" + json + "}");
        return temp.wrap_result;
    }

    public static T ParseJson<T>(string json)
    {
       return JsonUtility.FromJson<T>(json);
    }

    public static string ToModelArray<T>(T model)
    {
        JsonArrayWrapper<T> wrapper = new JsonArrayWrapper<T>();
        wrapper.wrap_result = model;

        return JsonUtility.ToJson(wrapper);
    }

    public static string ToModel<T>(T model) 
    {
        return JsonUtility.ToJson(model);
    }
}