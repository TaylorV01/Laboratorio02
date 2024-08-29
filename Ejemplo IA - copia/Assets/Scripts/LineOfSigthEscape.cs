using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfSigthEscape : MonoBehaviour
{
    public float speed = 5f;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 point = target.position - transform.position;
        Vector3 vision = transform.position - point;

        vision.y = target.position.y;
        transform.LookAt(vision);

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
