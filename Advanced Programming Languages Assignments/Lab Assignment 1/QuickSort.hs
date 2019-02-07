--	----------------------------------------------------------------------------------------------------------------------------------------------------------------------	
--Name of the function  - qsort
--Input                 - list
--output                - list
--Functionality
--              - Two different scenarios are handelled by qsort function
--              - If the input is empty, the output is also going to be empty list
--              - Consider the input has the first element as x and the rest of the elements as xs
--              - We will sort the elements which are smaller than x and store it as small
--              - We will sort the elements which are greater than x and store it as large
--              - The number which are same as that of the first element of the list will be stored as mid
--              - Finally, all the above three, that is the sorted list of the small,sorted list of large and mid will be concatinated
--                  in such a way that the small is concatinated with x and then concatinated with large

qsort :: (Ord a) => [a] -> [a]    -- qsort takes list of type 'a' as input and returns a list of same type as output. Here 'a' is the
                                  --        instance of typeclasee 'Ord'. Hence comparision operators are defined for it. Therefore the
                                  --        elements of type 'a' can be compared with one another.
qsort []= []                      -- If the input is empty, the output is also going to be empty list
qsort (x:xs) = qsort small ++ mid ++ qsort large  -- Concatination of Sorted Result of SMALL with X with Sorted Result of LARGE
   where
     small = [y | y<-xs, y<x]           -- Small is the list of all y's which are derived from list xs such that y<x
     mid   = [y | y<-xs, y==x] ++ [x]   -- Mid is the list of all y's which are derived from list xs such that y==x. This condition is
                                        --        useful, if there are more than one element with the same start value.
     large = [y | y<-xs, y>x]           -- Large is the list of all y's which are derived from list xs such that y>x
--	----------------------------------------------------------------------------------------------------------------------------------------------------------------------	
main = do                                                       -- Main function which will call the qsort function with the input parameters and prints the output
    let result = qsort [4, 65, 2, -31, 0, 99, 2, 83, 782, 1]    -- The output of the qsort function is stored in a variable called result
    print result                                                -- The result is displayed on the console using the print command
--	----------------------------------------------------------------------------------------------------------------------------------------------------------------------	