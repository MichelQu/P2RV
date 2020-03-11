using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderCreator3 : MonoBehaviour
{
  
    /// <summary>
    /// Ceci est la version finale et fonctionnelle de ce script
    ///  en gros on va créer un script qui à chaque fois qu'on ajoute un son à la scène 
    ///  lui associe un slider pour gérer son volume 
    ///  souci, il va falloir gérer sa position et détecter quand on ajoute un son
    ///  
    /// autre idée: pendant la pause faire un menu déroulant avec 
    /// toutes les pistes sons et gérer le volume comme ça
    /// fait rien pour le moment
    /// 
    /// menu déroulant c'est pas core ça mais ça va venir, on atrouvé comment ajouter des sliders
    /// </summary>

    public List<AudioSource> audiolist;
    private GameObject thePlayer;
    private PauseMenu pausemenu;
    public List<float> slidervalue;

    // Start is called before the first frame update
    public Slider slide;
    public Canvas canva;
    bool change;

    // Update is called once per frame

    private void Start()
    {
        change = true;
        thePlayer = GameObject.Find("Main Camera");
        pausemenu = thePlayer.GetComponent<PauseMenu>();
        GetList();

        for (int i = 0; i < audiolist.Count; i++) // la mettre de taille 1000 évite des problèmes d'index out of range, la bibli de sons ne devrait pas dépasser cette taille anyway
        {
            slidervalue.Add(1f);
        }

    }


    void OnGUI()
    {
        if (pausemenu.isPaused)
        {
            for (int i = 0; i < audiolist.Count; i++)
            {
                CreerBouton(i);
                if (change)
                {
                    Slider slidi= CreerSlider(i);
                    slidi.value = slidervalue[i];
                    slidi.gameObject.name = i.ToString();
                }
            }
            Mute();
            Demute();
            change = false;   //pour qu'on instancie pas 1000 clones, on considère ici qu'on a une banque de sons qui ne bouge pas, ie qu'on a pris tous les sons dès le départ
        }
        if (!pausemenu.isPaused)
        {
            for (int i = 0; i < audiolist.Count; i++)  //on casse tout
            {
                Destroy(GameObject.Find(i.ToString()));
                change = true;
            }
        }
    }



    void Update()
    {
        pausemenu = thePlayer.GetComponent<PauseMenu>();

        if (pausemenu.isPaused)      // si on est en pause, on cherche les sliders 
        {
            GetList();
            if (audiolist.Count > slidervalue.Count)
            {
                for (int i = 0; i < slidervalue.Count; i++)
                {
                    Destroy(GameObject.Find(i.ToString()));
                }
                change = true; // psk ça veut dire qu'on a ajouté un son : pb ça réinstancie du coup pour les autres : réglé avec le destroy
                for (int j = 0; j < audiolist.Count - slidervalue.Count; j++)
                {
                    slidervalue.Add(1f);  //on ajoute autant de valeurs qu'il en manque
                }
            }
            if (audiolist.Count < slidervalue.Count)  // il faut les détruire, ce sont des sliders non affiliés à une piste son
            {
                for (int i = audiolist.Count; i < slidervalue.Count; i++)
                {
                    Destroy(GameObject.Find(i.ToString()));
                    slidervalue.RemoveAt(i);
                }
            }

                for (int i = 0; i < audiolist.Count; i++)
            { 
                if (GameObject.Find(i.ToString()) != null)
                {
                    Slider slidi = GameObject.Find(i.ToString()).GetComponent<Slider>();
                    audiolist[i].volume = slidi.value;
                    slidervalue[i] = slidi.value;
                }
            }
        }

    }


    public void GetList()   // la fonction qui va permettre de choper les Audio qui se jouent 
    {
        AudioSource[] getAudio;
        getAudio = Object.FindObjectsOfType(typeof(AudioSource)) as AudioSource[];  // on prend toutes les audiosource
        audiolist = new List<AudioSource>();
        for (int i = 0; i < getAudio.Length; i++)
        {
            if (getAudio[i].isPlaying)
            {
                audiolist.Add(getAudio[i]);
            }
        }
    }

    public void CreerBouton(int i)
    {
        // Le placement des Sliders se font par rapport au coin gauche du canvas.
        if (i < 11)
        {
            GUI.Button(new Rect(50, 20 + 45 * i, 120, 40), audiolist[i].name);
        }
        if (i < 22 && i > 10)
        {
            GUI.Button(new Rect(370, 20 + 45 * (i - 11), 120, 40), audiolist[i].name);
        }
        else
        {
            GUI.Button(new Rect(690, 20 + 45 * (i - 22), 120, 40), audiolist[i].name);
        }
    }

    public Slider CreerSlider(int i)
    {
        // Le placement des Sliders se font par rapport au centre du canvas.
        Slider slidi;
        if (i < 11)
        {
            slidi = Instantiate(slide, new Vector3(267, Screen.height + 2 - (45 * (i + 1)), 0), Quaternion.identity, canva.transform);
        }
        else if (i < 22 && i > 10)
        {
            slidi = Instantiate(slide, new Vector3(587, Screen.height + 2 - (45 * (i - 10)), 0), Quaternion.identity, canva.transform);
        }
        else
        {
            slidi = Instantiate(slide, new Vector3(907, Screen.height + 2 - (45 * (i - 21)), 0), Quaternion.identity, canva.transform);
        }
        return slidi;
    }


    public void Mute()
    {
        if (GUI.Button(new Rect(Screen.width - 130, 105, 110, 35), "Mute all"))
        {
            for (int i = 0; i < audiolist.Count; i++)
            {
                if (GameObject.Find(i.ToString()) != null)
                {
                    Slider slidi = GameObject.Find(i.ToString()).GetComponent<Slider>();
                    slidi.value = 0;
                }
            }
        }
    }

    public void Demute()
    {
        if (GUI.Button(new Rect(Screen.width - 130, 145, 110, 35), "Demute all"))
        {
            for (int i = 0; i < audiolist.Count; i++)
            {
                if (GameObject.Find(i.ToString()) != null)
                {
                    Slider slidi = GameObject.Find(i.ToString()).GetComponent<Slider>();
                    slidi.value = 1;
                }
            }
        }
    }
}