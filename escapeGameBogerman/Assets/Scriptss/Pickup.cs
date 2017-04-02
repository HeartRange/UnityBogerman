using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {
    GameObject mainCamera;
    public bool carrying;
    GameObject carriedObject;
    public float distance;
    public float smooth;
    public bool throwed;
    public float throwForce = 1000;
    public GameObject PakOp;
    public GameObject keyUI;
    public int i;
    public Color fadecolor;
    public GameObject TextTest;
    public bool UITime;
    // Use this for initialization
    void Start() {
        keyUI = GameObject.Find("keyUI");
        keyUI.SetActive(false);
        mainCamera = GameObject.FindWithTag("MainCamera");
        throwed = false;
        PakOp = GameObject.Find("PakOp");
        PakOp.SetActive(false);
        i = 0;
        TextTest = GameObject.Find("TextTest");
        TextTest.GetComponent<Animator>().SetBool("fadeStatus", false);
        UITime = false;
    }

    // Update is called once per frame
    void Update() {
        if (carrying) {
            carry();
            checkDrop();
            checkThrow();
            rotateObject();
        } else {
            pickup();
        }
    }

    void rotateObject() {
        carriedObject.GetComponent<Transform>().Rotate(5, 10, 15);
    }

    void carry() {
        carriedObject.transform.position = Vector3.Lerp(carriedObject.transform.position, mainCamera.transform.position + mainCamera.transform.forward * distance, Time.deltaTime * smooth);
        carriedObject.transform.rotation = Quaternion.identity;
        PakOp.SetActive(false);
    }

    void pickup() {
        int x = Screen.width / 2;
        int y = Screen.height / 2;
        Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x, y));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 2)) {
            Pickupable p = hit.collider.GetComponent<Pickupable>();
            Key q = hit.collider.GetComponent<Key>();
            if (p != null) {
                UITime = true;
                TextTest.GetComponent<Animator>().SetBool("fadeStatus", true);
                PakOp.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E)) {
                    carrying = true;
                    carriedObject = p.gameObject;
                    p.gameObject.GetComponent<Rigidbody>().useGravity = false;
                }
            } else if (q != null) {
                UITime = true;
                TextTest.GetComponent<Animator>().SetBool("fadeStatus", true);
                keyUI.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E) && i == 0) {
                    someGlobals.gotkey = true;
                    Destroy(GameObject.Find("Key"));
                    i++;
             }
                else if (Input.GetKeyDown(KeyCode.E) && i > 0) {
                    someGlobals.gotkey2 = true;
                    Destroy(GameObject.Find("Key2"));
                    i++;
                }
            }
        }
        else {
            if (UITime == true)
            {
                TextTest.GetComponent<Animator>().SetBool("fadeStatus", false);
                PakOp.SetActive(false);
                keyUI.SetActive(false);
                UITime = false;
            }
        }
    }

    void checkDrop() {
        if (Input.GetKeyDown(KeyCode.E)) {
            dropObject();
        }
    }
    void checkThrow() {
        if (Input.GetMouseButtonDown(1)) {
            throwObject();
            throwed = true;

        }
    }
    void dropObject() {
        carrying = false;
        carriedObject.gameObject.GetComponent<Rigidbody>().useGravity = true;
        carriedObject = null;
    }
    void throwObject()
    {
        carrying = false;
        carriedObject.gameObject.GetComponent<Rigidbody>().useGravity = true;
        carriedObject.gameObject.GetComponent<Rigidbody>().AddForce(mainCamera.transform.forward * throwForce);
    }
}
