using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class QuitServer : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void QuitRoom()
    {
        PhotonNetwork.Disconnect();
        //PhotonNetwork.LeaveRoom();
        print("desconectou");
        SceneManager.LoadScene("Menu");
    }
}
