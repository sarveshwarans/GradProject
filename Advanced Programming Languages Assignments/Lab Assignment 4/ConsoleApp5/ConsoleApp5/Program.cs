using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class DirectoryFileDetails
{
    //Initialization of variables
    //  -> fileType         - Holds the file extenstion
    //  -> fileCount        - Holds the file count
    //  -> fileSize         - Holds the total size of the file of same extenstion
    //  -> formattedSize    - Holds the formatted size in terms of B,kB,MB,GB,TB,PB,EB,ZB
    //  -> inputPath        - Holds the input path where the files are to be scanned
    //  -> htmlOutputPath   - Holds the output path where the HTML report will be generated

    static string fileType;
    static int fileCount = 0;
    static long fileSize = 0;
    static string formattedSize;
    static string inputPath, htmlOutputPath;

    //Funtion Name      - EnumerateFilesRecursively
    //Input Parameter   - inputPath which holds the path to be scanned
    //Return Type       - String which is of IEnumerable Type
    static IEnumerable<string> EnumerateFilesRecursively(string path)
    {
        DirectoryInfo dir = new DirectoryInfo(path);
        // fileList - Contains all the files in the parent directory and also in all its sub directories
        IEnumerable<System.IO.FileInfo> fileList = dir.GetFiles("*.*", System.IO.SearchOption.AllDirectories);
        // fileQuery - To group the files based on the file extension
        var fileQuery =
            from file in fileList
            group file by file.Extension.ToLower() into g
            orderby g.Key
            select g;
        // To process each group (file extension)
        foreach (var fi in fileQuery)
        {
            fileType = fi.Key;
            // fileCounter  - Holds the number of files which are of same file extension
            // fileLength   - Holds the total size of the files which are of same file extension 
            int fileCounter = 0;
            long fileLength = 0;
            // To process for each file present in the same group (file extension)
            foreach (var f in fi)
            {
                fileLength += f.Length;
                fileCounter++;
            }
            fileCount = fileCounter;
            fileSize = fileLength;
            // Call the FormatByteSize() to get the formatted size value
            formattedSize = FormatByteSize(fileSize);
            // Yield return fileType followed by fileCount followed by formattedSize
            yield return fileType;
            yield return fileCount.ToString();
            yield return formattedSize;
        }
    }

    // Function Name    - FormatByteSize
    // Input Parameter  - fileSize
    // Output Type      - String
    static string FormatByteSize(long byteSize)
    {
        if (byteSize < Math.Pow(10, 3))
        {
            formattedSize = string.Concat(byteSize.ToString("0.00"), "B");
        }
        else if (byteSize >= Math.Pow(10, 3) && byteSize < Math.Pow(10, 6))
        {
            formattedSize = string.Concat((byteSize / Math.Pow(10, 3)).ToString("0.00"), "kB");
        }
        else if (byteSize >= Math.Pow(10, 6) && byteSize < Math.Pow(10, 9))
        {
            formattedSize = string.Concat((byteSize / Math.Pow(10, 6)).ToString("0.00"), "MB");
        }
        else if (byteSize >= Math.Pow(10, 9) && byteSize < Math.Pow(10, 12))
        {
            formattedSize = string.Concat((byteSize / Math.Pow(10, 9)).ToString("0.00"), "GB");
        }
        else if (byteSize >= Math.Pow(10, 12) && byteSize < Math.Pow(10, 15))
        {
            formattedSize = string.Concat((byteSize / Math.Pow(10, 12)).ToString("0.00"), "TB");
        }
        else if (byteSize >= Math.Pow(10, 15) && byteSize < Math.Pow(10, 18))
        {
            formattedSize = string.Concat((byteSize / Math.Pow(10, 15)).ToString("0.00"), "PB");
        }
        else if (byteSize >= Math.Pow(10, 18) && byteSize < Math.Pow(10, 21))
        {
            formattedSize = string.Concat((byteSize / Math.Pow(10, 18)).ToString("0.00"), "EB");
        }
        else
        {
            formattedSize = string.Concat((byteSize / Math.Pow(10, 21)).ToString("0.00"), "ZB");
        }
        return formattedSize;
    }
    // Function Name        - CreateReport
    // Input Parameter      - file which is of IEnumerable<string>
    // Output Type          - Void
    static void CreateReport(IEnumerable<string> files)
    {
        int iCount = 0;
        // Below set of html tags will be generated before getting the first yield return value
        string htmlString = "<table style=\"font-family:Verdana; \"border=\"1\";>  \n" +
                            "\t <tr>\n" +
                            "\t <th>" + "File Extension" + "</th>\n" +
                            "\t <th>" + "Num Of Files" + "</th>\n" +
                            "\t <th>" + "Total Size" + "</th>\n" +
                            "\t </tr>\n";
        foreach (var i in files)
        {
            //On receiving the first yield return value the below set of tags will be appeneded to the htmlString
            if (iCount == 0)
            {
                htmlString += "\t <tr>\n";
                htmlString += "\t <td>" + i + "</td>\n";
            }
            //On receiving the second yield return value the below set of tags will be appeneded to the htmlString
            if (iCount == 1)
            {
                htmlString += "\t <td>" + i + "</td>\n";
            }
            //On receiving the third yield return value the below set of tags will be appeneded to the htmlString
            if (iCount == 2)
            {
                htmlString += "\t <td>" + i + "</td>\n";
                htmlString += "\t </tr>\n";
            }
            //Increment the iCount counter if it is the first or second yield return
            if (iCount != 2)
                iCount++;
            //In case of third yield return set the iCount to 0. This is done so as to set the start and end of <tr> tags at appropriate place
            else
                iCount = 0;
        }
        htmlString += "</table>";
        //Append the htmlOutputPath with the html file name (htmlReport.html)
        htmlOutputPath += "\\htmlReport.html";
        //Write the htmlString in htmlReport.html file in the hhmlOutputPath location
        File.WriteAllText(htmlOutputPath, htmlString);
    }
    public static void Main(string[] args)
    {
        // Get the first command line argument and assign it to inputPath
        inputPath = args[0];
        // Get the second command line argument and assign it to htmlOutputPath
        htmlOutputPath = args[1];
        //Print the output on the console
        Console.WriteLine("Path to be Scanned: "+ inputPath);
        Console.WriteLine("HTML Output Path: " + htmlOutputPath);
        //Functions are called as shown below
        CreateReport(EnumerateFilesRecursively(inputPath));
    }
}