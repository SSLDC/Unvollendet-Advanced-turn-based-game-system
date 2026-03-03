using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class BotonColor : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler, IPointerDownHandler
{
    private TextMeshProUGUI text;
    public string escena;
    private string nombreEscena;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        nombreEscena = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        text.color = Color.white;
    }

    public void OnPointerClick(PointerEventData eventData)
    {

        if (text.text == "Salir")
        {
            #if UNITY_EDITOR
                        UnityEditor.EditorApplication.isPlaying = false;
            #else
                                        Application.Quit();
            #endif
        }
        //verificara si esta en ciertas escenas para el control, reincio o modificación de ciertas variables
        if (text.text == "Nueva Partida")
        {
            PlayerPrefs.DeleteKey("Batalla");
        }
        
        if (text.text == "Cargar Partida")
        {
            return;
        }

       
        if (text.text.Trim().Equals("No salvarla"))
            {
                GameManager.primeraBatalla = 0;
            }
        if (text.text.Trim().Equals("Salvarla"))
            {
                GameManager.primeraBatalla = 0;
            }


        if (nombreEscena.Trim().Equals("FinalA"))
            {
                ControladorVideo.FinalA = true;
                Debug.Log("activa boton a");
            }
        if (nombreEscena.Trim().Equals("FinalB"))
            {
                ControladorVideo.FinalB = true;
                Debug.Log("activa boton b");
            }


        if (nombreEscena.Trim().Equals("Conver-1")) Conversaciones.contaVideo = 2;

        if (nombreEscena.Trim().Equals("Conver-2")) Conversaciones2.contaVideo2 = 1;

        if (nombreEscena.Trim().Equals("Conver-3")) Conversaciones3.contaVideo3 = 1;

        Transicion trans = Object.FindAnyObjectByType<Transicion>();
            text.color = Color.white;
            StartCoroutine(trans.SceneLoad(escena));

    }

    // Se llama cuando el cursor sale del botón
    public void OnPointerExit(PointerEventData eventData)
    {
        text.color = Color.black;
    }

    // Se llama cuando se presiona el botón
    public void OnPointerDown(PointerEventData eventData)
    {
        text.color = Color.white;
    }

}