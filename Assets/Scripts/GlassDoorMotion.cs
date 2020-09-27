using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassDoorMotion : MonoBehaviour
{
    public Animator animator;
    public bool isOpen;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NPC1") || other.CompareTag("NPC2") || other.CompareTag("NPC3"))
        {
            animator.SetTrigger("GlassOpen");
            isOpen = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (isOpen)
        {
            animator.SetTrigger("GlassClose");
            isOpen = false;
        }
    }
}
