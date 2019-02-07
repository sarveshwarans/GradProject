#include<stdio.h>
#include<stddef.h>
#include "stdafx.h"
// Heap size is assigned to 100 for the purpose of demonstration
int heap_size[100];
// Block structure is created with block_size (holding the size of the block, free_flag (shows the availability of the block) and next_block (holding the address of the next available block)
struct Block {
	int block_size;
	int free_flag;
	struct Block *next_block;
};	
struct Block *free_head = (void*)heap_size;
//Global constant variable is declared as overhead_size which will hold the value of sizeof(struct Block)
const int overhead_size = sizeof(struct Block);

void my_initialize_heap(int size);
void block_split(struct Block *current_slot, int size);
void* my_alloc(int size);
void my_free(void* data);

// The below function is to intitialize the heap and assign the block_size, free and next_block to it. 
void my_initialize_heap(int size) 
{
	// MALLOC is used to allocate the memory for free_head
	free_head = malloc(size);
	free_head->block_size = size - overhead_size;
	free_head->free_flag = 1;
	free_head->next_block = NULL;
}
// The below function is used to split the available block into two such that one is assigned to the requester and the remaining is left as available block
void block_split(struct Block *current_slot, int size)
{
	// new_block - This will be the new block which will be the newly available free block after splitting it.
	struct Block *new_block = (void*)(current_slot + size + overhead_size);
	// The new size of the new block is calculated
	new_block->block_size = (current_slot->block_size) - size - overhead_size;
	// The free flag is set to one to show that is is available to store the values
	new_block->free_flag = 1;
	new_block->next_block = current_slot->next_block;
	// The block size of the current_slot will be same as that of the requested size
	current_slot->block_size = size;
	// The free flag of current_slot is set to zero to show that it is occupied
	current_slot->free_flag = 0;
	current_slot->next_block = new_block;
}

void* my_alloc(int size) 
{
	// start_address - Returns starting address of the newly allocated memory  
	void *start_address;
	// Two new pointers are created namely current and previous
	struct Block *current;
	struct Block *previous;
	// The below checks if the free_head has a size assigned to it. If not, it will be initialized using my_initialize_heap()
	if (!(free_head->block_size)) 
	{
		//Call to my_initialize_heap function with the heap_size
		my_initialize_heap(heap_size);
		printf("Initilization of Memory was SUCCESSFUL \n");
	}
	// current is set to point to free_head
	current = free_head;
	// Scenario 1 - If the requested block size is greater than the available size of the block
	// Condition 1 - If the next block is a pointing to an address AND (if the block size is less than the requested size OR the free flag is set to 0)
	while ((current->next_block != NULL) && (((current->block_size)<size) || ((current->free_flag) == 0)))
	{
		// Assign the current pointer to the previous pointer
		previous = current;
		// Assign the next block to the current pointer
		current = current->next_block;
		printf("Encountered Scenario 1 - Requested Block Size > Available Block Size. Moving on to Next Block. \n");
	}
	// Secnario 2 - If the requested block size is same as that of the available block size
	if ((current->block_size) == size) 
	{
		// Assign the free flag to zero so as to show that this block is occupied 
		current->free_flag = 0;
		// start_address will now return the starting address of the newly allocated memory 
		start_address = (void*)(++current);
		printf("Encountered Scenario 2 - Requested Block Size = Available Block Size. Memory Allocated Successfully. \n");
		return start_address;
	}
	// Scenario 3 - If the requested block size is less than the available block size
	else if ((current->block_size)>(size + overhead_size)) 
	{
		// As the available space is more than the requested space, we will be splitting the available space so as to give only the required space
		block_split(current, size);
		// start_address will now return the starting address of the newly allocated memory 
		start_address = (void*)(++current);
		printf("Encountered Scenario 3 - Requested Block Size < Available Block Size. Memory Allocated Successfully After Splitting The Block. \n");
		return start_address;
	}
	else {
		// Scenario 4 - If no blocks are found, then return NULL
		start_address = NULL;
		printf("Encountered Scenario 4 - No Blocks With Requested Size Available. Hence Returning NULL. \n");
		return start_address;
	}
}

void my_free(void* data)
{
	//Check if the pointer is in the heap address range
	if (((void*)heap_size <= data) && (data <= (void*)(heap_size + 100)))
	{
		struct Block* curr = data;
		--curr;
		//If yes, then assign the free flag to 1
		curr->free_flag = 1;
	}
	else
	{
		printf("Given pointer is not in scope. It points to an address outside the heap block\n");
	}
}

int main()
{
	printf("*** Start of Testing *** \n");
	printf("*** Test Condition 1 *** \n");
	int *test1a = (int*)my_alloc(1 * sizeof(int));
	printf("%p\n", (void *)&test1a);
	my_free(test1a);
	int *test1b = (int*)my_alloc(1 * sizeof(int));
	printf("%p\n", (void *)&test1b);
	my_free(*test1b);
	printf("*** Test Condition 2 *** \n");
	int *test2a = (int*)my_alloc(2 * sizeof(int));
	printf("%p\n", (void *)&test2a);
	int *test2b = (int*)my_alloc(2 * sizeof(int));
	printf("%p\n", (void *)&test2b);
	printf("*** Test Condition 3 *** \n");
	int *test3a = (int*)my_alloc(3 * sizeof(int));
	printf("%p\n", (void *)&test3a);
	int *test3b = (int*)my_alloc(3 * sizeof(int));
	printf("%p\n", (void *)&test3b);
	int *test3c = (int*)my_alloc(3 * sizeof(int));
	printf("%p\n", (void *)&test3c);
	my_free(test3b);
	double *test3d = (double*)my_alloc(3 * sizeof(double));
	printf("%p\n", (void *)&test3d);
	int *test3e = (int*)my_alloc(3 * sizeof(int));
	printf("%p\n", (void *)&test3e);
	printf("*** Test Condition 4 *** \n");
	char *test4a = (char*)my_alloc(4 * sizeof(char));
	printf("%p\n", (void *)&test4a);
	int *test4b = (int*)my_alloc(4 * sizeof(int));
	printf("%p\n", (void *)&test4b);
	printf("*** End Of Testing *** ");
	printf("*** Standard Deviation ***");
	getch();
}