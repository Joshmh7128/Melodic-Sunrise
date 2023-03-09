using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteHandler : DapperReceiver
{
    public float speed;
    Vector3 target;


    private void Start()
    {
        base.Start();
        StartCoroutine(Kill());
        target = transform.position + transform.forward * speed * Time.fixedDeltaTime;

        // set speed
        switch ((int)GlowController.instance.mood)
        {
            case 0:
                speed = 75;
                break;
            case 1:
                speed = 150;
                break;
            case 2:
                speed = 225;
                break;
        }
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target, speed * Time.deltaTime);
    }

    public void FixedUpdate()
    {
        target = transform.position + transform.forward * speed * Time.fixedDeltaTime;
    }

    public override void LowMood()
    {
        speed = 75;
    }
    
    public override void MidMood()
    {
        speed = 150;
    }

    public override void HighMood()
    {
        speed = 300;
    }

    IEnumerator Kill()
    {
        yield return new WaitForSeconds(4);
        GlowController.instance.renderers.Remove(gameObject.GetComponent<Renderer>());

        Destroy(gameObject);
    }   

}
