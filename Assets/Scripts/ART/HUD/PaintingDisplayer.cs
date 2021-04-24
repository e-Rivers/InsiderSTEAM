using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaintingDisplayer : MonoBehaviour
{
    // Public attributes
    public static PaintingDisplayer instance;
    public GameObject bg;
    public Button button;
    public bool canPause;
    // Private attributes
    [SerializeField] Text scoreText;
    [SerializeField] Image multiplier;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip paintingAppearanceClip;
    [SerializeField] AudioClip winClip;
    private Image bgImg;
    private Image image;
    private RectTransform rect;
    private float xSizeLimit;
    private float ySizeLimit;
    private float buttonTimer;
    private bool btnState;

    // Start is called before the first frame update
    void Start()
    {
        // Set self reference
        instance = this;
        // Get components
        image = GetComponent<Image>();
        bgImg = bg.GetComponent<Image>();
        rect = GetComponent<RectTransform>();
        // Disable painting
        image.enabled = false;
        // Set private variables
        xSizeLimit = transform.localScale.x;
        ySizeLimit = transform.localScale.y;
        buttonTimer = 0.0f;
        btnState = false;
        canPause = true;
        // Set painting size
        transform.localScale = new Vector3(0f, 0f, 1f);
        // Set button visibility
        button.GetComponent<Image>().enabled = false;
        button.transform.GetChild(0).gameObject.GetComponent<Text>().enabled = false;
    }

    // Function to display painting and info
    public void EnableCanvas()
    {
        StartCoroutine("PaintingDisplay");
        StartCoroutine("ShowBackground");
    }

    // Function to disable canvas
    public void DisableCanvas()
    {
        btnState = false;
        image.enabled = false;
        PaintingInfo.instance.titleText.enabled = false;
        PaintingInfo.instance.descText.enabled = false;
        button.GetComponent<Image>().enabled = false;
        button.transform.GetChild(0).gameObject.GetComponent<Text>().enabled = false;
    }

    // Coroutine to display painting information
    IEnumerator PaintingDisplay()
    {
        // Avoid player pausing during this screen
        ArtPauseMenu.instance.canPause = false;
        // Play winning sound
        audioSource.PlayOneShot(winClip);
        // Enable current level's painting
        image.enabled = true;
        image.sprite = InstructionManager.instance.currPainting;
        // Disable multiplier and score
        scoreText.enabled = false;
        multiplier.enabled = false;
        // Shake camera
        ArtCameraShake.instance.ShakeCamera(0.5f, 1.0f);
        // Stop player movement
        PlayerMovement.instance.disableInput = true;
        // Stop drops from spawning
        ColorSpawn.canSpawn = false;
        // Make first growing animation
        while (transform.localScale.x < xSizeLimit || transform.localScale.y < ySizeLimit)
        {
            if (transform.localScale.x < xSizeLimit)
            {
                transform.localScale += new Vector3(0.1f, 0f, 0f);
            }
            if (transform.localScale.y < ySizeLimit)
            {
                transform.localScale += new Vector3(0f, 0.1f, 0f);
            }
            yield return null;
        }
        // Move painting towards it's winning screen position
        while (rect.localPosition.x > -545 || rect.localPosition.y < 0)
        {
            if (rect.localPosition.x > -545)
            {
                rect.localPosition -= new Vector3(30f, 0f, 0f);
            }
            if (rect.localPosition.y < 0)
            {
                rect.localPosition += new Vector3(0f, 30f, 0f);
            }
            yield return null;
        }
        // Double painting scale
        while (transform.localScale.x < xSizeLimit * 2.5)
        {
            transform.localScale += new Vector3(1f, 1f, 0f) * Time.deltaTime * 10.0f;
            yield return null;
        }
        // Display painting info
        audioSource.PlayOneShot(paintingAppearanceClip);
        PaintingInfo.instance.SetInfo(LevelManager.level);
        btnState = true;
        // Wait for button to be active
        while (buttonTimer < 12.0f)
        {
            buttonTimer += 0.1f;
            yield return null;
        }
        // Activate button
        button.GetComponent<Image>().enabled = btnState;
        button.transform.GetChild(0).gameObject.GetComponent<Text>().enabled = btnState;
        // Determine button text according to number of levels played
        if (LevelManager.levelsPlayed < 3)
        {
            button.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Siguiente";
        }
        else
        {
            button.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Completar";
        }
    }

    // Increase winning background's opacity
    IEnumerator ShowBackground()
    {
        // While background's opacity is less than 180
        while (bgImg.color.a < 0.75)
        {
            // Increase opacity
            bgImg.color += new Color(0, 0, 0, 0.1f);
            yield return null;
        }
    }
}
