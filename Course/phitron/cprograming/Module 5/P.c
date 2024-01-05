#include <stdio.h>
int main()
{
    int x;
    scanf("%d", &x);

    int i = x/1000;

    if(i%2==0)
    {
        printf("EVEN");
    }else{
        printf("ODD");
    }

    return 0;
}