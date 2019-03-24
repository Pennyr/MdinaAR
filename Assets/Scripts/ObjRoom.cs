using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjRoom : MonoBehaviour
{
    int id;
    string roomID;
    string hostGuid;
    bool roomName;
    Time dateTimeStart;
    int lastDoneQuestID;
    int lastDoneRiddleID;
    int playerTwo;
    int playerThree;


    public ObjRoom(int _id, string _roomID, string _hostGuid, bool _roomName, Time _dateTimeStart, int _lastDoneQuestID, int _lastDoneRiddleID, int _playerTwo, int _playerThree)
    {
        id = _id;
        roomID = _roomID;
        hostGuid = _hostGuid;
        roomName = _roomName;
        dateTimeStart = _dateTimeStart;
        lastDoneQuestID = _lastDoneQuestID;
        lastDoneRiddleID = _lastDoneRiddleID;
        playerTwo = _playerTwo;
        playerThree = _playerThree;

    }

    public ObjRoom( string _roomID, string _hostGuid, bool _roomName, Time _dateTimeStart, int _lastDoneQuestID, int _lastDoneRiddleID, int _playerTwo, int _playerThree)
    {
        roomID = _roomID;
        hostGuid = _hostGuid;
        roomName = _roomName;
        dateTimeStart = _dateTimeStart;
        lastDoneQuestID = _lastDoneQuestID;
        lastDoneRiddleID = _lastDoneRiddleID;
        playerTwo = _playerTwo;
        playerThree = _playerThree;

    }
}
