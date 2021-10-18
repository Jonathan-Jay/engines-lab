using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandInvoker : MonoBehaviour
{
    static Queue<ICommand> commandBuffer;

    static List<ICommand> commandHistory;
    static int counter;

    private void Awake() 
    {
        commandBuffer = new Queue<ICommand>();
        commandHistory = new List<ICommand>();
    }

    public static void AddCommand(ICommand command)
    {
        //while(commandHistory.Count > counter)
        if (commandHistory.Count > counter)
        {
            //commandHistory.RemoveAt(counter);
            commandHistory.RemoveRange(counter, commandHistory.Count - counter);
        }
        
        commandBuffer.Enqueue(command);
    }

    // Update is called once per frame
    void Update()
    {
        if (commandBuffer.Count > 0)
        {
            ICommand c = commandBuffer.Dequeue();
            c.Execute();
            
            //commandBuffer.Dequeue().Execute();

            commandHistory.Add(c);
            ++counter;
            Debug.Log("Command history length: " + commandHistory.Count);
        }
        else
        {
			//if ((Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Y)) ||
			//(Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Z)))
			if (Input.GetKeyDown(KeyCode.R))
            {
                if (counter < commandHistory.Count)
                {
                    commandHistory[counter++].Execute();
                }
            }
            //else if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Z))
            else if (Input.GetKeyDown(KeyCode.Z))
            {
                if (counter > 0)
                {
                    commandHistory[--counter].Undo();
                }
            }
        }
    }
}
