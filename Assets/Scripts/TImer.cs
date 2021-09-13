using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text cronometro;
    public float tiempo = 50f;
    private float tiempo2 = 3f;
    private bool presionoBoton = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("t"))
        {
            presionoBoton = true;
        }
        if (tiempo <= 0)
        {
            tiempo = 0;
        }
        else
        {
            if (presionoBoton == true)
            {
                if (tiempo2 <= 0)
                {
                    presionoBoton = false;
                }
                else
                {
                    tiempo2 = tiempo2 - Time.deltaTime;
                    tiempo = tiempo - Time.deltaTime / 2;
                }
            }
            else
            {
                tiempo = tiempo - Time.deltaTime;
            }


        }
        cronometro.text = "Tiempo : " + tiempo.ToString("f0");
    }
}