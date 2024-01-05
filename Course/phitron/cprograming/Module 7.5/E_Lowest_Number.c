#include <stdio.h>
#include <limits.h>

int main()
{
    int n;
    scanf("%d", &n);
    int ar[n];

    for(int i = 0; i< n; i++)
    {
        scanf("%d", &ar[i]);
    }

    int lowest = 1000;
    int position = 0;

    for(int i = 0; i < n; i++)
    {
        if(ar[i] < lowest)
        {
            lowest = ar[i];
            position = i+1;
        }
    }

    printf("%d %d", lowest, position);
    return 0;
}