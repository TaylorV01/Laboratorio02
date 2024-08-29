using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfSightRunAway : MonoBehaviour
{
    public float speed = 5f;
    public Transform target;
    public float rangoVision = 50f;
    public float rangoFOV = 30f;
    private Vector3 jugadorDesdeIA;
    public float distanciaAJugador = 0f;
    public float angulo = 0f;

    void Update()
    {
        bool visto = false;

        // Calculamos la distancia cuadrada
        distanciaAJugador = Vector3.SqrMagnitude(transform.position - target.position);

        // Verificamos si está en el rango de visión
        if (distanciaAJugador <= (rangoVision * rangoVision))
        {
            // Vector de la IA al personaje
            jugadorDesdeIA = target.position - transform.position;

            // Calculamos el ángulo
            angulo = Vector3.Angle(transform.forward, jugadorDesdeIA);

            // Verificamos si está en el ángulo de visión
            if (angulo <= rangoFOV)
            {
              
                RaycastHit hit;
                if (Physics.Raycast(transform.position, jugadorDesdeIA.normalized, out hit, rangoVision))
                {
                    
                    if (hit.transform == target)
                    {
                        visto = true;
                    }
                }
            }
        }

        if (visto)
        {
          
            Vector3 direction = transform.position - target.position; 
            direction.y = 0; 
            transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
        }
    }
}


