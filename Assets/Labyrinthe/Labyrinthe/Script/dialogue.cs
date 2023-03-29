using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class dialogue : MonoBehaviour
{
    private bool conversation = false;
    public Text TxtQuestion;
    string[] newText = new string[4];
    private int counter = 0;
    private Coroutine coroutine;


    private bool isShowingText = false;

    void initialise(){
        newText[0] = "Bonjour. Si vous voyez ce premier hologramme, cela signifie que vous êtes arrivé sur ma planète. Je suis un scientifique qui a étudié cette planète pendant de nombreuses années avant que ces créatures ne prennent le contrôle. Mais ne parlons pas de cela maintenant. Vous êtes ici, et vous avez besoin de savoir comment sortir de ce labyrinthe. Appuyez sur E pour continuer...";
        newText[1] = "Le labyrinthe est rempli de portes verrouillées, chacune nécessitant une clé différente pour être ouverte. Heureusement pour vous, j'ai laissé des hologrammes ainsi que des indices partout pour vous aider à trouver les clés. Vous devez être attentif, car chaque clé est cachée dans un endroit différent. Appuyez sur E pour continuer...";
        newText[2] = "Cependant, vous devez faire attention aux créatures qui patrouillent dans les couloirs. Appuyez sur E pour continuer...";
        newText[3] = "Soyez prêt à explorer chaque recoin de ce labyrinthe, car vous ne savez jamais où se cache la clé suivante. Bonne chance, vous allez en avoir besoin.";
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
            counter = 0;
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
        if(conversation) Conversation();
        
    }

    void Conversation(){
        if(counter >3){
            counter = -1;
        }
       if(Input.GetKey(KeyCode.E) && isShowingText == false){
            counter = counter + 1;
            coroutine = StartCoroutine(ShowLetterByLetter(newText[counter]));
       }
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
