using System.Collections;
using System.Collections.Generic;
using Prototype.NetworkLobby;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkLobbyHook : LobbyHook
{

    public WebInterface wi;



    public override void OnLobbyServerSceneLoadedForPlayer(NetworkManager manager, GameObject lobbyPlayer, GameObject gamePlayer)
    {
        LobbyPlayer lobby = lobbyPlayer.GetComponent<LobbyPlayer>();
        PlayerHUD localPlayer = gamePlayer.GetComponent<PlayerHUD>();
        LobbyManager lobbyManager = manager.GetComponent<LobbyManager>();

        wi.CallLogin(lobby.playerName, lobbyManager.MatchIDNumber.ToString());
 
        
        Debug.Log("Lobby Player Name: " + lobby.playerName + ", Match ID Number Name: " + lobbyManager.MatchIDNumber);

    }
    
}
