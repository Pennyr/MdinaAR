using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserSelect : MonoBehaviour
{
    private string URL = "http://localhost:8080/ARGameF/UserSelect.php";

    public string[] userData;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        WWW users = new WWW(URL);
        yield return users;
        string userDataString = users.text;
        userData = userDataString.Split(';');
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
