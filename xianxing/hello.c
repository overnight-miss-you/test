#include <stdio.h>
#include <malloc.h>
#include <stdlib.h>
typedef int elemtype;
void guibing(elemtype *arr,int start,int mid,int end)
{  int start_t = start;
int mid_t = mid;
int j = 0;
elemtype *temparr = (elemtype*)malloc(sizeof(elemtype)*(end-start+1));
if (NULL == temparr)
exit(1);
while(start<mid_t && mid<=end)
{ if (arr[start] >= arr[mid])
temparr[j++] = arr[mid++];
else
temparr[j++] = arr[start++];}
while (start<mid_t){
temparr[j++] = arr[start++];}
while (mid<=end){
temparr[j++] = arr[mid++];}
for (j=0;start_t<=end;++j){
arr[start_t++] = temparr[j];}
free(temparr);}
void guibingSort(elemtype *arr,int start,int end)
{
if (NULL == arr) return ;
if (end>start)
{
guibingSort(arr,start,(end+start)/2);
guibingSort(arr,(end+start)/2+1,end);
guibing(arr,start,(end+start)/2+1,end);}}
void printArr(elemtype *arr,int arrSize)
{  int i=0;
while (i<arrSize){
printf("%d ",arr[i++]);}
printf("\n");}
int main(void){
elemtype arr [10];
int i=0 ;
int a=10;
printf("\n");
 for(i=0;i<a;i++){
  scanf("%d",&arr[i]);}
int size = sizeof(arr)/sizeof(elemtype);
guibingSort(arr,0,size-1);
printf("");
printArr(arr,size);
return 0;}
