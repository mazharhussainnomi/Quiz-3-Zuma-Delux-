using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    public List<Transform> BodyParts = new List<Transform> ();
    public float mindistance = 0.25f;
    public int beginsize;
    public float speed = 1;
    public float rotationSpeed = 50;
    public GameObject bodyprefab;

    private float dis;
    private Transform curBodyPart;
    private Transform preBodyPart;

    

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < beginsize -1; i++)
        {
            AddBodyPart();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if(Input.GetKey(KeyCode.Q))
            AddBodyPart ();
    }
    public void Move()
    {
        float curspeed = speed;
        if (Input.GetKey(KeyCode.W))
            curspeed *= 2;
        BodyParts[0].Translate(BodyParts[0].forward * curspeed * Time.smoothDeltaTime, Space.World);
        if (Input.GetAxis("Horizontal") != 0)
            BodyParts[0].Rotate(Vector3.up * rotationSpeed * Time.deltaTime * Input.GetAxis("Horizontal"));
        for(int i = 1; i < BodyParts.Count; i++)
        {
            curBodyPart = BodyParts[i];
            preBodyPart = BodyParts[i - 1];
                dis = Vector3.Distance(preBodyPart.position, curBodyPart.position);

            Vector3 newpos = preBodyPart.position;
            newpos.y = BodyParts[0].position.y;
            float T = Time.deltaTime *dis/ mindistance * curspeed;

            if (T > 0.5f)
                T = 0.5f;

            curBodyPart.position = Vector3.Slerp(curBodyPart.position, newpos, T);
            curBodyPart.rotation = Quaternion.Slerp(curBodyPart.rotation, preBodyPart.rotation, T);
        }
    }
    public void AddBodyPart()
    {
        Transform newpart = (Instantiate(bodyprefab, BodyParts[BodyParts.Count - 1].position, BodyParts[BodyParts.Count - 1].rotation) as GameObject).transform;
        newpart.SetParent(transform);
        BodyParts.Add(newpart);
    }

}
