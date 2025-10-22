using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DecisionManager : MonoBehaviour
{
    [Header("UI Elements")]
    public TextMeshProUGUI descriptionText;
    public Button option1Button;
    public Button option2Button;
    public Button restartButton;

    [Header("Starting Node")]
    public DecisionNode startNode;

    private DecisionNode currentNode;

    void Start()
    {
        if (startNode == null)
        {
            Debug.LogError("No hay un nodo asignado!");
            return;
        }

        restartButton.onClick.AddListener(RestartGame);
        restartButton.gameObject.SetActive(false);

        currentNode = startNode;
        UpdateUI();
    }

    void UpdateUI()
    {
        if (currentNode == null) return;

        descriptionText.text = currentNode.description;

        bool isEndNode = currentNode.option1Next == null && currentNode.option2Next == null;

        if (isEndNode)
        {
            ShowEnding();
        }
        else
        {
            ShowDecisions();
        }
    }

    void ShowDecisions()
    {
        // Mostramos dos botones
        option1Button.gameObject.SetActive(true);
        option2Button.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(false);

        // Actualizar los textos
        option1Button.GetComponentInChildren<TextMeshProUGUI>().text = currentNode.option1Text;
        option2Button.GetComponentInChildren<TextMeshProUGUI>().text = currentNode.option2Text;

        // Limpiar listeners antiguos
        option1Button.onClick.RemoveAllListeners();
        option2Button.onClick.RemoveAllListeners();

        // Asignar nuevas decisiones
        option1Button.onClick.AddListener(() => ChooseOption(currentNode.option1Next));
        option2Button.onClick.AddListener(() => ChooseOption(currentNode.option2Next));
    }

    void ShowEnding()
    {
        descriptionText.text += "\n\nFin del juego.";
        option1Button.gameObject.SetActive(false);
        option2Button.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(true);
    }

    void ChooseOption(DecisionNode nextNode)
    {
        currentNode = nextNode;
        UpdateUI();
    }

    void RestartGame()
    {
        currentNode = startNode;
        UpdateUI();
    }
}