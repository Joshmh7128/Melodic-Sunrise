using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteHandler : MonoBehaviour
{
    public float speed = 10;
    Vector3 target;

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target, speed * Time.deltaTime);
    }

    public void FixedUpdate()
    {
        target = transform.position + Vector3.forward * speed * Time.fixedDeltaTime;
    }

}
