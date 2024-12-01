using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //public TriviaManager triviaManager;

    public List<question> responseList; //lista donde guardo la respuesta de la query hecha en la pantalla de selecci�n de categor�a

    public int currentTriviaIndex = 0;

    public int randomQuestionIndex = 0;

    public List<string> _answers = new List<string>();

    public bool queryCalled;

    private int _points;

    private int _maxAttempts = 10;

    public int _numQuestionAnswered = 0;

    [SerializeField] TextMeshProUGUI _timerText;
    [SerializeField] TextMeshProUGUI _pointsText;
    
    string _correctAnswer;

    public static GameManager Instance { get; private set; }

    private HashSet<int> _askedQuestions = new HashSet<int>();

    void Awake()
    {
        // Configura la instancia
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Para mantener el objeto entre escenas
        }
        else
        {
            Destroy(gameObject);
        }

    }


    void Start()
    {

        StartTrivia();

        queryCalled = false;


    }

    void StartTrivia()
    {
        // Cargar la trivia desde la base de datos
        //triviaManager.LoadTrivia(currentTriviaIndex);

        //print(responseList.Count);

    }

    public void CategoryAndQuestionQuery(bool isCalled)
    {
        isCalled = UIManagment.Instance.queryCalled;

        if (!isCalled)
        {

            do
            {
                randomQuestionIndex = UnityEngine.Random.Range(0, responseList.Count);
            } while (_askedQuestions.Contains(randomQuestionIndex));

            _correctAnswer = responseList[randomQuestionIndex].CorrectOption;

            _answers.Clear();
            _answers.Add(responseList[randomQuestionIndex].Answer1);
            _answers.Add(responseList[randomQuestionIndex].Answer2);
            _answers.Add(responseList[randomQuestionIndex].Answer3);

            _answers.Shuffle();

            for (int i = 0; i < UIManagment.Instance._buttons.Length; i++)
            {
                UIManagment.Instance._buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = _answers[i];

                int index = i;
                UIManagment.Instance._buttons[i].onClick.RemoveAllListeners(); 
                UIManagment.Instance._buttons[i].onClick.AddListener(() => UIManagment.Instance.OnButtonClick(index));
            }

            _askedQuestions.Add(randomQuestionIndex); 
            UIManagment.Instance.queryCalled = true;
        }
    }

    private void Update()
    {
    }
}
