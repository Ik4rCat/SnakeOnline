using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;

public class SnakeMover: NetworkBehaviour
{
    [SerializeField] float rotationSpeed = 180f, speedChange = 0.5f;
    [SerializeField,SyncVar] float speed = 3f;

    public float Speed 
    {
        get { return speed; }
        private  set { speed = value; }
    }

    public override void OnStartServer()
    {
        Food.ServerFoodEaten += OnServerFoodEaten;
    }

    public override void OnStopServer()
    {
        Food.ServerFoodEaten -= OnServerFoodEaten;
    }

    private void OnServerFoodEaten(GameObject playerWhoAte)
    {
        if (playerWhoAte != gameObject) return;

        Speed += speedChange;
    }

    [Client]
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime * Input.GetAxis("Horizontal"));
    }

}
