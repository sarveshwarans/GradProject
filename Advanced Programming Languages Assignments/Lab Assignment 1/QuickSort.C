//Importation the necessary header files
#include <stdio.h>
#include <stdlib.h>
//Declaration of functions which are used in this program
void initiateQSort(int *a, int n);
void quick_sort( int *a, int p, int r);
int partition(int *a, int p, int r);
//Main Function
int main()
{
	//Declaration of the variables
	int iNumOfElements;		//Holds the Number Of Elements Of The Array
	int *input_array;		//Holds the pointer to the array
	int i;
	input_array = (int *)malloc(sizeof(int)*50);	//Memory allocation to the array

	clrscr();
	printf("Enter the number of elements: \n");		//Get the number of elements from the user
	scanf("%d", &iNumOfElements);					//Store it in a variable	
	printf("Number of elements: %d \n", iNumOfElements);	//Prints the number of elements on the console

	for(i=0;i<iNumOfElements;i++)					//For loop to get the value of each element in the array
	{
		printf("Enter element %d: ",i,": \n");		
		scanf("%d",&input_array[i]);
	}

	initiateQSort(input_array, iNumOfElements);		//Call the initiateQSort function with the input_array and iNumOfElements as the parameters
	getch();
	return 0;
}

void initiateQSort(int *a, int n)			//Function - initiateQSort; Input - pointer to the array and number of elements in that array
{
	int i;
	int p=0;								//p represents the left most index of the input array
	int r=n-1;								//r represents the count of right most index of the input array. n being the total number of elements, r[n-1] will represent the last index
	quick_sort(a,p,r);						//Call quick_sort function with the input_array,first and last index
	printf("Final Sorted Array:\n");		//Print the final sorted array
	for(i=0;i<n;i++)						//Using FOR loop to print all the elements of the sorted array
	{
		printf(" %d \n",a[i]);
	}
}
void quick_sort(int *a, int p, int r)		//Function - quick_sort; Input - pointer to the array, first and last index of the array
{
	int q,i;
	if(p<r)									//If the first index is less than r index, only then proceed to below set of code
	{
		q=partition(a,p,r);					//q= Partition function returns the pivot index and the index is stored as q
		quick_sort(a,p,q-1);				//quick_sort function with input_array, p and q-1 as input
		quick_sort(a,q+1,r);				//quick_sort function with input_array, q+1 and r as input

	}
}
int partition(int *a, int p, int r)			//Function - partition; Input - pointer to the array, first and last index of the array
{


	int x,i,j,temp;
	x=a[r];									//Holds the value of the r index of the input array
	i=p-1;									//Pointer i is set to start one before the p index
	for(j=p;j<=r-1;j++)						//FOR loop to check if the value in the input_array is less than x
	{
		if(a[j]<=x)							//If this condition is true, then increment i and then swap a[i] and a[j]
		{
		       i++;
		       temp = a[j];
		       a[j] = a[i];
		       a[i] = temp;
		}
	}
	temp   = a[r];							//Finally swap a[i+1] and a[r]- This will set the pivot element at the correct position in the array
	a[r]   = a[i+1];
	a[i+1] = temp;
	return (i+1);							//Returns the location at which the pivot element was placed
}
