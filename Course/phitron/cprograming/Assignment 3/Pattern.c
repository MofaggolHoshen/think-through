#include <stdio.h>
int main()
{
    int n;
    scanf("%d", &n);
    int nn = (n*2)-1;
    int k = 1;
    int s = n - 1;
    for (int i = 1; i < n; i++)
    {
        for (int l = s; l >= 1; l--)
        {
            printf(" ");
        }
        if(i%2 != 0)
        {
            for (int j = 1; j <= k; j++)
            {

                printf("#");
            }
        }else{
            for (int j = 1; j <= k; j++)
            {

                printf("-");
            }
        }

        k = k+2;

        printf("\n");
    }
    

    return 0;
}