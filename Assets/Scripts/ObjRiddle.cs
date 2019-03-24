using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjRiddle : MonoBehaviour
{
    int id;
    int riddleID;
    string riddleText;
    bool isReady;
    int extraTime;
    int roomID;


    public ObjRiddle(int _id, int riddleID, string _riddleText, bool _isReady, int _extraTime, int _roomID)
    {
        id = _id;
        riddleID = riddleID;
        riddleText = _riddleText;
        isReady = _isReady;
        extraTime = _extraTime;
        roomID = _roomID;
    }

    public ObjRiddle(int riddleID, string _riddleText, bool _isReady, int _extraTime, int _roomID)
    {

        riddleID = riddleID;
        riddleText = _riddleText;
        isReady = _isReady;
        extraTime = _extraTime;
        roomID = _roomID;
    }
}
