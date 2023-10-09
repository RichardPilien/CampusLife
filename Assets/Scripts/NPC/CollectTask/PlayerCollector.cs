using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Basic3rdPersonMovementAndCamera
{
    public class PlayerCollector : MonoBehaviour
    {
        public CollectTaskGiver[] taskGiver;
        public NPCCollectTask taskToGive;
        private bool canCollect = false;
        private int itemIndex = -1; // Initialize with an invalid index.

        // private bool canTalk = false;

        void Update()
        {
            if (canCollect && Input.GetKeyDown(KeyCode.F))
            {
                CollectBook();
            }

            // if (canTalk && Input.GetKeyDown(KeyCode.F))
            // {
            //     StartDialogue();
            // }
        }

        private void CollectBook()
        {
            // Loop through each element of the taskGiver array
            foreach (CollectTaskGiver giver in taskGiver)
            {
                if (giver.questStarted == true && itemIndex != -1)
                {
                    // Perform book collection logic here
                    // For example, update quest progress or inventory
                    giver.CollectBook(itemIndex); // Pass the item index to the taskGiver.
                }
            }
        }

        // private void StartDialogue()
        // {
        //     taskToGive.DialogueGUI.SetActive(true);
        //     // taskToGive.nameText.text = 
        //     taskToGive.dialogueText.text = "Hello there!";
        // }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Sphere"))
            {
                canCollect = true;

                // Loop through each element of the taskGiver array
                foreach (CollectTaskGiver giver in taskGiver)
                {
                    if (giver.questStarted == true)
                    {
                        taskToGive.InteractGUI.SetActive(true);
                    }
                }

                if (taskToGive.interactText != null)
                {
                    taskToGive.interactText.text = "[F] to Collect.";
                }

                // Loop through each element of the taskGiver array
                foreach (CollectTaskGiver giver in taskGiver)
                {
                    // Find the index of the item in the array.
                    for (int i = 0; i < giver.itemToCollect.Length; i++)
                    {
                        if (giver.itemToCollect[i] == other.gameObject)
                        {
                            itemIndex = i;
                            break; // Exit the loop when the item is found.
                        }
                    }
                }
            }

            // if (other.CompareTag("NPCDialogue"))
            // {
            //     canTalk = true;

            //     taskToGive.interactText.text = "[F] to Talk";
            //     taskToGive.InteractGUI.SetActive(true);
            // }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Sphere"))
            {
                canCollect = false;

                // Loop through each element of the taskGiver array
                foreach (CollectTaskGiver giver in taskGiver)
                {
                    taskToGive.InteractGUI.SetActive(false);
                }
                itemIndex = -1; // Reset the itemIndex when the player leaves the sphere.
            }
            // if (other.CompareTag("NPCDialogue"))
            // {
            //     canTalk = false;

            //     taskToGive.interactText.text = "[F] to Talk";
            //     taskToGive.InteractGUI.SetActive(false);
            //     taskToGive.DialogueGUI.SetActive(false);
            // }
        }
    }
}
