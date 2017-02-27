using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Teleport2 : MonoBehaviour
{

    IEnumerator OnTriggerEnter(Collider other) {

        if (someGlobals.trig == false) {
            if (other.tag == "Player") {
                someGlobals.trig = true;
                GetComponent<AudioSource>().Play();
                yield return new WaitForSeconds(2 / 3);
                other.transform.position = new Vector3(28.24f, 5, 16.19f);
                }
            }
        }

    IEnumerator OnTriggerExit(Collider other) {
        yield return new WaitForSeconds(2);
        someGlobals.trig = false;
        }
    }


