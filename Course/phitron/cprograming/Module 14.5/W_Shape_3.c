#include <stdio.h>
int main()
{
    int n;
    scanf("%d", &n);

    int k = 1;
    int s = n - 1;
    int isDOt = 1;
    for (int i = 1; i <= n; i++)
    {
        for (int l = s; l >= 1; l--)
        {
            printf(" ");
        }
        if (isDOt == 1)
        {
            for (int j = 1; j <= k; j++)
            {

                printf("#");
            }
            isDOt = -1;
        }
        else
        {
            for (int j = 1; j <= k; j++)
            {

                printf("-");
            }

            isDOt = 1;
        }

        k += 2;
        s--;

        printf("\n");
    }

    int k1 = n + 1;
    int s1 = 1;
    int isDot2 = 1;
    for (int i = n; i >= 1; i--)
    {
        for (int l = 1; l <= s1; l++)
        {
            printf(" ");
        }
        if (isDot2 == 1)
        {
            for (int j = k1; j >= 1; j--)
            {
                printf("#");
                isDot2 = -1;
            }
        }
        else
        {
            for (int j = k1 - 1; j >= 1; j--)
            {
                printf("-");
                isDot2 = 1;
            }
        }

        k1 -= 2;
        s1++;
        printf("\n");
    }
    return 0;
}