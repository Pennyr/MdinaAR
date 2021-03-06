﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ObjectivesTextHandler : MonoBehaviour {

    //public Text QuestText;
    public int stage = 1;
    /*
    readonly Dictionary<int, string> _questTextList = new Dictionary<int, string>()
    {
        {1, "Collect the letter from the knight next to the dungeons"},
        {2, "The war has come and we need to be prepared. " +
            "One of the rifles is missing and we want to make sure that all of our resources are available. " +
            "Someone claimed that there is a rifle outside the armory at " +
            "Mesquita Square. Find it!"},
        {3, "Go the Villegaignon Street and check that " +
            "the street name is mounted to the wall so that this hero will never be " +
            "forgotten."},
        {4, "Take the tools to the bastion as fast as " +
           "possible because we need to get ready for any other attacks."},
        {5, "Go and take this letter to the postage box in front of the cathedral " +
           "to request help from our allies."},
        {6, "Go to King Ferdinand " +
           "Lane and inform the infantry that we will stay in Mdina until further " +
           "notice."},
        {7, "Find the horses near the Gharraqin Gate and inform the " +
           "knights that we are going to be on the move within a half an hour."},
        {8, "Collect four " +
           "decrees signed by the nobles and then we will proceed to the project " +
           "based on the majority’s vote."},
    };

    */
    Dictionary<int, string> _questTextList;

    private void Start()
    {
        _questTextList = new Dictionary<int, string>();
        _questTextList = ObjSerDes.getObjectives();
    }

    public void Update()
    {
        transform.Find("ObjInfoTxt").gameObject.GetComponent<Text>().text = _questTextList[stage];
        transform.Find("ObjInfoNum").gameObject.GetComponent<Text>().text = "Quest " + stage.ToString();
    }
}
