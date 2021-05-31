using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeIdentifier : MonoBehaviour
{
    GameObject hitObject;
    [SerializeField] float timeTillNextUpdate = 1f;
    GameObject currentObject;
    [SerializeField] GameObject dynamite;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {  
       if(Time.time < timeTillNextUpdate) {return;} 
       if(currentObject != hitObject)
       {
           var objectCollider = currentObject.GetComponent<BoxCollider>();
           var objectRenderer = currentObject.GetComponent<MeshRenderer>();
           
           objectCollider.enabled = true;
           objectRenderer.enabled = true;
       }
        var ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width/2,Screen.height/2,0f));
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit,25))
        {
            GameObject hitObject = hit.transform.gameObject;
            if(hitObject.tag == "FakeObject")
            {
                var objectRenderer = hitObject.GetComponent<MeshRenderer>();
                var objectCollider = hitObject.GetComponent<BoxCollider>();
                objectRenderer.enabled = false;
                objectCollider.enabled = false;

                currentObject = hitObject;
            }
            else
            {
                currentObject = null;
            }
    
            }
                timeTillNextUpdate = Time.time + 1f;

        }
    }
