using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MoveNumber : MonoBehaviour 
{
	public float speed = 20;
    int num;

    void Start()
    {
        GetComponentInChildren<Text>().text = num.ToString();
    }

	// Update is called once per frame
	void Update () 
	{
        gameObject.GetComponent<Transform>().localPosition = Vector3.Lerp(gameObject.GetComponent<Transform>().localPosition, new Vector3(-46, 21, 34), speed * Time.deltaTime);

       
        if(gameObject.GetComponent<Transform>().localPosition == new Vector3(-46,21,34))
        {
            int leftSide, rightSide, answer;
            GameControl gameState = new GameControl();
            
            leftSide = GameObject.Find("Equation").GetComponent<EquationGenerator>().getLeftSide();
            rightSide = GameObject.Find("Equation").GetComponent<EquationGenerator>().getRightSide();
            answer = GameObject.Find("Equation").GetComponent<EquationGenerator>().getAnswer();

            if (gameState.GetCurrentRound() == 1) // First Round
            {
                GameObject.Find("Equation").GetComponent<Text>().text = num + " = " + answer;

            }
            else if (gameState.GetCurrentRound() == 2)
            {
                GetComponent<Text>().text = num + " = " + answer;
            }

            //Adjust text to account for negative and positive sign
            else if (leftSide >= 0)
                GetComponent<Text>().text = num + " + " + leftSide + " = " + rightSide;
            else if (rightSide < 0)
                GetComponent<Text>().text = num + " - " + Mathf.Abs(leftSide) + " = " + rightSide;

            Destroy(gameObject);
        }
	}

    public void setNumber(int number)
    {
        num = number;
    }
}
