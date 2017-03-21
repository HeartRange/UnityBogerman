using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opendoor : MonoBehaviour
{
    public string door = "door1";
    public string handle = "handleTestdoor";
    public bool open = false;
    public float degreeOpen = 90;
    public AudioClip openSound;
    public AudioClip closeSound;
    private Quaternion angle;
    private float smooth = 1f;
    private Quaternion angleDoor;
    private Quaternion angleHandle;
    private bool busy = false;
	public bool key;
	public bool key2;
	public bool textline;
    private void Start()
    {
        angleDoor = GameObject.Find(door).transform.rotation;
        angle = Quaternion.Euler(0, degreeOpen, 0);
		textline = false;
        
    }


    private IEnumerator OnTriggerStay(Collider other)
    {
		if (Input.GetKeyDown(KeyCode.E) && busy == false && key == true)
        {
            someGlobals.gotkey = false;
            busy = true;
            GameObject.Find(handle).transform.rotation = Quaternion.Slerp(GameObject.Find(handle).transform.rotation, angleHandle * Quaternion.Euler(0, -45, 0), 300 * Time.deltaTime);
            yield return new WaitForSeconds(0.4f);
            open = !open;
            GameObject.Find(handle).transform.rotation = Quaternion.Slerp(GameObject.Find(handle).transform.rotation, angleHandle * Quaternion.Euler(0, 45, 0), 300 * Time.deltaTime);
            yield return new WaitForSeconds(Time.deltaTime);

            if (open == true)
            {
                AudioSource.PlayClipAtPoint(openSound, transform.position);
                yield return new WaitForSeconds(0.5f);
                GetComponent<AudioSource>().Stop();
            }
            if (open == false)
            {
                AudioSource.PlayClipAtPoint(closeSound, transform.position);
                yield return new WaitForSeconds(0.5f);
                GetComponent<AudioSource>().Stop();
            }
            busy = false;
            

        }
		else if (Input.GetKeyDown(KeyCode.E) && busy == false && key2 == true)
		{
			textline = true;
			busy = true;
			GameObject.Find(handle).transform.rotation = Quaternion.Slerp(GameObject.Find(handle).transform.rotation, angleHandle * Quaternion.Euler(0, -45, 0), 300 * Time.deltaTime);
			yield return new WaitForSeconds(0.4f);
			open = !open;
			GameObject.Find(handle).transform.rotation = Quaternion.Slerp(GameObject.Find(handle).transform.rotation, angleHandle * Quaternion.Euler(0, 45, 0), 300 * Time.deltaTime);
			yield return new WaitForSeconds(Time.deltaTime);

			if (open == true)
			{
				AudioSource.PlayClipAtPoint(openSound, transform.position);
				yield return new WaitForSeconds(0.5f);
				GetComponent<AudioSource>().Stop();
			}
			if (open == false)
			{
				AudioSource.PlayClipAtPoint(closeSound, transform.position);
				yield return new WaitForSeconds(0.5f);
				GetComponent<AudioSource>().Stop();
			}
			busy = false;


		}
        //transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 10 * smooth * Time.deltaTime);

    }

    private void Update()
    {
        key = someGlobals.gotkey;
        key2 = someGlobals.gotkey2;
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
