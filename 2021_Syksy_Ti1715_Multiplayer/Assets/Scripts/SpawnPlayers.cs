using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerPrefab;
    public float minX = -10;
    public float maxX = 10;
    public float minZ = -10;
    public float maxZ = 10;
    // Start is called before the first frame update
    void Start()
    {
        Vector2 randomPosition = new Vector2(Random.Range(minX,maxX), Random.Range(minZ,maxZ));
        Vector3 spawnPostion = new Vector3(randomPosition.x + transform.position.x, transform.position.y, randomPosition.y + transform.position.z);
        PhotonNetwork.Instantiate(playerPrefab.name,spawnPostion,Quaternion.identity);
    }


}
