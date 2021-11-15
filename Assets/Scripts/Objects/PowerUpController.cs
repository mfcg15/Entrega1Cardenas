using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    private PlayerController player;
    private bool isAnimated = true, isRotating = true, isFloating = true, isScaling = true, scalingUp = true, goingUp = true;
    private float floatTimer, scaleTimer, rotationSpeed = 10, scaleSpeed = 1;
    private Vector3 rotationAngle = new Vector3(0, 0, 10);
    enum behaviour { A, B, C };

    [SerializeField] float floatSpeed , floatRate , scaleRate ;
    [SerializeField] Vector3 startScale , endScale;
    [SerializeField] behaviour chooseObject;
  

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        Animation();
    }


    private void Animation()
    {
        if (isAnimated)
        {
            if (isRotating)
            {
                transform.Rotate(rotationAngle * rotationSpeed * Time.deltaTime);
            }

            if (isFloating)
            {
                floatTimer += Time.deltaTime;
                Vector3 moveDir = new Vector3(0.0f, 0.0f, floatSpeed);
                transform.Translate(moveDir);

                if (goingUp && floatTimer >= floatRate)
                {
                    goingUp = false;
                    floatTimer = 0;
                    floatSpeed = -floatSpeed;
                }

                else if (!goingUp && floatTimer >= floatRate)
                {
                    goingUp = true;
                    floatTimer = 0;
                    floatSpeed = +floatSpeed;
                }
            }

            if (isScaling)
            {
                scaleTimer += Time.deltaTime;

                if (scalingUp)
                {
                    transform.localScale = Vector3.Lerp(transform.localScale, endScale, scaleSpeed * Time.deltaTime);
                }
                else if (!scalingUp)
                {
                    transform.localScale = Vector3.Lerp(transform.localScale, startScale, scaleSpeed * Time.deltaTime);
                }

                if (scaleTimer >= scaleRate)
                {
                    if (scalingUp) { scalingUp = false; }
                    else if (!scalingUp) { scalingUp = true; }
                    scaleTimer = 0;
                }
            }
        }
    }

    public void TipeObject()
    {
        switch (chooseObject)
        {
            case behaviour.A:
                player.lifePlayer++;
                break;

            case behaviour.B:
                player.gems++;
                break;
            case behaviour.C:
                player.jumpForce = 8f;
                break;
            default:
                Debug.Log("Objeto no encontrado");
                break;
        }
    }

}
