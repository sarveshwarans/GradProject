import Data.List
a = [645.32, 37.40, 76.30, 5.40, -34.23, 1.11, -34.94, 23.37, 635.46, -876.22, 467.73, 62.26]
--sortBy compare a
--sortBy (flip compare) a
b = ["Hal","Susann","Dwight","Kassandra","Lawrence","Cindy","Cory","Mac","Romana","Doretha","Danna","Zara","Rosalyn","Risa","Benny","Juan","Natalie"]
--sortBy compare b
c = [("Hal", 20), ("Susann", 31), ("Dwight", 19), ("Kassandra", 21), ("Lawrence", 25),("Cindy", 22),("Cory", 27),("Mac", 19), ("Romana", 27), ("Doretha", 32), ("Danna", 20),("Zara", 23), ("Rosalyn", 26),("Risa", 24), ("Benny",28), ("Juan", 33), ("Natalie", 25)]
sortDesBasedOnAge (a1, b1) (a2, b2)
  | b1 < b2 = GT
  | b1 > b2 = LT
  | b1 == b2 = compare a1 a2
--sortBy sortDesBasedOnAge c
