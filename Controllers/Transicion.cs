using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Transicion : MonoBehaviour
{
    public string escena;
    private string nombre;
    private Animator transition;
    void Start()
    {
        transition = GameObject.Find("Fade").GetComponent<Animator>();
        nombre = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (!nombre.Equals("Main"))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(SceneLoad(escena));
            }
        }*/
    }

    public IEnumerator SceneLoad(string escena)
    {
        Time.timeScale = 1;
        transition.SetTrigger("StartTransition");
        yield return new WaitForSeconds(1.2f);
        SceneManager.LoadScene(escena);
    }
}
