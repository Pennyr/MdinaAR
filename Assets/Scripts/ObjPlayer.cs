using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjPlayer : MonoBehaviour
{
    int id;
    string guID;
    string username;
    string password;

    public ObjPlayer(int _id, string _guID, string _username, string _password)
    {
        id = _id;
        guID = _guID;
        username = _username;
        password = _password;
    }

    public ObjPlayer(string _guID, string _username, string _password)
    {
        guID = _guID;
        username = _username;
        password = _password;
    }
}
