using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opendoor : MonoBehaviour
{
    public string door = "door1";
    public string handle = "handleTestdoor";
    public bool open = false;
    public float degreeOpen = 90;
    private Quaternion angle;
    public float smooth = 1f;
    private Quaternion angleDoor;
    private Quaternion angleHandle;
    private bool busy = false;

    private void Start()
    {
        angleDoor = GameObject.Find(door).transform.rotation;
        angle = Quaternion.Euler(0, degreeOpen, 0);
        
    }


    private IEnumerator OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E) && busy == false)
        {
            busy = true;
            GameObject.Find(handle).transform.rotation = Quaternion.Slerp(GameObject.Find(handle).transform.rotation, angleHandle * Quaternion.Euler(0, -45, 0), 300 * Time.deltaTime);
            yield return new WaitForSeconds(0.4f);
            open = !open;
            GameObject.Find(handle).transform.rotation = Quaternion.Slerp(GameObject.Find(handle).transform.rotation, angleHandle * Quaternion.Euler(0, 45, 0), 300 * Time.deltaTime);
            yield return new WaitForSeconds(Time.deltaTime);
            
            GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(1);
            GetComponent<AudioSource>().Stop();
            busy = false;
            

        }
        //transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 10 * smooth * Time.deltaTime);

    }

    private void Update()
    {
        angleHandle = GameObject.Find(handle).transform.rotation;
        if (open == false)
        {
            GameObject.Find(door).transform.parent.rotation = Quaternion.Slerp(GameObject.Find(door).transform.parent.rotation, angleDoor, 10 * smooth * Time.deltaTime);
        }

        if (open == true)
        {
            GameObject.Find(door).transform.parent.rotation = Quaternion.Slerp(GameObject.Find(door).transform.parent.rotation, angleDoor * angle, 10 * smooth * Time.deltaTime);
        }
    }

}
