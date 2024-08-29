using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public struct SMovimiento
{
    public float rotacion;
    public float tiempo;
    public float velocidad;
    public float velRotacion;

    public SMovimiento(float pRotacion, float pTiempo, float pVelocidad, float pVelRotacion)
    {
        rotacion = pRotacion;
        tiempo = pTiempo;
        velocidad = pVelocidad;
        velRotacion = pVelRotacion;
    }
}

public class MovPatron : MonoBehaviour
{
    private int cantidadPasos;
    private List<SMovimiento> patron = new List<SMovimiento>();
    private float tiempo = 0;
    private int indice = 0;
    private Vector3 direccion;
    private bool shouldMove = false;

    public Button button1; // Assign the button in the Unity Inspector
    public Button button2; // Assign the button in the Unity Inspector
    public Button button3; // Assign the button in the Unity Inspector

    void Start()
    {
        // Assign button click events
        button1.onClick.AddListener(() => OnButtonClick(1));
        button2.onClick.AddListener(() => OnButtonClick(2));
        button3.onClick.AddListener(() => OnButtonClick(3));
    }

    void Update()
    {
        if (shouldMove)
        {
            tiempo += Time.deltaTime;

            if (tiempo > patron[indice].tiempo)
            {
                // Reseteamos tiempo y avanzamos el movimiento
                tiempo = 0;
                indice++;

                // Verificamos si es necesario repetir el patron
                if (indice >= cantidadPasos)
                    indice = 0;
            }

            // Calculamos el vector de rotacion
            direccion = Quaternion.AngleAxis(patron[indice].rotacion, Vector3.up) * transform.forward;
            Quaternion rotObjetivo = Quaternion.LookRotation(direccion);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotObjetivo, patron[indice].velRotacion * Time.deltaTime);
            transform.Translate(transform.forward * patron[indice].velocidad * Time.deltaTime);
        }
    }

    void OnButtonClick(int buttonID)
    {
        // Disable all buttons
        button1.interactable = false;
        button2.interactable = false;
        button3.interactable = false;

        // Execute the pattern sequence based on the button clicked
        ExecutePatternSequence(buttonID);
    }

    void ExecutePatternSequence(int buttonID)
    {
        patron.Clear();
        indice = 0;
        tiempo = 0;
        shouldMove = false;

        switch (buttonID)
        {
            case 1:
                PatternOne();
                PatternTwo();
                PatternThree();
                break;
            case 2:
                PatternTwo();
                PatternThree();
                PatternOne();
                break;
            case 3:
                PatternThree();
                PatternTwo();
                PatternOne();
                break;
        }

        cantidadPasos = patron.Count;
        shouldMove = true;
    }

    void PatternOne()
    {
        patron.Add(new SMovimiento(30, 2, 5, 3));
        patron.Add(new SMovimiento(-30, 2, 5, 2));
        patron.Add(new SMovimiento(0, 3, 5, 0));
    }

    void PatternTwo()
    {
        patron.Add(new SMovimiento(0, 1, 7, 1));
        patron.Add(new SMovimiento(90, 2, 5, 4));
        patron.Add(new SMovimiento(-45, 2, 8, 3));
    }

    void PatternThree()
    {
        patron.Add(new SMovimiento(45, 3, 3, 2));
        patron.Add(new SMovimiento(-45, 3, 3, 2));
        patron.Add(new SMovimiento(0, 4, 6, 1));
    }
}
