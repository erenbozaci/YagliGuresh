using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class AttributeSelectionUI : MonoBehaviour
{
    [System.Serializable]
    public class AttributeOptionUI
    {
        public TextMeshProUGUI titleText;
        public TextMeshProUGUI descriptionText;
        public Button selectButton;
    }

    public GameObject panel;
    public AttributeOptionUI[] optionsUI; // Must be size 3
    public Button rerollButton;



  

    

   

    

    private void ClosePanelAndContinue()
    {
        Time.timeScale = 1f;
        panel.SetActive(false);

        // Load next dungeon or level
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    

        //if (skill is Skill_Beam)
        //{
        //    var list = new SkillAttribute[] {
        //        new Beam_ChainLightning(),
        //        new Beam_ArmorBreak(),
        //        new Beam_Wider()
        //   };
        //    return list[Random.Range(0, list.Length)];
        //}


    
}
