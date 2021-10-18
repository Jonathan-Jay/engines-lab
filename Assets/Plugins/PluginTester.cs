using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class PluginTester : MonoBehaviour
{
	[DllImport("DLL practice")]
	public static extern int AddTwoIntegers(int a, int b);

	[DllImport("DLL practice")]
	public static extern int MultTwoIntegers(int a, int b);

	[DllImport("DLL practice")]
	public static extern int SubTwoIntegers(int a, int b);

	[DllImport("DLL practice")]
	public static extern int DivideTwoIntegers(int a, int b);

	[DllImport("DLL practice")]
	public static extern void SortArray(int[] a, int length);

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(AddTwoIntegers(4, 2));
        Debug.Log(MultTwoIntegers(4, 2));
        Debug.Log(SubTwoIntegers(4, 2));
        Debug.Log(DivideTwoIntegers(4, 2));
		int[] arr = {
			4, 5, 5, 5, 5, 7, 8, 4, 3, 3, 2, 1
		};
		string text = "";
		for (int i = 0; i < arr.Length; ++i) {
			text += arr[i] + " ";
		}
		Debug.Log(text);

		SortArray(arr, arr.Length);
		text = "";
		for (int i = 0; i < arr.Length; ++i) {
			text += arr[i] + " ";
		}
		Debug.Log(text);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
