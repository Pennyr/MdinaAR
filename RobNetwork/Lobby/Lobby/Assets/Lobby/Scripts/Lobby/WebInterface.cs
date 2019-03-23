using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WebInterface : MonoBehaviour
{
    private static string _name = "", _game = "";

    public void CallLogin(string name, string game)
    {
        _name = name;
        _game = game;

        StartCoroutine(Login());
    }

    static IEnumerator Login()
    {
        WWWForm form = new WWWForm();

        string baseURL = "http://localhost:8080/ARGameF/GameInsert.php?";
        string playerName = "PlayerName=";
        string gameID = "&GameID=";


        WWW www = new WWW(baseURL + playerName + _name + gameID +_game, form);
        Debug.Log(www.ToString());
        yield return www;
    }

    private static string[] userData;

    public void CallQuests()
    {
        StartCoroutine(Quests());
    }
    // Start is called before the first frame update
    static IEnumerator Quests()
    {
        string URL = "http://localhost:8080/ARGameF/UserSelect.php";


        WWW users = new WWW(URL);
        yield return users;
        string userDataString = users.text;
        userData = userDataString.Split(';');
    }


}
