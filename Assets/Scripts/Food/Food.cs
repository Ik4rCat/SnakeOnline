using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System;

public class Food : NetworkBehaviour
{
    [SerializeField] BoomPartical particlePrefab;
    public static event Action<GameObject> ServerFoodEaten;

    [Server]
    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        BoomPartical boom = Instantiate
            (particlePrefab, transform.position, particlePrefab.transform.rotation);
        NetworkServer.Spawn(boom.gameObject);
        boom.DestroySelf(3f);
        NetworkServer.Destroy(gameObject);
        ServerFoodEaten?.Invoke(other.gameObject);

    }


}
