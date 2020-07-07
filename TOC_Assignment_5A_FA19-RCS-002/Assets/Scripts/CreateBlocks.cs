using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

public class CreateBlocks : MonoBehaviour
{

   public GameObject PickUp;
 //  public GameObject displayText;
    private Vector3 Cubes;
    private float radius = 1;
    private int numCubes = 10;
    public static int com;

    private static System.Random random = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        int i = 0;
        List<string> results = createPalindrome();

        while (numCubes > 0)
        {
            Cubes = new Vector3(UnityEngine.Random.Range(-10, 10), UnityEngine.Random.Range(1.2f, 1.2f), UnityEngine.Random.Range(-10, 10));
            if (Physics.CheckSphere(Cubes, radius))
            {

            }
            else
            {
                Debug.Log("its trigger,..");
                Instantiate(PickUp, Cubes, Quaternion.identity);
                //for text
      //        Instantiate(displayText, Cubes, Quaternion.identity);

                PickUp.transform.GetChild(0).GetComponent<TMPro.TextMeshPro>().text = results[i];
               // displayText.GetComponent<TMPro.TextMeshPro>().text = results[i];
                i++;
                numCubes = numCubes - 1;
            }
        }
    }

    public static List<string> RandomString()
    {
        List<string> list_of_strings = new List<string>();
        int x;
        for (int i = 0; i <= 10; i++)
        {
            x = UnityEngine.Random.Range(9, 15);
            const string chars = "XA2";
            string val = new string(Enumerable.Repeat(chars, 11)
              .Select(s => s[random.Next(s.Length)]).ToArray());
            list_of_strings.Add(val);
        }


        return list_of_strings;
    }


    public List<string> createPalindrome()
    {
        List<string> randomStrings = RandomString();
        List<string> pelindromeStrings = new List<string>();
        int count = 0;
        com = UnityEngine.Random.Range(3, 9);

        for (int i = 0; i < com; i++)
        {
            count++;
            string first = randomStrings[i].Substring(0, randomStrings[i].Length / 2);
            char[] arr = first.ToCharArray();
            Array.Reverse(arr);
            string temp = new string(arr);
            randomStrings[i] = first + temp;
            string value = randomStrings[i];
        }


        return randomStrings;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
