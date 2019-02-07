//Importation the necessary header files
#include <stdio.h>
#include <stdlib.h>
#include <limits.h>
//Declaration of functions which are used in this program
void initiateMSort(int *a, int n);
void merge_sort( int *a, int p, int r);
void merge(int *a, int p, int q, int r);
//Main Function
int main()
{
	//Declaration of the variables
	int iNumOfElements;										//Holds the Number Of Elements Of The Array
	int *input_array;										//Holds the pointer to the array
	int i;
	input_array = (int *)malloc(sizeof(int)*50);			//Memory allocation to the array

	clrscr();
	printf("Enter the number of elements: \n");				//Get the number of elements from the user
	scanf("%d", &iNumOfElements);							//Store it in a variable
	printf("Number of elements: %d \n", iNumOfElements);	//Prints the number of elements on the console

	for(i=0;i<iNumOfElements;i++)							//For loop to get the value of each element in the array
	{
		printf("Enter element %d: ",i,": \n");
		scanf("%d",&input_array[i]);
	}

	initiateMSort(input_array, iNumOfElements);				//Call the initiateMSort function with the input_array and iNumOfElements as the parameters
	getch();
	return 0;
}

void initiateMSort(int *a, int n)							//Function - initiateMSort; Input - pointer to the array and number of elements in that array
{
	int i;
	int p=0;												//p represents the left most index of the input array
	int r=n-1;												//r represents the count of right most index of the input array. n being the total number of elements, r[n-1] will represent the last index
	merge_sort(a,p,r);										//Call merge_sort function with the input_array,first and last index
	printf("Final Sorted Array:\n");						//Print the final sorted array
	for(i=0;i<n;i++)										//Using FOR loop to print all the elements of the sorted array
	{
		printf(" %d \n",a[i]);
	}
}
void merge_sort(int *a, int p, int r)						//Function - merge_sort; Input - pointer to the array, first and last index of the array
{
	int q,i;
	if(p<r)													//If the first index is less than r index, only then proceed to below set of code
	{
		q=(p+r)/2;											//Get the floor value of the average of p and r. This will be used as mid 
		merge_sort(a,p,q);									//merge_sort function with input_array, p and q as input
		merge_sort(a,q+1,r);								//merge_sort function with input_array, q+1 and r as input
		merge(a,p,q,r);										//merge function with input_array,p,q and r as input
	}
}
void merge(int *a, int p, int q, int r)						//Function - merge; Input - pointer to the array, first, last and mid index of the array
{

	int i,j,k;
	int n1=q-p+1;											//n1 - holds the number of elements in the left array
	int n2=r-q;												//n2 - holds the number of elements in the right array
	int leftArray[50];										//Initialization of left array
	int rightArray[50];										//Initialization of right array
	for(i=0;i<n1;i++)										//Assign the values to the left array using FOR loop
	{
		leftArray[i]=a[p+i];
	}
	for(j=0;j<n2;j++)										//Assign the values to the left array using FOR loop
	{
		rightArray[j]=a[q+j+1];
	}
	leftArray[n1]=INT_MAX;									//Assign the last index of the left array with the max value. This comes handy during the comparison of left and right array
	rightArray[n2]=INT_MAX;									//Assign the last index of the right array with the max value. This comes handy during the comparison of left and right array
	i=0;
	j=0;
	for(k=p;k<=r;k++)
	{
		if(leftArray[i]<=rightArray[j])						//Compare the values of the left and right array and store the value in the input_array accordingly and increment i and j counters
		{
			a[k]=leftArray[i];
			i++;
		}
		else
		{
			a[k]=rightArray[j];
			j++;
		}
	}
}