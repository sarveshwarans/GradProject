#include "stdafx.h"
#include <stdio.h>
#include <stdlib.h>

struct userProfile 
{
	char name[100];
	int age;
};
struct userProfile person[]		= 
{ 
	{ "Hal", 20 },		{ "Susann", 31 },	{ "Dwight", 19 },	{ "Kassandra", 21 },	{ "Lawrence", 25 },	{ "Cindy", 22 },
	{ "Cory", 27 },		{ "Mac", 19 },		{ "Romana", 27 },	{ "Doretha", 32 },		{ "Danna", 20 },	{ "Zara", 23 },	
	{ "Rosalyn", 26 },	{ "Risa", 24 },		{ "Benny", 28 },	{ "Juan", 33 },			{ "Natalie", 25 } 
};
double doubleArray[]			= 
{ 
	645.32, 37.40, 76.30, 5.40, -34.23, 1.11, -34.94, 23.37, 635.46, -876.22, 467.73, 62.26 
};
const char *stringArray[]		= 
{
	"Hal","Susann","Dwight","Kassandra","Lawrence","Cindy","Cory","Mac","Romana","Doretha","Danna","Zara","Rosalyn","Risa","Benny","Juan","Natalie" 
};

int compareDoubleValues(const void * first, const void * second)
{
	double firstDoubleValue		= *(double *)first;
	double secondDoubleValue	= *(double *)second;
	return (firstDoubleValue - secondDoubleValue);
}

int compareStringValues(const void * first, const void * second)
{
	const char **firstCharacter		= (const char **)first;
	const char **secondCharacter	= (const char **)second;
	return strcmp(*firstCharacter, *secondCharacter);
}

int compareStructValues(const void *first, const void *second)
{
	struct userProfile *firstStructValue	= (struct userProfile *)first;
	struct userProfile *secondStructValue	= (struct userProfile *)second;
	return (secondStructValue->age - firstStructValue->age);
}

int main() 
{
	int n;
	printf("Double Numbers Sorted in Ascending Order: \n");
	int numOfElements = sizeof(doubleArray) / sizeof(doubleArray[0]);
	qsort(doubleArray, numOfElements, sizeof(double), compareDoubleValues);
	for (n = 0; n < numOfElements; n++) 
	{
		printf("%f ", doubleArray[n]);
		printf("\t");
	}

	printf("\n");
	printf("\n");
	printf("\n");

	printf("User Names Sorted In Ascending Order: \n");
	numOfElements = sizeof(stringArray) / sizeof(stringArray[0]);
	qsort(stringArray, numOfElements, sizeof(char*), compareStringValues);
	for (n = 0; n < numOfElements; n++)
	{
		printf("%s", stringArray[n]);
		printf("\t");
	}

	printf("\n");
	printf("\n");
	printf("\n");

	printf("User Names Sorted Based On Age In Descending Order: \n");
	numOfElements = sizeof(person) / sizeof(struct userProfile);
	qsort(person, numOfElements, sizeof(struct userProfile), compareStructValues);
	for (n = 0; n < numOfElements; n++)
	{
		printf("%s", person[n].name);
		printf("\t");
		printf("%d", person[n].age);
		printf("\n");
	}
	getch();
	return(0);
}


