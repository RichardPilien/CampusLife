using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
namespace Basic3rdPersonMovementAndCamera
{

    [System.Serializable]
    public class NPCCollectTask
    {
        public string questName;
        public TextMeshProUGUI nameText;
        [TextArea(5, 10)]
        public string questDescription;
        public bool taskComplete = false;
        public GameObject InteractGUI;
        public TextMeshProUGUI interactText;         // Reference to the UI text element
        public GameObject DialogueGUI;
        public TextMeshProUGUI dialogueText;
        public GameObject ProgressGUI;
        public TextMeshProUGUI progressText;
        public GameObject TaskInfoGUI;
        public TextMeshProUGUI taskInfoTitle;
        public TextMeshProUGUI taskInfoDescription;

        // public void AddObjective(CollectibleItem item)
        // {
        //     objectives.Add(item);
        // }

        // public void Complete()
        // {
        //     taskComplete = true;
        //     dialogueText.text = "Here is your Reward!";
        //     // QuestManager.instance.CompleteQuest(this);
        // }
    }
}
