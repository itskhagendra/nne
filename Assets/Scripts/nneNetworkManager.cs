using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.Netcode;

public class nneNetworkManager : MonoBehaviour
{
    [SerializeField]
    TMP_Text networkIP;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void StartServer()
    {
        if (NetworkManager.Singleton.StartServer())
        {
            Debug.Log("Server Started");
        }
        else
        {
            Debug.Log("Server Couldn't Start");
        }
    }
    public void StartHost()
    {
        if (NetworkManager.Singleton.StartHost())
        {
            Debug.Log("Host Joined and Connected");
        }
        else { Debug.Log("Host Couldn't Start server or Join"); }
    }
    public void StartClient()
    {
        if (NetworkManager.Singleton.StartClient())
        {
            Debug.Log("Client Joined");
        }
        else
        {
            Debug.Log("Client Couldn't Join");
        }
    }

}
