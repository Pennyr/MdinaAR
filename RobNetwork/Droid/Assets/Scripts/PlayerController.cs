using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PlayerController : NetworkBehaviour
{
    public GameObject PlayerUnitPrefab;

    [SyncVar]
    public float gameTime; //The length of a game, in seconds.
    [SyncVar]
    public float timer; //How long the game has been running. -1=waiting for players, -2=game is done
    [SyncVar]
    public int minPlayers; //Number of players required for the game to start
    [SyncVar]
    public bool masterTimer = false; //Is this the master timer?
    //public ServerTimer timerObj;

    PlayerController serverTimer;

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

            PlayerController[] timers = FindObjectsOfType<PlayerController>();
            for (int i = 0; i < timers.Length; i++)
            {
                if (timers[i].masterTimer)
                {
                    serverTimer = timers[i];
                }
            }
        }

        Debug.Log("PlayerInvObject::Start -- Spawning... " + this.name );

        /*
         * Instantiate() only creates an object on the LOCAL COMPUTER.
         * Even if it has a NetworkIdentity is still will NOT exist on
         * the network ( and therefore not on any other client ) UNLESS
         * NetworkServer.Spawn() is called on this object by the server
         */
        //Instantiate(PlayerUnitPrefab);
        // Command the server to SPAWN our unit
        CmdSpawnMyUnit();
    }

    // Update is called once per frame
    void Update()
    {
        // Update runs on EVERYONE's device, whether they own this particular player object or not
        if (!isLocalPlayer)
        {
            // This object belongs to another player
            return;
        }
        
        if (Input.GetKeyDown(KeyCode.S))
        {
            // spacebar hit, instruct server to do something with this player unit
            CmdSpawnMyUnit();
        }


        if (masterTimer)
        { //Only the MASTER timer controls the time
            if (timer >= gameTime) // if timer exceeds maximum game time
            {
                timer = -2;
            }
            else if (timer == -1) // if server is waiting for players
            {
                if (NetworkServer.connections.Count >= minPlayers)
                {
                    timer = 0;
                }
            }
            else if (timer == -2)
            {
                //Game done.
            }
            else
            {
                timer += Time.deltaTime;
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

                this.GetComponentInChildren<Text>().text = minutes + ":" + seconds;
            }
            else
            { //Maybe we don't have it yet?
                PlayerController[] timers = FindObjectsOfType<PlayerController>();
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

    ///////////// COMMANDS
    // Commands are special functions that ONLY get executed on the server
    // Commands are called by the clients for the server to execute

    [Command]
    void CmdSpawnMyUnit()
    {
        // This guarantees to be on server right now.
        GameObject gO = Instantiate(PlayerUnitPrefab);


        //gO.GetComponent<NetworkIdentity>().AssignClientAuthority(connectionToClient);
        // Now that the object exists on the server, propagate it to all the clients
        // (and also wire up the NetworkIdenity)

        NetworkServer.SpawnWithClientAuthority(gO, connectionToClient);
    }
}
