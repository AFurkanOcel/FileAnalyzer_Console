# FileAnalyzer Console App

A console app that allows users to select and analyze files with `.txt`, `.docx`, and `.pdf` extensions.  
The application provides a user-friendly file selection dialog using OpenFileDialog and processes the selected file content with appropriate reader classes.

## Features

- Supports `.txt`, `.docx`, and `.pdf` file formats  
- Reads and processes file content as text  
- Utilizes specific readers based on file type (TxtFileReader, DocxFileReader, PdfFileReader)  
- Performs detailed text analysis including:  
  - Total character count  
  - Number of lines  
  - Count of unique words filtered by excluding conjunctions and numbers  
  - Word frequency sorted from most to least frequent  
  - Number of occurrences for each word  
- Logs errors and exceptions to `Logs/log.txt`

## Requirements

- .NET Framework  
- Windows OS (required for OpenFileDialog)

## Usage

1. Run the program; a file selection dialog will open.  
2. Choose the file you want to analyze.  
3. The program reads and analyzes the file, then outputs analysis results to the console or designated output.  
4. Any errors encountered are logged in the `Logs` folder.

---

Feel free to ask if you want me to help with adding installation instructions or example outputs!
