using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjSerDes : MonoBehaviour
{
    public static string serialize(object obj)
    {
        return JsonUtility.ToJson(obj);
    }

    public static Dictionary<int, string> getRiddles()
    {
        // server Riddle Request
        string json = "";
        return JsonUtility.FromJson<Dictionary<int, string>>(json);
    }

    public static Dictionary<int, string> getObjectives()
    {
        // server Objective Request
        string json = "";
        return JsonUtility.FromJson<Dictionary<int, string>>(json);
    }

    public static Dictionary<int, string> getRooms()
    {
        // server Rooms Request
        string json = "";
        return JsonUtility.FromJson<Dictionary<int, string>>(json);
    }

    public static int getUserAccessResponse(string json = "")
    {        
        // server Credential Request = json
        return JsonUtility.FromJson<int>(json);
    }
}
