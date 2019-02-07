//The below program will be used to find the standard deviation of the given set of numbers
//Header file declaration
#include<stdio.h>
//Math Header file - To make use of Square Root function
#include<math.h>	

void main()
{
//Variable Initialization
int a[100],i,n,values,sum=0;
float average,finalResult,result=0.0;

printf("Enter the total number of integers that will be given as input: \n");
scanf("%d",&n);
printf("Enter the interger values:\n");
//Read all the input integers 
for(i=0; i<n; i++)
{
  scanf("%d",&values);
  a[i]=values;
}
//Calculate the sum of all the integers
for(i=0; i<n; i++)
{
sum=sum+a[i];
}
printf("Sum : %d \n",sum);
//Calculate the average of all the integers
average=sum/n;
printf("Average :%f \n",average);
for(i=0; i<n; i++)
{
result=result+((a[i]-average)*(a[i]-average));
}
//Calculate the Standard Deviation 
finalResult=sqrt(result/n);
printf("Standard Deviation :%f\n",finalResult);
getch();
}
