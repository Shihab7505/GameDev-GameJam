using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeCrystalIdentifier : MonoBehaviour
{
    GameObject crystal;
    [SerializeField] GameObject dynamite;
    GameObject hitObject;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width/2,Screen.height/2,0f));
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit,25))
        {
            hitObject = hit.transform.gameObject;
            if(hitObject.tag == "FakeCrystal")
            {
                var collider = hitObject.GetComponent<BoxCollider>();
                var renderer = hitObject.GetComponent<MeshRenderer>();
                collider.enabled = false;
                renderer.enabled = false;

                Instantiate(dynamite, hitObject.transform.position, Quaternion.identity);   
            }
        }
    }
}
