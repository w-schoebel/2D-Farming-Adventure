using System;

public class SupportFunctoins
{
	public SupportFunctoins()
	{

	}

	public void ShowOnGUI(string toShow)
    {
		// Make a text field that modifies stringToEdit.
		stringToShow = GUI.TextField(new Rect(10, 10, 200, 20), toShow);
	}
}
