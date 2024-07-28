using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class TailNetwork: NetworkBehaviour
{
    [SyncVar] SnakeMover owner;
    [SyncVar] GameObject target;

    public SnakeMover Owner
    {
        get { return owner; }
        private set { owner = value; }
    }

    public GameObject Target
    {
        get { return target; }
        private set { target = value; }
    }

    public override void OnStartServer()
    {
        Owner = connectionToClient.identity.GetComponent<SnakeMover>();
        List<GameObject> tails = Owner.GetComponent<TailSpawner>().Tails;
        
        Target = tails.Count == 0 ? Owner.gameObject : tails[tails.Count-1];
        tails.Add(gameObject);
    }

}
