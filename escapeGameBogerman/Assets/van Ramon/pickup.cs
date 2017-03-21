using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour {
    public AudioClip clip;

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            AudioSource.PlayClipAtPoint(clip, transform.position);
            Destroy(gameObject);
            someGlobals.itemC = true;
        }
    }

}
