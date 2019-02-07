using System;
using System.Collections;
using System.Collections.Generic;

public class JavaMetrics
{
    private static HashSet<String> uniqueKeywords = new HashSet<String>();
    private static HashSet<String> uniqueIdentifiers = new HashSet<String>();


    private static HashSet<String> uniqueConstants = new HashSet<String>();
    private static HashSet<String> uniqueSpecial = new HashSet<String>();

    private static HashSet<String> mccabeValues = new HashSet<String>();

    public static HashSet<string> UniqueKeywords { get => uniqueKeywords; set => uniqueKeywords = value; }
    public static HashSet<string> UniqueIdentifiers { get => uniqueIdentifiers; set => uniqueIdentifiers = value; }
    public static HashSet<string> UniqueConstants { get => uniqueConstants; set => uniqueConstants = value; }
    public static HashSet<string> UniqueSpecial { get => uniqueSpecial; set => uniqueSpecial = value; }
    public static HashSet<string> MccabeValues { get => mccabeValues; set => mccabeValues = value; }
}