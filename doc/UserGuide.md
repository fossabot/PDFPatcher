# Software function introduction

PDF Patcher is a tool for modifying information in PDF files. It has the following functions:

- Modify the document (the functions marked with "\*" need to be implemented through the advanced patch modification function):
    - Modify document properties (such as author, subject, keywords, etc.). Support for overriding document properties by filename.
    - Bookmark Editor: Add, modify or delete PDF bookmarks, set the text color of bookmarks, open or collapse status, click jump position and page zoom ratio, etc. to modify PDF bookmark functions.
    - Replace fonts used in documents, or embed fonts into PDF documents that do not have embedded fonts.
    - Add or modify links within the page. \*
    - Add or change logical page numbering of PDF documents.
    - Change the initial settings of the reader (such as aspect ratio, interface, etc.).
    - Unify page size, crop or enlarge page size.
    - Adjust the page rotation direction.
    - Remove XML metadata embedded in documents or pages.
    - Remove actions that are automatically performed when a document or page is opened.
    - Remove restrictions on copying and printing PDF files.
- Advanced patch modification function (in two steps).
    - First export the information file (export the PDF document properties, initial state of the reader, page number settings, page settings, bookmarks and other information into an editable XML file.
    - Import information files to generate new files: Combine the above information files with existing PDF files to generate a new PDF document with the settings of the XML information file (such as page settings, bookmarks, etc.).
- Create PDF files: By importing a batch of images or existing PDF files, generate a PDF file containing images and the specified page range of the existing PDF file (bookmarks can be attached). This feature also splits or merges PDF files and preserves the bookmarks of the original files.
- Auto-generate PDF bookmarks: Analyze the text of PDF documents and generate bookmarks automatically.
- Text recognition: call Microsoft Office
    A 2003 or 2007 optical character recognition engine that converts pictures of PDF documents into text. The recognition results can be written into PDF documents.
- Lossless export of pictures to PDF files.
- Extract specified pages in PDF files.
- Rename PDF file names based on PDF document metadata.
- Analyze the document structure: View the PDF document structure in the form of tree nodes, and export the page or document content into XML files and binary files for PDF lovers to analyze and debug.
- Support to open and modify large PDF documents exceeding 2G bytes.

# License and license agreement

"PDF Patcher" software (hereinafter referred to as the software) is protected by copyright law, international treaty provisions and other intellectual property laws and treaties.

This software is free for end users, and you can freely use and disseminate it on the basis of following this agreement. Once you install, copy or use this software, it means that you have agreed to the terms of this agreement.

If you do not agree to this agreement, please do not install and use this software.

1. Software: Software refers to the "PDF Patcher" software and its updates, product manuals, online documents and other related carriers.

2. You may distribute an unlimited number of complete copies of the Software in any manner, provided that:

1. You must provide the full version of the software, and you are not allowed to make any modifications to the software or even its installation program without permission;

2. You cannot charge fees in any way or for any reason;

3. You cannot add this software to commercial promotional activities or products unless you have obtained the written permission of the copyright owner.

3. Support: The software will be continuously updated due to the needs of users, and the copyright owner will provide various related information support including user manuals, e-mails, etc., but the software does not guarantee that the supported content and functions will not change.

4. Termination: When you do not agree with or violate this agreement, the agreement will be automatically terminated, and you must delete this software product immediately.

5. Copyright: You need to be clear that you only have the right to use the software. This software is protected by copyright law, international treaty provisions and other intellectual property laws and treaties.

6. Disclaimer: This software and the copyright owner are not responsible for any damages caused by the installation, copying and use of this software.

# Software installation and use environment

## runtime environment

The PDF patch requires the Microsoft .NET Framework 4.0 or higher operating environment to be installed on the computer to run.

## How to install and run the program

PDF Patcher is a portable software, unzip the compressed package and run the PDFPatcher.exe file.

## Uninstall method

Delete the directory where the PDF patch is located to complete the uninstallation.

# Detailed function introduction

## Program interface

After starting the program, you will see the program interface as shown in the figure below.

![Program main interface](media/image3.png)
<figcaption>Figure 4--1: The program interface of the PDF patch</figcaption>

The interface is mainly divided into upper and lower parts: the upper part is the menu and toolbar area, and the lower part is the program function area and function switching area.

Clicking a menu item or toolbar button will open the corresponding function.

Frequently used functions appear as icons and function text in the toolbar, and less frequently used functions appear as icons. Move the mouse to the icon on the toolbar and hold it for a few seconds, the program will pop up the description text of the corresponding function of the button.

After the function is turned on, a tab will be added in the function switch area, corresponding to the function.

If you don't need to use this function, you can click the "X" button on the tab to close the tab and the corresponding function.

Each function of the program is introduced one by one below.

## process the file

The interface for processing PDF files is shown in the figure below.

![new image](media/image4.png)
<figcaption>Figure 4--2: Processing PDF file function</figcaption>

### document list

In the center of the interface is the "source file and file attribute list" (Figure 3 above). The list lists the files and their properties that need to be processed. Press and hold the Shift key or Ctrl key of the keyboard, and then click the source file name of the file list with the mouse to select multiple files at a time.

### add files

Use the "Add Files" button on the toolbar (① above) to add files to be processed to the file list. There is a small upside-down triangle button to the right of the "Add Files" button. Clicking this button will bring up a menu listing recently processed PDF files. You can also add files to the file list by clicking the File item on the menu.

Alternatively, you can select a batch of files in Windows Explorer (or another program's file list box), then drag and drop file items onto the list with the mouse.

**Note**: If the "Clear list before adding files" checkbox is selected, the file list will be cleared before adding files, and then the file items will be added. If the files that need to be processed are added to the file list several times, clear the check box.

**Notes**: When adding a file, if the PDF file itself is encrypted and requires a password to be opened, an authentication dialog box will pop up for entering the password. If the correct password is not provided, the PDF document will not be processed.

### Adjust the processing order of files

The order in which the program processes the files in the file list is from top to bottom.

After selecting a file, drag the selected item with the left mouse button to adjust the processing order of the file.

Use the sort menu on the toolbar to sort files. There are two ways to sort: "Sort Numerically and Alphabetically" considers numbers in filenames as numeric values. "Sort Alphabetically" sorts alphabetically by filename.

For example, there are four files "1.tif", "2.tif", "10.tif" and "3.tif" in the import list, after sorting them numerically and alphabetically, due to the "10" in the file name is larger than "3", so "10.tif" should be sorted after "3.tif", so the sorted order is "1.tif", "2.tif", "3.tif" and "10.tif" ; If sorting in alphabetical order, "1" in "10.tif" appears before "2" and "3", so the sorted order is "1.tif", "10.tif", "2.tif" and "3.tif".

Click the header of the file list to sort by the data corresponding to the header item. Click the first time to perform sequential sorting, and click again to perform reverse sorting.

### delete file item

After selecting an item on the file list, click the "X" button to delete the selected item.

### Modify the properties of the output file

Click on the "Title", "Author", "Subject" and "Keywords" columns of a file item in the file list, and the list item will enter the editing state. Edit the text of the item to modify the properties of the output file (the properties of the original file will not be changed). As shown below.

![new image](media/image5.png)
<figcaption>Figure 4--3: Modifying the properties of the output file</figcaption>

The file properties of some PDF files do not use the correct encoding, and the file properties will be displayed as garbled characters. In this case, you can select the PDF file in the file list, then click the inverted triangle button to the right of the "Refresh Document Properties" button on the toolbar, and select another encoding in the pop-up menu. As shown below.

![new image](media/image6.png)
<figcaption>Figure 4--4: Decoding document properties using other encodings</figcaption>

There are many kinds of commonly used encodings, try them one by one, you may choose the correct encoding method and turn the garbled characters into readable text.

### Toggle patch and rename mode

Under the toolbar is the "mode switch bar" (2 in the above figure), which contains two radio buttons, corresponding to two processing methods. By switching the processing method, the following tasks can be completed (see below for details):

[Independent patch](#Independent patch processing mode): Modify the content of the PDF document (modify bookmarks, page links, lift copy restrictions, etc.) to generate new files;

[Rename](#pdfDocument Options): View PDF document properties and rename PDF files according to document properties.

### Output file, info file path and execute button

The "Generate PDF File" button will execute the task corresponding to the mode selected in the mode bar, generate a new PDF file, and output it to the file path corresponding to "Output PDF File" (5 in the figure above). Some functions may involve information files used to modify PDF documents. It can be specified at "PDF information file" (④ in the above figure).

The following will introduce the usage methods according to the above two processing methods.

## "Independent Patch" processing mode

The "independent patch" mode of the processing file function is used to modify each PDF file of the processing list.

### The operation steps of patch modification document

The usual steps for independent patch mode are as follows:

1. Select the "Independent Patch" processing method of <q>processing PDF documents</q>.

2. Use the "Add" button or drag and drop to add the PDF files to be processed to the file list.

3. Click the "[Configure Processing File Options](#Advanced Patch Function Export and Import Information File)" link in the upper right corner of the interface (or select "PDF Document Options" in the function directory tree), in this interface [specify PDF files that need to be changed] Settings](#Advanced patch function export and import information files) (such as specifying the reader interface, removing restrictions such as copying and printing, setting the bookmark status to off, prohibiting bookmarks and page links from changing the display ratio, etc.). The modified settings will be applied to the generated PDF file. See section 4.5 for details.

4. Close the Options dialog box, return to the "Process/Make PDF File" function, and specify the path of the output PDF file (you can insert the output file name including the substitute character in the text box. Please refer to Section 4.3.2 for the usage of the substitute character) .

5. Click the "Generate PDF File" button. The program will process the PDF files in the file list one by one according to the settings of "PDF Document Options", and generate corresponding new PDF files to the output location.

### Batch operation output file naming rules

In order to correctly operate the batch patch operation of multiple original files, it is necessary to understand the location and naming rules of the output files after the batch operation. There are two naming conventions for programs: default naming convention and substitution naming convention.

#### Default naming convention

When there are multiple files in the file list, the output file name is the directory name where the specified file name is located in "Output PDF file" + the original file name + ".pdf" suffix.

For example: the selected original PDF file is in the "M:\\abc" folder, and there are two "f1.pdf" and "f2.pdf". The corresponding directory of "Output PDF file" is "E:\\efg", and the file name is "xyz.pdf" (that is, the path is "E:\\efg\\xyz.pdf").

In batch operations, the program will ignore the filename part of the output path and output files to the "E:\\efg" directory with the filenames "f1.pdf" and "f2.pdf". As shown in the table and diagram below.

Table 4-1: Example of batch operation output file name

| Input file name | "Output PDF file" location | Actual output file name |
| --------------- | ----------------- | --------------- |
| M:\\abc\\f1.pdf | E:\\efg\\xyz.pdf | E:\\efg\\f1.pdf |
| M:\\abc\\f2.pdf | E:\\efg\\xyz.pdf | E:\\efg\\f2.pdf |

![new image](media/image7.png)
<figcaption>Figure 4--5: Files output by default naming convention</figcaption>

#### Substitution Naming Rules

In the "Output PDF file" combo edit box, click the right mouse button and a context menu will pop up. Click an item of the menu to insert a substitute. When outputting the file, the surrogate character of the file name will be replaced with the corresponding content. The operation interface for inserting a substitute is shown in the figure below.

![new image](media/image8.png)
<figcaption>Figure 4-6: Inserting Substitutes in the Output Path</figcaption>

The meaning of each substitute is shown in the table below.

Table 4--2: Meaning of Substitutes

| Substitute name | Substitute content |
| ------------------ | ------------------------------ -------------------------------------------------- --------------------- |
| `<title>` | The "title" attribute of the original document |
| `<author>` | The "author" attribute of the original document |
| `<subject>` | The "subject" property of the original document |
| `<keyword>` | The "keyword" attribute of the original document |
| `<source directory path>` | The original PDF file path except the part of the file name (if the path of the source file is "M:\\abc\\efg\\hi.pdf", the substitution character means "M:\\ abc\\efg\\") |
| `<source file name>` | Original PDF file path file name without extension (if the source file path is "M:\\abc\\efg\\hi.pdf", the substitution character means "hi ") |
| `<source directory name>` | The folder name of the original PDF file path (if the source file path is "M:\\abc\\efg\\hi.pdf", the substitution character means "efg") |

Tip: The properties of the source file are listed in the file list.

An example is as follows:

The selected original PDF files are "M:\\abc\\efg\\f1.pdf" and "M:\\abc\\efg\\f2.pdf".

Where the "f1.pdf" file has the following document properties: "Title" is "Example 1", "Author" is "W. Jordan", and "Keywords" is "Example Document".

The 'f2.pdf' file does not have document properties.

The output path is `<source directory path><title>`, where `<source directory path>` represents the path part of the original PDF file except the file name. "`<title>`" represents the "title" attribute of the document.

Since the 'f2.pdf' document does not contain a 'title' attribute, the result of the surrogate substitution results in an empty filename. In this case, the program will automatically use the filename of the original path as the output filename part.

The output is shown in the table below.

Table 4-3: Output file name when output path contains the substitution character "`<source directory path><title>`"

| Input File Name | Document Properties | Output File Name |
|----------------------|---------------------|---- ---------------------|
| M:\\abc\\efg\\f1.pdf | Title=\"Example 1\" <br>Author=\"W. Jordan\" <br>Keywords=\"Example Document\" | M: \\abc\\efg\\Example 1.pdf |
| M:\\abc\\efg\\f2.pdf | No Document Properties | M:\\abc\\efg\\f2.pdf |

**Note**: In this example, the "f2.pdf" file output path is the same as the original path, so the patch cannot be executed.

![new image](media/image9.png)
<figcaption>Figure 4--7: Output of Substitute Naming Rules</figcaption>

## Advanced patch function (export, import info file)

The advanced patch function is used to export the information of the PDF document into an editable document. This document contains information such as PDF document properties, bookmarks, page links, page dimensions, etc., and is called an "info file".

Patching is done in two steps:

The first step, [Export information file](#Export information file): Export the information in the PDF document into [editable and modifiable XML information file](#xml information file reference).

The second step, [Import information file](#Import information file): Use a text editor to modify the XML file exported in the previous step, and then specify the information file in the processing PDF file, click the "Generate PDF file" button, the source PDF file and info file to generate a new PDF file with modified settings.

### Export info file

The operation steps are as follows.

1. Select the <q>Independent Patch</q> processing method of <q>processing PDF documents</q>.

2. Add the PDF file whose information needs to be exported to the file list.

3. Click the <q>Browse</q> button to the right of <q>PDF Information File</q> to specify the location to save the exported information file.

4. Click the <q>Export Information File</q> button, and the program will export the information in the original PDF file to the corresponding location of the <q>PDF Information File</q>.

The operation steps are shown in the following figure:

![new image](media/image10.png)
<figcaption>Figure 4--8: The process of exporting information files</figcaption>

### About "info file"

There are two types of information files: one is [XML format information file](#application example) (the file name suffix is ​​"xml"), the other is [simple text file](#Simple bookmark file reference) (document name suffixed with "txt").

When exporting info files, the type of info file is determined by the filename suffix. For example, if the information file name is "file.xml", the information file in XML format is exported; the information file name is "file.txt", the simple text bookmark file is exported.

The XML information file contains more complete and rich information. The information it can contain includes document properties, reader settings, bookmarks, page links, page layout settings, and so on. See the introduction in Chapter 6.

A text bookmark file contains only document properties and bookmark information pointing to a page (see Chapter 7 for details), much less information than an XML information file. For example, if you export the bookmarks of a PDF document into a simple text bookmark file, and then re-import it into the document after editing, because the simple text bookmark contains less information, the bookmarks of the original document may lose some information (such as the inability to precisely locate the specified position on the page). Wait). Therefore, in general, do not export simple text bookmark files.

### Import info file

After exporting the information file in the previous step, you can open it with a text editor or XML editor and modify the information in it. After modification, the content of the information file can be merged with the original PDF file to generate a new PDF file. The operation steps are as follows.

1. Specify the PDF source file and information file as in the previous step.

2. Click the <q>Browse</q> button on the right of <q>Output PDF file</q> to specify the location of the PDF file after saving the patch; or you can directly enter the output file path in the combo box corresponding to the output PDF file .

3. Click the <q>Generate PDF file</q> button. The program will switch to the output information interface. If the import is successful, the output PDF file will contain the content of the original PDF file and the information attached to the PDF information file.

![new image](media/image11.png)
<figcaption>Figure 4--9: The process of importing information files</figcaption>

The content of the information file does not necessarily need to be imported into the PDF file. You can specify which content of the information file should be imported at the <q>Import Options</q> of the <q>Info File Options</q> function.

For details on how to use the information file, please refer to [Application Example](#Application Example) and [Information File Reference](#xml Information File Reference).
### Batch processing method

If there are multiple original PDF files selected, the information file will be exported to the directory specified by the <q>PDF Information File</q> combo box, and the information file name will be named according to the PDF file name.

For example: the selected original PDF file is in the "M:\\abc" folder, and there are two "f1.pdf" and "f2.pdf". After clicking the <q>Browse</q> button on the right of the <q>PDF information file</q>, the specified information file is placed in the "M:\\efg" directory, and the file name is "xyz.xml" (that is, the path is "M:\\efg\\xyz.xml"). The program will ignore the file name part of the output path in batch operations, so the actual output information files will be placed in the "M:\\efg" directory with the file names "f1.xml" and "f2.xml".

Table 4-4: Example of output file name for batch export information file

| Input File Name | "PDF Info File" Location | Actual Output Info File Name |
| --------------- | ------------------ | -------------- -- |
| M:\\abc\\f1.pdf | M:\\efg\\xyz.xml |M:\\efg\\f1.xml |
| M:\\abc\\f2.pdf | M:\\efg\\xyz.xml |M:\\efg\\f2.xml |

![new image](media/image12.png)
<figcaption>Figure 4--10: Naming rules for batch export bookmarks</figcaption>

When importing files, the naming rules of information files are the same as above, that is, the program reads the information files with the same file name as the PDF file in the directory where the <q>PDF information file</q> is located as the information file for batch processing.

The naming of the output file is determined as described in Section 4.3.2.

### info file options

The info file option is used to specify what is exported and imported in the two steps of advanced patching. Select the <q>Info File Options</q> command in the <q>Options</q> menu of the program, and the Info File Options dialog box will pop up.

#### General export options

General export options specify what to export by the [Export Info File](#export info file) function. The interface is shown below.

![new image](media/image13.png)
<figcaption>Figure 4-11: Info File Options (General Export Options)</figcaption>
The options are described below.

1. <q>Character encoding</q>: Specify which encoding is used to export the information file. The system default encoding is GBK. Some PDF files contain some characters that cannot be represented by GBK encoding. At this time, you can try to select the encoding method such as <q>GB18030</q>, <q>UTF-8</q> or <q>UTF-16</q> in the drop-down box (use the system default, UTF-8 Or the information file exported in UTF-16 encoding can be directly opened and edited with Windows Notepad).
2. <q>Document Properties</q>: Specify whether to export metadata information such as title, author, keywords, and subject of the PDF document.
3. <q>Document bookmarks</q>: Specify whether to export bookmark information in PDF documents. Check this option when you need to modify PDF bookmarks.
4. <q>Links within pages</q>: Specify whether to export links within pages of the PDF document. For some PDF documents, clicking on certain areas can jump to other locations in the document, open a new document or open a website, etc. You can select this option when you need to modify these links.
5. <q>Parse the named location of bookmarks and page links</q>: The <q>named location</q> in the PDF document is a jump target represented by a specific name, which is stored independently of the bookmark information. If you find that the exported PDF bookmarks or page links cannot be patched to the PDF document, you can try selecting this option to convert the named locations of bookmarks and page links to actual locations.
6. <q>Reader settings</q>: Specify whether to export the initial layout method (such as single page, single page continuous, double pages, etc.), page numbering style (the logical page numbering method seen in the PDF reader, such as Roman numeral page number in the form of "I", "II", "III", English alphabetical page number in the form of "A", "B", "C") and other settings.
7. <q>Dimensional measurement unit</q>: Specify which unit to use to express the coordinate value of the PDF document. The program defaults to <q>cm</q>.

Tip: The standard unit of measurement used in PDF documents is <q>points</q>. For precise export of positioning information, select <q>points</q> as the unit of measurement.

#### Advanced export options

Advanced Export Options is an advanced feature provided by PDF Patcher for PDF developers. This function can export the content of PDF pages, processing instructions and other information in XML representation for development reference. The interface is shown below.

![new image](media/image14.png)
<figcaption>Figure 4-12: Info File Options (Advanced Export Options)</figcaption>

1. <q>Export catalog information</q>: After selecting this check box, the exported information file will contain the content in the PDF Catalog dictionary.
2. <q>Export page content</q>: After selecting this check box, the exported information file will contain the dictionary and drawing instructions of the PDF page for debugging and document research.
3. <q>Page range</q>: Specifies to export only the content of some pages. If no page number range is specified, the content of all pages will be exported.
4. Select the <q>Export page dictionary information</q> check box to export the page dictionary information.
5. Select the <q>Export Drawing Page Commands</q> check box to export commands that output text, pictures, and images to the page.
6. Select the <q>Export image as a separate file</q> check box to save the image as a separate file instead of writing it to the XML information file.
7. Select the <q>Decode the text in the exported page</q> check box to decode and extract the text of the content stream of the document page.

If you only need to analyze the contents of the first few bytes of the binary stream, you can enter a value in the number adjustment box of <q>limiting the number of bytes of the binary stream to be exported</q>, such as "100", which means that only the first 100 bytes of the binary stream are exported. content of bytes.

**Note**: The XML content exported by the advanced export option is for reference only and will not be written to the PDF document upon import. The binary content in the PDF document will be encoded into a CDATA string in the XML document using HexBin encoding.

#### import options

The import option is used to specify the content imported in the advanced patch function. The interface and the meaning of each option are as follows.

![new image](media/image15.png)
<figcaption>Figure 4--13: PDF Document Options (Information File Content)</figcaption>

1. <q>Document attribute information</q>: Whether to use the metadata specified in the information file (such as author, subject, keywords, etc.).
2. <q>Document bookmarks</q>: Whether to use the bookmarks specified in the information file. If this option is not checked, the bookmarks of the output file are the same as those of the original PDF file. For the bookmark format, please refer to the description in the [Bookmark](#Document Bookmark) section of [Information File Reference](#xml Information File Reference).
3. <q>Links in the page</q>: Whether to import the page links contained in the information file. If this option is selected, it can be replaced with the page link in the information file (select the <q>Replace</q> radio button to the right of the <q>original page link</q>) or overlay (select <q>Keep< /q> radio button) the page link of the original PDF file.
4. <q>Reader settings</q>: Whether to import the initial state of the reader (such as whether to display bookmarks when opening the document, full screen display, initial page state) and page numbering method.
5. <q>Page Settings</q>: Whether to import the size, cropping frame, rotation angle and other data of each page.

## PDF document options

PDF document options are used to specify how to modify the PDF document. Clicking the <q>PDF Document Options</q> item on the toolbar will open the PDF Document Options dialog box.

The Options dialog box divides the options in tabs. The interface is divided into <q>page size</q>, <q>reading method</q>, <q>compression cleaning</q>, <q>document properties</q>, <q>page label</q > and <q>Substitute Fonts</q> and other tabs are described below.

### page size

This option can unify the size of the PDF document or adjust the margin of the page border. The interface and the meaning of each option are as follows.

**Description**: The default state of the tab is shown in the figure below. If the settings of the interface are changed, the settings on the interface shall prevail when importing information; if the default settings are kept, the information specified in the information file shall prevail.

![new image](media/image16.png)
<figcaption>Figure 4--14: PDF document options (page size)</figcaption>

1. <q>Page Size, Width, Height</q>: In this list, you can specify the page size of the output PDF file. After changing the selected item in the <q>Page Size</q> list, the specific size will be displayed in the text boxes corresponding to <q>width</q> and <q>height</q>. The final page size is based on the dimensions specified by <q>width</q> and <q>height</q>. Even if the page size of the source PDF file is different, the output pages will be the same size.
2. <q>Special page sizes</q>:
1. <q>Same as original content size</q>: Does not change the page size of the output PDF document.
2. <q>Fixed page width and automatic height</q>: Freely specify the page width of the output PDF document, and scale the source PDF page proportionally to the specified width.
3. <q>Position</q>: Specify the alignment of the source PDF page on the new size page.
4. <q>Page Space</q>: The space left on the four sides of the page. When the <q>Synchronous adjustment of margins</q> option is selected, changing any of the margin values ​​will change the values ​​of the other three. Uncheck this option box to adjust the margin values ​​individually for each side. Values ​​can be negative to reduce page white space.

### How to read

The Reading Mode tab is used to specify the interface settings of the reader. The interface and the meaning of each option are as follows.

**Description**: The default state of the tab is shown in the figure below. If the settings of the interface are changed, the settings on the interface shall prevail when importing information; if the default settings are kept, the information specified in the information file shall prevail.

![new image](media/image17.png)
<figcaption>Figure 4--15: PDF document options (reading mode)</figcaption>

Reader settings: Specify the initial view, reading direction and initial mode of the reader. When <q>Keep unchanged</q> is selected in the drop-down list, the settings specified in the message file or original PDF file will prevail.

When two pages of vertical text (such as some ancient books) are displayed on one screen, the reading direction of the document can be set to <q>right to left</q> to suit the vertical reading mode.

The <q>Bookmark Status</q> option specifies whether to open (expand) or close all bookmarks. When the status is not specified, the status specified in the information file or the original PDF file shall prevail.

<q>Bookmark and Link Action</q>: Specify the zoom ratio of bookmarks and links within the page. Some bookmarks or page links will change the current display ratio of the reader after clicking. Select the <q>Prohibit bookmarks and page links from changing the display ratio</q> check box to remove such behaviors, so that after clicking bookmarks and page links The aspect ratio of the reader is still maintained. For some PDF documents, bookmarks are invalid after changing the file name. Selecting the option <q>Force change external PDF file links to internal links</q> can fix such bookmarks.

<q>Viewer interface settings</q>: Specify the interface when opening PDF files in a PDF reader. By default, the interface settings of the PDF reader are not forced to be changed. To override the UI settings for the PDF document, select the <q>Specify UI settings</q> check box. When this checkbox is checked, the gray disabled checkbox below will become operational. By setting the selected state of these check boxes, you can specify the interface of the PDF reader after opening the document.

### Compression cleanup

This feature is used to improve the compression ratio of PDF documents and to clean up some unwanted content. The interface and options are as follows.

![new image](media/image18.png)
<figcaption>Figure 4--16: PDF Document Options (Compression Cleanup)</figcaption>

1. <q>Source document processing, source document page processing</q>: used to clear restrictions (such as copying, printing, etc.), automatically executed actions, document annotations and metadata information.

   **Notes**: About the extended markup (XML) metadata attribute: XML metadata attribute is a kind of annotation information attached to the document, which generally does not affect the reading, and can be deleted if it is not necessary.

2. <q>Attempt to fix documentation errors</q>: In general, it is not necessary to select this checkbox. If the <q>Invalid operator</q> error occurs when opening certain PDF documents, select this check box to try to repair the document content.

3. <q>Clear all text on the page</q>: Do not select this check box under normal circumstances. This option will clear all text content on the page.

4. <q>Compress index table and bookmarks</q>: When this option is selected, the program will compress PDF index table and bookmark data to minimize the space occupied by PDF files.

   **Note**: Older or incompatible PDF readers may not be able to open PDF documents with compressed index tables.

5. <q>Optimize compression of black and white images</q>: When this option is selected, the program will try to use the JBIG2 algorithm to compress the black and white images in the PDF document in order to reduce the file space occupied by the images. If the file size cannot be reduced after compression, the original image will remain unchanged. Selecting this option will not reduce image quality, but may use more processing time.

### Document Properties

The Document Properties tab is used to specify document properties. In general, you do not need to use this tab to set document properties, you can directly enter the document properties to be set in the document list. This tab is used to set document properties in bulk. The interface and the meaning of each option are as follows.

**Description**: The default state of the tab is shown in the figure below. If the settings of the interface are changed, the settings on the interface shall prevail when importing information; if the default settings are kept, the information specified in the information file shall prevail.

![new image](media/image19.png)
<figcaption>Figure 4--17: PDF Document Options (Document Properties)</figcaption>

Document information: After selecting the <q>Use document attribute information set here</q> check box, you can specify document title, author, subject, keywords and other attributes.

In the processing mode of <q>independent patch</q>, you can right-click each document property text box, and a menu command for inserting `<source file name>` and `<source directory name>` substitutes will pop up. `<source file name>` means use the file name of the source PDF file as the specified document attribute, `<source directory name>` means use the directory name as the specified attribute. Use this feature to easily modify the properties of a PDF file using the PDF file name or directory name.

When rewriting the document properties, if the set document properties are empty, the corresponding original properties of the PDF document are retained. If the attribute is one or more half-width spaces (` `), the original attribute corresponding to the PDF document is deleted.

### Page Labels

Page number labels for a PDF document are usually displayed on the page-turning controls of a PDF reader and represent logical page numbers in the document.

The Page Labels tab can be used to specify logical page labels. The interface and the meaning of each option are as follows.

**Description**: The default state of the tab is shown in the figure below. If the settings of the interface are changed, the settings on the interface shall prevail when importing information; if the default settings are kept, the information specified in the information file shall prevail.

![new image](media/image20.png)
<figcaption>Figure 4--18: PDF document options (page number tags)</figcaption>

Click the <q>Add</q> button to add a page number label. If you need to modify the page number label, you can directly click the corresponding page number label item in the list box to modify its content. Click the <q>Delete</q> button to delete the selected page tag.

1. <q>Document Page Number</q>: Indicates the actual page number in the document that uses this page number tag. On the PDF reader interface, starting from this page, subsequent pages will display page numbers using the set tags.

2. <q>Page Numbering Style</q>: The style of page numbering. The default is a number, and Roman numerals and English letters can be used.

3. <q>Prefix text</q>: The text before the logical page number label.

4. <q>Start number</q>: The number of the start number of the logical page number label, generally kept as 1.

Take the following figure as an example to illustrate the usage of page number labels.

![new image](media/image21.png)
<figcaption>Figure 4--19: Example of page number label setting</figcaption>

In the above figure, the document page number of the first item is 1, the page number style is "capital English letters", the prefix text is "cover", and the starting page number is "1", then the page number of the first page in the reader is displayed as "Cover A".

The document page number of the second item is 2, the page number style is "capital Roman numerals", the prefix text is "Table of Contents-", and the starting page number is "1", then it starts from page 2 and ends on page 8 in the reader. (7 pages in total), the page numbers are displayed as "Table of Contents-I", "Table of Contents-II", "Table of Contents-III"..."Table of Contents-VII".

The document page number of the third item is 9, the page number style is "number", the prefix text is empty, and the starting page number is 1, then in the reader from the 9th page to the last page of the document, the page number is displayed as "1", "2", "3"......

### Substitute font

The settings in the Replace Font tab are used to replace the font of the PDF document with other fonts installed in the system. For some PDF documents without embedded fonts, this function can also implement the function of embedded fonts. The interface and the meaning of each option are as follows.

![new image](media/image22.png)
<figcaption>Figure 4--20: PDF document options (substitute fonts)</figcaption>

<q>Embedded Chinese Character Library</q>: After selecting this option, the following common font libraries are automatically embedded for PDF documents without embedded font libraries: Song, Hei, Kai, Imitation Song, and Young Circle.

<q>Allow font substitution</q>: Check this option to replace fonts in the PDF document.

<q>List document fonts</q>: To replace fonts in a PDF document, you first need to know which fonts are used in the document. Click this button and a dialog will appear. As shown below.

![new image](media/image23.png)
<figcaption>Figure 4--21: List document fonts</figcaption>

Click the <q>Browse</q> button, select the PDF document whose fonts need to be listed, and then click the <q>List Fonts</q> button, the fonts used in the document will be listed in the list at the bottom of the dialog box .

Select the checkbox corresponding to the font name, and then click the <q>Add selected item to the replacement list</q> button, the selected font will be added to the replacement font list of the PDF document options. Click the <q>Replace font</q> column to the right of the list item to specify the font installed in the system.

After the patch operation is performed, the fonts in the <q>original font</q> column will be replaced with the fonts in the <q>replacement font</q> column.

## Rename processing mode

This function is used to view the properties of the PDF document and can change the PDF file name according to the document properties.

The operation is similar to the independent patch processing mode.

The output PDF file is used to change the naming template of the PDF file. Named templates support replacers, so you can rename PDF files with document properties (eg <q>title</q>). For the usage of the substitution character, please refer to the introduction in the section [Substitution Character Naming Rules](#Substitution Character Naming Rules).

Click the <q>Test</q> button to preview the renaming results.

Clicking the <q>Generate PDF file</q> button will change the source PDF file name to the name specified by the template according to Rename Template. If you select the <q>Keep original file</q> check box, the PDF file before renaming will be kept, otherwise the file will be changed to the new name.

## Merge files

This function can realize the function of making PDF files in various ways, such as making e-books of scanned books, merging pictures and PDF files of the entire catalog into one PDF file, etc.

The merge function can also extract pages in a specified range from an existing PDF file and export to the generated PDF file, that is, it can merge or split the PDF file.

There is a list box in the center of the interface called <q>File List</q>. In the file list, you can mix the specified image and PDF file, and insert the image into the page of the PDF file.

Double-click the source PDF file in the list to specify the range of page numbers in the document that participate in the merge operation. The default page number range is from the first page to the last page. By modifying the page number range, the function of splitting and rearranging the pages of the PDF file can be realized.

In addition, you can specify the properties of the output PDF file when merging PDF files by modifying the settings of [Merge Document Options] (#Merge Document Options).

The interface of this function is shown in the figure below.

![](media/image24.PNG)
<figcaption>Figure 4--22: Merge Document Function</figcaption>

### How to operate

The steps to generate a PDF document using the merge file function are as follows.

1. Click the <q>Merge Files</q> button on the toolbar.

2. Add images (JPEG, PNG, GIF, BMP and TIFF files) or source PDF files to the file list. Each picture will become a page of the PDF document, if there are 3 pictures, the PDF document will have 3 pages; if there are 10 pictures, the document will have 10 pages. If the picture file has multiple frames, each frame will be treated as a separate page.

3. To add a blank page, click the <q>Insert Blank Page</q> button on the toolbar.

4. Click the <q>Add Folder</q> button, and a dialog box to open the file will pop up. Use this dialog to locate the folder to be added, and click the <q>Open</q> button to add all the pictures or PDF files in the folder to the list (including subfolders).

5. If you have added a file or folder that does not need to be merged, you can select the item and click the <q>Delete File</q> button on the toolbar to delete the file or folder from the file list.

6. To add bookmarks to the generated PDF files, click the <q>Browse</q> button to the right of <q>PDF information files</q> to specify the location of the bookmarked files. The information file is not required and can not be specified. When no bookmark is specified, the program generates bookmarks according to the generated PDF files listed as <q>bookmark text</q> in the file list.

7. Click the <q>Browse</q> button to the right of <q>Output PDF</q> to specify the save location of the created PDF file.

8. Click the <q>Generate PDF file</q> button.

9. The program will create the PDF file, and then add the pictures or source PDF files to the pages of the output PDF file one by one in the order of the file list.

Tip: In addition to using the button to add files or folders, you can also drag and drop files to the file list directly from Explorer.

#### Sort files

After selecting the file item, use the mouse to click and hold the text area where the file needs to be moved, and then drag the mouse to move the file. Move the mouse over other file items and release the mouse button to move the selected file to the corresponding position.

For example, after selecting the two file items <q>program main interface.PNG</q> and <q>subfolder2</q> in the following figure, drag them to <q>folder1< /q> bookmarks. A blue rectangle will appear on <q>folder 1</q>.

![new image](media/image25.png)
<figcaption>Figure 4--23: Sorting file items</figcaption>

The blue rectangle has four areas, and releasing the mouse button in different areas moves in different ways. Take the picture above as an example.

Release the mouse button on the ① area, and the selected file item will be moved to the front of "Folder 1".

Release the mouse button on the ② area, and the selected file item will be moved to the back of "Folder 1".

Release the mouse button on the ③ area, and the selected file item will be moved to the front of all sub-items of "Folder 1".

Release the mouse button on the ④ area, the selected file item will be moved to the back of all the sub-items of "Folder 1".

The effects of moving the file items are shown in the following figures respectively (the two file items being moved are in the selected state).

![new image](media/image26.png)
<figcaption>Figure 4--24: Effect of moving file items</figcaption>

**Notes**: When dragging bookmarks, press the keyboard's Esc key to cancel the drag operation.
#### Set bookmark text and bookmark style

When merging to generate PDF files, you can specify navigation bookmarks, and clicking the bookmarks in the reader will jump to the page corresponding to the file.

The bookmark text is set in the <q>Bookmark text</q> column of the merged file list. After adding the file to the merged files list, click the cell in the <q>Bookmark Text</q> column. The cell will enter the editing state, enter text in it, and then set the corresponding bookmark item for the file.

When the bookmark text is not empty, select the file item, and then click the <q>B</q> and <q>I</q> buttons on the toolbar to set the bold and italic styles for the bookmark item respectively ; Click the small inverted triangle button next to the palette button on the toolbar to set the text color of the bookmark item.

If the bookmark text content is empty, the item does not generate a bookmark. If the item has children, and the child text is not empty, the children still generate corresponding bookmarks.

**Description**: When adding a file to the merged file list, the program will automatically set its corresponding bookmark text according to the file name. This behavior can be adjusted in the merge file options.

#### Crop source image options

Double-click the image file in the file list, and the <q>Source Image Processing Options</q> dialog box will pop up, as shown in the figure below. Use this dialog to specify that when importing an image to make a PDF file, the image is cropped before importing into the document.

![new image](media/image27.png)
<figcaption>Figure 4--25: Source Image Processing Options Dialog</figcaption>

#### Filter source PDF file page options

Double-click the PDF file in the file list, and the <q>Source PDF File Options</q> dialog box will pop up, as shown below. Use this dialog box to specify to import only a few pages of the source PDF document, or only images within the PDF document.

The default state of the controls in the image method column of importing and processing source PDF files is disabled. Only available if the <q>Import only images from the source PDF file</q> check box is selected. The import picture option is similar to the option of the [Extract picture](#global option) function, please refer to the description of this chapter.

Tip: The page number range supports the reverse order range, such as the page number range "10-1", it will first insert the 10th page of the source file, then the 9th page, and so on, and finally insert the 1st page into the output document.

![new image](media/image28.png)
<figcaption>Figure 4--26: Source PDF File Options Dialog</figcaption>

### Known Issues

- The size of the imported bookmarks should match the size of the selected output file, otherwise the positioning coordinates may be inaccurate.

- The document properties and metadata of the source PDF file will not be output to the generated target file, but can be imported into the output file by specifying the information file, or specifying the document information in <q>PDF document options</q>.

## Merge document options

Merge Document Options is used to specify options for PDF documents generated by the merge function. Click the <q>Merge Document Options</q> item on the toolbar, or click the <q>Set Merge PDF Document Options</q> link on the interface to open the <q>Merge Document Options</q> dialog box .

The Options dialog box divides the options in tabs. The interface is divided into <q>page layout</q>, <q>reading method</q>, <q>bookmarks</q>, <q>document miscellaneous</q> and <q>page label</q> etc tab. Among them, the contents and functions of <q>Reading Mode</q>, <q>Document Miscellaneous</q>, and <q>Page Label</q> are basically the same as those of the PDF document options, and will not be repeated here. The two tabs, <q>Page Layout</q> and <q>Bookmarks</q>, are described below.

### Page Layout

The <q>Page Layout</q> tab interface is shown in the figure below, which is similar to the <q>Page Size</q> dialog box of the PDF document options, but with the following options added.

![](media/image29.PNG)

Auto-rotate page to fit original content aspect orientation: When this option is checked, the program will automatically rotate the page to better fit the image if the image has a different aspect and page orientation and the page cannot accommodate the image.

For example, click the <q>Size</q> drop-down list and select a page size of 16K (width 184mm, height 260mm), which is a portrait page whose width is smaller than its height. At this time, the size of the input source page is 1024 pixels wide and 768 pixels high, and the picture is a horizontal page whose width is greater than its height. If this option is not selected, the horizontal picture will be directly placed on the vertical page, leaving a lot of blanks (left side of the picture below)

After selecting this option, the program will automatically set the page layout to landscape, adapt to the orientation of the source image, and then place the content of the source image on the new page (right below).

![shot](media/image30.jpeg)

1. <q>Scale original content to fit page</q>: Specify whether to resize the source image to fit the page size. Select the <q>Lossless Shrink</q> check box to shrink the original content to fit the page when the page is smaller than the original content size. Check the <q>Lossless Enlarge</q> checkbox to enlarge the original content to fit the page when it is smaller than the page size.

**TIP**: Adjusting the zoom ratio will not reduce the quality of the image (it only uses the PDF built-in zoom command to make the image appear in different dimensions).

2. <q>Source PDF Page Adjustment</q>: Specify whether to change the page enlargement ratio of the source PDF file to fit the page size of the output document. By default, <q>Adjust to page size</q> is selected, the program keeps the original content of the document unchanged, but changes the page size to make it consistent with the size of the page setting. This can expand the blank area of ​​the page to add comments, or hide unnecessary white space on the page for easy reading. If <q>Scale content to fit page</q> is checked, the pages imported from the source PDF file will be stretched to fit the pages of the output document.

3. <q>Make black and white pictures transparent</q>: For pictures that are only black and white, set them to be transparent (the picture will not be selected and copied in the PDF reader).

4. <q>Optimize the compression of black and white pictures</q>: Use the JBIG2 algorithm with a higher compression rate to compress black and white pictures.

### Bookmarks

The Bookmarks tab contains options to control the generation of bookmarks from PDF files, and its interface is as follows.

![](media/image31.PNG)
<figcaption>Figure 4--27: PDF Document Options (Bookmarks)</figcaption>

Automatically generate bookmark text according to the file name when adding an item: When this option is selected, a bookmark item is added to the page corresponding to each source file (image or source PDF file), and the text of the bookmark item is the source file name (delete the extension part) .

Ignore leading numbers in filenames: This option is available when the <q>Auto-generate bookmark text from filenames when adding items</q> check box is selected. When checked, the text of the bookmark item is the part of the source file name with the preceding number removed. If the filename is empty after removing the number, the page will not be bookmarked. For example, the file list used to generate the PDF has 4 image files with the file names: "0001Cover.jpg", "0002Category.tif", "0003.tif" and "0004Chapter 1.tif", Then the generated bookmarks have three items named "Cover" (jump to page 1), "Contents" (jump to page 2) and "Chapter 1" (jump to page 4).

Sort subfolders before files: When this option is checked, the subfiles contained in the folder will be sorted before files when adding a folder to the file list. When this option is not checked, files are sorted alphabetically.

File names are sorted by numerical value and text respectively: When this option is selected, when adding a folder to the file list, the files contained in the folder will be sorted by numerical value and text respectively, for example, the following sequence is sorted by numerical value and text 1.pdf, 2 .pdf and 10.pdf (sorting treats "10" as numeric, after "2"), while 1.pdf, 10.pdf and 2.pdf are sorted by text (sorting treats "10" as numerical text, before "2").

**Note**: After changing each of the above options, the bookmark text of the file list will not refresh. If you need to refresh the bookmark text, you can delete the originally added file in the file list, and when you add a file to the list again, the bookmark text will be generated according to the new settings.

Keep bookmarks from source PDF files: Copy bookmarks from source PDF files to the merged output document. If the page of the source PDF file is not in the output document, clicking the bookmark will do nothing.

Delete bookmarks linked to invalid pages: This option is valid when the <q>Keep bookmarks of the source PDF file</q> checkbox is selected. When this option is selected, if the page of the source PDF file is not in the output document, the bookmark pointing to this page will be deleted (if the bookmark contains sub-bookmarks, the sub-bookmarks will also be deleted). For example, the source PDF file has 100 pages, and only 1 to 50 pages of which are imported to generate a new PDF file, the bookmark items in the source file pointing to the 51st to 100th pages of the original document will be deleted.

## Automatically generate bookmarks

This feature can be used to automatically generate bookmarks for PDF documents. The principle is: the text of the PDF document has certain formatting rules, so according to the rules of page text, size, font used, etc., the text that conforms to the rules (often large-character titles) can be screened out, and the PDF bookmarks can be generated by using these texts. The interface of this function is shown in the figure below.

![new image](media/image32.png)
<figcaption>Figure 4--28: Automatic bookmark generation function</figcaption>

**Notes**: This function automatically creates bookmarks for PDF documents by analyzing the font size of the text content in the PDF document, instead of performing Optical Character Recognition (OCR) to recognize images as text.

### Steps

Use this function to generate bookmark files of text PDF, and the operation steps are as follows.

1. Select the <q>Identify title as bookmark</q> function.

2. Click the <q>Browse</q> button to the right of the <q>original PDF file</q> and specify the PDF file whose title is to be identified as bookmarks.

3. Click the <q>Browse</q> button to the right of <q>PDF Information File</q>, and specify the information file to save the bookmark after recognition.

4. If necessary, adjust the options (specifically <q>Identify Page Range</q>).

5. Click the <q>Export Info File</q> button. The program will analyze and identify the text within the specified page number range in the original PDF file, extract the text whose size is larger than the value of the <q>title text size</q> spinner, organize it into bookmarks, and save it as an XML information file. During the processing of the program, the log window outputs the text identified as the title, the level, and the page number on which it is located.

6. Observe the output content of the log window to see the overview of the output bookmarks. Usually the bookmarks obtained from the first analysis are not ideal, you can return to adjust the filtering options, such as adjusting the title text size to include the title text with a smaller (or larger) font, specifying the filter text to filter out unwanted text, and processing in advanced filtering. Add a filter to the options to exclude specific fonts, etc.

**Tips**: You can open the information file output by this function with a text editor, which lists the size of the title text. Alternatively, in the <q>Advanced Filter Processing</q> option, click the <q>Add from Information File</q> button. After clicking this button, the program pops up a dialog box. Use this dialog to add header text filters from the output info file.

7. Repeat steps 5 and 6 until a satisfactory nesting effect of bookmarks is obtained.

8. After completion, go to the <q>Independent Patch</q> processing mode of the <q>Processing, Generate PDF Document</q> function, patch the PDF file with the previously generated information file, and check the bookmark effect of the output file. If the effect is not satisfactory, you can manually modify the XML information file and re-patch.

Tip: Detailed application examples can be found in Section 5.10 of this manual.

### Header recognition options

The filter parameters for the analysis process can be specified in the tabs of this function.

1. <q>Identify page number range</q>: Specify the page number of the text to be analyzed.

2. <q>Title text size</q>: Specifies that only text with a size larger than this value may be extracted as bookmarks.

3. <q>The positioning position is shifted upward by several double spacing</q>: When the text is extracted as a bookmark item, clicking the bookmark item will jump to the corresponding text, but it will be shifted upward by some positions, so that the positioned Text does not stick to the top of the reader window.

4. <q>Automatically organize heading levels</q>: When this option is checked, the program generates multi-level bookmarks according to the size level of the text.

5. <q>Merge consecutive headings</q>: If two lines of text meet the conditions for forming a heading, it will be regarded as a heading (suitable for the occasion that a heading is displayed on two lines).

6. <q>Merge titles of different sizes in the same line</q>: When the font size of the title text is different, select this option to merge the texts of different sizes into one title.

7. <q>Merge titles with different fonts</q>: When the font styles of the title texts are different, select this option to merge the texts with different fonts into one title.

8. <q>Ignore overlapping text</q>: Some PDF authoring programs will output the same text multiple times at the same position with a slightly staggered position, so as to create the effect of imitation bold or shadow, which will cause Duplicate text appears. Check this option to have the program detect this technique and ignore repeated occurrences of text in the same position.

9. <q>Text typesetting direction</q>: The program can generally automatically detect the typesetting direction of the text, but due to the limited intelligence of the algorithm, it may infer wrongly. You can use this option to manually specify the typesetting direction of the text and improve the program organization of the text layout. accuracy.

10. <q>Merge consecutive headings not larger than several double-spaced</q>: After selecting <q>Merge consecutive headings</q>, headings smaller than this specified line spacing will be merged into one heading.

11. <q>Several layers of headings are positioned to the top of the page</q>: By default, the bookmarks generated after clicking the recognition will be positioned to the location of the bookmarks. With this option checked, clicking a bookmark within the specified number of layers will navigate to the top of the page instead of where the bookmark is located.

12. <q>Create bookmark for the first page</q>: After selecting this option, a bookmark item will be generated to point to the first page of the document. The text of the bookmark item is the PDF file name. In addition, no matter whether there is any text that meets the conditions of the title , no longer generate bookmarks for the home page. If this option is not selected, it will be processed according to normal rules.

### Text filter options

The text filter option specifies a list (one per line) to filter text. Text matching the specified pattern will be ignored. The interface is as follows.

![new image](media/image33.png)
<figcaption>Figure 4--29: Text filtering options for the auto-generated bookmark function</figcaption>

<q>Ignore headers with only one character</q>: Some PDF documents have large drop caps, which can be ignored with this option. Avoid drop words from being recognized as headings (when this option is checked, do not select the <q>Merge headings of different sizes in the same line</q> option, otherwise the drop words will be merged with normal text).

<q>Ignore numbers-only headings</q>: This option can often be used to ignore page numbers.

Fill in the title text to be ignored in the <q>Ignored Content</q> column. When the PDF text matches the ignored content, the program will not treat it as a bookmark title.

Check the box in the <q>Case Sensitive</q> column to make the matching ignore content case-sensitive.

Check the box of the <q>Match all headings</q> column, and only the entire line of PDF text will be ignored if the length of the entire line of PDF text and the ignored content are the same.

Select the checkbox in the <q>Regular Expression</q> column to ignore regular expressions.

If you need to delete the entered ignore content pattern, you can click the corresponding button under the <q>Delete</q> column or click the <q>Clear List</q> button.

### Advanced filter processing options

Advanced filter processing options specify whether to ignore text under certain conditions or to change the heading level of matching text. The interface is as follows.

![new image](media/image34.png)
<figcaption>Figure 4-30: Advanced Filter Processing Options for Auto-Bookmarks</figcaption>

In the above interface, you can add filter conditions to filter the title text. Added filters are listed in a list, and each row is a set of filters and the value of the adjustment level that matches the condition. If a piece of text meets the filter criteria for a specific group, the adjust level action is performed. When adjusting the level, if the check box of the filter condition corresponding to the <q>relative adjustment</q> column is selected, the text level matching the filter condition will increase or decrease the value specified in the <q>adjustment level</q> column. Otherwise the level of the text will be changed to the value specified in the <q>Adjustment Level</q> column.

Tip: When the adjustment level is 0, and the <q>Relative adjustment</q> check box is not selected, it means that the text matching the matching conditions will be filtered.

If the adjusted value is smaller than the <q>title text size</q> parameter specified in the <q>title recognition</q> option, the text will be ignored and not output to the generated bookmark. If the value is greater than the value of the title text size option, the text originally ignored by this option can also be output to the generated bookmark.

There are 5 buttons on the toolbar: the <q>Add</q> button is used to manually add filters, generally do not use this button, but use the <q>Add from information file</q> button, from the first pass Add filters to process the generated info file. The <q>Remove</q> button removes the selected filter from the list. The <q>Copy</q> and <q>Paste</q> buttons can be used to copy and paste filters.

For the usage of advanced filter processing options, please refer to the related introduction in the chapter [Application Example](#Application Example).

### Other options

Select the <q>Count fonts used for titles after recognition</q> check box, then the fonts used for titles will be listed in the log window after recognition.

If the <q>List Ignored Fonts</q> check box is selected, the statistics will also include font names that have been ignored by the filter.

If you select the <q>Export text position information</q> check box, the exported information file will also include the position information of the text in the page.

## Edit bookmark file

This function can edit [Easy Text Bookmark File](#Easy Bookmark File Reference), [XML Information File](#xml Information File Reference) or directly extract PDF document bookmarks, and save as an information file or add bookmarks to existing PDF documents . The interface of this function is shown in the figure below.

![Bookmark Editor](media/image35.png)
<figcaption>Figure 4--31: PDF Bookmark Editor Interface</figcaption>

There are two rows of buttons at the top of the interface, and a bookmark list displayed in the form of a tree in the middle. Move the mouse to a button on the toolbar and hold it for a while, a prompt message will pop up, explaining the purpose of the button and displaying the keyboard shortcuts. The first row of buttons is described from left to right as follows:

1. The <q>Open</q> button opens the information file or PDF file that needs to be edited. Clicking the small triangle next to the button will bring up a menu listing the most recently processed information files or PDF files. Clicking on the menu item will open the bookmark of the corresponding file.

2. The <q>Undo</q> button is used to undo the previous modification operation and restore the bookmark to the state before modification. Click the small triangle next to the <q>Undo</q> button, and a menu will pop up. Clicking an item in the menu can undo multiple operations at one time.

3. The <q>Copy</q> button is used to copy the selected bookmark.

4. The <q>Paste</q> button is used to paste the previously copied bookmark to the specified location.

5. The <q>Delete</q> button deletes the selected bookmark. If the bookmark contains sub-bookmarks, the sub-bookmarks are also deleted.

6. The <q>Insert Bookmark</q> button inserts a new bookmark item after the current bookmark.

7. The <q>Indent Bookmark</q> button sets the selected bookmark as a sub-bookmark of the previous sibling document.

8. The <q>bold</q>, <q>italic</q> buttons switch between the bold and italic styles of the bookmark text, respectively.

9. The <q>Color</q> button sets the color of the bookmark text. Click the small triangle next to it, and a color picker box will pop up, where you can select a predefined color, or use the color palette to select the desired color.

10. Clicking the <q>Select or Mark Bookmark</q> button will bring up a menu with the following commands:

11. <q>Select All</q>: Selects all bookmarks that are visible.

12. <q>Uncheck all</q>: Uncheck all bookmarks.

13. <q>Reverse selection status</q>: Select bookmarks that are not selected, and cancel the selected status of selected bookmarks.

14. <q>Mark Bookmark</q>: Mark the selected bookmark with the specified color for subsequent processing; or uncheck the marked status of the bookmark.

15. <q>Select bookmarked bookmarks</q>: Select bookmarks marked with the <q>Mark bookmarks</q> function.

16. <q>Collapse all</q>: Hide the sub-bookmarks of all bookmarks.

17. <q>Collapse sub-bookmarks</q>: Hide the sub-bookmarks of the currently selected bookmark.

18. <q>Expand All</q>: Expand all the sub-bookmarks of bookmarks, so that all bookmarks are displayed.

19. Clicking the <q>Search or Replace Bookmark Text</q> button will pop up a dialog box, which can be used to search or batch replace the text of the selected bookmarks.

20. Click the <q>Modify</q> menu button and a menu will pop up, which lists several commonly used commands for modifying bookmarks. Clicking the command will modify the selected bookmark. All modification commands are listed below.

21. <q>Set target display method</q>: Set the display method of jumping to the target position after clicking the bookmark.

22. <q>Set the default open status of bookmarks</q>: Set whether bookmarks are opened by default in the reader. This command is only available for bookmarks that contain sub-bookmarks.

23. <q>Clear bookmark target positioning offset</q>: Clearing the abscissa offset will prohibit changing the horizontal offset position of the reader after clicking the bookmark; clearing the ordinate offset will make it jump to the page after clicking the bookmark the top of the.

24. <q>Change target page number</q>: Modify the page number of the target page after clicking the bookmark.

25. <q>Change bookmark text capitalization</q>: Set the English capitalization of bookmark text.

26. <q>Change target page coordinates</q>: Change the target page coordinates after clicking the bookmark, you can set the absolute value or the offset modification value.

27. <q>Merge bookmarks</q>: Combine the selected bookmarks into one bookmark, keep the properties of the top bookmark, and concatenate all the selected bookmark texts as the bookmark text.

28. Forced to be set as in-file link: Some bookmarks will open external files when clicked, use this command to force the link behavior to be converted to go to the page in the current PDF file. The bookmarks of some PDF documents are invalid after the name is changed. The reason is that the bookmarks use the external file method to point to the page. Before the name change, the file name of the <q>external file</q> is exactly the same as the PDF file name; when the PDF document is renamed, The <q>external file</q> pointed to by the bookmark is invalid, so the specified page cannot be opened. Use this feature to fix these stale bookmarks.

29. Click the <q>Save</q> button to save the modified bookmark as a message file.

30. Click the <q>Patch</q> button to pop up a dialog box, in which you can directly combine the modified bookmark and the original PDF document into a new PDF document.

Check the <q>Modification operation includes unselected internal bookmarks</q> check box, then the modification operation will affect the sub-bookmarks of the selected bookmark. For details, please refer to the explanation in the section [Edit and modify sub-bookmarks] (#Edit and modify sub-bookmarks).

### Operation steps overview

The operation method of the bookmark editor is briefly described as follows:

Select the <q>Edit bookmark file</q> function.

Click the <q>Open</q> button to specify the bookmark file or PDF file to be edited.

After the file is loaded, the bookmarks will appear in a tree list and can be modified using the toolbar buttons or menus.

Click the <q>Save</q> button to save the bookmark as a message file. (After saving as an information file, you can use the <q>Import Information File</q> function of the advanced patch function or the merge processing mode to patch the bookmark to a new document; if you do not need to save the information file, you can skip this step)

Click the <q>patch</q> button, and the program will pop up a dialog box for selecting the location of the output PDF file. \
![new image](media/image36.png)

After selecting the target PDF file, click the <q>OK</q> button, and the program will copy the original PDF file and generate the target PDF file with bookmarks.

Tip: Hold down the Ctrl key and click the <q>Save</q> button to save with a different name. When the opened document is a PDF file, it is always saved with a name change.

### Basic editing functions

After opening a bookmark, you can use the editor interface to modify the style and properties of the bookmark. Basic editing operations are described below.

#### select bookmark

Use the mouse to click on the bookmark item, and the item color becomes reversed, indicating that the bookmark is selected.

Editor commands usually only work on selected bookmarks. To make edit commands work on internal bookmarks, select the <q>Modify actions include unchecked internal bookmarks</q> check box.

If you need to select multiple bookmarks at the same time, you can hold down the Shift key or Ctrl key of the keyboard, and then click the bookmarks to be selected with the mouse (press and hold the Shift key to select all bookmarks within a certain range; hold down the Ctrl key and click to select one by one Bookmarks that have been clicked by the mouse; when a bookmark is selected, hold down the Ctrl key and click the bookmark to cancel its selection).

Press Ctrl+A on the keyboard to select all displayed bookmarks.

**Note**: Pressing Ctrl+A will not select unexpanded sub-bookmarks.

#### Expand or collapse bookmarks in editor

When opening a bookmark file, bookmarks are collapsed by default. For example, after loading the bookmarks of a document, the bookmark editor is shown in the following figure. As can be seen from the figure, there are three top-level bookmarks, and the action of clicking the bookmark is to go to the page listed in the <q>page number</q> column of the PDF document.

![new image](media/image37.png)
<figcaption>Figure 4--32: Editor interface after loading a PDF bookmark</figcaption>

The bookmark item with the text "Bookmark 1" has a plus sign to the left, indicating that the bookmark contains sub-bookmarks. Click the plus sign, the sub-bookmarks collapsed within the bookmark will be displayed, and the plus sign will turn into a minus sign. As shown below. As can be seen from the figure, "sub-bookmark 1" also contains sub-bookmarks, while "sub-bookmark 2" and "sub-bookmark 3" do not contain sub-bookmarks.

![new image](media/image38.png)
<figcaption>Figure 4--33: Expand a bookmark to reveal its sub-bookmarks</figcaption>

Click the minus sign to the left of the bookmark text, and its sub-bookmarks will be collapsed back to the state before expansion.

#### Move or copy bookmarks

After the bookmark is selected, use the mouse to click and hold the text area where the bookmark needs to be moved, and then drag the mouse to move the bookmark. Move the mouse over other bookmarks and release the mouse button to move the selected bookmark to the position where the mouse is released.

For example, after selecting the two bookmarks "Grandchild Bookmark 1" and "Sub Bookmark 2" in the figure below, drag them to the "Sub Bookmark 1" bookmark with the mouse. A blue rectangle will appear on "Sub Bookmark 1".

![new image](media/image39.png)
<figcaption>Figure 4--34: Move or copy bookmarks</figcaption>

The blue rectangle has four areas, and releasing the mouse in different areas has different movements. Take the picture above as an example.

Release the mouse on the ① area, and the selected bookmark will be moved to the front of "Bookmark 1".

Release the mouse on the ② area, the selected bookmark will be moved to the back of "Bookmark 1".

Release the mouse on the ③ area, the selected bookmark will be moved to the front of all the sub-bookmarks of "Bookmark 1".

Release the mouse on the ④ area, the selected bookmark will be moved to the back of all sub-bookmarks of "Bookmark 1".

The effects of moving the bookmarks are shown in the following figures respectively (the two bookmarks that have been moved have been marked with colors).

![new image](media/image40.png)
<figcaption>Figure 4--35: The effect of moving bookmarks</figcaption>

**Notes**: When dragging bookmarks, press the keyboard's Esc key to cancel the drag operation.

When dragging the bookmark and releasing the mouse, press and hold the Ctrl key of the keyboard to copy the bookmark, that is, the original selected bookmark will be kept in the original place, and a copy of the selected bookmark will be created in the new location. Hold down the Ctrl and Shift keys of the keyboard and release the mouse, the copied bookmark will contain the sub-bookmarks of the selected bookmark.

#### Modify bookmark text

Method 1: Select the bookmark to be modified, and then click the bookmark item with the mouse (or press the F2 key of the keyboard), and the bookmark text will enter the editing state. When you are finished editing, press the Enter key (or click on another bookmarked item with the mouse) to confirm the modification. To cancel the editing operation, press the keyboard's Esc key to exit editing.

Method 2: Click the text in the <q>action</q> column corresponding to the bookmark, and a property box will pop up. Modify the text of the <q>Bookmark Text</q> text box in this property box, then click the <q>OK</q> button to close the dialog box. For details, see [Modify bookmark properties](#Modify bookmark properties)] section.

#### Modify bookmark properties <a name="modify bookmark properties"></a>

Click the blue text in the <q>Action</q> column corresponding to the bookmark item, and a property box will pop up. As shown below.

![new image](media/image41.png)
<figcaption>Figure 4--36: Link Action Editor</figcaption>

In this property box:

Modify the text corresponding to the <q>name</q> text box to modify the text of the bookmark.

In the <q>Type</q> drop-down box, you can select the action to be performed when the bookmark is clicked.

In the <q>Target</q> group box, you can specify the target location of the bookmark (usually select the <q>Go to the specified location</q> radio button). When the abscissa is <q>default</q>, the offset position of the abscissa will remain unchanged after clicking the bookmark. When the ordinate is selected as <q>default</q>, it will go to the top of the page by default after clicking the bookmark. If the abscissa or ordinate value is 0, the original coordinate offset value of the reader will remain unchanged after clicking the bookmark.

Click the <q>OK</q> button to close the dialog box and confirm the modification.

Click the <q>Cancel</q> button to cancel the operation of modifying bookmark properties.

#### Set bookmark style

Bookmark styles are bold and italic, and you can also set the color of the bookmark text. There are corresponding buttons in the toolbar.

Tip: When setting the bookmark text color, if white is selected, the bookmark text will be restored to the default color.

#### Set the default open state of bookmarks

The default open state of bookmarks can be set by modifying the checkbox selected in the <q>Open</q> column. When the checkbox is checked, the bookmark is opened by default in the reader (with its sub-bookmarks displayed), and when the Open checkbox is not selected, the bookmark is collapsed by default in the reader (the sub-bookmarks are not visible).

Use the <q>Set Bookmark Default Open Status</q> command in the <q>Modify</q> menu to modify the default open status of multiple bookmarks.

#### Insert bookmark

Click the <q>Insert Bookmark</q> button, or press the Insert key on the keyboard, to insert a new bookmark item.

Tip: You can also copy and create new bookmarks by dragging and dropping bookmarks while holding down the Ctrl key.

#### delete bookmarks

After selecting a bookmark, click the <q>Delete</q> button, or press the Delete key on the keyboard to delete the selected bookmark.

When deleting a bookmark, if the bookmark contains sub-bookmarks, the sub-bookmarks are also deleted. To avoid deleting sub-bookmarks, move the sub-bookmark out before deleting, and then delete the bookmark.

#### Edit and modify sub-bookmarks

Under normal circumstances, modifying a bookmark will not affect its sub-bookmarks or the bookmarks contained in the sub-bookmarks. When you press Ctrl+A to select all bookmarks, unexpanded sub-bookmarks will not be selected.

To modify the sub-bookmark, one method is to expand the bookmark to display the sub-bookmark, and then select the sub-bookmark to modify. As shown in the figure below, both bookmarks "Bookmark 1" and "Sub-Bookmark 2" are selected at the same time to be modified.

![new image](media/image42.png)
<figcaption>Figure 4--37: Selecting Expanded Subbookmarks for Editing</figcaption>

Another way is to check the "Modify function acts on unchecked internal bookmarks" checkbox. When this checkbox is checked, the editor's commands will modify both the selected bookmark and the internal bookmarks it contains, regardless of whether the bookmark is expanded or not. As shown below.

![Modify sub bookmark](media/image43.png)
<figcaption>Figure 4--38: Selected <q>Modify operation includes unselected internal bookmarks</q>Perform modification</figcaption>

**Note**: Hold down the Shift key and then click the command of the bookmark editor. The editing command will act on the internal bookmark of the bookmark, which is equivalent to temporarily selecting the <q>modification function to act on the unselected internal bookmark</q>. marquee.

#### Indent bookmark hierarchy

Click the <q>→</q> button on the toolbar, or press the Tab key on the keyboard to indent the selected bookmark one level inward.

In addition, you can also use the mouse to drag and drop to change the bookmark position (see the previous section "[Move or Copy Bookmark](#Move or Copy Bookmark)").

#### Change bookmark target page number

Click the <q>page number</q> column of the bookmark list to modify the target page number of the bookmark.

If you want to modify the target page numbers of multiple bookmarks at once, you can use the <q>Change target page number</q> command under the <q>Modify</q> menu, or press the plus or minus key on the keypad, Increase or decrease the page number of the selected bookmark.

In addition, click the link in the <q>Action</q> column to change the target page number of the bookmark in the pop-up dialog box.

### "Modify" menu function

The <q>Edit</q> menu contains a number of functions for editing PDF bookmarks. When using these functions, please note that the <q>Modify function works on unchecked internal bookmarks</q> checkbox is checked. When this checkbox is not selected, the modification function only applies to the selected bookmark; when this checkbox is selected, the modification function also applies to the lower-level bookmarks of the selected bookmark. Several functions of this menu have been described above, and the commands not described above will be introduced below.

#### Change how bookmarks are displayed

Some bookmarks change the aspect ratio of the reader when clicked. In general, this behavior is not what the reader wants. To remove the effect of bookmarks on the display scale, use the <q>Change how bookmarks are displayed</q> command and set the display scale to <q>Keep unchanged</q>.

Using this menu command, you can also specify to click the bookmark to zoom to the specified ratio, such as <q>fit to page</q>, <q>fit to page width</q>, etc.

If you only need to change the display mode of a certain bookmark, you can also click the link in the <q>Action</q> column of the bookmark list, and select the desired zoom ratio in the pop-up dialog box.

#### Clear coordinate positioning offset

Some bookmarks will offset the reader view in a certain direction when clicked, use this feature to clear the effect.

#### Change target page coordinates

This function can change the positioning coordinates after clicking on the bookmark to go to the target page. The command interface is shown below.

![new image](media/image44.png)
<figcaption>Figure 4--39: <q>Enter Coordinate Adjustment Values</q>Dialog Box</figcaption>

For most bookmarks, just edit the coordinates at <q>above</q>. <q>Relative adjustment</q> is to increase the coordinate adjustment amount on the basis of the original coordinate (a negative adjustment amount means to reduce the original coordinate). <q>Absolute adjustment</q> is to set the coordinate adjustment amount to the coordinate value.

If you only need to adjust the coordinates of a single bookmark, you can click the link in the <q>Action</q> column of the bookmark list to edit the target coordinate value of the bookmark in the pop-up dialog box.

#### Merge bookmarks

This function is to combine multiple sibling bookmarks into one bookmark. The text of the merged bookmark is the concatenation of the text of the original selected bookmark.

If the merged bookmark contains sub-bookmarks, all sub-bookmarks will become sub-bookmarks of the merged bookmark.

### Search and replace bookmark text

Another great feature of the bookmark editor is that you can batch search and replace bookmark text. Click the <q>Search and Replace Bookmark Text</q> button, a dialog box as shown below will pop up, and you can use this dialog box to complete the task of searching and replacing bookmark text.

![new image](media/image45.png)
<figcaption>Figure 4--40: <q>Search and Replace Bookmark Text</q>Dialog</figcaption>

In the <q>Search text</q> box, you can enter the text you want to search for. Click the triangle button on the right to select the text that was previously used to search.

The default search is not case-sensitive, if you want to differentiate, select the <q>Case-sensitive</q> check box.

The default search is a fuzzy search, which is a match as long as the bookmark text partially matches the search text. When the <q>Match entire bookmark's text</q> check box is selected, a match is only considered if the bookmark text exactly matches the search text.

There are three search modes.

The first is the <q>normal</q> mode, which retrieves whether the bookmark text contains the search text.

The second is the <q>regular expression</q> pattern. The search text is treated as a regular expression, and when the bookmark text matches the expression, it is considered a match.

The third is the <q>XPath</q> pattern. In this mode, the bookmarks of the bookmark editor are treated as an XML document, each bookmark is a <q>bookmark</q> element, and the attributes of the bookmarks (such as target page number, action, etc.) are treated as XML<q Attribute of the >Bookmark</q> element. The search text is treated as an XML path expression, and a bookmark element is considered a match when that expression is matched. The structure of the bookmark XML document can refer to the [document bookmark](#document bookmark) section of the information file.

In the <q>Replacement text</q> box, enter the text that replaces what you searched for. If a regular expression search pattern is used, and group matching is specified in the search expression, `$1`, `$2`, etc. can be used to replace the matching group in the replacement text.

#### Regular expression search example

The following uses a number of examples to illustrate the use of regular expression searches. The bookmarks that have been loaded by the bookmark editor are shown in the figure below.

![new image](media/image46.png)
<figcaption>Figure 4--41: Example bookmarks</figcaption>

Table 4-5: Regular Expression Search Example

| bookmarks to match | expressions | search results | descriptions |
|----------------------------------- |------------- -------- -|-------------------------------- -|------ -------------------------------------------------- -------------------------------------------------- ------------|
| Contains any character | .\* | All bookmarks | "." means any character; "\*" means 0 or any number of occurrences of the preceding pattern, ".\*" means 0 or any number of any character |
| Begins with "bookmark" | \^Bookmark | Bookmark1, Bookmark2, Bookmark10, Bookmark11 | "\^" means start of text |
| ends with "bookmark1" | bookmark1\$ |bookmark1, child bookmark1, grandchild bookmark1, bookmark11 | "\$" indicates end of text |
| Contains "sub bookmarks" or "grandson bookmarks" | \[subordinates\] bookmarks | sub bookmark 1, sub bookmark 2, sub bookmark 3, bookmark 2 | "\[\]" means range matching, as long as the matched text A character matching any character in the range is matched, the expression is equivalent to matching "sub bookmark" or "grandchild bookmark" text|
| | Child bookmark\|Grandchild bookmark | |"\|" means "logical OR" relationship, the meaning of this expression is "child bookmark" or "grandchild bookmark" |
| Bookmark text exactly matches "Bookmark 1" or "Sub Bookmark 1" | \^sub? Bookmark 1\$ | Bookmark 1, Sub Bookmark 1 | "?" means that the previous content does not appear or appears once |
| | \^(Bookmark 1\|Sub-Bookmark 1)\$ | |"()" means that the content inside is a group |
| "Bookmark" followed by a non-1 number | Bookmark \[2-90\] | Sub Bookmark 2, Sub Bookmark 3, Bookmark 2 | "\[\]" means range matching, "2-9" means match 2 Characters up to 9, the following "0" matches the character "0", which does not contain 1 in this set, so it matches a non-1 number |
| "Bookmark" followed by a non-1 character | Bookmark \[\^1\] | The result is the same as above | "\[\^\]" means that the filter range is matched, and the matched text cannot be any character in the square brackets, " \[\^1\]" means any character that cannot be 1 (may be Chinese characters or punctuation, etc.)|
| Contains two numbers | \[0-9\]{2} | Bookmark 10, Bookmark 11 | "{2}" means match the previous pattern twice, "\[0-9\]{2}" means match 2 digits |
| "Bookmark" followed by several numbers | \^Bookmark\[0-9\]+ |Bookmark 1, Bookmark 2, Bookmark 10, Bookmark 11 | "+" means match the preceding pattern at least once, "\[0-9 \]+" means match at least 1 number, and ".+" means match at least 1 arbitrary character |
| | \^Bookmark\[0-9\]{1,} | | "{1,}" means match the previous pattern at least once, which is equivalent to the "+" sign, and "{2,}" means the least matches the preceding pattern twice, while "{2,3}" means match 2 or 3 times |

If the search expression uses parentheses `()` to group, you can use `$1`, `$2` and other substitutes to replace the content of the group.

For example, to convert the form of "sub bookmark 1", "sub bookmark 2" to the form of "1) sub bookmark", "2) sub bookmark" (put the number in front), you can use the search expression "sub bookmark" (\[0-9\]+)" to locate bookmarks, and group by brackets "(\[0-9\]+)" to capture numbers, then use "\$1) sub-bookmarks" as replacement text, where "\$1" Represents a number matched within parentheses in an alternate search expression.

For another example, the numbers and texts of "sub-bookmark 1", "grandson bookmark 1", "sub-bookmark 2", etc. are exchanged to become "1 sub-bookmark", "1 grandson bookmark", "2 sub-bookmarks", etc. form, you can use the search expression "(\[children\]bookmarks)(\[0-9\]+)", use two pairs of parentheses to group, the first group matches "child bookmarks" or "grandchild bookmarks", the second group matches "child bookmarks" or "grandchild bookmarks" Group matches the following numbers, and then use "\$2\$1" as the replacement text to perform the replacement.

For more information on regular expressions, see the related tutorials and resources.

#### XML Path (XPath) Search Example

The principle of XPath search is to treat the bookmark information file as an XML document, and then perform XML path matching on it. Bookmarks that match the XML path expression will be selected. Use XML path search to accomplish search tasks that normal search cannot.

Each bookmark is represented by a `bookmark' element in the XML document, the properties of the bookmark (such as page number, action, etc.) are represented by XML attributes, and sub-bookmarks are regarded as sub-elements of the upper-level bookmark.

Take the bookmark shown in the illustration in the previous section as an example, and the number of XML path matches is shown in the table below.

| bookmarks to match | expressions | search results | descriptions |
| ----------------------------------- | ------------- ---------------------------- | --------------------- --------- | ---------------------------------------- -------------------------------------------------- -------------------------------------------------- -------------------------------------------------- ---- |
| The text is "Bookmark 1" | \@Text=\'Bookmark 1\' | Bookmark 1 | "\@Text" represents the bookmark text, the text string that needs to be matched is in English single quotation marks "\'" or double quotation marks" \""; the equal sign indicates whether the values ​​on both sides of the comparison are equal |
| The target page number ranges from 5 to 10 | \@page number\>= 5 and \@page number\<= 10 | Sub bookmark 3, bookmark 2 | "\@page number" indicates the target page number of the bookmark, "and" indicates "logical AND" "relation;"\>=" means greater than or equal to relation, and "\<=" means less than or equal relation |
| style is bold | \@style=\'bold\' | no matching bookmark | "\@style" represents the bold or italic style of the bookmark; there are no bookmarks with bold style in this example |
| bookmarks with sub-bookmarks | bookmarks | bookmark 1, sub-bookmarks 1 | "bookmark" means to check if there is a sub-bookmark named "bookmark" |
| Bookmarks with sub-bookmarks in sub-bookmarks | Bookmarks/Bookmarks | Bookmark 1 | The first "bookmark" matches the bookmark with sub-bookmarks, "/" means one level inward, and the second "bookmark" means matching the above Match bookmarks with sub-bookmarks in bookmarks |
| Bookmark with the same page number as the upper-level bookmark | ../\@page number = \@page number | grandchild bookmark 1 | "../" means the upper-level bookmark, "../\@page-number" means to get the "page number of the upper-level bookmark" "property, the second "\@page number" is the current bookmark page number; when the page number of the upper level bookmark is equal to the current bookmark page number, the equation is established (the page number of "grandchild bookmark 1" and the page number pointed to by its upper level bookmark "child bookmark 1" Page numbers are 3) |
| Bookmarks with sub-bookmarks whose text starts with "grandchild bookmarks" | bookmarks \[starts-with (\@text, \'grand bookmarks\')\] | sub-bookmarks 1 | bookmarks, and then "\[\]" indicates that the content is the judgment condition of these sub-bookmarks. If the condition is true, it is regarded as a match; "starts-with" is a function, when the first parameter starts with the second parameter, Deemed to be established |
| text contains "sub bookmark" | contains(\@text, \'sub bookmark\') | sub bookmark 1, sub bookmark 2, sub bookmark 3 | "contains" function means to check if the first text parameter contains the second The content of the text parameter |
| The first bookmark in the same level | position() = 1 | Cover, sub bookmark 1, grandson bookmark 1 | The "position" function returns the position of the current bookmark; when only the position is calculated, the simplified expression "1" can be used |
| | 1 | | |
| the last bookmark in the same level | last() | grandchild bookmark 1, sub bookmark 3, bookmark 2 | "last" function returns the position of the last bookmark in the same level, when the bookmark is the last bookmark, its position is equal to this function Returned value (this expression is equivalent to "position()=last()") |
| The location is not the last bookmark in the same level bookmarks | following-sibling::bookmarks | Cover, bookmark 1, sub bookmark 1, sub bookmark 2 | "following-sibling:: bookmark" means the next bookmark at the same level; The last bookmark has no next-level bookmark, so this requirement is equivalent to matching bookmarks with next-level bookmark |
| bookmarks with 3 sub-bookmarks | count(bookmarks)=3 | bookmarks 1 | "count" function returns the number of nodes matching its parenthesized expression |

For more information on XML paths, see the related tutorials and resources.

## Recognize image text

The image text recognition function can recognize the text of the picture in the PDF document and turn it into an editable text file. After editing the file, the text can be written into the PDF document to become a transparent text layer, so that the image text of the PDF document can be read. Index of search tools.

**Note**: This function requires the Document Imaging component of Microsoft Office 2003 or Office 2007 and the corresponding language recognition module to be installed on the machine.

The interface of this function is shown in the figure below.

![new image](media/image47.png)
<figcaption>Figure 4--42: Recognize image text function</figcaption>

### Recognize image text operation steps

1. Select the <q>Recognize Image Text</q> function.

2. Click the <q>Browse</q> button to the right of the <q>original PDF file</q> to specify the path of the PDF file that needs to identify the image and text.

3. To save the recognition result as a text file, click the <q>Browse</q> button to the right of <q>Recognition Result File</q> to specify the location to save the text file. If this file path is not specified during the identification process, the program will output the identification result to the log window.

4. In the <q>Identify page number range</q> text box, enter the page number of the image text to be recognized, if not, the images of all pages will be recognized.

5. Click the <q>Recognition Image Text</q> button to start recognition.

**Note**: If the suffix of the recognition result file is ".xml", the output information file will contain the coordinate information of the recognized text in the page.

### Write recognition result operation steps

1. Select the <q>Recognize Image Text</q> function.

2. Click the <q>Browse</q> button to the right of <q>original PDF file</q> to specify the PDF file path for generating the recognition result file.

3. Click the <q>Browse</q> button to the right of <q>Recognition Result File</q> to specify the path of the XML result file to be saved after recognition.

4. Click the <q>Browse</q> button on the right of <q>Output PDF</q> to specify the path to the PDF file generated after writing the recognition result.

5. Click the <q>Write recognition result</q> button to start recognition.

### Identify options

If the text in the original document image is in the same typesetting direction (that is, all horizontal or all vertical), it is recommended to select the corresponding typesetting method in the <q>Text typesetting direction</q> drop-down box.

In the <q>Text Recognition Language</q> drop-down box, you can select the recognition language, the default is Simplified Chinese, and you can choose Traditional Chinese or English.

**Description**: The function of recognizing image text is called by Microsoft Office Document
The Imaging component's recognition engine to recognize text. Therefore, the corresponding language recognition components must be installed first. If only the simplified Chinese recognition engine is installed, it is obviously impossible to correctly recognize traditional Chinese.

The <q>Rotation Correction</q> and <q>Stretch Correction</q> checkboxes allow the recognition engine to try to recognize the rotation and tilt of the text in the image to improve recognition. To improve the recognition speed, these two options are not selected by default.

Check the <q>Detect page orientation</q> check box to have the program automatically identify whether the page is landscape or portrait.

Checking the <q>Correct skewed pages</q> check box enables the program to automatically correct skewed pages and improve the recognition accuracy.

**Notes**: Selecting the above two options requires more operations to be performed. If the recognition result is ideal, there is no need to select the above two options in order to improve the recognition speed.

When the <q>Save original recognition results</q> check box is selected, the recognition results output by the Microsoft Office recognition component are saved as they are. It is recommended to select this option when the recognition result needs to be written into a PDF document. When the check box is not selected, the program attempts to combine text from the same line in order to extract the recognized text content.

### Identify directory pages as simple bookmark files

One function of recognizing image text is to recognize scanned PDF document table of contents pages into easy bookmark files for quick PDF bookmarking.

Microsoft Office's recognition engine is not very good at recognizing table of contents pages, and the recognition engine often misrecognizes periods in table of contents (i.e. consecutive ellipses "...") as a series of periods or numbers" 0" and other characters. It is recommended to select the "Recognize dot (...) separator for table of contents pages" checkbox so that the program will try to correct incorrect results from the recognition engine.

In addition, it is recommended to select the <q>Compress consecutive spaces</q> check box, and if necessary, select the <q>Remove spaces between Chinese characters</q> check box, and cancel the <q>Identification column typesetting </q> check box (when the text typesetting direction is <q>automatic detection</q>, the selection state of this check box cannot be switched, and this check box can be switched only by specifying the typesetting direction manually).

The text file output after recognition can be opened directly with [Bookmark Editor](#Edit Bookmark File).

Use the Bookmark Editor's <q>Change Target Page Number</q> feature to fix the correspondence between table of contents page numbers and actual page numbers.

## extract image

The function of extracting pictures can export the pictures of PDF documents as picture files without loss.

The interface of this function is shown in the figure below.

![new image](media/image48.png)
<figcaption>Chart 4--43: Extract Image Function</figcaption>

### Steps

1. Select the <q>Extract Image</q> function.

2. Click the <q>Browse</q> button to the right of <q>original PDF file</q> to specify the PDF file from which images need to be extracted.

3. Click the <q>Browse</q> button to the right of <q>Output Location</q>, and a directory browsing box will pop up. Use this dialog to select a directory, and the exported images will be stored in this directory.

4. Click the <q>Extract Image</q> button.

5. The program interface goes to the <q>Output Information</q> interface. The program will open the PDF file and export the pictures in the file to the directory specified earlier. During the export process, you can click the <q>Return</q> button in the output information interface at any time to terminate the export process.

### Extraction options

1. <q>Page range</q>: Specify to export images of a specific range of page numbers. If no <q>page range</q> is specified, all images found in the PDF file will be exported.

2. <q>Try to combine pictures on the same page</q>: Try to combine pictures with the same horizontal coordinates, the same width and the same format into one picture. The reason for providing this function is that some PDF production tools will divide a picture into multiple pieces and write them into the PDF file piece by piece. In this way, the extracted pictures will be fragmented. Using this feature will reunite these fragmented images into one image.

3. <q>Merge JPEG images into PNG images without loss</q>: When you select <q>Try to merge images on the same page</q>, if the images before merging are JPEG images, the images will be merged losslessly as PNG images.

4. <q>Flip image vertically</q>: Flip the exported image vertically. Some PDF authoring tools flip the image vertically and write it to the PDF file. In this way, the extracted picture will be upside down. Use this feature to restore an upside-down picture.

**Note**: If the image is compressed in a lossy format such as JPEG, flipping the image vertically may cause the quality of the extracted image to deteriorate.

5. <q>Invert the colors of black and white pictures</q>: Invert the colors of pictures with only two colors. Some PDF production tools will reverse the black and white of the image, and then use the method of setting the drawing color in the PDF rendering command to reverse the color when rendering. This will cause the extracted image to be black and white in reverse. Use this function to restore the opposite color back.

6. <q>Ignore images with specified width or height</q>: Some PDF files contain some very small images. If these images do not need to be exported, use this option to ignore them.

7. <q>Export pictures in comments</q>: After selecting this option, export pictures in comments. When this option is not checked, only images of the PDF body are exported.

### File Naming Rules

The extracted image file name defaults to the four-digit file name of the page number (the mask is "0000"), such as "0001.jpg", "0002.tif", "0010.tif", etc. The extension part of the file name is automatically generated according to the compression method used for the pictures in the PDF document. For example: the picture is compressed by JPEG algorithm, the extension is "jpg"; the black and white two-color (compressed by CCITTFax or JBIG2 algorithm), the extension is "tif"; the color or grayscale (compressed by algorithms such as Deflate), the extension is named "png".

The part before the file extension of the extracted image can be modified by changing the <q>filenamemask</q>.

If you don't need to fill the digits with 0, you can input the mask "0" or not, and the program will output image file names such as "1.jpg", "2.tif", "10.tif" and so on.

If Chinese characters are filled in the mask, the output file name contains the Chinese character name. For example, the mask "document 000" will generate image files such as "document 001.jpg" and "document 002.tif".

If the unchanged part of the file name contains "0", use half-width quotation marks "\"" to enclose the unchanged part. For example, the mask "\"Windows 2008 Reference \"0" will generate "Windows 2008 Reference 1" .jpg", "Windows 2008 Reference 2.png" and other pictures.

When changing the file mask, the "Examples" tab will demonstrate the naming of image files on pages 1, 2, 3, 11, 12, 13, and 100.

## Extract pages

The Extract Page Content function can export several pages of a specified range of a PDF document into a single PDF file.

The interface of this function is shown in the figure below.

![new image](media/image49.png)
<figcaption>Figure 4--44: Extract page function</figcaption>

Here's how to extract a page:

1. Select the <q>Extract Pages</q> function.

2. Click the <q>Browse</q> button to the right of <q>original PDF file</q> to specify the PDF file from which pages need to be extracted.

3. Click the <q>Browse</q> button to the right of <q>Output Location</q>, and a save file browsing box will pop up. Use this dialog box to specify the save location of the PDF file created after extracting the pages.

4. If you only need to export the content within a specific range of page numbers, you can fill in the page number range in the text box to the right of <q>page number range</q>. If no page number range is specified, all pages of the PDF file will be exported.

5. If some page numbers do not need to be extracted, you can also fill in the range of page numbers to be excluded in the <q>Excluded page number range</q> text box.

6. Click the <q>Extract Pages</q> button.

7. The program interface goes to the <q>Output Information</q> interface. The program will open the original PDF file and export the pages within the specified range as a new PDF file. During the export process, you can click the <q>Return</q> button in the output information interface at any time to terminate the export process.

Tip: The page number range supports the reverse order range, such as the page number range "10-1", it will first insert the 10th page of the source file, then the 9th page, and so on, and finally insert the 1st page into the output document. In addition to using this function to export the specified page of the PDF file, you can also use the "[Create PDF file](#global option)" function to generate a new PDF file from the exported pages of an existing PDF file.

## Document Structure Profiler

Document Structure Profiler provides a tool for PDF developers, enthusiasts, etc. to view and modify the internal structure of PDF documents.

The interface of this function is shown in the figure below.

![new image](media/image50.png)
<figcaption>Figure 4--45: Document Structure Profiler Interface</figcaption>

Operation method:

1. Select the <q>Document Structure Profiler</q> feature.

2. Click the <q>Open</q> button to open the PDF document of interest.

**TIP**: You can drag a PDF document from "My Computer" or Explorer to the function interface to open the document.

3. Wait for a while, after the program opens the document, the program displays the internal hierarchical structure of the PDF document in a tree list.

4. The first column of the list is the name of the node. Some nodes (such as dictionary, array type nodes) contain internal nodes and have a plus sign to the left of the node icon. Click the plus sign to expand the node to view the contents of the inner node. Some reference nodes that point to dictionaries or arrays also have a plus sign to the left of their icon. Click the plus sign to expand to see what the reference node points to.

5. The root node of the document is the document catalog (Trailer) node.

6. For the convenience of use, the program converts each page of the document into a separate page node and displays it independently under the Pages node (this node is a virtual node, which is actually generated according to the page tree dictionary inside the document).

7. The second column of the list is the value of the node. Click the corresponding cell with the mouse to modify its content.

8. Below the list is the remarks window, explaining the meaning of the selected node and its value range. The program has built-in information of dozens of common PDF nodes for reference by PDF lovers.

9. Click the <q>Delete</q> button to delete the selected node. Some nodes must exist in the document and cannot be deleted. When the node is selected, the <q>Delete</q> button will be disabled (grayed out). When a dictionary or array node is deleted, the content node of the dictionary or array is also deleted. When deleting a reference node, only the node is deleted, and the target node pointed to by the node is not deleted.

10. Select the data flow node of the document and press the <q>Export</q> button to export the content node to a binary file or text file for analysis by an external program.

11. Select the image data stream in the document and press the <q>View</q> button, a window will pop up to display the image of the data stream.

12. Select the text data stream in the document and press the <q>View</q> button to view the content of the text stream in the remarks window.

13. After modifying the document, if you want to save the modified document, you can click the <q>Save</q> button.

Warning: Before using the document structure profiler, some knowledge of PDF should be prepared. Improper use of this tool and overwriting the original PDF file with the modified document may result in irreparable loss of data.

## global options

This option specifies how the program functions generally work.

![new image](media/image51.png)
<figcaption>Figure 4--46: Global working options for the program</figcaption>

Accessing PDF documents: Specifies the program's policy for reading PDFs. If <q>Optimize processing efficiency</q> is selected, the program will try to load the entire PDF file into the memory, which is convenient to improve processing efficiency. If <q>reduce memory usage</q> is selected, the program will only load the PDF index table and minimize the amount of memory used. If the PDF document is large, use this option to prevent the program from running out of memory by loading the document.

The encoding used to read the document: Some PDF documents use irregular encoding, which makes it impossible to read normally, and the exported information file is also garbled. This option can be used to force the read encoding to try to export the information in a different encoding. For details, please refer to [Repair bookmarks with garbled characters] (#Use the independent patch function to modify the open status of bookmarks of multiple pdf files).

## output information

The <q>log content</q> text box of the interface outputs the information of the working process of the program and the errors encountered. The program will go to this interface after starting the task.

![new image](media/image52.png)
<figcaption>Figure 4--47: Output Information Interface</figcaption>

During the working process of the program, clicking the <q>Return</q> button will pop up a confirmation dialog box, and clicking the <q>Yes</q> button in the dialog box will terminate the working of the program.

After the program finishes its work, click the <q>Back</q> button to return to the previous function interface.

Click the underlined file name or directory name in the log window to open the corresponding file or directory.

# application example

In order to better explain how to use the PDF patch, here are several scenario examples, readers can draw lessons from one case and make better use of the program.

## Cancel the display ratio of bookmarks and page links

Task: Some PDF document bookmarks or page links will change the display ratio of the reader after clicking. For example, the reader originally used a display ratio of 135%. After clicking the bookmark, the display ratio becomes suitable for the page, and the font becomes small. This creates inconvenience for readers to read. Using the PDF patch can easily maintain the display ratio of the reader, and not let it change freely and affect the reading.

The operation steps are as follows:

1. Select the <q>PDF Document Options</q> function.

2. Click the <q>Read By</q> tab and select the <q>Prohibit bookmarks and page links from changing the aspect ratio</q> check box.

3. Select the <q>independent patch</q> mode of the <q>processing, making PDF document</q> function.

4. Add the PDF document to be modified to the file list.

5. Specify the path of the output PDF file.

6. Click the <q>Generate PDF file</q> button. In the resulting new file, clicking bookmarks and page links will no longer change the viewer's aspect ratio.

A schematic diagram of the processing procedure is shown below.

![new image](media/image53.png)
<figcaption>Figure 5--1: Patching Steps 1-2: Selecting Patch Options</figcaption>

![new image](media/image54.png)
<figcaption>Figure 5--2: Patching Steps 3-6: Select a file to execute the patch</figcaption>

## Turn off bookmarks in the default expanded state

Task: Some PDF documents have bookmarks for easy reading. However, there are many bookmarks and layers, and they are all expanded by default. You need to flip the scroll bar to find the desired item. Changing the default state of bookmarks to off and manually opening them when reading is usually more convenient than opening all bookmarks by default. Use the PDF patch to change the open state of document bookmarks in batches.

### Modify bookmark open status of multiple PDF files with independent patch function

The steps to modify the open state of bookmarks using the independent patch function are as follows:

1. Select the <q>PDF Document Options</q> function.

2. Click the <q>Read by</q> tab, find the <q>Bookmark Status</q> drop-down box, and select <q>Close all</q>.

3. Select the <q>independent patch</q> mode of the <q>processing, making PDF document</q> function.

4. Add the PDF document to be modified to the file list.

5. Specify the path of the output PDF file.

6. Click the <q>Generate PDF file</q> button. In the new file generated, the bookmarks are all turned off.

### Modify the bookmark open status of a single PDF file with the bookmark editor

The steps to use the bookmark editor to modify the open status of a PDF document bookmark are as follows:

1. Select the <q>Edit Bookmark</q> function.

2. Click the <q>Open</q> button to open the PDF file to be modified.

3. Select the bookmarks whose open status needs to be modified in batches, and then select the corresponding command in the <q>Set Bookmark Default Open Status</q> submenu under the <q>Modify</q> menu.

4. Click the <q>Patch</q> button to save the modified PDF file.

Tip: If the selected bookmark has sub-bookmarks, please select the <q>Modification operations include unselected internal bookmarks</q> check box to apply the modification command to the inner bookmarks.

Compared with the <q>standalone patch</q> function, this method can make certain bookmarks open by default, but obviously cannot batch process PDF files.

## Uniform page size

Task: The page size of a PDF file is uneven, and it is hoped that the page size can be unified for easy reading. The steps to use the PDF patch are as follows.

1. Select the <q>PDF Document Options</q> function.

2. On the <q>Page Layout</q> tab, by default, the size drop-down box is <q>Equal to original content size</q>, which can be changed to other defined sizes, such as <q >A4</q>, <q>16K</q>, etc., or select <q>Custom</q>, then at <q>width</q>, <q>height</q> Enter the appropriate value.

3. Select the <q>Scale content to fit page</q> radio box in the <q>Source PDF Page Fitting</q> group.

4. Return to the function of <q>Processing and Making PDF Documents</q> and select the <q>Independent Patch</q> mode.

5. Add files that require uniform page size and specify the output PDF file.

6. Click the <q>Export PDF file</q> button.

The options selected during the operation are shown in the figure below.

![new image](media/image55.png)
<figcaption>Figure 5--3: Patching Steps 2-3: Selecting a Uniform Size for the PDF Document</figcaption>

Tip: The dimensions of the first page of the PDF document are listed on the file list.

## Adjust the double page reading order of vertical documents

Task: Widescreen monitors are now popular, and some larger widescreen monitors can display two pages of documents at a time. Switching to dual-page view will reduce the number of page turns for easier reading. However, the default reading direction of the double-page display is <q>left to right</q>, which is inconvenient for vertical documents: first, start from the middle of the page, read to the lower left corner of the page, and then jump to the upper right of the page corner to read the next page. As shown on the left of the figure below.

If you can change the reading direction to <q>right to left</q>, it will be more convenient to read vertical documents: start reading from the upper right corner of the page, and read two pages at the lower left corner, without turning your eyes. As shown on the right in the figure below.

![1](media/image56.png) ![2](media/image57.png)

The operation steps are as follows:

1. Select the <q>PDF Document Options</q> function.

2. Click the <q>Read By</q> tab.

3. Select <q>Right to Left</q> in the <q>Reading Direction</q> drop-down box.

4. Return to the function of <q>Processing and Making PDF Documents</q> and select the <q>Independent Patch</q> mode.

5. Add the PDF files that need to be deleted.

6. Specify the path of the output PDF file.

7. Click the <q>Generate PDF file</q> button. Open the generated new PDF file with a PDF reader and switch to the two-page view, you will find that the reading order has been changed from right to left.

## Forbid the behavior of setting "fit to page" display by yourself when opening the document

Task: Some PDF documents automatically set the display ratio of the reader to <q>fit to page</q> when they are opened, resulting in the display font being too small, and it is quite inconvenient to manually adjust the display ratio every time you read it. This behavior can be disabled for documents with a PDF patch.

The operation steps are as follows:

1. Select the <q>PDF Document Options</q> function.

2. Click the <q>Documentation Miscellaneous</q> tab.

3. Select the <q>Delete Automatically perform actions when opening documents</q> check box.

![new image](media/image58.png)
<figcaption>Figure 5--4: Selecting the <q>Disable automatic action when opening document</q> option</figcaption>

4. Return to the function of <q>Processing and Making PDF Documents</q> and select the <q>Independent Patch</q> mode.

5. Add the PDF files that need to be deleted.

6. Specify the path of the output PDF file.

7. Click the <q>Generate PDF file</q> button, the program will read the original PDF file, delete the automatic execution of the document, and output it as a new PDF file.

## Clear the webpage that pops up when opening the page

Task: When a PDF file is read to a certain page, automatically open the browser to visit a specific website. This is because the PDF file performs the action of opening the web page in the page. These actions can be removed using a PDF patch.

The operation steps are as follows:

1. Select the <q>PDF Document Options</q> function.

2. Click the <q>Documentation Miscellaneous</q> tab.

3. Select the <q>Delete automatic action on page</q> check box.

4. If a web page pops up when the document is opened, select the <q>Delete the automatic action when opening the document</q> check box.

5. Return to the function of <q>processing, making PDF documents</q>, and select the <q>independent patch</q> mode.

6. Add the PDF file that needs to be deleted.

7. Specify the path of the output PDF file.

8. Click the <q>Generate PDF file</q> button, the program will read the original PDF file, delete the automatically executed actions in the page, and output it as a new PDF file.

## Export bookmarks as text

Task: Export bookmarks of PDF files into a table of contents in text form.

The operation steps are as follows:

1. Select the <q>Process/Make PDF</q> function.

2. Select the <q>Independent Patch</q> mode.

3. Add the PDF files that need to be exported to the file list.

4. At <q>PDF information file</q>, specify a text file with the suffix "txt" as the output information file.

5. Click the <q>Export Info File</q> button. The exported information file is a text file.

The operation steps are shown in the figure below.

![new image](media/image59.png)
<figcaption>Figure 5--5: Export Text Bookmark Information File</figcaption>

## Fix bookmarks with bookmark editor

Due to the limitation of tools during the production of some PDF documents, the bookmarks do not conform to the PDF specification and cannot be used normally in the new version of the PDF reader. The usual problems are: garbled text of bookmarks, invalidation of bookmarks after renaming the PDF file, and the target of bookmarks. The page range is incorrect.

Such PDF bookmarking issues can be easily fixed using PDF Patcher's bookmark editor.

### Fix bookmark text garbled

Task: The bookmark of a PDF document is garbled and cannot be read, as shown in the following figure.

![new image](media/image60.png)
<figcaption>Figure 5--6: Garbled bookmarks</figcaption>

Loaded the document using the bookmark editor and found that the bookmark text was also garbled. As shown below.

![new image](media/image61.png)
<figcaption>Figure 5--7: Garbled bookmarks displayed in bookmark editor</figcaption>

Use <q>Read Encoding</q> in the program's global options to force the encoding to be used to read the message and reopen the bookmark.

The operation steps are as follows.

Click <q>Global Options</q> to go to the program's global settings.

Select the <q>Read Encoding Options</q> tab. Select "UTF-16 Big Endian" in <q>Bookmark Text Encoding</q>. As shown below.
![new image](media/image62.png)

Back in the bookmark editor, click the <q>Open</q> button in the toolbar to reload the PDF in question. At this time, you can see that the bookmark text is normal (if it cannot be displayed normally, go back to step 2 to select other codes, and then repeat this step), as shown in the following figure. \
![new image](media/image63.png)

### Fix the invalid bookmark after the PDF file is renamed

The bookmarks for the above PDF documents seem to have been fixed, but there are still problems. Once the PDF file name is changed, an error such as <q>Unable to open document j24.pdf</q> will appear when opening the document and clicking the bookmark, as shown in the following figure. Only changing the PDF filename back to "j24.pdf" made the bookmarks work.

The reason for this problem is: PDF document bookmarks use external links to the specified file name, not internal links within the document.

![new image](media/image64.png)

To solve the above problem, the bookmark editor provides the function of <q>force changing external links to internal links</q>. The operation steps are as follows:

Open the bookmark with the bookmark editor (the result is shown in the figure in the previous section). As seen in the editor, the bookmark action is <q>Open external PDF document</q>. Expand bookmarks and find that the actions of all bookmark items are to open external PDF documents. Click any <q>Open External PDF Document</q> link in the <q>Bookmark Action</q> column of the editor, and in the pop-up dialog box, you can find that the bookmark action points to a file named "j24.pdf" "documentation. As shown below. \
![new image](media/image65.png)

That's why the link doesn't work after the PDF file is renamed. Only when the file name is "j24.pdf", click the link to jump to its designated page, otherwise the PDF reader will report an error that the file cannot be found because the "j24.pdf" file does not exist.

Click the <q>Cancel</q> button to close the above dialog and return to the bookmark editor.

Since all bookmarks have the same problem, you can use the command to modify the menu to fix it together. Press Ctrl+A (or select with the mouse) to select all bookmarks, and select the <q>Modify operation includes unselected internal bookmarks</q> check box to make subsequent operations work on sub-bookmarks hidden inside bookmarks.

Click the <q>Modify</q> button, and select the "Force set as in-file link" command in the pop-up menu.

Once done, as you can see from the editor, the bookmark action has changed to "Go to Page". As shown below.
![new image](media/image66.png)

### Modify the target page number of the link

After using the advanced patch function to patch the bookmark back to the PDF document, it can be found that the target page pointed to by the bookmark deviates one page forward. It should point to page 2, but it jumps to page 1; it should point to page 16, but it jumps to page 15. Use the bookmark editor to uniformly add one page to the target page number of all pages. The operation method is as follows:

Open the bookmark with the bookmark editor (the result is shown in the figure in the previous section). As can be seen from the bookmark editor, the page number of the first valid page "The Complete Works of Marx and Engels (39)" points to 0.

Check the <q>Modification operations include unchecked internal bookmarks</q> check box to make subsequent modification operations work on sub-bookmarks hidden inside bookmarks.

All bookmarked items are checked.

Click the <q>Modify</q> button, and select the <q>Add page number</q> command in the pop-up menu.

When done, you can see from the editor that the page numbers have all been incremented by 1. As shown below. \
![new image](media/image67.png)

In addition, there is no need to keep the first three bookmark items, you can select them with the mouse, and then click the <q>delete</q> button on the toolbar to delete them.

### Patch the modified result back to the PDF document

After the above steps, the bookmark has been successfully repaired. The final step is to combine the bookmarks with the original PDF document to generate a new repaired document. The operation steps are as follows:

Click the <q>Save</q> button of the editor to save the bookmark as an information file with an ".xml" suffix. (If you do not need to save the information file, you can skip this step)

Click the <q>Patch</q> button and a dialog will pop up. The dialog lists original PDF files and output PDF files. Specify the location of the patch output file at <q>Output PDF file</q>.

Click the <q>OK</q> button, wait for a while, the modification results just now will be saved to the new PDF file generated.

## Add easy bookmarks

### Example 1: Use Excel to make simple bookmarks

I have a photocopy of the Yellow Emperor's Classic of Internal Medicine without any bookmarks on hand. From the Internet we can easily find the table of contents text of this book. Copy it down, process it a little bit, and make it line by line text like this:

```
The First Treatise on the Ancient Heavenly Truth
The Second Treatise on the Four Energies and the Great Spirit
The Third Treatise on the Breath of Heaven
The Fourth Treatise on Jin Kui Zhen Shuan
......
```

Then copy the text to the Excel worksheet, and the text above becomes column A (column 1).

The above table of contents does not have page numbers, therefore, you need to add page numbers to make bookmarks jump to the specified page. Photocopy PDFs are usually accompanied by the original book table of contents. use
PDF
The reader opens the file, goes to the table of contents, and then enters the page number into column B (column 2) of Excel.

After inputting, there is a certain gap between the page number in the catalog page and the real page number in the PDF file. In this photocopied PDF file, the first chapter appears on page 14 of the file. Therefore, insert a row before row 1 of the Excel sheet, and enter "\#First page number=14", indicating that the first page in the following page numbers corresponds to the first page of the PDF file.
14 pages. The Excel sheet looks like this:

![67609\_090429232530](media/image68.png)
<figcaption>Figure 5--8: Use Excel to make simple bookmarks (the `#version` command in line 1 can be ignored)</figcaption>

After completing the input of bookmarks, use Excel to save it as a "bookmark.txt" text file (cannot be saved as an XLS file).

Open the PDF patch. Select the <q>independent patch</q> mode of the <q>processing, making PDF document</q> function. Add the PDF file of the Yellow Emperor's Classic of Internal Medicine to the file list. Select the text file you just saved at <q>PDF Information File</q>. Select the new PDF file obtained after importing the bookmark file at <q>Output PDF file</q>.

**Tips**: Close the Excel program before operation, otherwise the program cannot read the information file.

Click the <q>Generate PDF file</q> button, and the program will merge the simple bookmarks with the original file to generate a new PDF file.

**Note**: In addition to using the <q>independent patch</q> function, you can also use the bookmark editor to open the simple bookmark file and execute the patch.

Wait patiently for the program processing to complete. Finally, we have a PDF file with bookmarks. As shown below.

![67609\_090429233022](media/image69.png)
<figcaption>Figure 5--9: PDF file with simple bookmarks imported</figcaption>

### Example 2: Make a simple bookmark for a multi-level directory

The previous example explained the general steps for making simple bookmarks, this section introduces making more complex multi-level bookmarks.

First, enter the simple bookmark text you want to make. This example partial directory looks like this:

````
Chapter 1 Overview of Chinese Qigong 1
1. Brief History of Qigong Development 1
2. What is "Qigong" 3
3. Purpose of practice 5
4. What is the effect of Qigong 7
5. Classification and Characteristics of Qigong Techniques 9
Health Qigong 11
Diagnostic Qigong 19
......
````

This directory is actually divided into three layers, the first layer is chapters, the second layer is sections, and the last layer is subsections.

Copy the above text into the edit area of a text editor (eg AkelPad, PSPad, EditPlus, etc.). Select the lines from "1. History of Qigong Development" to "Diagnosis of Qigong" above, and press the "Tab" key on the keyboard. In this way, there is an extra tab in front of these lines, which seems to be indented by one layer. Then, select the two lines from "Health Qigong" to "Diagnosis Qigong" below, and press the "Tab" key again, and the two lines are indented one level inward. becomes the following form:

````
Chapter 1 Overview of Chinese Qigong 1
     1. Brief History of Qigong Development 1
     2. What is "Qigong" 3
     3. Purpose of practice 5
     4. What is the effect of Qigong 7
     5. Classification and Characteristics of Qigong Techniques 9
         Health Qigong 11
         Diagnostic Qigong 19
         ......
````

The contents of subsequent chapters are handled in a similar fashion.

Open the PDF file and see what page the actual page number corresponds to the first chapter (page 7 in this example). Therefore, we insert a line before the first line in the bookmark file, and add the `#first page number=7` instruction, which becomes the following form:

````
#Homepage number=7
Chapter 1 Overview of Chinese Qigong 1
1. Brief History of Qigong Development 1
......
````

The `#First page page number=7` instruction indicates that the first page of the following page number corresponds to the seventh page in the PDF document.

There is still a table of contents in front of this book. We can add something to the bookmarks file to include the table of contents in the bookmarks. Insert the content before the first line of the bookmark file, as follows:

````
catalog 1
#Homepage number=7
Chapter 1 Overview of Chinese Qigong 1
1. Brief History of Qigong Development 1
......
````

Although the page numbers of "Table of Contents" and "Chapter 1" are both 1, "Table of Contents" corresponds to the first page of the PDF file, and because the second line "\#First page number" specifies the page number relationship, "Chapter 1" Actually corresponds to page 7.

Save the bookmark file as a text file when done. Then import it into the original PDF document with the PDF patch to generate a bookmarked PDF file. As shown below.

![67609\_090430143020](media/image70.png)
<figcaption>Figure 5--10: PDF bookmarks with multi-level table of contents</figcaption>

### Example 3: Use character recognition to generate simple bookmarks

Another way to make simple bookmarks for scanned PDF documents is to use character recognition to identify the table of contents pages and generate bookmarks from the text of the table of contents pages. The basic operation steps are as follows.

1. Open and observe the document in a PDF reader to determine the range of content pages of the scanned PDF document.

2. Go to the <q>Recognize image text</q> function, specify the PDF files to be recognized, and select the appropriate processing options (it is recommended to select <q>Recognize dot separators for content pages</q>, <q> There are two options for compressing consecutive spaces</q>; in order to improve the recognition effect, you can manually specify the <q>text typesetting orientation</q> option as landscape or portrait; if the scanned page is skewed, you can select <q>rotation correction</q> q> and <q>Stretch Correction</q> options).

3. In the <q>Identify Page Range</q> text box, enter the page range of the table of contents page.

4. Specify the text file to be output after recognizing the text, and click the <q>Recognize image text</q> button to try to recognize the content page.

5. Edit the output text file to correct misrecognized characters.

6. Open the text file with a bookmark editor to make a bookmark file or directly patch to a PDF document.

## Automatically generate navigation bookmarks

Automatically generating navigation bookmarks is a useful feature. This function can automatically generate bookmarks for PDF documents, eliminating the inconvenience of manually entering bookmarks. The basic operation steps are as follows.

1. Observe the document and manually analyze the document title characteristics.

2. Attempt to generate bookmarks.

3. Adjust the title recognition options and add filter conditions.

4. View the output bookmarks in the output log window or bookmark editor. If you are not satisfied, repeat steps 2 and 3.

5. Use the bookmark editor to edit and optimize bookmarks.

6. Generate PDF files.

**Note**: The auto-generate PDF bookmark function can only generate bookmarks for text PDF documents, and cannot process PDF documents with scanned images.

The bookmarks in the PDF electronic version of this reference manual are generated using the automatic bookmark generation function. This section will take this manual as an example to describe the detailed operation steps of automatically generating bookmarks.

### Watch documentation

The first step in automatically generating bookmarks is to observe the PDF document to understand its typographical characteristics. Observe what characteristics the text that needs to be bookmarked has. Taking this document as an example, the document title has the following characteristics: ① Each title uses a larger size of bold Arial or bold, and ② the font size gradually decreases with the level of the title. ③ Each title is on its own line. As shown below:

![new image](media/image71.png)
<figcaption>Figure 5--11: Title style for this reference manual</figcaption>

### Attempt to generate bookmarks

Since the number of pages in a PDF book is often large, it takes a certain amount of time to process one time. First, use the default settings of the program to try to create some representative pages—pages with titles that need to be bookmarked , to generate bookmarks. Observe that the titles of these pages are fully bookmarked and that no additional text is introduced into the main body.

In this example, the default configuration is used to try to generate bookmarks for pages 2 to 20 of the usage document. The options configuration is shown in the following figure:

![new image](media/image72.png)
<figcaption>Figure 5--12: Generate bookmarks for pages 2 to 20 of the sample document using the default configuration</figcaption>

Click the <q>Export Info File</q> button, the program will generate the bookmark and display the text to the log window, as shown in the following figure.

![new image](media/image73.png)
<figcaption>Figure 5--13: Bookmark text content of log file output</figcaption>

### Observe the output and adjust the header recognition options

Observing the output content of the log window, it can be found that according to the default title size, it can only be output to title 2, and the text of title 3 and title 4 is not included in the output bookmarks.

In order to also output the text of heading 3 and heading 4 as bookmarks, you can try to adjust the heading recognition options, adjust the <q>title text size</q> parameter from the default 13 to a smaller 12, and then click <q> Export info file</q> button. As shown below.

![new image](media/image74.png)
<figcaption>Figure 5--14: Adjusting the title text size parameter to output lower-level titles</figcaption>

The output result is shown in the figure below.

![new image](media/image75.png)
<figcaption>Figure 5--15: Output bookmark text content after resizing the title text</figcaption>

Looking at the text output above, we can see that the content of heading 3 and heading 4 has been output to bookmarks.

However, because of the same font size, heading 3 and heading 4 have the same level after being output to bookmarks (see the two headings "4.3.2" and "4.3.2.1" in the above figure), which do not reflect the hierarchical relationship between the headings .

To make the output bookmarks reflect the hierarchical relationship between Title 3 and Title 4, you can add an adjustment item in the <q>Advanced Filter Processing</q> option to adjust the level of Title 3 to make it higher than Title 4. The operation method is as follows:

Select the <q>Advanced Filter Processing</q> tab.

Since the info file has been generated previously, click the <q>Add from info file</q> button.

Clicking the button will bring up a dialog box that lists the font used for the title of the document and its size, as well as the text content in the document that uses this size font for the first time. As shown below:

![new image](media/image76.png)
<figcaption>Figure 5--16: Adding font filters</figcaption>

English font names are generally used in PDF documents. Find the font corresponding to the first title 3 ("4.2.1 file list" in the example) in the dialog box. Since the title uses a mixture of two fonts, there are two The title text appears in all places, and the size is 12.00. The first one is "SimSun". Experienced readers know that the corresponding font is "宋体", that is, the number number ("4.2.1") in the title 3 text. The font used; the following "FZLanTingHei-DB-GBK" is the font used for the Chinese font ("file list") of title 3. Right-click the font name, and then select the "Filter fonts named 'FZLanTingHei-DB-GBK'" menu item in the pop-up context menu.

After clicking the above command, an item has been added will be visible in the <q>Filter criteria</q> list.

Click the <q>OK</q> button to close the dialog.

When returning to the <q>Advanced Filter Processing</q> option interface, it can be seen that a new filter condition has been added. Select the filter condition, enter "0.01" in the <q>adjustment level</q> column, and select the check box corresponding to the <q>relative adjustment</q> column (the meaning of these two options is that the filter will meet the The level of the text of the condition is increased by 0.01; if the <q>match-to-adjustment</q> check box is not checked, it means that the level of the matching text is reduced to 0.01). As shown below.

![new image](media/image77.png)
<figcaption>Figure 5--17: Increasing the level of captions matched by filter criteria</figcaption>

From the previous analysis, it can be seen that the level of title 3 and title 4 is the same, and now the level of title 3 is increased by 0.01, then title 3 will have a higher level than title 4, and title 4 will be included in the exported bookmark. Click the <q>Export Information File</q> button to re-execute the operation of generating bookmarks.

Looking at the output, it can be seen that header 3 already contains header 4. The output results are basically satisfactory.

Return to the interface for automatically generating bookmarks, and modify the page number range to include all the pages that need to be processed. Then perform the export information file operation to generate bookmarks for the entire document.

### Modify output bookmarks using bookmark editor

After generating the information file, you can use the bookmark editor to modify the text in it to make the bookmark more beautiful. The specific process is omitted here, please refer to the previous content. After modifying the bookmarks, you can use the patch function of the bookmark editor to generate a new PDF document with bookmarks.

## Batch delete the first and last pages of documents

Task: A netizen gets a batch of PDF files, the first and last pages of each file are advertisements, and wants to delete them in batches. The steps to use the PDF patch are as follows.

1. Select the <q>Extract Pages</q> function.

2. Put the original PDF file in the same directory (set the directory as "E:\\original file"), click the <q>Browse</q> button to the right of <q>original PDF file</q>, go to Go to the above directory and select the batch file.

3. In the combo edit box to the right of <q>Output PDF file</q>, specify the output location, such as "E:\\output file\\abc.pdf". The program will copy the original file to the "E:\\output file" directory (disregard the output file name "abc.pdf", the program will automatically replace the original file name with the file name of the output directory).

4. Do not enter anything in the <q>page range</q> text box, the program will process all pages by default. Enter "1;-1" in the <q>Exclude Page Number Range</q> text box to exclude the first and last pages (negative numbers indicate page numbers from the end).

5. Click the <q>Extract Page</q> button.

## Batch reverse reverse page order documents

Task: A netizen downloaded a batch of PDF files. The pages in each document are inverted. The first page of the original book becomes the last page in the PDF file, but the last page of the book is the first page. Using a PDF editor to manually adjust the number of pages document by document would take a lot of time. The netizen tried to use the <q>reverse order printing</q> function of the PDF printer to rearrange the pages, but reverse order printing would reduce the quality of the document and take even more time.

The order of page numbers can be easily adjusted in batches using the PDF patch. The operation steps and screenshots are as follows.

1. Select the <q>Extract Pages</q> function.

2. Click the <q>Browse</q> button to the right of <q>original PDF file</q>, and in the pop-up file open dialog box, select the PDF document whose page order needs to be rearranged (multiple choices are allowed).

3. In the output PDF file, enter the output path (<q>M:\\</q> in this example), then right-click the text box, and select `<source file name in the pop-up context menu >`, insert the source file name substitute, which means output to the output directory according to the file name of the original PDF file.

4. In the <q>Page Range</q> text box, fill in the page range in reverse order: "-1-1" (without quotation marks). The first "-1" indicates the last page of the document, the middle "-" indicates the page number range, and the last "1" indicates the first page. "-1-1" is the last page to the first page of the document (if you need to extract pages from the second to last page of the document, enter "-2-1").

5. Click the <q>Extract Pages</q> button to restore the original PDF file with reversed page numbers and save it to the output path.

![new image](media/image78.png)
<figcaption>Figure 5--18: Reorder pages in reverse order</figcaption>

## Illustrate, merge documents and keep original document bookmarks

Task: Combine "Fiction (1).pdf" and "Fiction (2).pdf" into one PDF file, and insert the "cover.jpg" image file in front of the first page of the combined PDF file. The two PDF files "Fiction (1)" and "Fiction (2)" have bookmarks for easy reading. I hope that the merged PDF document also has the original bookmarks for easy reading.

The above tasks of inserting pictures and merging PDF documents can be accomplished by using the PDF patch. The operation steps are as follows.

### add files

Select the <q>Merge Documents</q> mode of the <q>Processing, Making PDF Documents</q> function.

Click the <q>Add File</q> button, and navigate to the directory where the "Cover. Select these three files and click the <q>OK</q> button to add the files to the file list. If the files are not in the same directory, repeat this step multiple times until the files that need to be processed are added to the file list location.

Tip: You can drag and drop files to be processed directly to the file list from "My Computer" or "Explorer".

### Adjust file order

The files at the top of the list will be inserted into the output PDF file first. If the order is not correct, you can use the <q>↑</q> and <q>↓</q> buttons on the program interface to adjust the order of the file items.

After completing the above adjustment operations, the file list from top to bottom is: "Cover.jpg", "Fiction (Top).pdf" and "Fiction (Bottom).pdf". "Cover" will be the first page of the output file; "Fiction (Top)" has 2 pages, which are on the 2nd and 3rd pages of the output file; "Fiction (bottom)" is on the 4th and 5th pages of the output file Page.

### Set page layout

Due to the inconsistency between the size of the above image and the PDF document. For the sake of aesthetics, you can adjust the page size of the image so that the page size of the image is the same as the page size of the two PDF files.

Select the <q>PDF Document Options</q> feature. Find <q>A4 (21cm\*29.7cm)</q> in the <q>Page Size</q> drop-down list and select it. At this time, the value adjustment boxes of <q>width</q> and <q>height</q> on the right side of the interface will be automatically changed to corresponding values.

Tip: If the required page size cannot be found in the list box, you can enter it in the <q>width</q>, <q>height</q> adjustment boxes.

### Keep bookmarks for source files

In this example, the source PDF file itself has bookmarks. After completing the merge operation, the program can bring bookmarks from the source PDF file to the new file as well.

In the [Bookmark Settings tab] (#page tag) of <q>PDF file options</q>, select the <q>Automatically generate bookmarks when information files have no bookmarks</q> radio box, and <q>Keep source PDF file bookmarks</q> check box, and then generate the file.

### Generate files

After completing the adjustment of the page layout, return to the <q>processing PDF document</q> function.

Click the <q>Browse</q> button to the right of <q>Output PDF file</q> to specify the location of the output PDF file.

Click the <q>Generate PDF file</q> button. The program will combine the above three files into one PDF file.

The files generated by this example are in Adobe
The display effect of Reader is shown in the figure below (for convenience of display, manually change the display mode of the document to <q>Double-page continuous</q>).

![new image](media/image79.png)

## Insert merge documents

Task: A netizen scans a batch of double-sided documents with a scanner and obtains two PDF files. One contains the contents of the front side (odd pages) and the other contains the contents of the back side (even pages), and now I want to merge the two PDF files into one PDF file by actual front and back.

There are two ways to accomplish the above tasks using PDF patches. The first method is to extract the image and generate the file; the second method is to merge two PDF files into one, and then rearrange the page order. They are introduced as follows.

### Extract the image and regenerate the file

Since the scanned PDF file is a full-image PDF file, you can extract all the images from the two PDF files, sort them by file name, and then regenerate a new PDF file. The operation steps are as follows.

1. Select the <q>Extract Image</q> function.

2. Select the first PDF file and specify the output directory, eg "C:\\Documents\\Pictures".

3. Specify the file mask as "0000A", so that the output file format is a four-digit number followed by an "A" word, such as "0001A.tif", "0002A.tif" and so on.

4. Click the <q>Extract Image</q> button to export the image to the output directory.

5. Select the second PDF file again, do not change the output directory specified above, but change the file mask to "0000B", so that the output file name is in the form of "0001B.tif", "0002B.tif". In this way, the images output from the two PDF files will be stored in the same directory, and the image file names can be sorted naturally according to the page number and the "A" and "B" suffixes.

6. Select the <q>Merge files</q> mode of the <q>Process PDF Documents</q> function.

7. Add all the image files generated in the above steps to the file list.

8. Use the sort function to sort the picture files in the file list so that the order is "0001A.tif", "0001B.tif", "0002A.tif", "0002B.tif", etc.

9. Specify a filename for the generated PDF file.

10. Click the <q>Generate PDF file</q> button, the program will combine the pictures into a PDF file in the order of the file list.

### Merge documents and then sort

Another method is to combine two PDF files into one PDF file and then use the Export Pages function to rearrange the page order. The operation steps are as follows.

1. Select the <q>Merge Documents</q> mode of the <q>Process PDF Documents</q> function.

2. Drag and drop the first PDF file and the second PDF file to the file list and sort them in order.

3. Specify the output file location.

4. Then click the <q>Generate PDF file</q> button to generate the file.

5. Select the <q>Extract Pages</q> function.

6. Specify the file you just generated at <q>Original PDF file</q>.

7. Specify the output location.

8. Assuming that the number of pages in the two original files is equal, both are 100, then the combined PDF file has 200 pages. After rearranging the pages, the page order should be 1, 101, 2, 102, 3, 103...99, 199, 100, 200. Therefore, the following sequence should be specified at <q>page range</q>: "1;101;2;102;3;103 (intermediate items omitted here);99;199;100;200".

9. Click the <q>Extract Pages</q> button, and the program will automatically rearrange the pages of the merged PDF document to generate a new document.

Tip: The method of generating the above page number sequence is very simple. Use a spreadsheet program (such as Excel, WPS spreadsheet, etc.) to automatically fill in two rows. The first row is 1 to 100; the second row is 101 to 200. The numbers in the two rows are staggered by one grid each, and then in the third row, use the formula to add up the numbers in the two rows (as shown in the figure below) to get a staggered sequence. Copy the content of this line, it is the above page number order (the third line of text copied from the spreadsheet program has tabs, don't care, the program will automatically ignore).

![new image](media/image80.png)

### Comparison of the two methods

The first method is quick and easy, but only suitable for PDF files that are completely image.

The second method has relatively high fidelity and is suitable for PDF files containing text and pictures, but the operation steps are a bit more complicated.

**Notes**: In the second method above, you can actually rearrange the page numbers by using the <q>Merge files</q> mode. First merge the two files to generate a new file. Empty the file list, add the above new file to the file list, double-click the item in the file list, enter the page number sequence in the above form in the <q>page order</q> text box in the properties dialog box, and then generate a new file You can also.

# XML info file reference

The information file used by the PDF patch can be exported from the [Export Document Information](#Export Information File) function. Info files are XML files that can be opened for editing with an XML editor or a text editor.

## info file root element

The root element of the info file is <q>PDF info</q>.

### Attributes

The document root element can contain the following attributes:

<q>Program name</q> attribute (fixed): take the fixed value <q>PDFPatcher</q>.

<q>Program version</q> attribute (required): Indicates the minimum version of the document that can be properly opened and processed by the PDF patcher.

<q>Export time</q> attribute (optional): The date and time when the document was exported.

<q>PDF file location</q> attribute (optional): The original PDF file path used to export the information document. The bookmark editor uses this property to open the PDF document corresponding to the bookmark.

<q>Number of pages</q> attribute (optional): The number of pages in the PDF document.

### child elements

The root element can contain the following child elements. Each child element is optional.

<q>[unit of measure](#unit of measure)</q> element: The unit of measure that represents the size of the document.

<q>[document information](#document metadata document information element)</q> element: Contains the metadata information of the document.

<q>[Reader setting](#Reader initial setting reader setting element)</q> element: Indicates the initial setting of the reader.

<q>[page numbering style](#page numbering style page numbering style element)</q> element: Contains the numbering method of the logical page number of the document.

<q>[document bookmark](#document bookmark)</q> element: contains the navigation bookmark of the document.

<q>[page link](#_Toc260694714)</q> element: Contains the jump link within the document page.

<q>[named location](#named location)</q> element: Contains the named jump target location in the document.

<q>[page setting](#page setting)</q> element: Contains settings such as page size and rotation angle.

The content of each element is described in detail below.

## Unit of measure

The unit of measure for page and position dimensions in the info file is represented in the <q>unit of measure</q> element.

The unit of measure contains the <q>units</q> property, which can be <q>centimeters</q>, <q>millimeters</q>, <q>inches</q>, and <q>points< /q>. If the <q>unit of measure</q> element or <q>unit</q> attribute does not appear, the unit is <q>points</q>. 1 inch (approximately 2.54 centimeters) is equal to 72 points.

<q>Point</q> is a unit of measurement used internally in PDF files.

## Document metadata ("document info" element)

The metadata information of the document is represented by the <q>document information</q> element under the root element.

### Attributes

Each attribute is optional. If the information file does not specify attributes, the corresponding data of the original PDF file is retained.

<q>PDF version</q> attribute: PDF version number, such as 1.4, 1.5, 1.6, etc.

<q>Title</q> attribute: The title of the PDF document.

<q>author</q> attribute

<q>Theme</q> attribute

<q>Keyword</q> attribute

<q>Creator</q> attribute: Indicates the program used to create the PDF document.

<q>Processor</q> attribute: Indicates the program that processed the PDF document for the last time.

<q>CreationDate</q> attribute: Indicates the creation date and time of the PDF document.

<q>Last Modified Date</q> attribute: Indicates the date and time when the PDF document was last modified.

When importing an info file, title, author, subject, and keywords can be imported into the document.

### Example

````xml
<Document Information
Create Program="WPS Office Personal"
keyword="PDF, PDFPatcher, manual"
Author="WMJ"
Title="PDF Patch User Manual"
subject="PDF Patch"
Created Date="2010-04-28 16:47:50"
handler="PDFlib 7.0.3 (C++/Win32)" />
````

## Reader initial settings ("reader settings" element)

The initial setting of the reader is represented by the <q>reader setting</q> element under the root element, which is used to specify the interface layout of the reader when the document is opened.

### Attributes

Each attribute is optional and not all PDF readers support these attributes. If the information file does not specify attributes, the corresponding data of the original PDF file is retained.

<q>Page layout</q> attribute: The initial layout when displaying the page, the valid values ​​are: <q>Single page continuous</q>, <q>Single page</q>, <q>Double page Consecutive</q>, <q>Double Pages</q>, <q>Double-page Consecutive Homepage</q> or <q>Double-page Homepage</q>. Among them, the <q>continuous</q> layout allows the reader to display the document across pages. In the double-page layout, the first page (cover) can be placed on a separate page.

<q>Initial mode</q> attribute: display the navigation bar displayed when the document is opened (such as page thumbnails, document bookmarks, etc.), the valid values ​​are <q>do not display sidebar</q>, <q>show document Bookmarks</q>, <q>Show Page Thumbnails</q>, <q>Show Full Screen</q>, <q>Show Selectable Content Groups</q>, or <q>Show Attachment Bar</q > One of the six. The more common values ​​are <q>Show document bookmarks</q> or <q>Full screen</q>.

<q>Hide Toolbar</q> property: Indicates whether to hide the toolbar of the reader interface, the valid value is <q>Yes</q> or <q>No</q> (not all PDF readers support this property).

<q>Hide menu</q> attribute: indicates whether to hide the menu bar of the reader interface, the valid value is <q>yes</q> or <q>no</q> (not all PDF readers support this Attributes).

<q>Show document content only</q> attribute: Indicates whether to hide other content of the user interface, the valid value is <q>Yes</q> or <q>No</q> (not all PDF readers support this property).

<q>Fit the window to the first page of the document</q> attribute: Indicates whether to adjust the window of the reader to fit the content of the first page of the document, the valid value is <q>Yes</q> or <q>No</q> (Not all PDF readers support this property).

<q>Window Center</q> property: Valid values ​​are <q>yes</q> or <q>no</q> (not all PDF readers support this property).

<q>Show document title</q> attribute: Indicates whether to display the document title in the window title bar of the reader, the valid value is <q>Yes</q> or <q>No</q> (not all PDFs Readers support this property).

<q>Reading direction</q> attribute (only valid when the page layout is double-page): Indicates the display mode of two adjacent pages under the double-page layout, the valid value is <q>from left to right</q> or <q>right to left</q>. If the document is a traditional vertical layout, select <q>Right to Left</q>.

### Example

Example 1: When the reader is opened to display the document, the bookmark of the document is displayed.

````xml
<Reader Settings Initial Mode="Show Document Bookmarks" />
````

Example 2: Using a right-to-left approach to reading text, the initial page layout is two-page facing, continuous scrolling, where the first page of the document is placed alone.

````xml
<Reader settings
Initial Mode="Show Document Bookmarks"
reading direction="right to left"
Page layout="Double-page continuous homepage" />
````

## Page number style ("page number style" element)

The logical page number setting of a PDF document is represented by the <q>page numbering style</q> element under the root element. This element has no attributes.

### "style" child element

The <q>Page Number Style</q> element contains a series of <q>style</q> elements that specify a logical page numbering style starting from a particular page number.

Each style represents a page numbering sequence, starting from the page corresponding to the <q>actual page number</q> in the document and ending with the <q>actual page number</q> specified by the next <q>style</q>. End of page number.

The <q>style</q> element can contain the following attributes.

<q>Actual page number</q> attribute (numeric, required): an absolute page number, the valid value should be a number between 1 and the number of pages in the PDF document, indicating that this <q>style< The page numbering style specified by the /q> element.

<q>Starting page number</q> attribute (numeric, optional): Indicates the starting number of the page number style used from <q>actual page number</q>, the valid value should be 1 to the end of the PDF document Numerical value between pages. The default starts from 1.

<q>page prefix</q> attribute (optional): a piece of text before the page number, such as the page number style is <q>number</q>, and the <q>page prefix</q> is "P- ", the logical page numbers seen on the reader are "P-1", "P-2", and so on. No prefix by default.

<q>style</q> attribute (optional): Specifies the number style used for page numbering. Valid values ​​are <q>numbers</q>, <q>lowercase Roman numerals</q>, <q One of five uppercase Roman numerals</q>, <q>lowercase English letters</q>, or <q>uppercase English letters</q>. Defaults to Arabic numerals.

### Example

The following example demonstrates a document with multiple page numbering styles.

The page numbering style for pages 1-4 is uppercase Roman numerals (I, II, III, IV).

The page numbering pattern for pages 5 to 25 is a number starting with P (P1, P2...P21).

The page numbers on pages 26 and 27 are in capital letters (A, B).

The page numbers on pages 28 to 21 are in lowercase English letters (a, b, c, d).

Page numbers from page 32 to the end of the document are Arabic numerals (1, 2, 3...).

````xml
<page number style>
<style actual page number="1" style="capital roman numerals" />
<style actual page="5" page prefix="P" style="number" />
<style actual page number="26" style="capital letters" />
<style actual page number="28" style="lowercase English letters" />
<style actual page number="32" style="number" />
</page style>
````

## Document bookmarks

A document bookmark is an interactive element in a PDF reader. After clicking a document bookmark, you can jump to the specified location of the document, open an external PDF document or execute an external executable file.

PDF document bookmarks are represented by the <q>document bookmarks</q> element under the root element.

### "Bookmark" sub-element

The bookmark sub-element represents a bookmark in the reader.

1. The `Bookmark` element can contain the following attributes.

2. `Text` property (required): The text representing the bookmark.

3. `Open by default` attribute (optional): Indicates whether to open bookmarks by default. Possible values ​​are `yes` and `no`. The default value is `yes`, which means that bookmarks are on by default.

4. `Style` attribute (optional): Indicates the appearance of the bookmark text. The optional styles are `bold`, `italic` and `bold italic`.

5. `Color property group (optional)`: Indicates the color of the bookmark text. An attribute group with 3 values ​​of `red`, `green` and `blue`, representing the three components of RGB, the value is a decimal between 0 and 1, and 1 is the full value. Therefore, the combination of the three attributes `red="1" green="1" blue="1"` represents white. In addition to using numerical colors, you can also use colors named by the .NET framework, which are represented by the `color` attribute, such as `color="Red"` for red, `color="Blue"` for blue, `color="DarkGreen" "` means dark green. In addition, the hexadecimal representation of `#RRGGBB` on the Web can also be used, such as `color="#FFFFFF"` for white, `color="#FF0000"` for red, etc.

6. `Action` attribute (optional): Indicates the action performed after clicking the bookmark. The optional actions are `Go to page` (jump to the specified location of the current PDF document), `Open external PDF document` (open the external PDF document and jump to the specified page), `Open URL` and `Start the program` `Four kinds. The default action is `go to page`. If the bookmark has no `action` and `page number` attributes, clicking the bookmark does not perform any action.

7. `Page Number` attribute (positive integer): Indicates the page to jump to after clicking the bookmark. Valid when the `action` property is `go to page` or `open external PDF document`.

8. `First page number` (optional): Indicates the page number offset value. For example, if the `first page number` is 5 and the page number is 3, it will actually jump to page 5+3-1=7.

9. `Display method` attribute (optional): Indicates the display method after jumping to the specified page. Valid when the `action` attribute is `go to page`. The display methods are as follows: `Coordinate Zoom` (Go to the coordinates of the specified page and zoom to the specified ratio), `Fit to page`, `Fit to window`, `Fit to window width`, `Fit to window height`, `Fit to window` Page Width, 'Fit to Page Height', and 'Fit to Area' (scale to the dimensions of the specified rectangular area).

10. `Named position` attribute (optional): Indicates jumping to the position of the specified name. The `named location` is specified by the `[named location](#named location)` element of the info file.

11. `PDF name` attribute (optional): Indicates to jump to the position indicated by the name of the PDF document.

The coordinate attribute group (optional, numerical value) has 5 attributes, `up`, `left`, `down`, `right` and `scale`, which are used in conjunction with the `display style` attribute. as shown in the table below.

| Properties | Explanation |
|------------ |----------------------------------- -------------------------------------------------- ----------------------------------|
| Display Mode | Coordinates |
| Coordinate scaling| It consists of 3 numeric properties, the `left` property specifies the offset value of the abscissa, the `up` property is the offset value of the ordinate, and the `scale` property specifies the scaling ratio (optional, 1 means 100 %). |
| Fit to Page | Should not have any coordinates. |
| Fit to Window | Should not have any coordinates. |
| Fit to the window width | Contains the `up` property, indicating the vertical coordinate after the jump. |
| Fit to window height | Contains the `left` property, which represents the abscissa after the jump. |
| Fit to page width | Contains the `up` attribute, indicating the vertical coordinate after the jump. |
| Fit to page height | Contains the `left` attribute, indicating the abscissa after the jump. |
| Fitting area | Contains 4 values ​​of `up`, `left`, `down`, `right`, indicating the rectangular area to be zoomed to after jumping. |

**Description**: The coordinates take the lower left corner of the page (0,0) as the minimum value. The unit of the coordinate value depends on the "[unit of measure](#unit of measure)" element of the document. If this element does not exist, the unit of measure is `point`. When the value is 0 or `null`, it means that the offset or scale before the jump remains unchanged.

The `named location`, `PDF name` and coordinate properties are mutually exclusive, only one of them can be specified.

`External file` attribute: Indicates that an external file is opened. Valid when the `action` property is `open external PDF` or `launcher`.

`URI` attribute: Indicates the open URL. Valid when the `action` property is `open url`.

`New window` property: Indicates whether to open the document in a new window. Valid when the `action` property is `open external PDF`.

The `bookmark` element can contain subordinate `bookmark` elements, indicating the nested relationship between bookmarks.

### Example

The following example indicates that there is only one bookmark in the PDF document.

The bookmark's text is `ABCDEF`, shown in bold. After clicking, jump to page 1. Since the unit of measurement is centimeters, after clicking, the abscissa of the page coordinates is 0, that is, the horizontal position of the current reader is kept unchanged, and the ordinate is 29.7, that is, it jumps to the first page where the ordinate is 29.7 centimeters, and the zoom ratio is 0, which means that the current display zoom ratio of the reader is not changed.

````xml
<unit of measure unit="cm" />
<document bookmark>
<bookmark text="ABCDEF" style="bold" page="1" display="coordinate scaling" left="0" top="29.7" scale="0" action="go to page" />
</document bookmarks>
````

Tip: It is recommended to change the zoom ratio to 0 to avoid changing the display zoom state of the reader when clicking on the bookmark, so as to facilitate reading. In addition, scaling can be forced to 0 when [Import info file](#import info file) by [specify "unlink target scaling" option](#advanced patch function export import info file).

The following example indicates that the "ABC" bookmark contains the "XYZ" bookmark, but not the "DEF" bookmark.

The color of the "ABC" bookmark is blue and is disabled by default. Since the bookmark has no "action" and "page number" properties, clicking the bookmark in the reader will not perform any action.

The action of the "XYZ" bookmark is "Go to page". After clicking the bookmark, the display scale of the reader will be changed to "Fit to Width", and the page will jump to page 5. The ordinate is 5.24 cm from the bottom of the page.

"DEF" is an empty bookmark that does nothing when clicked.

````xml
<unit of measure unit="cm" />
<document bookmark>
<Bookmark Text="ABC" Color="Blue" Default On="No">
<bookmark text="XYZ" page="5" display="fit to width" top="5.24" action="go to page" />
</bookmark>
<bookmark text="DEF"/>
</document bookmarks>
````

**Note**: The last attribute of the "ABC" bookmark is followed by "\>", which means that the bookmark contains sub-bookmarks, and the last attribute of the "XYZ" bookmark is followed by "/\>", which means that it does not contain sub-bookmarks. The "\</bookmark\>" after the "XYZ" bookmark corresponds to the "ABC" bookmark, indicating that the scope of the "ABC" bookmark ends here, and the "DEF" bookmark is not nested within the "ABC" bookmark.

Tip: Before [Import Information File](#Import Information File), you can specify the "Bookmark Status" as "All Closed" in the "[Reading Method Settings](#Page Size)" tab of the PDF document options to force the All bookmarks are off by default.

## page link

Represents a link within a page of a PDF document. Represented by the "page link" element below the root element.

Each `link` element under the `page link` element represents a page link. Link elements can contain the following attributes.

`pagenumber` property (required, positive integer): Indicates the page number where the link is located.

Coordinate attribute group (required): There are 4 attributes `left`, `down`, `up` and `right`, which represent the rectangular area where the link is located.

`border` property (optional): Contains the border property value composed of three values.

`Click effect` attribute: Indicates the effect after clicking the link.

`text` property: Represents the textual description of the link.

Color attribute group: Indicates the color of the link tag, which is a combination of three primary color components combined with three attributes of `red`, `green` and `blue`.

The `Page Links` element can contain the following child elements:

Border style: Indicates the style of the border, which can include the `style` attribute.

Elements named after actions (such as `go to page`, `open url`, etc.), see the `action` attribute of the `bookmark` element. Elements can contain attributes that correspond to actions.

## named location

Represents a location with a specific name in a PDF document.

## page settings

The size, display area, and rotation of a page can be expressed using the `Page Setup` element.

### "page" child element

The `page` child element represents the settings of the page and contains the following attributes.

1. `Page Number Range` property (required): Indicates the absolute page number range corresponding to this page setting.
2. `Page filter` attribute (optional): used to filter the page number range, the value can be `single page` (all odd pages within the page number range) or `even page` (all even number pages within the page number range) ).
3. `Page Border` property (required): Indicates the coordinate position of the page border. The border contains a rectangular area consisting of two pairs of coordinate values. The first pair is the coordinates (0,0) of the lower left corner of the page, and the latter pair is the coordinates of the upper right corner of the page. The unit of measure for the coordinates is determined by the "[unit of measure](#unit of measure)" element of the document.
4. `Intercept Border` property (required): Indicates which content in the page border can be displayed. The coordinates of the clipping border cannot fall outside the rectangle defined by the page border.
5. `CropBorder` property (optional, see the schematic diagram in the "[PDF page border](#pdf page border)" section)
6. `Bleed Border` property (optional)
7. `ContentBorder` property (optional)
8. `Rotation Angle` property (optional): indicates the page rotation direction, which must be 0, 90, 180 or 270 degrees. Defaults to 0 degrees.

### Borders of PDF pages

PDF pages are primarily specified by a rectangular range given by the `page border`. The relationship between other borders and page borders except the clipping border is shown in the following figure.

![shot](media/image81.png)
<figcaption>Figure 6--1: PDF Border Diagram</figcaption>

Since the `cutout border` has no specific relationship with other borders other than the page border (the interception border must fall within the page border), it is not drawn in the figure.

In general, you only need to define page borders and intercept borders.

### Example

The following example indicates that page dimensions from 1 to 517 are 21 cm wide and 29.7 cm high.

````xml
<unit of measure unit="cm" />
<Page Setup>
<page page range="1-517"
         page border="0 0 21 29.7"
         truncate border="0 0 21 29.7" />
</page setup>
````

Use the crop border and page border together to crop the page. The following example represents the even-numbered pages from pages 1 to 517, and the content of 1 cm on the left is cropped. The actual page width should be 21-1=20 cm.

````xml
<unit of measure unit="cm" />
<Page Setup>
<pages page range="1-517" page filter="even pages"
         page border="0 0 21 29.7"
         intercept border="1 0 21 29.7" />
</page setup>
````

By changing the page borders you can leave extra white space for PDF pages that weren't originally much blank. For example the example below leaves 3 cm of extra space down the page.

````xml
<unit of measure unit="cm" />
<Page Setup>
<page page range="1-517"
         page border="0 -3 21 29.7"
         truncate border="0 -3 21 29.7" />
</page setup>
````

Different sizes can be specified for different pages. The example below defines page 1, and different sizes for odd and even pages between pages 2 and 517, respectively.

````xml
<unit of measure unit="cm" />
<Page Setup>
<page page range="1" rotation angle="90"
         page border="0 0 29.7 21"
         truncate border="0 0 29.7 21" />
<pages page range="2-517" page filter="even pages"
         page border="0 0 21 29.7"
         truncate border="1 0 22 29.7" />
<Pages Page Range="2-517" Page Filter="Singular Pages"
         page border="0 0 21 29.7"
         truncate border="0 0 21 29.7" />
</page setup>
````

# Easy bookmark file reference

Easy Bookmarks file is mainly used to make PDF bookmarks quickly. The function of the simple bookmark file is limited. If you need more powerful functions, you can use the [Convert bookmark file] (#_Import information generation file_) function to convert it into an XML information file. The simple bookmark file format is described below.

**Note**: If you export the original bookmarks of a PDF document into a simple text bookmark file, and then re-import it into the document after editing, because the simple text bookmarks contain less information, the bookmarks of the original document may lose some information (such as cannot pinpoint a specific location on the page, specify bold text for bookmarks, etc.). Therefore, in general, do not export simple text bookmark files.

## file structure

The simple bookmark file contains two parts: the file header and the bookmark.

## file header

The file header contains information such as version, title, subject, keywords, author, etc.

`#version` indicates the version number of the bookmark file and must appear on the first line. The version number should match the version of the PDF patch. It is also possible to not use this line, but it will prompt that the version does not match when importing. Programs of higher versions are generally compatible with bookmark files of lower versions.

`#Title`, `#Subject`, `#Keyword`, and `#Author` represent the title of the PDF document properties, respectively.

The following code specifies the bookmark file version as 0.2.6 and the corresponding metadata information.

````
#version=0.2.6
#title=PDF Patch User Manual
#theme=pdfpatch
#Keyword=PDF, PDFPatcher, User Manual
#author=WMJ
````

## bookmark content

Except for this line, everything else is the bookmark content. Each line of text represents a bookmark. Bookmarks consist of the following four parts:

Indent markers (defaults to tabs).

Bookmark text.

Separator between text and page numbers.

page number.

### indent mark

When a bookmark has one more indent mark than the previous bookmark, it indicates that this bookmark is a child bookmark of the previous bookmark. The text of the first bookmark must not have any indent marks before it.

The default indent marker is the tab character.

### bookmark text

The indent marker string is only valid at the start position, and indent marker characters appearing in bookmark text will be treated as bookmark text.

### delimiter

The separator between text and page numbers can be more than one of the following characters: tab, half- or full-width space, period `.`, ellipsis `...`, minus sign `-`, underscore `_`.

### Page number

Page numbers in Arabic numerals. There can be no content after the page number except for extra white space.

Page numbers can be either half-width or full-width, but not Chinese or Roman numerals.

If the page number part is empty, it means a bookmark that does not jump to any part of the document.

### Example

For example, the following defines six bookmarks.

````
Top Bookmarks ................. 1
Secondary bookmark ______ 2
Level 3 bookmarks 3
another top bookmark
Secondary Bookmark 2 ----- 7
Secondary Bookmarks 3...56
````

Note the nesting relationship indicated by the use of tab indentation before bookmarks: top-level bookmarks contain second-level bookmarks, and second-level bookmarks contain third-level bookmarks.

The separators for each bookmark are different (any one is correct), and the page numbers are 1, 2, 3, 7, 56. The 4th bookmark (another top-level bookmark) has no page number, and clicking that bookmark in the reader will do nothing.

## bookmark command

### Home page number (specify the reference value of page number)

In many cases, the page numbers of the text we see are not in the PDF
Begins with the first page in the document. Often the first few pages are the preface, the table of contents, etc., and many pages are followed by the text. When we enter the simple bookmark text, we usually enter it against the catalog page (as shown in the multi-level bookmark above), so the page number in the simple bookmark text is the page number on the catalog page when inputting, not
Page numbers in the PDF document.

In the bookmark content, you can use the `#HomepageNumber` command to specify the bookmark that appears below, corresponding to the actual page number of the homepage page number.

For example, the page number corresponding to `main body` defined in the following content is 1, and the page number corresponding to `first chapter` is 2, but because of the `#first page page number=39` command, the `text` actually corresponds to the page number in the PDF document. On page 39, `Chapter 1` corresponds to page 40.

````
#Homepage number=39
body 1
Chapter 2
Section 3
Chapter 2 14
````

A simple bookmark file can have multiple `#First page page numbers` commands, each command only affects the correspondence between the bookmark page numbers that appear later and the actual page numbers, and does not affect the previous bookmark page numbers.

For example, the following example appears with multiple `#HomepageNumber` directives.

````
#Homepage number=1
cover 1
#Homepage number=3
XX Preamble 1
Sequence 5
#Homepage number=11
catalog 1
#Homepage number=39
body 1
Chapter 2
Section 3
Chapter 2 14
````

### Indent mark (custom bookmark nested mark)

The program uses tabs as indent markers by default, which is convenient in editors that support the Tab key to indent content (such as AkelPad, EditPlus, PsPad, etc.). However, using tabs is inconvenient in some situations (such as in
Excel
Enter the bookmark file in the file, it is not good to enter tabs). You can use the `#indent mark` directive to specify an indent mark, and the indent mark is the content after the equal sign.

The following examples use `. ` as an indent marker.

````
#Homepage number=39
# indent marker = .
body 1
. Chapter 2
. . Section 3
. Chapter 2 14
````

More than one character can be used as an indent marker.

The following examples use `, , ` as indentation markers.

````
#Homepage number=39
#indent mark=,,,
body 1
,,, Chapter 1 2
,,,,,, Section 1 3
,,, Chapter 2 14
````

Similar to the `#HomepageNumber` command, the `#indent mark` can appear multiple times in a simple bookmark file, and is only valid for the bookmark text that appears after it.

### Open bookmarks (specify the default open state)

The program sets bookmarks to off by default. To open a bookmark and display its sub-bookmarks by default, use the `#open bookmark` command.

The following example specifies that the `body` bookmark is open and each subsequent bookmark is closed.

````
# open bookmarks = yes
body 1
#open bookmark=no
Chapter 2
Section 3
Chapter 2 14
````

# Technical support and contact information

## common problem

### The file list is automatically cleared, no more files can be added

Q: Every time I add a file to the file list, it clears the previous files by itself, making it impossible to patch multiple files at once. Is there a way to solve?

A: You can add multiple files to the file list without checking the <q>Clear list before adding files</q> check box on the interface.

### The principle of the lossless image extraction function

Q: Does the PDF patcher use a virtual device to extract pictures to print them into pictures?

A: The PDF patcher is to parse the data in the PDF file and restore the data to a picture file without loss.

Images in PDF files usually have several encodings: uncompressed, Deflate, JPEG, JPEG2000, FAX, and JBIG2. Uncompressed pictures and Deflate-encoded ones can be saved as PNG, JPEG and JPEG2000 generally save the stream directly as image files, FAX-encoded ones can be restored to TIFF files, and JBIG2-encoded ones will be converted to TIFF files. Since the image data is extracted from the PDF file and saved as an image file by direct saving or lossless compression immediately after decoding, there is no problem of reducing image quality such as secondary compression.

## Known issues

If you encounter the following problems during use, please do not write.

1. Cannot export or import PDF bookmarks or page links that contain multiple actions or multimedia actions.
2. Unable to open PDF documents encrypted with Adobe Acrobat X.

## Contact information

If you find any problems during use, please submit an issue on the [Github code repository](https://github.com/wmjordan/PDFPatcher/issues). In submitting a question, please provide the following information:

1. PDF patch version.

2. Operating system version and revision number.

3. Conditions and steps to reproduce the problem.

Please describe the PDF file causing the problem in as much detail as possible. If possible, use the Export Pages feature to export a few representative pages of the document and send them as attachments with the email.

<link rel="stylesheet" href="style.css">
