using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorScript : MonoBehaviour
{

    public PlayerScript playerScript;
    public Text doorText;

    private string enter = "Appuyez sur E pour ouvrir la porte.";

    private string noKey = "Vous n'avez pas de cle pour ouvrir la porte";  

    // Start is called before the first frame update
    void Start()
    {
        
    }


    private bool playerInside = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorText.text = enter;
            doorText.GetComponent<Text>().enabled = true;
            playerInside = true;
            
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
            doorText.text = enter;
            doorText.GetComponent<Text>().enabled = false;
        }
    }

    void Update()
    {
        if (playerInside && Input.GetKey(KeyCode.E))
        {

            if(playerScript.KeyNumber > 0){
                ActivateFunctionality();
            }else{
                doorText.text = noKey;
            }
            // Call the functionality to activate
        }
    }

    void ActivateFunctionality()
    {
        doorText.GetComponent<Text>().enabled = false;
        Debug.Log("La porte a été détruite");
        playerScript.KeyNumber = playerScript.KeyNumber - 1;
        playerScript.TxtQuestion.text = playerScript.KeyNumber+"";

        // Destroy the object that this script is attached to
        Destroy(gameObject);
    }

}
