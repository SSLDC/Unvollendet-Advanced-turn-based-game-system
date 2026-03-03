using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
public class ControladorVideo : MonoBehaviour
{
    public VideoPlayer player;
    public string escena;      // Nombre de la escena que se cargará al terminar el video
    public static bool FinalA=false;
    public static bool FinalB=false;
    private string nombreEscena;
    void Start()
    {
        // Se suscribe al evento que se activa cuando el video termina de reproducirse
        player.loopPointReached += OnVideoFinished;

        nombreEscena = SceneManager.GetActiveScene().name;
    }

    // Método que se llama cuando el video termina de reproducirse
    void OnVideoFinished(VideoPlayer vp)
    {
        if (nombreEscena == "FinalA")
        {
            FinalA = true;
            Debug.Log("entra en la condcion a");
        }
        else if (nombreEscena == "FinalB")
        {
            FinalB = true;
            Debug.Log("entra en la condcion b");
        }
        Transicion trans = Object.FindAnyObjectByType<Transicion>();

        // Inicia la carga de la nueva escena usando una corrutina
        StartCoroutine(trans.SceneLoad(escena));
    }
}
