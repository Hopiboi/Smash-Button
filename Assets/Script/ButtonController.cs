using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{

    private SpriteRenderer sR;
    private Rigidbody2D rB2D;


    [SerializeField] private Sprite defaultImage;
    [SerializeField] private Sprite pressedImage;
    [SerializeField] private AudioSource clickEffect;
    [SerializeField] private AudioSource explodeEffect;

    private bool isLaunch;
    private float launchPower = 100f;
    private int launchCounter = 0;


    public KeyCode keyCode;

    void Start()
    {
        sR = GetComponent<SpriteRenderer>();
        rB2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(keyCode))
        {
            clickEffect.Play();
            sR.sprite = pressedImage;
            launchCounter += +1;
            Debug.Log(launchCounter);
            isLaunch = true;
        }

        if (Input.GetKeyUp(keyCode) && isLaunch == true)
        {
            sR.sprite = defaultImage;

            if (launchCounter == 10)
            {
                Input.GetKey(keyCode);
                rB2D.velocity = new Vector2(0, launchPower);
                launchCounter = 0;
                explodeEffect.Play();

                if (launchCounter == 0)
                {
                    isLaunch = false;
                    Destroy(gameObject, 2);
                }
            }
        }
    }


}
