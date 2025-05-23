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

    private SkillAttribute[] currentAttributes = new SkillAttribute[3];
    private Skill[] skills;

    private void Start()
    {
        rerollButton.onClick.AddListener(OnRerollClicked);
        skills = FindObjectOfType<SkillManager>().skills;
    }

    public void ShowRandomAttributes()
    {
        Time.timeScale = 0f;
        panel.SetActive(true);

        for (int i = 0; i < 3; i++)
        {
            // Pick random skill
            Skill randomSkill = skills[Random.Range(0, skills.Length)];

            // Generate a random attribute for that skill
            SkillAttribute attribute = GenerateRandomAttributeForSkill(randomSkill);

            currentAttributes[i] = attribute;

            optionsUI[i].titleText.text = $"{attribute.attributeName} ({randomSkill.skillName})";
            optionsUI[i].descriptionText.text = attribute.description;

            int capturedIndex = i;
            optionsUI[i].selectButton.onClick.RemoveAllListeners();
            optionsUI[i].selectButton.onClick.AddListener(() => ApplyAttribute(capturedIndex, randomSkill));
        }
    }

    private void ApplyAttribute(int index, Skill skill)
    {
        skill.AddAttribute(currentAttributes[index]);
        Debug.Log($"Applied {currentAttributes[index].attributeName} to {skill.skillName}");

        ClosePanelAndContinue();
    }

    private void OnRerollClicked()
    {
        if (PlayerStats.Instance.RerollPoints > 0)
        {
            PlayerStats.Instance.RerollPoints--;
            ShowRandomAttributes(); // Just call again to reroll
        }
        else
        {
            Debug.Log("No reroll points left.");
        }
    }

    private void ClosePanelAndContinue()
    {
        Time.timeScale = 1f;
        panel.SetActive(false);

        // Load next dungeon or level
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    private SkillAttribute GenerateRandomAttributeForSkill(Skill skill)
    {
        // For now, hardcoded pool. Later, load dynamically or via ScriptableObjects.
        if (skill is Skill_Dash)
        {
            var list = new SkillAttribute[] {
                new Dash_Lifesteal(),
            };
            return list[Random.Range(0, list.Length)];
        }

        if (skill is Skill_Shockwave)
        {
            var list = new SkillAttribute[] {
                //new Shockwave_Stun(),
                //new Shockwave_DoublePulse(),
                //new Shockwave_Burn()
            };
            return list[Random.Range(0, list.Length)];
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

        return null;
    }
}
