using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingScript : MonoBehaviour
{
    [SerializeField] Vector3 startPos;
    [SerializeField] float speed = .6f;
    [SerializeField] Vector3 endPos;
    void Start()
    {
        startPos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float time = Mathf.PingPong(Time.time*speed,1);
        transform.position = Vector3.Lerp(startPos,endPos,time);
    }
}
