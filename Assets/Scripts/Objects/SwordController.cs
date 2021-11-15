using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{

    private TakeSword sword;
    private PlayerController player;
    [SerializeField] int numberSword;

    void Start()
    {
        sword = GameObject.FindGameObjectWithTag("Player").GetComponent<TakeSword>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            sword.ActivateSwords(numberSword);
            player.sword = true;
            Destroy(gameObject);
        }
    }
}
