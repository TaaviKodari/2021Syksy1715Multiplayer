using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        //Tämä yhdistää meidät photon servuun heti kun tämä kyseinen scene ladataan
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        //Yhdistää meidät Lobbyyn (aulaan)
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
       SceneManager.LoadScene("Lobby");
    }
}
