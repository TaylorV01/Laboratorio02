using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfSigthChase : MonoBehaviour
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
                // Realizamos un raycast para verificar si hay un obstáculo
                RaycastHit hit;
                if (Physics.Raycast(transform.position, jugadorDesdeIA.normalized, out hit, rangoVision))
                {
                    // Si el raycast golpea al jugador, lo ve
                    if (hit.transform == target)
                    {
                        visto = true;
                    }
                }
            }
        }

        if (visto)
        {
            // Si el jugador está en la línea de visión, el NPC lo persigue
            Vector3 direction = target.position - transform.position;
            // Mantenemos la dirección de la visión en 0 cada vez que se llama para evitar que se vaya hacia abajo
            direction.y = 0;
            transform.rotation = Quaternion.LookRotation(direction);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }

}
