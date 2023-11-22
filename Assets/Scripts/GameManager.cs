using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.InputSystem;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Manager;

    // UI object to display winning text.
    public GameObject winTextObject;

    // UI text component to display count of "PickUp" objects collected.
    public TextMeshProUGUI countText;

    // UI text component to display count of "PickUp" objects collected.
    public TextMeshProUGUI timerText;

    // Variable to keep track of game time duration
    public float currentTime;

    // Variable to keep track of collected "PickUp" objects.
    private int count;

    private bool success;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize count to zero.
        count = 0;

        // Initialize time.
        currentTime = 0;

        // Update the count display.
        SetCountText(count);

        // Initially set the win text to be inactive.
        winTextObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!success) {
        currentTime += Time.deltaTime;
        timerText.text = "Timer : " + currentTime.ToString("00.000");
        }
    }

    public void Awake()
    {
        if (GameManager.Manager != null)
        {
            Destroy(this);
        }
        Manager = this;
    }

    // Function to update the displayed count of "PickUp" objects collected.
    public void SetCountText(int count)
    {
        // Update the count text with the current count.
        countText.text = "Count : " + count.ToString();

        // Check if the count has reached or exceeded the win condition.
        if (count >= 15)
        {
            // Display the win text.
            winTextObject.SetActive(true);

            success = true;
        }
    }

    // Function qui sera appelé lorsque le joueur ramasse un collectible.
    public void Collect(Collider other)
    {
        // Deactivate the collided object (making it disappear).
        other.gameObject.SetActive(false);

        // Increment the count of "PickUp" objects collected.
        count = count + 1;

        // Update the count display.
        GameManager.Manager.SetCountText(count);
    }


}
