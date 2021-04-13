using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingSceneManager : MonoBehaviour
{
    // Public attributes
    public int buildIndex = 3;
    public float loadTime = 2.0f;

    // Private attributes
    private Scene scn;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        scn = SceneManager.GetSceneByBuildIndex(buildIndex);
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
