using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class NetworkCustomManager : NetworkManager
{
    public void StartupHost()
    {
        SetPort();
        NetworkManager.singleton.StartHost();
    }


    void StopdownHost()
    {
        NetworkManager.singleton.StopHost();
    }

    public void JoinGame()
    {
        SetIPAddress();
        SetPort();
        NetworkManager.singleton.StartClient();
    }

    void SetIPAddress()
    {
        string ipAddress = GameObject.Find("HostIP").transform.FindChild("Text").GetComponent<Text>().text;
        NetworkManager.singleton.networkAddress = ipAddress;
    }

    void SetPort()
    {
        NetworkManager.singleton.networkPort = 7777;
    }

    void SetupMenuSceneButton()
    {
        GameObject.Find("StartGame").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("StartGame").GetComponent<Button>().onClick.AddListener(StartupHost);

        GameObject.Find("JoinGame").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("JoinGame").GetComponent<Button>().onClick.AddListener(JoinGame);

    }

    void StopMenuSceneButton()
    {
        GameObject.Find("StopGame").GetComponent<Button>().onClick.RemoveAllListeners();
        GameObject.Find("StartGame").GetComponent<Button>().onClick.AddListener(StopdownHost);
    }

    void OnLevelWasLoaded(int level)
    {
        if(level == 0 )
            SetupMenuSceneButton();
        else
            StopMenuSceneButton();
    }
}
