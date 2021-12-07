using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
public class Ball : MonoBehaviourPunCallbacks
{
    public TMP_Text teamBlueText;
    public TMP_Text teamRedText;
    public int teamBlueScore = 0;
    public int teamRedScore = 0;

    Rigidbody _rigidbody;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        UpdateScoreText();
    }


    private void UpdateScoreText()
    {
        teamBlueScore = (int)PhotonNetwork.CurrentRoom.CustomProperties["BlueScore"];
        teamRedScore = (int)PhotonNetwork.CurrentRoom.CustomProperties["RedScore"];

        teamBlueText.text = "Team Blue: " + teamBlueScore;
        teamRedText.text = "Team Red: " + teamRedScore;
    }

    public override void OnRoomPropertiesUpdate(ExitGames.Client.Photon.Hashtable propertiesThatChanged)
    {
        UpdateScoreText();
    }

    void OnTriggerEnter(Collider other)
    {
        Vector3 startPoint = new Vector3(0, 1, 0);

        if(other.gameObject.tag == "BlueGoal")
        {
            teamRedScore += 1;
            PhotonNetwork.CurrentRoom.SetCustomProperties(new ExitGames.Client.Photon.Hashtable() {{"RedScore",teamRedScore}});
        }

        if(other.gameObject.tag == "RedGoal")
        {
            teamBlueScore += 1;
             PhotonNetwork.CurrentRoom.SetCustomProperties(new ExitGames.Client.Photon.Hashtable() {{"BlueScore",teamBlueScore}});
        }

        transform.position = startPoint;
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
        //UpdateScoreText();
    }
}
