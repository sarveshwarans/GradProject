--	----------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- Name of the function - firstHalfOfList
-- Input                - list
-- output               - list
-- Functionality
--                  - firstHalfOfList will take list as input and returns a list as output
--                  - firstHalfOfList will hold the elements of first half of the given list.
--                  - This is achieved by using the take function which returns n values of the given input.
--                  - The input for the take function is retrieved by dividing the total length of the list by 2.
--                  - When the number is divided by 2, we get the floor value of it. Using this value, first half of the given list is retrieved.
firstHalfOfList :: [a] -> [a]                       -- Takes list of type 'a' as input and returns list of same type 'a'
firstHalfOfList xs = take (length xs `div` 2) xs    -- xs is the list of elements. lenth of xs/2 = floor value. Using take function would give first half of
                                                    --        input list.
--	----------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- Name of the function - lastHalfOfList
-- Input                - list
-- output               - list
-- Functionality
--                  - lastHalfOfList will take list as input and returns a list as output
--                  - lastHalfOfList will hold the elements of last half of the given list.
--                  - This is achieved by using the drop function which exludes n values of the given input.
--                  - The input for the drop function is retrieved by dividing the total length of the list by 2.
--                  - When the number is divided by 2, we get the floor value of it. Using this value, last half of the given list is retrieved.
lastHalfOfList :: [a] -> [a]                        -- Takes list of type 'a' as input and returns list of same type 'a'
lastHalfOfList xs = drop (length xs `div` 2) xs     -- xs is the list of elements. lenth of xs/2 = floor value. Using drop function would drop first half of
                                                    --        input list. Hence this will return the elements not reported by firstHalfOfList
--	----------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- Name of the function - merge
-- Input                - list
-- output               - list
-- Functionality
--                - To merge two sorted lists
--                - If List X has values and List Y is empty, on merging the output will be List X
--                - If List Y has values and List X is empty, on merging the output will be List Y
--                - If there are two lists, the head values of both the lists will be compared. The value which is least will
--                    be concatinated with the result of the merging of other elements of the lists.
--                - x and y represents the head values of their respective lists.
--                - xs and ys represents the elements of the lists.
merge :: Ord a => [a] -> [a] -> [a]             -- merge takes list of type 'a' as input and returns a list of same type as output. Here 'a' is the
                                                --        instance of typeclasee 'Ord'. Hence comparision operators are defined for it. Therefore the
                                                --        elements of type 'a' can be compared with one another.
merge xs [] = xs                                -- If List X has values and List Y is empty, on merging the output will be List X
merge [] ys = ys                                -- If List Y has values and List X is empty, on merging the output will be List Y
merge (x:xs) (y:ys)                             -- merge function takes two input. List X with x being the first element and xs being the other elements of the list
                                                --        and List Y with y being the first element and ys being the other elements of the list
          | (x <= y)  = x:(merge xs (y:ys))     -- If x<=y, then cons x with (merge result of other elements of list X that is xs with list Y)
          | otherwise = y:(merge (x:xs) ys)     -- Otherwise, cons y with (merge results of list X with other elements of Y that is ys)
--	----------------------------------------------------------------------------------------------------------------------------------------------------------------------		  
-- Name of the function - msort
-- Input                - list
-- output               - list
-- Functionality
--                - To merge sort the input list
--                - If the input list is empty, then the output will also be empty
--                - If the input list has only one value, then the output will also have only one list(Singleton list)
--                - xs represents the elements of the input list
-- Execution Flow In Case Of Lists With Values
--                - The msort function would first call the merge function.
--                - The merge function requires two sorted Lists as input.
--                - firstHalfOfList and lastHalfOfList function will divide the input lists into two.
--                - These lists will then be used by two different msort function to return two sorted lists.
--                - These sorted lists will then be used as parameters to merge ().
--                - The output of merge function, after recurssion would be a merge sorted list.
msort :: Ord a => [a] -> [a]                    -- msort takes list of type 'a' as input and returns a list of same type as output. Here 'a' is the
                                                --        instance of typeclasee 'Ord'. Hence comparision operators are defined for it. Therefore the
                                                --        elements of type 'a' can be compared with one another.
msort [] = []                                   -- If the input list is empty, then the output will also be empty
msort [x] = [x]                                 -- If the input list has only one value, then the output will also have only one list(Singleton list)
msort xs = merge (msort (firstHalfOfList xs)) (msort (lastHalfOfList xs)) -- Execution flow is explained above the function
--	----------------------------------------------------------------------------------------------------------------------------------------------------------------------
main = do                                                       -- Main function which will call the msort function with the input parameters and prints the output
    let result = msort [4, 65, 2, -31, 0, 99, 2, 83, 782, 1]    -- The output of the msort function is stored in a variable called result
    print result                                                -- The result is displayed on the console using the print command
--	----------------------------------------------------------------------------------------------------------------------------------------------------------------------