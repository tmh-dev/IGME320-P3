using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatChanger : MonoBehaviour {
    public GameObject activePlayer;
    public GameObject strengthImage;
    public GameObject armorImage;
    public GameObject healthImage;
    private StatHandler stats;

    public Button strPlusButtonPrefab;
    public Button strMinusButtonPrefab;

    public Button armorPlusButtonPrefab;
    public Button armorMinusButtonPrefab;

    public Button healthPlusButtonPrefab;
    public Button healthMinusButtonPrefab;

    private Button strPlusButton;
    private Button strMinusButton;

    private Button armorPlusButton;
    private Button armorMinusButton;

    private Button healthPlusButton;
    private Button healthMinusButton;

    public bool switched;

    // Use this for initialization
    void Start () {
        switched = false;
        stats = activePlayer.GetComponent<StatHandler>();

        CreateButtons();
    }

    private void Update()
    {
        if (switched)
        {
            stats = activePlayer.GetComponent<StatHandler>();
            DeleteButtons();
            CreateButtons();
            switched = false;
        }

    }

    void CreateButtons()
    {
        strPlusButton = Instantiate(strPlusButtonPrefab);
        strMinusButton = Instantiate(strMinusButtonPrefab);
        strPlusButton.transform.SetParent(strengthImage.transform, false);
        strMinusButton.transform.SetParent(strengthImage.transform, false);

        armorPlusButton = Instantiate(armorPlusButtonPrefab);
        armorMinusButton = Instantiate(armorMinusButtonPrefab);
        armorPlusButton.transform.SetParent(armorImage.transform, false);
        armorMinusButton.transform.SetParent(armorImage.transform, false);

        healthPlusButton = Instantiate(healthPlusButtonPrefab);
        healthMinusButton = Instantiate(healthMinusButtonPrefab);
        healthPlusButton.transform.SetParent(healthImage.transform, false);
        healthMinusButton.transform.SetParent(healthImage.transform, false);

        strPlusButton.onClick.AddListener(() => stats.strength++);
        strMinusButton.onClick.AddListener(() => stats.strength--);

        armorPlusButton.onClick.AddListener(() => stats.armor++);
        armorMinusButton.onClick.AddListener(() => stats.armor--);

        healthPlusButton.onClick.AddListener(() => stats.health++);
        healthMinusButton.onClick.AddListener(() => stats.health--);
    }

    void DeleteButtons()
    {
        Destroy(strPlusButton);
        Destroy(strMinusButton);
        Destroy(armorPlusButton);
        Destroy(armorMinusButton);
        Destroy(healthPlusButton);
        Destroy(healthMinusButton);
    }
}
