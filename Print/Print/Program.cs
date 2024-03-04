// See https://aka.ms/new-console-template for more information
using System;

Console.WriteLine("Hello, World!");

string sourceFilePath = "../../../input.txt";
string destinationFilePath = "../../../output.txt";

try
{
	// Read from the source file
	using (StreamReader reader = new StreamReader(sourceFilePath))
	{
		// Write to the destination file
		using (StreamWriter writer = new StreamWriter(destinationFilePath))
		{
			string line;
			while ((line = reader.ReadLine()) != null)
			{
				// Process each line if needed
				// For simplicity, we'll just write the line to the destination file
				int startIndex = line.IndexOf('/');
				if (startIndex != -1)
				{
					int endIndex = line.IndexOf('\"', startIndex);
					string key = line.Substring(startIndex + 2, endIndex - startIndex - 2);
					string value = line.Substring(startIndex, endIndex - startIndex);
					string firstLine = $"<data name=\"{key}\" xml:space=\"preserve\">";
					string secondLine = $"<value>{value}</value>";
					string thirdLine = "</data>";
					writer.WriteLine(firstLine);
					writer.WriteLine(secondLine);
					writer.WriteLine(thirdLine);
				}
			}
		}

		Console.WriteLine("File copy successful!");
	}
}
catch (Exception ex)
{
	Console.WriteLine($"An error occurred: {ex.Message}");
}
