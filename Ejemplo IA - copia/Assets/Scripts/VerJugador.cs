using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerJugador : MonoBehaviour
{
    public Transform objetivo;
    public float rangoVision = 50;
    public float rangoFOV = 30;
    private Vector3 jugadorDesdeIA;
    public float distanciaAJugador = 0;
    public float angulo = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool visto = false;
        //Calculamos la distancia cuadrada
        distanciaAJugador = Vector3.SqrMagnitude(transform.position - objetivo.position);
        //Verificamos si esta en el rango de vision
        if(distanciaAJugador <= (rangoVision * rangoVision))
        {
            //Vector de la IA al personaje
            jugadorDesdeIA = objetivo.position - transform.position;
            //Calculamos el angulo
            angulo = Vector3.Angle(transform.forward, jugadorDesdeIA);
            //Verificamos si esta en el angulo de vision
            if(angulo <= rangoFOV)
            {
                visto = true;
            }
        }
        if(visto)
        {
            Debug.Log("Veo al jugador");
        }
        else
        {
            Debug.Log("No veo al jugador");
        }
    }
}
