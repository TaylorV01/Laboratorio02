using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{
    public float speed = 5f;
    public Transform target;
    private float x=0;
    private float y=0;
    private float z=0;
    // Start is called before the first frame update
    void Start()
    {
        y = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        x = transform.position.x;
        z = transform.position.z;

        if (target.position.x > x)
            x += speed * Time.deltaTime;
        if (target.position.x < x)
            x -= speed * Time.deltaTime;
        if (target.position.z > z)
            z += speed * Time.deltaTime;
        if (target.position.z < z)
            z -= speed * Time.deltaTime;
        transform.position = new Vector3(x, y, z);
    }
}
