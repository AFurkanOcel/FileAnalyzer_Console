# FileAnalyzer Console

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

## 📂 Project Structure

FileAnalyzer_Console/ </b>
├── Properties/
├── References/
├── FileReaders/
│ ├── TxtFileReader.cs
│ ├── DocxFileReader.cs
│ ├── PdfFileReader.cs
│ ├── App.config
│ ├── packages.config
├── Program.cs
├── TextAnalyzer.cs

## Usage

1. Run the program; a file selection dialog will open.  
2. Choose the file you want to analyze.  
3. The program reads and analyzes the file, then outputs analysis results to the console or designated output.  
4. Any errors encountered are logged in the `Logs` folder.

## 📸 Screenshots

**File Selection Dialog**  
When the program starts, a file selection dialog appears for choosing the file to analyze.

<img width="600" height="636" alt="selectfile" src="https://github.com/user-attachments/assets/9fcddc28-2d8e-45f9-ad0f-930bc71405ff" />

---

**Console Output**  
After selecting a file, the program analyzes it and displays the results in the console.

<img width="600" height="637" alt="console" src="https://github.com/user-attachments/assets/7f612d49-83dd-470d-8122-3c6ea542f382" />
