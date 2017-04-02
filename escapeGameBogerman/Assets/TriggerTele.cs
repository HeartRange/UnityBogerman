using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTele : MonoBehaviour {
    GameObject teleporterBeerman;

    void Start()
    {
        teleporterBeerman = GameObject.Find("teleporterBeer");
        teleporterBeerman.SetActive(false);
    }

  void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Triggered");
            teleporterBeerman.SetActive(true);
        }
	}
  void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Triggered Exit");
            teleporterBeerman.SetActive(false);
        }

    }

}
