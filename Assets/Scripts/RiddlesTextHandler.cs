using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RiddlesTextHandler : MonoBehaviour {

    //public Text RiddleText;
    public int stages = 6;

    readonly Dictionary<int, string> _questTextList = new Dictionary<int, string>()
    {
        {1, "It reminds you of mosquitos,\r\nyet its not one of those.\r\nIt refers to a place of worship,\r\nin many languages for Muslim fellowship.\r\nAnd you definitely must be aware,\r\nIt’s the name of a street that leads to a square."},
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


    // Update is called once per frame
    public void Update () {
	    transform.Find("RidInfoTxt").gameObject.GetComponent<Text>().text = _questTextList[stages];
	    transform.Find("RidInfoNum").gameObject.GetComponent<Text>().text = "Riddle " + stages.ToString();
    }
}
