using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class enigme1 : MonoBehaviour
{
    public Text boxText;
    public GameObject objectToDisable;
    private Coroutine coroutine;
    public float delai = 0.07f;



    public string enigme1Text = "Je suis une chose que tout le monde possède, mais dont personne ne veut entendre parler. Je suis souvent considéré comme inutile, mais je peux être très utile en cas d'urgence. Les riches peuvent s'en offrir de plus beaux que les pauvres. De quoi s'agit-il ?";

    public string reponse = "           Réponses : Une assurance (porte de gauche) / Un coffre-fort (porte de droite)";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            boxText.GetComponent<Text>().enabled = true;
            objectToDisable.SetActive(true);
            coroutine = StartCoroutine(ShowLetterByLetter(enigme1Text + reponse));


        }
    }

    private void OnTriggerExit(Collider other){
        if(other.CompareTag("Player")){
            boxText.GetComponent<Text>().enabled = false;
            objectToDisable.SetActive(false);
            StopCoroutine(coroutine); 

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ShowLetterByLetter(string newTexts){
        for(int i=0; i<= newTexts.Length; i++){
            boxText.GetComponent<Text>().text = newTexts.Substring(0,i);
            yield return new WaitForSeconds(delai);
        }
    }

}
