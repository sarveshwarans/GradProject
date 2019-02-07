from operator import itemgetter

floatPointList = [645.32, 37.40, 76.30, 5.40, -34.23, 1.11, -34.94, 23.37, 635.46, -876.22, 467.73, 62.26]
userNameList = ["Hal","Susann","Dwight","Kassandra","Lawrence","Cindy","Cory","Mac","Romana","Doretha","Danna",
                "Zara","Rosalyn","Risa","Benny","Juan","Natalie"]
userProfileList = [("Hal", 20), ("Susann", 31), ("Dwight", 19), ("Kassandra", 21), ("Lawrence", 25),("Cindy", 22), 
                   ("Cory", 27),("Mac", 19), ("Romana", 27), ("Doretha", 32), ("Danna", 20),("Zara", 23), 
                   ("Rosalyn", 26),("Risa", 24), ("Benny",28), ("Juan", 33), ("Natalie", 25)]

print("*** Sorted Floating Point List ***")
print(" ")
print (sorted (floatPointList, reverse = False))
print(" ")
print("*** Sorted User Profile List Based on Name(Alphabetical Order) ***")
print(" ")
print (sorted (userNameList, reverse = False))
print(" ")
print("*** Sorted User Profile List Based on Age(Descending Order) ***")
print(" ")
print (sorted(sorted(userProfileList, key = itemgetter(0), reverse = False), key = itemgetter(1), reverse = True))