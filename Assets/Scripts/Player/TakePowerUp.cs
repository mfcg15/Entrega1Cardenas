using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakePowerUp : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "PowerUp")
        {
            other.GetComponent<PowerUpController>().TipeObject();
            Destroy(other.gameObject);
        }

    }
}
