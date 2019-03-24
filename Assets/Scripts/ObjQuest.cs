using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjQuest : MonoBehaviour
{
    int id;
    int questID;
    string questText;
    bool isReady;
    string roomID;

    public ObjQuest(int _id, int _questID, string _questText, bool _isReady, string _roomID)
    {
        id = _id;
        questID = _questID;
        questText = _questText;
        isReady = _isReady;
        roomID = _roomID;
    }

    public ObjQuest(int _questID, string _questText, bool _isReady, string _roomID)
    {

        questID = _questID;
        questText = _questText;
        isReady = _isReady;
        roomID = _roomID;
    }

}
