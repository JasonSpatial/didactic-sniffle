using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChillLabelManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _chillLabel;
    [SerializeField]
    private TMP_Text _noChillLabel;

    private Image _chillBar;    
    // Start is called before the first frame update
    void Start()
    {
        _chillBar = gameObject.GetComponent<Image>();
        _noChillLabel.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_chillBar.fillAmount < .01)
        {
            _chillLabel.enabled = false;
            _noChillLabel.enabled = true;
        }

        if (_chillLabel.enabled == false && _chillBar.fillAmount > .01)
        {
            _chillLabel.enabled = true;
            _noChillLabel.enabled = false;
        }
    }
}
