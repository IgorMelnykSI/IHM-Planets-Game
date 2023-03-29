using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IndiceKey : MonoBehaviour
{
    public Text indice;
    public string IndiceText = "EH PSSSST VIENS LA, IL Y A DES CLES !!!!";

    public GameObject objectToDisable;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")){
            indice.text = IndiceText;
            indice.GetComponent<Text>().enabled = true;
            objectToDisable.SetActive(true);
        }
        
    }

    private void OnTriggerExit(Collider other) {
        if(other.CompareTag("Player")){
            indice.GetComponent<Text>().enabled = false;
            objectToDisable.SetActive(false);

        }     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
