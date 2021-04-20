using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArtPauseMenu : MonoBehaviour
{
    // Private attributes
    private bool paused;
    private float speed;
    [SerializeField] Image bg;
    [SerializeField] GameObject pauseFrame;
    // Start is called before the first frame update
    void Start()
    {
        paused = false;
        speed = 10.3f / 7;
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PaintingDisplayer.instance.canPause)
            {
                if (!paused)
                {
                    paused = true;
                }
                else
                {
                    paused = false;
                }
                StartCoroutine("BgEnable");
                StartCoroutine("StopTimeScale");
                StartCoroutine("MovePauseFrame");
            }
        }
    }

    public void Retry()
    {
        paused = false;
        LevelManager.addLevel = false;
        LevelManager.instance.getNextLevel();
    }

    // Enable/disable background
    IEnumerator BgEnable()
    {
        if (paused)
        {
            while (bg.color.a < 0.7)
            {
                bg.color += new Color(0f, 0f, 0f, 0.1f);
                yield return null;
            }
        }
        else
        {
            while (bg.color.a > 0)
            {
                bg.color -= new Color(0f, 0f, 0f, 0.1f);
                yield return null;
            }
        }
    }
    // Set timescale
    IEnumerator StopTimeScale()
    {
        if (paused)
        {
            while (Time.timeScale > 0.1f)
            {
                Time.timeScale -= 0.1f;
                yield return null;
            }
            Time.timeScale = 0.0f;
        }
        else
        {
            while (Time.timeScale < 1.0f)
            {
                Time.timeScale += 0.1f;
                yield return null;
            }
        }
    }
    // Set buttons
    IEnumerator MovePauseFrame()
    {
        if (paused)
        {
            while (pauseFrame.transform.position.y > 0.7)
            {
                pauseFrame.transform.position -= new Vector3(0f, speed, 0f);
                yield return null;
            }
        }
        else
        {
            while (pauseFrame.transform.position.y < 11)
            {
                pauseFrame.transform.position += new Vector3(0f, speed, 0f);
                yield return null;
            }
        }
    }
}
