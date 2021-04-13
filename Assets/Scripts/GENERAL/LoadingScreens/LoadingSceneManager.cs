using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingSceneManager : MonoBehaviour
{
    // Public attributes
    public float loadTime = 2.0f;

    // Private attributes
    private Scene scn;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        scn = SceneManager.GetSceneByPath("Assets/Scenes/MATH/MathRealm.unity");
        Debug.Log(scn.name);
        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < loadTime)
        {
            timer += Time.deltaTime;
        } else
        {
            SceneManager.LoadScene(scn.name);
        }
    }
}
