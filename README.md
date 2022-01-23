# PDFPatcher

Thank you for your attention to the PDFPatcher. Please read this description and license agreement before using the software or source code. This software and source code adopts AGPL + "**Conscience Authorization**" agreement - **If users benefit from this software each time, they should do a good deed; if they use the source code to develop new software and obtain benefits, and should donate not less than one-thousandth of the proceeds to disadvantaged groups in society**.

## Function introduction

PDFPatcher is a PDF processing tool. It has the following functions:

- Modify PDF documents: modify document properties, page numbers, page links; unify page size; delete actions such as automatically opening web pages; remove copying and printing restrictions; set the initial mode of the reader; page.
- Intimate PDF bookmark editor: with a reading interface (with a right-to-left reading method that is easy to read vertical documents), you can batch modify PDF bookmark properties (color, style, target page number, zoom ratio, etc.), and bookmarks can be accurately positioned Go to the middle of the page; perform search and replace in bookmarks (regular expression and XPath matching are supported, and chapter, chapter, and section bookmarks can be quickly selected), [Automatically and quickly generate document bookmarks](https://www.cnblogs.com/pdfpatcher/p/8452025.html).
- Make PDF files: Merge existing PDF files or images to generate new PDF files; the merged PDF document has bookmarks of the original document, and new bookmarks (or generated according to the file name), new bookmark text and styles can also be attached customizable; merged PDF documents can be assigned a uniform page size for easy printing and reading.
- Split or merge PDF files and keep the original bookmarks or add new ones.
- High-speed lossless export of images from PDF documents.
- Convert PDF pages to images.
- Extract or delete specified pages in PDF documents adjust the page order of PDF documents.
- Rename PDF file names based on PDF document metadata.
- Invoke the image recognition engine of Microsoft Office to analyze the text in the image of the PDF document; convert the content page of the image PDF into a PDF bookmark. The recognition results can be written to PDF files.
- Replace fonts: replace fonts used in documents; embed fonts into PDF documents to eliminate garbled characters when copying text, making it readable on devices without fonts (e.g., e-book readers such as Kindle).
- Analyze the document structure: Display the PDF document structure in a tree view, edit and modify the PDF document nodes, or export the PDF document into an XML file for PDF lovers to analyze and debug.
- Free forever, never expires, no ads, no pop-up nonsense dialogs, no privacy snooping.

## License Agreement

The "PDFPatcher" software (referred to as the software) is protected by copyright law, international treaty provisions, and other intellectual property laws and treaties.
This software is free to end-users. Since this software uses third-party open source components with AGPL terms, the terms of use of this software and its source code are also based on the AGPL. In addition, the following additional conditions apply. Under the premise of complying with this software, you can freely use and disseminate it following this agreement. Once you install, copy or use this software, it means that you have agreed to the terms of this agreement. If you do not agree to this agreement, please do not install and use this software, nor use its source code.

Additional conditions:
Every user who uses this software, if this software helps you, you should do one good deed after each use of this software. Good deeds are no matter how big or small. For example:

1. If your parents are around, you can cook a delicious meal for your parents or massage and wash their feet for them; if they are far away, you can initiate a call to them to greet their health and life.
2. When it rains heavily, if you have an umbrella, you can share it with your fellow travelers; when the sun is shining, if you see sanitation workers working under the sun, you can buy them a bottle of water and give them to them; On crowded public transport, or while waiting in line in a public place, if you have a seat, give it to the elderly, pregnant women, or heavy lifters.
3. You can use the skills you are good at to solve problems for the people around you; you can share your knowledge with others to benefit; you can donate money to people who are more difficult than you.
4. If you think this software is straightforward to use, please introduce its usage to others so that others can benefit from using it or introduce other software that you feel is easy to use.

If you can't do 1 good deed after using this software, please keep it in mind. Do good deeds when you have the opportunity. Whether or not to follow this User Agreement is entirely up to your conscience. It is for "**authorized by conscience**".

Related definitions:

1. Software: Software refers to the "PDFPatcher" software and its updates, product manuals, online documents, and other related carriers.
2. Restrictions: You may use the source code of this software to develop applications (free, shared, or commercial), and you may distribute an unlimited number of complete copies of this software in any way, provided that:
(1) You must provide the full version of the software when distributing the software, and you may not make any modifications to the software or even its installation program without permission;
(2) You cannot change this License Agreement when distributing the software;
(3) If you add this software to commercial publicity activities or products, you should obtain the written permission of the copyright owner;
(4) If you use the source code of this software to write other software and generate sales revenue, you should donate not less than one-thousandth of the software sales revenue to disadvantaged groups in society.
3. Support: The software will be continuously updated due to users' needs, and the copyright owner will provide various related information support, including user manuals, e-mails, etc., but the software does not guarantee that the supported content and functions will not change.
4. Termination: When you do not agree with or violate this agreement, the agreement will be automatically terminated, and you must delete this software product immediately.
5. Copyright: The software and source code are protected by copyright laws, international treaty provisions, and other intellectual property laws and treaties.
6. Disclaimer: This software and the copyright owner are not responsible for any loss caused by installing, copying, and using this software.

## Introduction to commonly used PDF open-source components

The specification for PDF documents (ISO 32000-1:2008 "Document management — Portable document format — Part 1: PDF 1.7") is available online and is generally required reading for developers of PDF processing programs.

The PDF document format involves many technologies in the printing field, has a unique document structure, and uses a variety of data compression algorithms. Writing a PDF document processing program from scratch is often complicated and impractical for the average person. The PDFPatcher is developed using .NET Framework and mainly uses iText and MuPDF, two open-source component libraries, to process PDF documents.

The former is a .NET component, which has better interoperability with the PDF main program and is superior to the latter in parsing, generating, and modifying PDF documents and embedding a subset of TTF fonts.

The latter is developed and compiled in C language. Compared with the former, its most significant advantage is rendering PDF documents as bitmaps. The dynamic component library compiled by MuPDF can be downloaded from the author's other open-source library [SharpMuPDF](https://github.com/wmjordan/SharpMuPDF). The PDFPatcher invokes the function of the component library through P/Invoke technology.

In addition to PDF open-source components, the program also uses other excellent open-source components. For example, ObjectListView is a robust list control, FreeImage, to read and decode various bitmap image files. Cyotek's ImageBox is used to display rendered PDF document pages, TabControlExtra is used to build tabbed document interface, HTMLRenderer is used to display HTML web interface, etc.

## The structure of the source code

- App directory: PDFPatcher main program
  - Common: some commonly used tool classes
  - Functions: Forms and controls are used to present various functions of the software
  - Lib: 3rd party components used by the program
  - Model: High-level model used when editing documents (basic data models are implemented by iText and MuPDF classes)
  - Options: Options for the program
  - Processor: Algorithm for processing PDF documents (P/Invoke classes that call MuPDF are placed in the Mupdf directory)
- doc directory: place the usage documentation of the program
- JBig2 directory: place encoding and decoding library code for JBIG2 images

## Runtime environment

- Windows 7 or later operating system.
- .NET Framework version 4.0 to 4.8.
- The Document Imaging Component (MODI) of Microsoft Office 2003 (or 2007) is required to use the text recognition feature.
- Compile the program source code, it is recommended to use Visual Studio 2019 or newer, and install both ".NET Desktop Development" and "C++ Desktop Development" workloads.

## Contact the author

Except for third-party components, the source code of this software is entirely open:

<https://github.com/wmjordan/PDFPatcher>

<https://gitee.com/wmjordan/pdfpatcher>

It is recommended to submit your suggestions or needs by submitting an issue through an open-source website. Due to the busy daily work, we do not provide QQ or WeChat consultation services. For the time being, please understand.

Please include your version number in the e-mail or message, attach screenshots and attachments, and detail the problem you encountered.

If you need to provide an attachment, please make it smaller. Under normal circumstances, it is best not to send attachments over 10M.

- For PDF files, the "Extract Pages" function can be used to extract representative pages.
- For image files, compress the source file, or provide a representative page or two of images.
