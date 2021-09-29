using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public enum Type
    {
        POWER, HEAL
    }
    public Type colType;
    public GameObject player;
    PlayerHealth playerHealth;
    PlayerMovement playerMovement;
    CapsuleCollider playerCollider;
    // Start is called before the first frame update
    void Start()
    {


    }

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        playerMovement = player.GetComponent<PlayerMovement>();
        playerCollider = player.GetComponent<CapsuleCollider>();


    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(1, 1, 1), 1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == playerCollider)
        {
            if (colType == Type.HEAL)
            {
                playerHealth.PlayerHeal(10);
                Destroy(gameObject);
                // gameObject.SetActive(false);
            }
            else
            {
                playerMovement.SpeedBoost();
                Destroy(gameObject);

            }
        }
    }
}
