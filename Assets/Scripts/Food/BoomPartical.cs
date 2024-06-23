using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class BoomPartical : NetworkBehaviour
{
    public void DestroySelf(float delay = 0)
    {
        StartCoroutine(DestroyBoomDelayed(delay));
    }
    IEnumerator DestroyBoomDelayed( float delay)
    {
        yield return new WaitForSeconds(delay);
        NetworkServer.Destroy(gameObject);
    }
}
