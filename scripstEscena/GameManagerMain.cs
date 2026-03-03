using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Video;

public class GameManagerMain : MonoBehaviour
{
    private GameObject[] titulos;
    private GameObject[] botones;
    public VideoPlayer[] player;
    public Animator[] animator;
    private GameObject panel;
    private Animator AnimatorPanel;
    private TextMeshProUGUI text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        titulos = GameObject.FindGameObjectsWithTag("titulo");
        botones = GameObject.FindGameObjectsWithTag("boton");
        panel = GameObject.Find("PanelFinales");

        //Inicialización de los menús
        for (int i = 0; i < botones.Length; i++)
        {
            botones[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < player.Length; i++)
        {
            player[i].gameObject.SetActive(false);
        }

        int num= Random.Range(0, player.Length);
        player[num].gameObject.SetActive(true);
        player[num].Play();

        for (int i = 0; i < titulos.Length; i++)
        {
            TextMeshProUGUI texto=titulos[i].GetComponent<TextMeshProUGUI>();

            if (texto != null && texto.text.Equals("Unvollendet"))
            {
                if (num == 2 || num == 4) texto.color = Color.white;
                else texto.color = Color.black;
            }
            
        }

        panel.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            panel.SetActive(true);

            for (int i = 0; i < titulos.Length; i++)
            {
                titulos[i].gameObject.SetActive(false);
            }

            for (int i = 0; i < botones.Length; i++)
            {
                text = botones[i].GetComponentInChildren<TextMeshProUGUI>();
                if (text != null)
                {
                    if (text.text.Equals("Final A"))
                    {
                        Debug.Log("finala");
                        botones[i].SetActive(ControladorVideo.FinalA);
                    }
                    else if (text.text.Equals("Final B"))
                    {
                        Debug.Log("finalb");
                        botones[i].SetActive(ControladorVideo.FinalB);
                    }
                    else
                    {
                        botones[i].SetActive(true); // Mostrar todos los demás botones
                    }

                    animator[i].Play("Aparecer2");

                }
            }
        }
    }

    /*
    public void CargarPartida()
    {
        Transicion trans = Object.FindAnyObjectByType<Transicion>();
        int batallaProgresoGuardado = PlayerPrefs.GetInt("Batalla", 0);
        if (batallaProgresoGuardado != 0)
        {
            GameManager.primeraBatalla = batallaProgresoGuardado;
            StartCoroutine(trans.SceneLoad("Conver-" + batallaProgresoGuardado));
        }
        else
        {
            Debug.Log("No hay partida guardada. Comenzando desde el inicio.");
        }
    }
    */
}
