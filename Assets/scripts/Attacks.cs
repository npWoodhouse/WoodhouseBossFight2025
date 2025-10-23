using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class Attacks : MonoBehaviour
{
    private PlayerInput playerInput;

    public GameObject SlashBox;

    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerInput.actions["Attack"].triggered)
        {
            slash();
        }
    }

    void slash()
    {
        SlashBox.SetActive(true);
        StartCoroutine(SlashOff());
    }

    IEnumerator SlashOff()
    {
        yield return new WaitForSeconds(0.1f);
        SlashBox.SetActive(false);
    }
}
