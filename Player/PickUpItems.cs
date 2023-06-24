using UnityEngine;

public class FirstPersonController : MonoBehaviour {
    GameObject grabbedObject;
    public Camera playerCamera;

    void Update() {

        // If player presses the right mouse button is clicked
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (grabbedObject == null)
            {
                // Check for a nearby item tagged as "Pickable"
                Collider[] nearbyColliders = Physics.OverlapSphere(playerCamera.transform.position, 3f);
                foreach (Collider collider in nearbyColliders)
                {
                    if (collider.CompareTag("Pickable"))
                    {
                        // Picks up the item
                        grabbedObject = collider.gameObject;
                        grabbedObject.transform.parent = playerCamera.transform;
                        grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
                        break;
                    }
                }
            }
            else
            {
                // Releases the grabbed item
                grabbedObject.transform.parent = null;
                grabbedObject.GetComponent<Rigidbody>().isKinematic = false;
                grabbedObject = null;
            }
        }
        
    }
}

