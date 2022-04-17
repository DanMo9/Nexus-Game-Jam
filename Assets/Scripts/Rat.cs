using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Rat : MonoBehaviour
{
    public float speed = 1;
    public float turnSpeed = 1;
    public Inventory inventory;
    public MessageDisplay messageDisplay;
    
    public GameObject lightWorldMouse;
    public GameObject darkWorldMouse;
    
    public AudioClip PickUpSound;
    
    private List<InteractableObject> interactableObjects = new List<InteractableObject>();
    private List<Tool> nearbyTools = new List<Tool>();
    private bool movementEnabled = true;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        ChangeWorld(World.light);
    }

    void Update()
    {
        if (!movementEnabled) return;
        Move();
        Interact();
    }

    private void Move()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 dir = Input.mousePosition - pos;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(angle - 90f, Vector3.forward),
            Time.deltaTime * speed);

        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        //var speedX =  transform.right * horizontal * speed * Time.deltaTime;
        var speedY = transform.up * vertical * speed * Time.deltaTime;

        transform.position += speedY;
    }

    private void Interact()
    {
        SetInteractionText();
        InteractWithObjects();
    }

    private void InteractWithObjects()
    {
        if (Input.GetKeyDown(KeyCode.E) && (interactableObjects.Count > 0 || nearbyTools.Count > 0))
        {
            foreach (var interactableObject in interactableObjects)
            {
                if (interactableObject.used) continue;
                
                if (!interactableObject.Use(this))
                {
                    messageDisplay.SetMessage(interactableObject.hint);
                }
                else
                {
                    if (interactableObject.onUseSound != null)
                        audioSource.PlayOneShot(interactableObject.onUseSound);
                    interactableObject.used = true;
                }
            }

            List<Tool> toRemove = new List<Tool>();
            foreach (var nearbyTool in nearbyTools)
            {
                audioSource.PlayOneShot(PickUpSound);
                inventory.AddTool(nearbyTool.toolData);
                toRemove.Add(nearbyTool);
            }

            foreach (var toolToRemove in toRemove)
            {
                Destroy(toolToRemove.gameObject);
            }
        }
    }

    private void SetInteractionText()
    {
        if (nearbyTools.Count > 0)
        {
            messageDisplay.SetPickupIndicator();
        }
        else if (interactableObjects.Count > 0 && interactableObjects.Any(x => !x.used))
        {
            messageDisplay.SetObjectIndicator();
        }
        else
        {
            messageDisplay.ClearIndicator();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var interactableObject = other.gameObject.GetComponent<InteractableObject>();
        if (interactableObject != null && !interactableObjects.Contains(interactableObject))
        {
            interactableObjects.Add(interactableObject);
        }
        
        var tool = other.gameObject.GetComponent<Tool>();
        if (tool != null)
        {
            nearbyTools.Add(tool);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        var interactableObject = other.gameObject.GetComponent<InteractableObject>();
        if (interactableObject != null)
        {
            interactableObjects.Remove(interactableObject);
        }
        
        var tool = other.gameObject.GetComponent<Tool>();
        if (tool != null)
        {
            nearbyTools.Remove(tool);
        }
    }
    
    public void ChangeWorld(World world)
    {
        if (world == World.light)
        {
            lightWorldMouse.SetActive(true);
            darkWorldMouse.SetActive(false);
        }
        else
        {
            lightWorldMouse.SetActive(false);
            darkWorldMouse.SetActive(true);
        }
    }

    public void EnableMovement()
    {
        movementEnabled = true;
    }

    public void DisableMovement()
    {
        movementEnabled = false;
        messageDisplay.ClearIndicator();
    }
}
