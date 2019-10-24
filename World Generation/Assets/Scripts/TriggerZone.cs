using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerZone : MonoBehaviour
{
    public AudioClip lockedSound;
    public Light doorLight;
    public Text textHints;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (Inventory.charge == 4)
            {
                transform.Find("door").SendMessage("DoorCheck");
                if(GameObject.Find("chargeUI"))
                {
                    Destroy(GameObject.Find("chargeUI"));
                    doorLight.color = Color.green;
                }
            }
            else
            {
                transform.Find("door").GetComponent<AudioSource>().PlayOneShot(lockedSound);
                col.gameObject.SendMessage("HUDon");
                textHints.SendMessage("ShowHint", "Hmm, this door looks like it's locked. Maybe I need to grab some cells for this generator.");
            }
        }
    }
}
