#include "stdio.h"

void insSort(int *arr){
    for (int i=0; i<6; i++) {
        for (int j=i; j>=0; j--) {
            if(arr[j+1]<arr[j]){
                int tmp=arr[j+1];
                arr[j+1]=arr[j];
                arr[j]=tmp;
            }
        }
    }
}

int main(int argc, const char * argv[]) {
    int arr[6];
    arr[0]=48;
    arr[1]=62;
    arr[2]=35;
    arr[3]=77;
    arr[4]=55;
    arr[5]=14;
    insSort(arr);
    for (int i=0; i<6; i++) {
        printf("%d\t",arr[i]);
    }
    return 0;
}