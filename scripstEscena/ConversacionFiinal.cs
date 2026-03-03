using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.Video;

public class ConversacionFiinal : MonoBehaviour
{

    public GameObject caja;
    public string[] textos;
    private TextMeshProUGUI text;
    private TextMeshProUGUI info;
    private TextMeshProUGUI nombre;
    public int num = 0;
    private int conta = 1;
    public string escena;
    private bool enter;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enter = false;
        text = GameObject.Find("Texto").GetComponent<TextMeshProUGUI>();
        info = GameObject.Find("Informacion").GetComponent<TextMeshProUGUI>();
        nombre = GameObject.Find("Nombre").GetComponent<TextMeshProUGUI>();
        caja.gameObject.SetActive(false);
        info.gameObject.SetActive(false);

        Invoke("activarCaja", 0.25f);
    }

    // Update is called once per frame
    void Update()
    {
        if (enter == true)
        {
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                conta++;
                if (num < textos.Length)
                {
                    text.text = textos[num++];
                }

                if (conta > textos.Length) cambiarEscena();
            }
        }
    }

    

    public void activarCaja()
    {
        caja.gameObject.SetActive(true);
        info.gameObject.SetActive(true);
        text.text = textos[num];
        num++;
        enter = true;
    }

    public void cambiarEscena()
    {
        Transicion trans = Object.FindAnyObjectByType<Transicion>();
        StartCoroutine(trans.SceneLoad(escena));
    }
}
