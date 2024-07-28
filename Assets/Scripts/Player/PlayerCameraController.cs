using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerCameraController : NetworkBehaviour
{
    [SerializeField] GameObject vCam;
    public override void OnStartAuthority()
    {
        vCam.SetActive(true);
    }
}
