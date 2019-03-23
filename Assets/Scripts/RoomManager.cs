using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomManager : MonoBehaviour {

    //public Text roomNumber;
    //public Text roomHost;
    public ScrollRect scrollView;
    public GameObject scrollContent;
    public GameObject row;

	// Use this for initialization
	void Start () {

        for (int i = 1; i < 20; i++)
        {
            generateRow(i);
            Debug.Log("row "+i+"generated" );
        }
        scrollView.verticalNormalizedPosition = 1;

    }

    public void updateTable()
    {
        var roomsData = new Dictionary<int,string>();
        roomsData = getRooms();

        foreach (KeyValuePair<int, string> row in roomsData)
        {
            //Printing data to table.
            Console.WriteLine("Key = {0}, Value = {1}", row.Key, row.Value);
        }

    }

    Dictionary<int, string> getRooms()
    {
        //Get Rooms from database
        return new Dictionary<int, string>();
    }

    void generateRow(int itemNumber)
    {
        GameObject scrollItemObj = Instantiate(row);
        scrollItemObj.transform.SetParent(scrollContent.transform, false);
        scrollItemObj.transform.Find("Room#Txt").gameObject.GetComponent<Text>().text = itemNumber.ToString();
    }
}
