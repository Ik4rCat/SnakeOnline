using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System;

public class Food : NetworkBehaviour
{
    [SerializeField] BoomPartical particlePrefab;
    public static event Action ServerFoodEaten;

    
    [Server]
    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        FindObjectOfType<Snake>().AddTail();
        BoomPartical boom = Instantiate
            (particlePrefab, transform.position, particlePrefab.transform.rotation);
        NetworkServer.Spawn(boom.gameObject);
        boom.DestroySelf(3f);
        NetworkServer.Destroy(gameObject);
        ServerFoodEaten?.Invoke();

    }


}
