using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.SceneManagement;


public class PlayerCamera : NetworkBehaviour
{
    public GameObject cameraHolder;

    public Vector3 offset;

    public override void OnStartAuthority()
    {
        cameraHolder.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "SlutsArena")
        {
            cameraHolder.transform.position = transform.position + offset;
        }
    }
}
