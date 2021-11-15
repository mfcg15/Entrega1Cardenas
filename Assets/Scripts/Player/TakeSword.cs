using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeSword : MonoBehaviour
{
    [SerializeField] GameObject[] swords;
    private BoxCollider puño;

    void Start()
    {
        puño = GameObject.FindGameObjectWithTag("Fist").GetComponent<BoxCollider>();
    }

    public void ActivateSwords(int number)
    {
        for (int i = 0; i < swords.Length; i++)
        {
            swords[i].SetActive(false);
        }

        swords[number].SetActive(true);
    }


    private void ActivateCollider()
    {
        puño.enabled = true;
    }

    private void DesactivarCollider()
    {
        puño.enabled = false;
    }

}
