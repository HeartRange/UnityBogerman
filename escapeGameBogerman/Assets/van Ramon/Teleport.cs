﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public string telepad = "";


    IEnumerator OnTriggerEnter(Collider other)
    {

        if (someGlobals.trig == false)
        {
            if (other.tag == "Player")
            {
                someGlobals.trig = true;
                GetComponent<AudioSource>().Play();
                yield return new WaitForSeconds(2 / 3);
                other.transform.position = GameObject.Find(telepad).transform.position;
            }
        }
    }

    IEnumerator OnTriggerExit(Collider other)
    {
        yield return new WaitForSeconds(0.5f);
        someGlobals.trig = false;
    }
}

/*
IEnumerator OnTriggerEnter(Collider other) {
        yield return new WaitForSeconds(2/3);
        if (other.gameObject.tag == "Player")
        {
            GetComponent<AudioSource>().Play();
            other.transform.position = new Vector3(24, 5, 32);
            }
        yield return new WaitForSeconds(2);
    }
}
*/
