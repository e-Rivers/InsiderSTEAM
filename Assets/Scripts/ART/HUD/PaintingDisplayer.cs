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
    private Image bgImg;
    private Image image;
    private RectTransform rect;
    private float xSizeLimit;
    private float ySizeLimit;
    private float buttonTimer;
    private bool btnState;
    private bool shaker;
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
        shaker = true;
        btnState = false;
        canPause = true;
        // Set painting size
        transform.localScale = new Vector3(0f, 0f, 1f);
        // Set button visibility
        button.GetComponent<Image>().enabled = false;
        button.transform.GetChild(0).gameObject.GetComponent<Text>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // If player has won
        if (InstructionManager.instance.win)
        {
            // Avoid pausing
            canPause = false;
            // Disable player movement
            PlayerMovement.instance.disableInput = true;
            // Disable score display
            scoreText.enabled = false;
            multiplier.enabled = false;
            // If it's the first time function has been called
            if (shaker)
            {
                // Enable current level's painting
                image.enabled = true;
                image.sprite = InstructionManager.instance.currPainting;
                // Shake camera
                ArtCameraShake.instance.ShakeCamera(0.5f, 1.0f);
                shaker = false;
            }
            // Make first growing animation
            if (transform.localScale.x < xSizeLimit || transform.localScale.y < ySizeLimit)
            {
                if (transform.localScale.x < xSizeLimit)
                {
                    transform.localScale += new Vector3(1f, 0f, 0f) * Time.deltaTime * 2.0f;
                }
                if (transform.localScale.y < ySizeLimit)
                {
                    transform.localScale += new Vector3(0f, 1f, 0f) * Time.deltaTime * 2.0f;
                }
            }
            else
            {
                if (rect.localPosition.x > -545 || rect.localPosition.y < 0)
                {
                    // Move image towards it's winning screen position
                    if (rect.localPosition.x > -545)
                    {
                        rect.localPosition -= new Vector3(1f, 0f, 0f) * Time.deltaTime * 1000.0f;
                    }
                    if (rect.localPosition.y < 0)
                    {
                        rect.localPosition += new Vector3(0f, 1f, 0f) * Time.deltaTime * 100.0f;
                    }
                }
                // Make last growing animation
                else
                {
                    if (transform.localScale.x < xSizeLimit * 2.5)
                    {
                        transform.localScale += new Vector3(1f, 1f, 0f) * Time.deltaTime * 10.0f;
                    }
                    else
                    {
                        if (buttonTimer < 4.0f)
                        {
                            PaintingInfo.instance.SetInfo(LevelManager.level);
                            btnState = true;
                            buttonTimer += Time.deltaTime;
                        }
                        else
                        {
                            button.GetComponent<Image>().enabled = btnState;
                            button.transform.GetChild(0).gameObject.GetComponent<Text>().enabled = btnState;
                            if (LevelManager.levelsPlayed < 3)
                            {
                                button.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Siguiente";
                            }
                            else
                            {
                                button.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Completar";
                            }
                        }
                    }
                }
            }
            // While background's opacity is less than 180
            if (bgImg.color.a < 0.75)
            {
                // Increase opacity
                bgImg.color += new Color(0, 0, 0, Time.deltaTime);
            }
        }
    }

    public void DisableCanvas()
    {
        btnState = false;
        image.enabled = false;
        PaintingInfo.instance.titleText.enabled = false;
        PaintingInfo.instance.descText.enabled = false;
        button.GetComponent<Image>().enabled = false;
        button.transform.GetChild(0).gameObject.GetComponent<Text>().enabled = false;
    }

}
