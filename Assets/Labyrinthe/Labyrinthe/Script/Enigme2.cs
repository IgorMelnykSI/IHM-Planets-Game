using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Enigme2 : MonoBehaviour
{
    public Text boxText;
    public GameObject objectToDisable;
    private Coroutine coroutine;
    public float delai = 0.07f;



    public string enigme1Text = "Je suis un endroit mystérieux qui est caché dans les profondeurs de la terre. J'ai été créé par la nature, et j'ai des formations rocheuses étranges qui peuvent prendre la forme de colonnes, de stalactites et de stalagmites. J'attire de nombreux visiteurs qui viennent me découvrir chaque année.";

    public string reponse = "           Réponses : Une grotte (porte de gauche) / Un abysse (porte de droite)";
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
