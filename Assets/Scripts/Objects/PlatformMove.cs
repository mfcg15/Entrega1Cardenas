using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    private bool flag = true;
    private float speedPlataform = 4f;
    enum behaviour { H, V,H2 };

    [SerializeField] behaviour typePlataform;

    void Update()
    {
        switch (typePlataform)
        {
            case behaviour.H:
                MoveRightLeft();
                break;

            case behaviour.V:
                MoveUpDow();
                break;

            case behaviour.H2:
                MoveRightLeft2();
                break;

            default:
                Debug.Log("Movimiento no encontrado");
                break;
        }
    }

    private void MovePlataform(Vector3 direction)
    {
        transform.Translate(speedPlataform * Time.deltaTime * direction);
    }

    private void MoveRightLeft()
    {
        if (flag)
        {
            MovePlataform(Vector3.right);
        }
        else
        {
            MovePlataform(Vector3.left);
        }

        if (transform.position.x < -8f && !flag)
        {
            flag = true;
        }

        if (transform.position.x > 8f && flag)
        {
            flag = false;
        }
    }

    private void MoveUpDow()
    {
        if (flag)
        {
            MovePlataform(Vector3.up);
        }
        else
        {
            MovePlataform(Vector3.down);
        }

        if (transform.position.y < -1f && !flag)
        {
            flag = true;
        }

        if (transform.position.y > 6.8f && flag)
        {
            flag = false;
        }
    }

    private void MoveRightLeft2()
    {
        if (flag)
        {
            MovePlataform(Vector3.right);
        }
        else
        {
            MovePlataform(Vector3.left);
        }

        if (transform.position.x < -34f && !flag)
        {
            flag = true;
        }

        if (transform.position.x > -17.8f && flag)
        {
            flag = false;
        }
    }

}
