//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//
//public class opendoor : MonoBehaviour
//{
//    private Quaternion door;
//    private bool open = false;
//    private Quaternion angled;
//    private Quaternion nangled;
//    public float smooth = 1f;
//
//    private void Start()
//    {
//        door = GameObject.Find("door1").transform.rotation;
//        angled = Quaternion.Euler(0, 90, 0);
//        nangled = Quaternion.Euler(0, -90, 0);
//    }
//    private IEnumerator OnTriggerStay(Collider other)
//    {
////        if (Input.GetKeyDown(KeyCode.E) && someGlobals.itemC == true)
//        {
//            open = !open;
//            GetComponent<AudioSource>().Play();
//            yield return new WaitForSeconds(1);
//            GetComponent<AudioSource>().Stop();
//        }
//        //transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 10 * smooth * Time.deltaTime);
//
//    }
//
//    private void Update()
//    {
//        if (open == false)
//        {
//            GameObject.Find("door1").transform.parent.rotation = Quaternion.Slerp(GameObject.Find("door1").transform.parent.rotation, door, 10 * smooth * Time.deltaTime);
//        }
//
//        if (open == true)
//        {
//            GameObject.Find("door1").transform.parent.rotation = Quaternion.Slerp(GameObject.Find("door1").transform.parent.rotation, door * angled, 10 * smooth * Time.deltaTime);
//        }
//    }
//
//}
