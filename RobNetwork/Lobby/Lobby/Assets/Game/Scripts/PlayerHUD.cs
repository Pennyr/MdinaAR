using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PlayerHUD : NetworkBehaviour
{
    
    [SyncVar]
    public float gameTime; //The length of a game, in seconds.
    //[SyncVar (hook = "CmdChangeName")]
    [SyncVar]
    public float timer; //How long the game has been running. -1=waiting for players, -2=game is done
    [SyncVar]
    public int minPlayers; //Number of players required for the game to start
    [SyncVar]
    public bool masterTimer = false; //Is this the master timer?
    //public ServerTimer timerObj;

    PlayerHUD serverTimer;

    private string minutes;
    private string seconds;

    // Start is called before the first frame update
    void Start()
    {
        // Is this my own local PlayerInvObject?
        if (!isLocalPlayer)
        {
            // This object belongs to another player
            return;
        }

        if (isServer)
        { // For the host to do: use the timer and control the time.
            if (isLocalPlayer)
            {
                serverTimer = this;
                masterTimer = true;
            }
        }

        else if (isLocalPlayer)
        { //For all the boring old clients to do: get the host's timer.

            PlayerHUD[] timers = FindObjectsOfType<PlayerHUD>();
            for (int i = 0; i < timers.Length; i++)
            {
                if (timers[i].masterTimer)
                {
                    serverTimer = timers[i];
                }
            }
        }

        ////Debug.Log("PlayerInvObject::Start -- Spawning... " + this.name);

    }

    // Update is called once per frame
    void Update()
    {/*
        // Update runs on EVERYONE's device, whether they own this particular player object or not
        if (!isLocalPlayer)
        {
            // This object belongs to another player
            return;
        }
        */
        if (masterTimer)
        { //Only the MASTER timer controls the time
            if (timer == -1) // if server is waiting for players
            {
                timer = gameTime;

            }
            else if (timer <= 0) // if timer exceeds maximum game time
            {
                timer = 0; //Game done.
            }
            else if (timer == -2)
            {
                //Game done.
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }

        if (isLocalPlayer)
        { //EVERYBODY updates their own time accordingly.
            if (serverTimer)
            {
                gameTime = serverTimer.gameTime;
                timer = serverTimer.timer;
                minPlayers = serverTimer.minPlayers;

                minutes = Mathf.Floor(timer / 60).ToString("00");
                seconds = (timer % 60).ToString("00");

            }
            else
            { //Maybe we don't have it yet?
                PlayerHUD[] timers = FindObjectsOfType<PlayerHUD>();
                for (int i = 0; i < timers.Length; i++)
                {
                    if (timers[i].masterTimer)
                    {
                        serverTimer = timers[i];
                    }
                }
            }
        }
    }
    
    void OnGUI()
    {
        if (isLocalPlayer)
        {
            GUI.TextField(new Rect(25, Screen.height - 40, 100, 30), minutes + ":" + seconds);
            if (GUI.Button(new Rect(130, Screen.height - 40, 120, 30), "Some Extra Points"))
            {
                CmdChangeName();
            }

            
            if (GUI.Button(new Rect(130, Screen.height - 80, 80, 30), "Get quests"))
            {
                CmdQuests();
            }

            //GUI.TextField(new Rect(25, Screen.height - 80, 100, 30), minutes + ":" + seconds);

        }
    }

    [Command]
    public void CmdChangeName()//(int timer)
    {
        timer += 20;

    }

    public string[] userData;

    [Command]
    IEnumerator CmdQuests()
    {
        string URL = "http://localhost:8080/ARGameF/UserSelect.php";


        WWW users = new WWW(URL);
        yield return users;
        string userDataString = users.text;
        userData = userDataString.Split(';');
    }

}