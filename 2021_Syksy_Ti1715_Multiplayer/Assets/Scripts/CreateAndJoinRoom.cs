using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
public class CreateAndJoinRoom : MonoBehaviourPunCallbacks
{
    public TMP_InputField createInput;
    public TMP_InputField joinInput;

  public void CreateRoom()
  {
      //tämä luo huoneen
      PhotonNetwork.CreateRoom(createInput.text);
  }
}
