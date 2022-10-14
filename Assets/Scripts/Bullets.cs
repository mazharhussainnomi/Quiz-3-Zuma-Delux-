using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    public float speed = 40.9f;

    public float life = 3;

    private void Awake()
    {

        Destroy(gameObject, life);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime);
    }
}
