using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueFin : MonoBehaviour
{
    private bool conversation = false;
    public Text TxtQuestion;
    string[] newText = new string[4];
    private int counter = 0;
    private Coroutine coroutine;


    private bool isShowingText = false;

    void initialise(){
        newText[0] = "Bravo ! Tu as réussi à trouver la sortie tout en échappant aux monstres !! Maintenant court vers la porte au fond de la pièce tu pourras accéder à la planète suivante...";
    }

    public GameObject objectToDisable;

    public float delai = 0.07f;

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player"){
            // Ici on peut aussi éviter cette ligne et remplir juste au dessus le newText
            TxtQuestion.text = null;
            TxtQuestion.GetComponent<Text>().enabled = true;
            objectToDisable.SetActive(true);
            conversation = true;
            coroutine = StartCoroutine(ShowLetterByLetter(newText[0]));
        }
    }

    void OnTriggerExit(Collider other) {
        if(other.gameObject.tag == "Player"){
            TxtQuestion.GetComponent<Text>().enabled = false;
            TxtQuestion.GetComponent<Text>().text = null;
            objectToDisable.SetActive(false);
            conversation = false;
            StopCoroutine(coroutine); 

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        initialise();
    }

    // Update is called once per frame
    void Update()
    {        
    }

    IEnumerator ShowLetterByLetter(string newTexts){
        isShowingText = true;
        for(int i=0; i<= newTexts.Length; i++){
            TxtQuestion.GetComponent<Text>().text = newTexts.Substring(0,i);
            yield return new WaitForSeconds(delai);
        }
        isShowingText = false;
    }
}

